using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public abstract class Figura
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public int Size { get; set; }
        
        public Color Color { get; protected set; }

        protected Figura (int x, int y, int size, Color color)
        {
            X = x;
            Y = y;
            Size = size;
            Color = color;


        }

        public abstract void Dibujar (Graphics g);
    }
}
