using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Circulo : Figura

    {
        public Circulo(int x, int y, int size, Color color) : base (x, y, size, color) {}

        public override void Dibujar(Graphics g)
        {
            using (Pen pen = new Pen(Color, 2))

            {
                g.DrawEllipse(pen, X, Y, Size, Size);
            }
        }
    }
}
