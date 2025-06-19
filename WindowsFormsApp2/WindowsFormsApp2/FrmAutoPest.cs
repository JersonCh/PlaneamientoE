using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmAutoPest : Form
    {
        private ToolTip tooltip = new ToolTip();

        public FrmAutoPest()
        {
            InitializeComponent();
            ConfigurarGrafico();
            CargarAutoPESTExistente();
        }

        private void CargarAutoPESTExistente()
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    var resultado = dc.SP_ObtenerAutoPEST(Sesion.EmpresaId);

                    foreach (var autoPest in resultado)
                    {
                        // Array con los valores de las 25 preguntas
                        int[] valores = {
                            autoPest.p1, autoPest.p2, autoPest.p3, autoPest.p4, autoPest.p5,
                            autoPest.p6, autoPest.p7, autoPest.p8, autoPest.p9, autoPest.p10,
                            autoPest.p11, autoPest.p12, autoPest.p13, autoPest.p14, autoPest.p15,
                            autoPest.p16, autoPest.p17, autoPest.p18, autoPest.p19, autoPest.p20,
                            autoPest.p21, autoPest.p22, autoPest.p23, autoPest.p24, autoPest.p25
                        };

                        // Marcar los RadioButtons correspondientes
                        for (int i = 1; i <= 25; i++)
                        {
                            int valorPregunta = valores[i - 1];

                            // Buscar el panel de la pregunta i
                            Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                            if (panel != null)
                            {
                                // Buscar el RadioButton con el valor correspondiente
                                string nombreRadioButton = $"p{i}_{valorPregunta}";
                                RadioButton rb = panel.Controls.Find(nombreRadioButton, false).FirstOrDefault() as RadioButton;
                                if (rb != null)
                                {
                                    rb.Checked = true;
                                }
                            }
                        }

                        // Llenar los TextBoxes con los resultados R1-R5
                        txtSociales.Text = autoPest.R1 ?? "";
                        txtPoliticos.Text = autoPest.R2 ?? "";
                        txtEconomicos.Text = autoPest.R3 ?? "";
                        txtTecnologicos.Text = autoPest.R4 ?? "";
                        txtAmbientales.Text = autoPest.R5 ?? "";

                        // Generar el gráfico con los datos cargados
                        GenerarGraficoDesdeTextos();

                        return; // Solo tomar el primer resultado
                    }

                    // Si no hay datos, limpiar todo
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar AutoPEST: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarGraficoDesdeTextos()
        {
            var resultados = new List<(string factor, double porcentaje)>();

            // Extraer porcentajes de los TextBoxes
            resultados.Add(("Factores Sociales y Demográficos", ExtraerPorcentaje(txtSociales.Text)));
            resultados.Add(("Factores Políticos", ExtraerPorcentaje(txtPoliticos.Text)));
            resultados.Add(("Factores Económicos", ExtraerPorcentaje(txtEconomicos.Text)));
            resultados.Add(("Factores Tecnológicos", ExtraerPorcentaje(txtTecnologicos.Text)));
            resultados.Add(("Factores Medio Ambientales", ExtraerPorcentaje(txtAmbientales.Text)));

            // Actualizar el gráfico
            ActualizarGrafico(resultados);
        }

        private double ExtraerPorcentaje(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return 0;

            // Buscar el patrón de porcentaje al inicio del texto (ej: "75.5%" o "10%")
            Match match = Regex.Match(texto, @"^(\d+(?:\.\d+)?)%");

            if (match.Success && double.TryParse(match.Groups[1].Value, out double porcentaje))
            {
                return porcentaje;
            }

            return 0;
        }

        private void LimpiarFormulario()
        {
            // Desmarcar todos los RadioButtons
            for (int i = 1; i <= 25; i++)
            {
                Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
                    {
                        rb.Checked = false;
                    }
                }
            }

            // Limpiar los TextBoxes
            txtSociales.Text = "";
            txtPoliticos.Text = "";
            txtEconomicos.Text = "";
            txtTecnologicos.Text = "";
            txtAmbientales.Text = "";

            // Limpiar el gráfico
            chartFactores.Series.Clear();
        }

        // Resto de tu código original...
        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
            int[] valoresPreguntas = new int[25];

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

            var resultados = new List<(string factor, double porcentaje)>
            {
                ("Factores Sociales y Demográficos", CalcularFactor(1, 5)),
                ("Factores Políticos", CalcularFactor(6, 10)),
                ("Factores Económicos", CalcularFactor(11, 15)),
                ("Factores Tecnológicos", CalcularFactor(16, 20)),
                ("Factores Medio Ambientales", CalcularFactor(21, 25))
            };

            MostrarResultado(txtSociales, resultados[0].porcentaje, resultados[0].factor);
            MostrarResultado(txtPoliticos, resultados[1].porcentaje, resultados[1].factor);
            MostrarResultado(txtEconomicos, resultados[2].porcentaje, resultados[2].factor);
            MostrarResultado(txtTecnologicos, resultados[3].porcentaje, resultados[3].factor);
            MostrarResultado(txtAmbientales, resultados[4].porcentaje, resultados[4].factor);

            GuardarAutoPEST(valoresPreguntas,
                GenerarMensajeResultados(resultados[0]),
                GenerarMensajeResultados(resultados[1]),
                GenerarMensajeResultados(resultados[2]),
                GenerarMensajeResultados(resultados[3]),
                GenerarMensajeResultados(resultados[4]));

            ActualizarGrafico(resultados);
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
            string mensaje = porcentaje >= 70
                ? $"HAY UN NOTABLE IMPACTO DE {factorNombre.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA"
                : $"NO HAY UN NOTABLE IMPACTO DE {factorNombre.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA";

            txt.Text = $"{porcentaje:0.##}% - {mensaje}";
        }

        private string GenerarMensajeResultados((string factor, double porcentaje) resultado)
        {
            string mensaje = resultado.porcentaje >= 70
                ? $"HAY UN NOTABLE IMPACTO DE {resultado.factor.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA"
                : $"NO HAY UN NOTABLE IMPACTO DE {resultado.factor.ToUpper()} EN EL FUNCIONAMIENTO DE LA EMPRESA";

            return $"{resultado.porcentaje:0.##}% - {mensaje}";
        }

        private void GuardarAutoPEST(int[] valores, string r1, string r2, string r3, string r4, string r5)
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    var resultado = dc.SP_InsertarOActualizarAutoPEST(
                        Sesion.EmpresaId,
                        valores[0], valores[1], valores[2], valores[3], valores[4],
                        valores[5], valores[6], valores[7], valores[8], valores[9],
                        valores[10], valores[11], valores[12], valores[13], valores[14],
                        valores[15], valores[16], valores[17], valores[18], valores[19],
                        valores[20], valores[21], valores[22], valores[23], valores[24],
                        r1, r2, r3, r4, r5);

                    var primerResultado = resultado.FirstOrDefault();
                    if (primerResultado != null)
                    {
                        string accion = primerResultado.Resultado;
                        MessageBox.Show(accion == "INSERTADO"
                            ? "Análisis PEST registrado correctamente."
                            : "Análisis PEST actualizado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar Análisis PEST: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrafico()
        {
            chartFactores.Series.Clear();
            chartFactores.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            chartFactores.ChartAreas.Add(area);

            chartFactores.ChartAreas[0].AxisX.Title = "Factores";
            chartFactores.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartFactores.ChartAreas[0].AxisX.Interval = 1;
            chartFactores.ChartAreas[0].AxisY.Title = "Porcentaje (%)";
            chartFactores.ChartAreas[0].AxisY.Minimum = 0;
            chartFactores.ChartAreas[0].AxisY.Maximum = 100;
        }

        private void ActualizarGrafico(List<(string factor, double porcentaje)> totales)
        {
            chartFactores.Series.Clear();

            Series serie = new Series("Impacto")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var item in totales)
            {
                int index = serie.Points.AddXY(item.factor, item.porcentaje);

                serie.Points[index].Color = item.porcentaje >= 70 ? Color.Red :
                    item.porcentaje >= 40 ? Color.Orange : Color.Green;

                string mensaje = GenerarMensajeResultados(item);
                serie.Points[index].ToolTip = mensaje;
            }

            chartFactores.Series.Add(serie);
        }
        private void FrmAutoPest_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar código cuando necesites cargar datos
        }
    }
}