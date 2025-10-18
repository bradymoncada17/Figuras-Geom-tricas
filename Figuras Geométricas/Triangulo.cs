using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geométricas
{
    public class Triangulo : Figura
    {
        public override void Dibujar(Graphics g)
        {
            // Triángulo equilátero simple con base en (X, Y) hacia abajo
            Point p1 = new Point(X, Y);                      // esquina izquierda
            Point p2 = new Point(X + Tamaño, Y);             // esquina derecha
            Point p3 = new Point(X + Tamaño / 2, Y + (int)(Tamaño * 0.866)); // vértice hacia abajo

            Point[] puntos = { p1, p2, p3 };

            using (SolidBrush brocha = new SolidBrush(Color))
            using (Pen pluma = new Pen(Color, 2))
            {
                g.FillPolygon(brocha, puntos);
                g.DrawPolygon(pluma, puntos);
            }
        }
    }

    }
