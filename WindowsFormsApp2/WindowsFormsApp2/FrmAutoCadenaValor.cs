using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmAutoCadenaValor : Form
    {
        public FrmAutoCadenaValor()
        {
            InitializeComponent();
        }
        string f1;
        string f2;
        string d1;
        string d2;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtF1.Text) || string.IsNullOrWhiteSpace(txtF2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    string f1 = txtF1.Text.Trim();
                    string f2 = txtF2.Text.Trim();

                    dc.SP_RegistrarFortaleza(f1, Sesion.EmpresaId);
                    dc.SP_RegistrarFortaleza(f2, Sesion.EmpresaId);
                }

                MessageBox.Show("Fortalezas registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar las Fortalezas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrWhiteSpace(txtD1.Text) || string.IsNullOrWhiteSpace(txtD2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    string D1 = txtD1.Text.Trim();
                    string D2 = txtD2.Text.Trim();

                    dc.SP_RegistrarDebilidad(D1, Sesion.EmpresaId);
                    dc.SP_RegistrarDebilidad(D2, Sesion.EmpresaId);
                }

                MessageBox.Show("Debilidades registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar las debilidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
