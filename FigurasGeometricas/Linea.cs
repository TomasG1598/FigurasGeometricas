using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Linea : Figura
    {
        public int X2 { get; private set; }
        public int Y2 { get; private set; }

        public Linea(int x1, int y1, int x2, int y2, Color color) : base(x1, y1, 0, color)
        {
            X2 = x2;
            Y2 = y2;
        }
        public override void Dibujar(Graphics g)
        {
            using (Pen pen = new Pen(Color, 2))
            {
                g.DrawLine(pen, X, Y, X2, Y2);
            }
        }

        }
}
