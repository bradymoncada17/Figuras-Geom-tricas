using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geométricas
{
    public class Circulo:Figura
    {
        public override void Dibujar(Graphics g)
        {
            var rect = new Rectangle(X, Y, Tamaño, Tamaño);
            using (var pen = new Pen(Color, 2))
            using (var brush = new SolidBrush(Color))
            {
                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
