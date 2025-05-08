using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmAutoCadenaValor : Form
    {
        public FrmAutoCadenaValor()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int total = 0;
            double total2 = 0;
            for (int i = 1; i <= 25; i++)
            {
                Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
                    {
                        if (rb.Checked)
                        {
                            // Extrae el valor del nombre, por ejemplo "p1_4" -> 4
                            string[] parts = rb.Name.Split('_');
                            if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                            {
                                total += value;
                            }
                            break; // Ya encontramos el seleccionado en este panel
                        }
                    }
                }
            }
            total2 = 1 - (total / 100.0);
            txtTotal.Text = (total2 * 100).ToString() + "%";
        }
    }
}
