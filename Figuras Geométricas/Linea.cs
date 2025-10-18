using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geométricas
{
    public class Linea:Figura
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public override void Dibujar(Graphics g)
        {
            using (var pen = new Pen(Color, 2))
            {
                g.DrawLine(pen, X, Y, X2, Y2);
            }
        }
    }
}
