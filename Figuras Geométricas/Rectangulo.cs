using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geométricas
{
    public class Rectangulo:Figura
    {
        public override void Dibujar(Graphics g)
        {
            // Tamaño será ancho y alto igual (cuadrado), ajusta si quieres ancho/alto distinto
            var rect = new Rectangle(X, Y, Tamaño, Tamaño);
            using (var pen = new Pen(Color, 2))
            using (var brush = new SolidBrush(Color))
            {
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
