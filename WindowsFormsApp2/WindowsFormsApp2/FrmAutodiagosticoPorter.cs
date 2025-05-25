using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomMessageBox;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmAutodiagosticoPorter : Form
    {
        Dictionary<string, TextBox[]> filas;

        public FrmAutodiagosticoPorter()
        {
            InitializeComponent();
            InicializarFilas();
            AsociarEventos();
        }

        private void InicializarFilas()
        {
            filas = new Dictionary<string, TextBox[]>
            {
                { "Crecimiento", new[] { txtCrecimiento1, txtCrecimiento2, txtCrecimiento3, txtCrecimiento4, txtCrecimiento5 } },
                { "Naturaleza", new[] { txtNaturaleza1, txtNaturaleza2, txtNaturaleza3, txtNaturaleza4, txtNaturaleza5 } },
                { "Exceso", new[] { txtExceso1, txtExceso2, txtExceso3, txtExceso4, txtExceso5 } },
                { "Rentabilidad", new[] { txtRentabilidad1, txtRentabilidad2, txtRentabilidad3, txtRentabilidad4, txtRentabilidad5 } },
                { "Diferenciacion", new[] { txtDiferenciacion1, txtDiferenciacion2, txtDiferenciacion3, txtDiferenciacion4, txtDiferenciacion5 } },
                { "BarrerasSalida", new[] { txtBarrerasSalida1, txtBarrerasSalida2, txtBarrerasSalida3, txtBarrerasSalida4, txtBarrerasSalida5 } },

                { "Economias", new[] { txtEconomias1, txtEconomias2, txtEconomias3, txtEconomias4, txtEconomias5 } },
                { "Capital", new[] { txtCapital1, txtCapital2, txtCapital3, txtCapital4, txtCapital5 } },
                { "AccesoTec", new[] { txtAccesoTec1, txtAccesoTec2, txtAccesoTec3, txtAccesoTec4, txtAccesoTec5 } },
                { "Reglamentos", new[] { txtReglamentos1, txtReglamentos2, txtReglamentos3, txtReglamentos4, txtReglamentos5 } },
                { "Tramites", new[] { txtTramites1, txtTramites2, txtTramites3, txtTramites4, txtTramites5 } },
                { "Reaccion", new[] { txtReaccion1, txtReaccion2, txtReaccion3, txtReaccion4, txtReaccion5 } },

                { "NumClientes", new[] { txtNumClientes1, txtNumClientes2, txtNumClientes3, txtNumClientes4, txtNumClientes5 } },
                { "Integracion", new[] { txtIntegracion1, txtIntegracion2, txtIntegracion3, txtIntegracion4, txtIntegracion5 } },
                { "RentClientes", new[] { txtRentClientes1, txtRentClientes2, txtRentClientes3, txtRentClientes4, txtRentClientes5 } },
                { "Cambio", new[] { txtCambio1, txtCambio2, txtCambio3, txtCambio4, txtCambio5 } },


                { "Sustitutos", new[] { txtSustitutos1, txtSustitutos2, txtSustitutos3, txtSustitutos4, txtSustitutos5 } },
            };
        }

        private void AsociarEventos()
        {
            foreach (var fila in filas.Values)
            {
                foreach (var txt in fila)
                {
                    txt.TextChanged += (s, e) => CalcularTotalYActualizar();
                }
            }
        }

        private void CalcularTotalYActualizar()
        {
            int total = 0;
            foreach (var fila in filas)
            {
                int valorFila = ObtenerValor(fila.Value);
                if (valorFila == -1)
                {
                    txtConclusion.Text = $"Error: más de una 'X' en la fila '{fila.Key}'.";
                    txtTotal.Text = "-";
                    return;
                }
                total += valorFila;
            }

            txtTotal.Text = total.ToString();
            txtConclusion.Text = ObtenerConclusion(total);
        }

        private int ObtenerValor(TextBox[] fila)
        {
            int countX = 0;
            int index = -1;

            for (int i = 0; i < fila.Length; i++)
            {
                if (fila[i].Text.Trim().ToUpper() == "X")
                {
                    countX++;
                    index = i + 1;
                }
            }

            if (countX > 1)
                return -1;

            return countX == 1 ? index : 0;
        }

        private string ObtenerConclusion(int total)
        {
            if (total < 30)
                return "Estamos en un mercado altamente competitivo, en el que es muy difícil hacerse un hueco en el mercado.";
            else if (total < 45)
                return "Estamos en un mercado de competitividad relativamente alta, pero con ciertas modificaciones en el producto y la política comercial de la empresa, podría encontrarse un nicho de mercado.";
            else if (total < 60)
                return "La situación actual del mercado es favorable a la empresa.";
            else
                return "Estamos en una situación excelente para la empresa.";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validar que los campos de Oportunidades y Amenazas no estén vacíos
            if (string.IsNullOrWhiteSpace(txtO1.Text) || string.IsNullOrWhiteSpace(txtO2.Text) ||
                string.IsNullOrWhiteSpace(txtA1.Text) || string.IsNullOrWhiteSpace(txtA2.Text))
            {
                //MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                var result = RJMessageBox.Show("Por favor, complete todos los campos",
                  "Validación",
                  MessageBoxButtons.YesNoCancel,
                  MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    string o1 = txtO1.Text.Trim();
                    string o2 = txtO2.Text.Trim();

                    string a1 = txtA1.Text.Trim();
                    string a2 = txtA2.Text.Trim();

                    dc.SP_RegistrarOportunidad(o1, Sesion.EmpresaId);
                    dc.SP_RegistrarOportunidad(o2, Sesion.EmpresaId);

                    dc.SP_RegistrarAmenaza(a1, Sesion.EmpresaId);
                    dc.SP_RegistrarAmenaza(a2, Sesion.EmpresaId);
                }

                //MessageBox.Show("Oportunidades y Amenazas registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = RJMessageBox.Show("Éxito",
                   "Oportunidades y Amenazas registradas correctamente");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al registrar Oportunidades y Amenazas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var result = RJMessageBox.Show("Error al registrar Oportunidades y Amenazas",
                "Error",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
            }
        }
    }
}
