using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class MainForm : Form
    {
        // Lista que guarda las figuras (puede inicializarse con new: esto no viola la regla)
        private List<Figura> figuras = new List<Figura>();

        // Color seleccionado (null equivale a no seleccionado)
        private Color? selectedColor = null;

        public MainForm()
        {
            InitializeComponent();
            SetupCustom();
        }

        private void SetupCustom()
        {
            // Llenar combo si no se hizo en el diseñador
            cmbFigura.Items.Clear();
            cmbFigura.Items.Add("Rectángulo");
            cmbFigura.Items.Add("Círculo");
            cmbFigura.Items.Add("Línea");
            cmbFigura.Items.Add("Triángulo");
            cmbFigura.SelectedIndex = 0;

            // valores por defecto
            nudX.Minimum = 0;
            nudX.Maximum = 5000;
            nudY.Minimum = 0;
            nudY.Maximum = 5000;
            nudX2.Minimum = 0;
            nudX2.Maximum = 5000;
            nudY2.Minimum = 0;
            nudY2.Maximum = 5000;

            nudTamaño.Minimum = 1;
            nudTamaño.Maximum = 1000;
            nudTamaño.Value = 50;

            txtContador.ReadOnly = true;
            txtContador.Text = "0";

            // Eventos
            cmbFigura.SelectedIndexChanged += CmbFigura_SelectedIndexChanged;
            pbLienzo.Paint += PbLienzo_Paint;
            pbColor.Click += PbColor_Click;
            btnCrear.Click += BtnCrear_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

            // Inicial estado
            AjustarControlesSegunFigura();
        }

        private void CmbFigura_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjustarControlesSegunFigura();
        }

        private void AjustarControlesSegunFigura()
        {
            string tipo = cmbFigura.SelectedItem.ToString();
            if (tipo == "Línea")
            {
                // habilitar X2,Y2; deshabilitar tamaño
                nudX2.Enabled = true;
                nudY2.Enabled = true;
                nudTamaño.Enabled = false;
            }
            else
            {
                nudX2.Enabled = false;
                nudY2.Enabled = false;
                nudTamaño.Enabled = true;
            }
        }

        private void PbColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
                pbColor.BackColor = colorDialog1.Color;
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Validar color seleccionado
            if (selectedColor == null)
            {
                MessageBox.Show("Seleccione un color antes de crear la figura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbFigura.SelectedItem.ToString();

            // Valores desde controles
            int x = (int)nudX.Value;
            int y = (int)nudY.Value;

            // Reglas de negocio: los límites dependen del tamaño del lienzo
            int anchoLienzo = pbLienzo.Width;
            int altoLienzo = pbLienzo.Height;

            if (tipo == "Línea")
            {
                int x2 = (int)nudX2.Value;
                int y2 = (int)nudY2.Value;

                // Validar que ambos puntos estén dentro del lienzo
                if (!EstaDentroLienzo(x, y, anchoLienzo, altoLienzo) || !EstaDentroLienzo(x2, y2, anchoLienzo, altoLienzo))
                {
                    MessageBox.Show($"Para líneas, ambos puntos deben estar dentro del lienzo (0..{anchoLienzo}, 0..{altoLienzo}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear vía factory (NO usar new en el formulario para figuras)
                Figura f = FiguraFactory.CreateLinea(x, y, x2, y2, selectedColor.Value);
                figuras.Add(f);
            }
            else
            {
                int size = (int)nudTamaño.Value;

                // regla: tamaño > 0
                if (size <= 0)
                {
                    MessageBox.Show("El tamaño debe ser mayor que 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la figura quede completamente visible en el lienzo
                if (!EstaDentroLienzo(x, y, size, size, anchoLienzo, altoLienzo))
                {
                    MessageBox.Show("La figura debe estar completamente visible en el lienzo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear vía factory (el factory usa new internamente)
                Figura f = FiguraFactory.Create(tipo, x, y, size, selectedColor.Value);
                if (f == null)
                {
                    MessageBox.Show("Tipo de figura no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                figuras.Add(f);
            }

            // Actualizar contador y pedir repintado
            txtContador.Text = figuras.Count.ToString();
            pbLienzo.Invalidate(); // fuerza repaint
        }

        private bool EstaDentroLienzo(int x, int y, int anchoLienzo, int altoLienzo)
        {
            return x >= 0 && x <= anchoLienzo && y >= 0 && y <= altoLienzo;
        }

        // Para figuras rectangular/círculo/triangulo: comprobar que x..x+width y y..y+height estén dentro
        private bool EstaDentroLienzo(int x, int y, int width, int height, int anchoLienzo, int altoLienzo)
        {
            return x >= 0 && y >= 0 && (x + width) <= anchoLienzo && (y + height) <= altoLienzo;
        }

        private void PbLienzo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            foreach (var f in figuras)
            {
                f.Dibujar(e.Graphics);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            figuras.Clear();
            txtContador.Text = "0";
            pbLienzo.Invalidate();
        }
    }
}