using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geométricas
{
    public class Triangulo:Figura
    {
        public override void Dibujar(Graphics g)
        {
            // Triángulo equilátero simple con base en (X,Y)
            Point p1 = new Point(X, Y);
            Point p2 = new Point(X + Tamaño, Y);
            Point p3 = new Point(X + Tamaño / 2, Y - (int)(Tamaño * 0.866)); // altura aproximada
            Point[] pts = { p1, p2, p3 };

            using (var brush = new SolidBrush(Color))
            using (var pen = new Pen(Color, 2))
            {
                g.FillPolygon(brush, pts);
                g.DrawPolygon(pen, pts);
            }
        }

    }
}
