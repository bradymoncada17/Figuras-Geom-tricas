using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geométricas
{
    public static class FiguraFactory
    {
        public static Figura Crear(string tipo, int x, int y, int tamaño, System.Drawing.Color color, int x2 = 0, int y2 = 0)
    {
        switch (tipo.ToLower())
        {
            case "rectángulo":
            case "rectangulo":
                return new Rectangulo { X = x, Y = y, Tamaño = tamaño, Color = color };
            case "círculo":
            case "circulo":
                return new Circulo { X = x, Y = y, Tamaño = tamaño, Color = color };
            case "línea":
            case "linea":
                return new Linea { X = x, Y = y, X2 = x2, Y2 = y2, Color = color };
            case "triángulo":
            case "triangulo":
                return new Triangulo { X = x, Y = y, Tamaño = tamaño, Color = color };
            default:
                throw new ArgumentException("Tipo de figura no soportado.");
        }
    }



    }
}
