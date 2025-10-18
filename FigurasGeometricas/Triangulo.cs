using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Triangulo : Figura
    {
        public Triangulo(int x, int y, int size, Color color) : base(x, y, size, color) { }
        public override void Dibujar(Graphics g)
        {
            using (Pen pen = new Pen (Color, 2))
            {
                Point p1 = new Point (X, Y + Size);
                Point p2 = new Point(X + Size / 2, Y);
                Point p3 = new Point(X + Size, Y + Size);
                g.DrawPolygon(pen, new Point[] { p1, p2, p3 });
            }
        }
    }
}
