using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras_Geométricas
{
    public partial class Form1 : Form
    {
        private List<Figura> figuras = new List<Figura>();
        private Color colorSeleccionado = Color.Black;

        public Form1()
        {
            InitializeComponent();
            InicializarUI();
            pbLienzo.Paint += PbLienzo_Paint;
        }

        private void InicializarUI()
        {
            cmbFigura.Items.AddRange(new string[] { "Rectángulo", "Círculo", "Línea", "Triángulo" });
            cmbFigura.SelectedIndex = 0;
            nudX.Minimum = 0; nudY.Minimum = 0; nudTamano.Minimum = 0;
            // nudX2,y2 sólo habilitados para Linea
            nudX2.Enabled = nudY2.Enabled = false;
            txtContador.ReadOnly = true;
            ActualizarContador();
        }
        private void ActualizarContador()
        {
            txtContador.Text = figuras.Count.ToString();
        }

        private void PbLienzo_Paint(object sender, PaintEventArgs e)
        {
            foreach (var f in figuras)
            {
                f.Dibujar(e.Graphics);
            }
        }

        private void pbColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorSeleccionado = colorDialog1.Color;
                pbColor.BackColor = colorSeleccionado;
            }
        }
    }
}
