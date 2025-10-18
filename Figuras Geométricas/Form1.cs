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

       

        private void cmbFigura_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipo = cmbFigura.SelectedItem.ToString();
            if (tipo.ToLower().Contains("línea") || tipo.ToLower().Contains("linea"))
            {
                nudX2.Enabled = nudY2.Enabled = true;
                nudTamano.Enabled = false;
            }
            else
            {
                nudX2.Enabled = nudY2.Enabled = false;
                nudTamano.Enabled = true;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string tipo = cmbFigura.SelectedItem.ToString();
            int x = (int)nudX.Value;
            int y = (int)nudY.Value;
            int tamaño = (int)nudTamano.Value;
            int x2 = (int)nudX2.Value;
            int y2 = (int)nudY2.Value;

            // Validaciones
            if (colorSeleccionado == Color.Transparent)
            {
                MessageBox.Show("Seleccione un color.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((tipo.ToLower().Contains("línea") || tipo.ToLower().Contains("linea")))
            {
                // Validar que puntos estén dentro del PictureBox
                if (!PuntoDentroLienzo(x, y) || !PuntoDentroLienzo(x2, y2))
                {
                    MessageBox.Show("Los puntos de la línea deben estar dentro del lienzo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (tamaño <= 0)
                {
                    MessageBox.Show("El tamaño debe ser mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Validar que la figura completa quede dentro del lienzo
                if (!FiguraDentroLienzo(tipo, x, y, tamaño))
                {
                    MessageBox.Show("La figura no cabe completamente en el lienzo con esas coordenadas/tamaño.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Crear usando la factory (NO se usa new aquí en el Form)
            try
            {
                var figura = FiguraFactory.Crear(tipo, x, y, tamaño, colorSeleccionado, x2, y2);
                figuras.Add(figura);
                ActualizarContador();
                pbLienzo.Invalidate(); // fuerza repaint
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando la figura: " + ex.Message);
            }
        }
    
    private bool PuntoDentroLienzo(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= pbLienzo.Width && y <= pbLienzo.Height;
        }

        // Verifica que la figura completa quepa dentro del lienzo
        private bool FiguraDentroLienzo(string tipo, int x, int y, int tamaño)
        {
            if (tipo.ToLower().Contains("rect"))
            {
                return x >= 0 && y >= 0 && (x + tamaño) <= pbLienzo.Width && (y + tamaño) <= pbLienzo.Height;
            }

            if (tipo.ToLower().Contains("círc") || tipo.ToLower().Contains("circ"))
            {
                return x >= 0 && y >= 0 && (x + tamaño) <= pbLienzo.Width && (y + tamaño) <= pbLienzo.Height;
            }

            if (tipo.ToLower().Contains("tria"))
            {
                // Triángulo equilátero simple con base horizontal
                int minY = y - (int)(tamaño * 0.866); // altura aprox.
                return x >= 0 && minY >= 0 && (x + tamaño) <= pbLienzo.Width && y <= pbLienzo.Height;
            }

            return false;
        }

     

        private void lblContador_Click(object sender, EventArgs e)
        {

        }

        private void txtContador_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            figuras.Clear();
            ActualizarContador();
            pbLienzo.Invalidate();
        }

        private void pbColor_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorSeleccionado = colorDialog1.Color;
                pbColor.BackColor = colorSeleccionado;
            }

        }
    }
}
