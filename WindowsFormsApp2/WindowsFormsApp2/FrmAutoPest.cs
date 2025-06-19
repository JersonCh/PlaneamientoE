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

        // Definimos un tipo para el evento que enviará los totales
        public delegate void TotalesCalculadosHandler(object sender, List<(string factor, double porcentaje)> totales);

        // Evento que se dispara cuando se calculan los totales
        public event TotalesCalculadosHandler TotalesCalculados;

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
            // Array para almacenar los valores de cada pregunta
            int[] valoresPreguntas = new int[25];

            // Capturar todos los valores individuales
            for (int i = 1; i <= 25; i++)
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
                                valoresPreguntas[i - 1] = value;
                            }
                            break;
                        }
                    }
                }
            }

            // Calcular resultados y preparar lista para el evento
            var resultados = new List<(string factor, double porcentaje)>
            {
                ("Factores Sociales y Demográficos", CalcularFactor(1, 5)),
                ("Factores Políticos", CalcularFactor(6, 10)),
                ("Factores Económicos", CalcularFactor(11, 15)),
                ("Factores Tecnológicos", CalcularFactor(16, 20)),
                ("Factores Medio Ambientales", CalcularFactor(21, 25))
            };

            // Mostrar resultados en los TextBoxes
            MostrarResultado(txtSociales, resultados[0].porcentaje, resultados[0].factor);
            MostrarResultado(txtPoliticos, resultados[1].porcentaje, resultados[1].factor);
            MostrarResultado(txtEconomicos, resultados[2].porcentaje, resultados[2].factor);
            MostrarResultado(txtTecnologicos, resultados[3].porcentaje, resultados[3].factor);
            MostrarResultado(txtAmbientales, resultados[4].porcentaje, resultados[4].factor);

            // Guardar en base de datos (solo los primeros 4 resultados según tu tabla)
            GuardarAutoPEST(valoresPreguntas,
                GenerarMensajeResultados(resultados[0]),
                GenerarMensajeResultados(resultados[1]),
                GenerarMensajeResultados(resultados[2]),
                GenerarMensajeResultados(resultados[3]));

            // Disparar evento para avisar al padre
            TotalesCalculados?.Invoke(this, resultados);
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
                mensaje = $"HAY UN NOTABLE IMPACTO DE {factorNombre.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA";
            else
                mensaje = $"NO HAY UN NOTABLE IMPACTO DE {factorNombre.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA";

            txt.Text = $"{porcentaje:0.##}% - {mensaje}";
        }

        private string GenerarMensajeResultados((string factor, double porcentaje) resultado)
        {
            string mensaje;
            if (resultado.porcentaje >= 70)
                mensaje = $"HAY UN NOTABLE IMPACTO DE {resultado.factor.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA";
            else
                mensaje = $"NO HAY UN NOTABLE IMPACTO DE {resultado.factor.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA";

            return $"{resultado.porcentaje:0.##}% - {mensaje}";
        }

        private void GuardarAutoPEST(int[] valores, string r1, string r2, string r3, string r4)
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    // Llamar al procedimiento almacenado
                    var resultado = dc.SP_InsertarOActualizarAutoPEST(
                        Sesion.EmpresaId,  // empresa_id
                        valores[0],   // p1
                        valores[1],   // p2
                        valores[2],   // p3
                        valores[3],   // p4
                        valores[4],   // p5
                        valores[5],   // p6
                        valores[6],   // p7
                        valores[7],   // p8
                        valores[8],   // p9
                        valores[9],   // p10
                        valores[10],  // p11
                        valores[11],  // p12
                        valores[12],  // p13
                        valores[13],  // p14
                        valores[14],  // p15
                        valores[15],  // p16
                        valores[16],  // p17
                        valores[17],  // p18
                        valores[18],  // p19
                        valores[19],  // p20
                        valores[20],  // p21
                        valores[21],  // p22
                        valores[22],  // p23
                        valores[23],  // p24
                        valores[24],  // p25
                        r1,           // R1 - Factores Sociales
                        r2,           // R2 - Factores Políticos  
                        r3,           // R3 - Factores Económicos
                        r4            // R4 - Factores Tecnológicos
                    );

                    // Mostrar mensaje según el resultado
                    var primerResultado = resultado.FirstOrDefault();
                    if (primerResultado != null)
                    {
                        string accion = primerResultado.Resultado;
                        if (accion == "INSERTADO")
                        {
                            MessageBox.Show("Análisis PEST registrado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (accion == "ACTUALIZADO")
                        {
                            MessageBox.Show("Análisis PEST actualizado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar Análisis PEST: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtO3_TextChanged(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o manejar cambios en los textos aquí si lo necesitas
        }
    }
}