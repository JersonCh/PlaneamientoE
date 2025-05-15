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
    public partial class FrmAutoPest : Form
    {
        public FrmAutoPest()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos de Oportunidades y Amenazas no estén vacíos
            if (string.IsNullOrWhiteSpace(txtO3.Text) || string.IsNullOrWhiteSpace(txtO4.Text) ||
                string.IsNullOrWhiteSpace(txtA3.Text) || string.IsNullOrWhiteSpace(txtA4.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    string o3 = txtO3.Text.Trim();
                    string o4 = txtO4.Text.Trim();

                    string a3 = txtA3.Text.Trim();
                    string a4 = txtA4.Text.Trim();

                    dc.SP_RegistrarOportunidad(o3, Sesion.EmpresaId);
                    dc.SP_RegistrarOportunidad(o4, Sesion.EmpresaId);

                    dc.SP_RegistrarAmenaza(a3, Sesion.EmpresaId);
                    dc.SP_RegistrarAmenaza(a4, Sesion.EmpresaId);
                }

                MessageBox.Show("Oportunidades y Amenazas registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Oportunidades y Amenazas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            MostrarResultado(txtSociales, CalcularFactor(1, 5),
                "FACTORES SOCIALES Y DEMOGRÁFICOS");

            MostrarResultado(txtPoliticos, CalcularFactor(6, 10),
                "FACTORES POLÍTICOS");

            MostrarResultado(txtEconomicos, CalcularFactor(11, 15),
                "FACTORES ECONÓMICOS");

            MostrarResultado(txtTecnologicos, CalcularFactor(16, 20),
                "FACTORES TECNOLÓGICOS");

            MostrarResultado(txtAmbientales, CalcularFactor(21, 25),
                "FACTORES MEDIO AMBIENTALES");
        }

        private double CalcularFactor(int inicio, int fin)
        {
            int suma = 0;
            for (int i = inicio; i <= fin; i++)
            {
                Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
                    {
                        if (rb.Checked)
                        {
                            string[] parts = rb.Name.Split('_');
                            if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                            {
                                suma += value;
                            }
                            break;
                        }
                    }
                }
            }
            return (suma / 20.0) * 100;
        }

        private void MostrarResultado(TextBox txt, double porcentaje, string factorNombre)
        {
            string mensaje;

            if (porcentaje >= 70)
                mensaje = $"HAY UN NOTABLE IMPACTO DE {factorNombre} EN EL FUNCIONAMIENTO DE LA EMPRESA";
            else
                mensaje = $"NO HAY UN NOTABLE IMPACTO DE {factorNombre} EN EL FUNCIONAMIENTO DE LA EMPRESA";

            txt.Text = $"{porcentaje:0.##}% - {mensaje}";
        }

        private void txtO3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
