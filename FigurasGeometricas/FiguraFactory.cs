using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public static class FiguraFactory
    {
        public static Figura Create (string tipo, int x, int y, int size, Color color)
        {
            switch (tipo)
            {
                case "Rectángulo":
                    return new Rectangulo (x, y, size, color);
                case "Círculo":
                    return new Circulo (x, y, size, color);
                case "Triángulo":
                    return new Triangulo (x, y, size, color);
                default : return null;
            }
        }
        public static   Figura CreateLinea (int x1, int y1, int x2, int y2, Color color)
        {
            return new Linea(x1, y1, x2, y2, color);
        }
    }
}
