using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Figuras_Geométricas
{
    public abstract class Figura
    {
        public Color Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Tamaño { get; set; } // usado para rectángulo/círculo/triángulo
        public abstract void Dibujar(Graphics g);
    }



    }






