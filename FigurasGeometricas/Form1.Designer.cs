namespace FigurasGeometricas
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbFigura;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.NumericUpDown nudTamaño;
        private System.Windows.Forms.NumericUpDown nudX2;
        private System.Windows.Forms.NumericUpDown nudY2;
        private System.Windows.Forms.PictureBox pbLienzo;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtContador;
        private System.Windows.Forms.Label lblFigura;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblContador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbFigura = new System.Windows.Forms.ComboBox();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.nudTamaño = new System.Windows.Forms.NumericUpDown();
            this.nudX2 = new System.Windows.Forms.NumericUpDown();
            this.nudY2 = new System.Windows.Forms.NumericUpDown();
            this.pbLienzo = new System.Windows.Forms.PictureBox();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtContador = new System.Windows.Forms.TextBox();
            this.lblFigura = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamaño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLienzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFigura
            // 
            this.cmbFigura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFigura.FormattingEnabled = true;
            this.cmbFigura.Location = new System.Drawing.Point(16, 36);
            this.cmbFigura.Name = "cmbFigura";
            this.cmbFigura.Size = new System.Drawing.Size(160, 21);
            this.cmbFigura.TabIndex = 0;
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(16, 86);
            this.nudX.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(80, 20);
            this.nudX.TabIndex = 1;
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(112, 86);
            this.nudY.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(80, 20);
            this.nudY.TabIndex = 2;
            // 
            // nudTamaño
            // 
            this.nudTamaño.Location = new System.Drawing.Point(16, 132);
            this.nudTamaño.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTamaño.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTamaño.Name = "nudTamaño";
            this.nudTamaño.Size = new System.Drawing.Size(80, 20);
            this.nudTamaño.TabIndex = 3;
            this.nudTamaño.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nudX2
            // 
            this.nudX2.Location = new System.Drawing.Point(16, 182);
            this.nudX2.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudX2.Name = "nudX2";
            this.nudX2.Size = new System.Drawing.Size(80, 20);
            this.nudX2.TabIndex = 4;
            // 
            // nudY2
            // 
            this.nudY2.Location = new System.Drawing.Point(112, 182);
            this.nudY2.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudY2.Name = "nudY2";
            this.nudY2.Size = new System.Drawing.Size(80, 20);
            this.nudY2.TabIndex = 5;
            // 
            // pbLienzo
            // 
            this.pbLienzo.BackColor = System.Drawing.Color.White;
            this.pbLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLienzo.Location = new System.Drawing.Point(200, 12);
            this.pbLienzo.Name = "pbLienzo";
            this.pbLienzo.Size = new System.Drawing.Size(900, 600);
            this.pbLienzo.TabIndex = 6;
            this.pbLienzo.TabStop = false;
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Gray;
            this.pbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColor.Location = new System.Drawing.Point(16, 242);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(50, 30);
            this.pbColor.TabIndex = 7;
            this.pbColor.TabStop = false;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(16, 290);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(80, 30);
            this.btnCrear.TabIndex = 8;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(112, 290);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 30);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // txtContador
            // 
            this.txtContador.Location = new System.Drawing.Point(112, 245);
            this.txtContador.Name = "txtContador";
            this.txtContador.ReadOnly = true;
            this.txtContador.Size = new System.Drawing.Size(80, 20);
            this.txtContador.TabIndex = 10;
            this.txtContador.Text = "0";
            // 
            // Labels
            // 
            this.lblFigura.AutoSize = true;
            this.lblFigura.Location = new System.Drawing.Point(13, 16);
            this.lblFigura.Name = "lblFigura";
            this.lblFigura.Size = new System.Drawing.Size(39, 13);
            this.lblFigura.Text = "Figura";
            //
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(13, 70);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.Text = "X";
            //
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(109, 70);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.Text = "Y";
            //
            this.lblTamaño.AutoSize = true;
            this.lblTamaño.Location = new System.Drawing.Point(13, 116);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(46, 13);
            this.lblTamaño.Text = "Tamaño";
            //
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(13, 166);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(22, 13);
            this.lblX2.Text = "X2";
            //
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(109, 166);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(22, 13);
            this.lblY2.Text = "Y2";
            //
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(13, 226);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.Text = "Color";
            //
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(109, 229);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(52, 13);
            this.lblContador.Text = "Contador";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1120, 630);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblY2);
            this.Controls.Add(this.lblX2);
            this.Controls.Add(this.lblTamaño);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblFigura);
            this.Controls.Add(this.txtContador);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.pbColor);
            this.Controls.Add(this.pbLienzo);
            this.Controls.Add(this.nudY2);
            this.Controls.Add(this.nudX2);
            this.Controls.Add(this.nudTamaño);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.cmbFigura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Figuras Geométricas";
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamaño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLienzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

