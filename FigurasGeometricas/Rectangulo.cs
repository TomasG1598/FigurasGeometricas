using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Rectangulo : Figura
    {

        public Rectangulo(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Dibujar (Graphics g)
        {
            using (Pen pen = new Pen(Color , 2))
            {
                g.DrawRectangle(pen, X, Y, Size, Size);
            }
        }
    }
}
