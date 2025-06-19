using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmBCGinicio : Form
    {
        public FrmBCGinicio()
        {
            InitializeComponent();
            ConfigurarChartBCG();
            GenerarMatrizBCGDesdeBD();
        }

        private Color[] GenerarColoresProductos(int cantidadProductos)
        {
            List<Color> colores = new List<Color>();

            // Colores base predefinidos
            Color[] coloresBase = {
                Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple,
                Color.Brown, Color.Pink, Color.Gray, Color.Cyan, Color.Magenta,
                Color.DarkBlue, Color.DarkGreen, Color.DarkRed, Color.Gold,
                Color.Violet, Color.Teal, Color.Navy, Color.Maroon, Color.Olive
            };

            // Si necesitamos más colores de los predefinidos, generar colores aleatorios
            Random random = new Random();

            for (int i = 0; i < cantidadProductos; i++)
            {
                if (i < coloresBase.Length)
                {
                    colores.Add(coloresBase[i]);
                }
                else
                {
                    // Generar color aleatorio con buena saturación
                    int r = random.Next(50, 255);
                    int g = random.Next(50, 255);
                    int b = random.Next(50, 255);
                    colores.Add(Color.FromArgb(r, g, b));
                }
            }

            return colores.ToArray();
        }

        private void ConfigurarChartBCG()
        {
            chartBCG2.Series.Clear();
            chartBCG2.ChartAreas.Clear();
            chartBCG2.Legends.Clear();
            chartBCG2.Annotations.Clear(); // Limpiar todas las anotaciones

            // Configurar el área del gráfico
            ChartArea chartArea = new ChartArea("BCGMatrix");
            chartArea.AxisX.Title = "Participación Relativa de Mercado";
            chartArea.AxisY.Title = "Tasa de Crecimiento del Mercado (%)";

            // CONFIGURAR EJE X CON ESCALA MANUAL LOGARÍTMICA
            chartArea.AxisX.Minimum = -2;     // Equivale a log10(0.01) = -2
            chartArea.AxisX.Maximum = 2;      // Equivale a log10(100) = 2
            chartArea.AxisX.IsReversed = true; // Mantener orden invertido

            // Configurar intervalos
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineWidth = 1;

            // Configurar las etiquetas personalizadas para X
            chartArea.AxisX.CustomLabels.Clear();
            chartArea.AxisX.CustomLabels.Add(0.8, 1.2, "10.000");   // log10(10) = 1
            chartArea.AxisX.CustomLabels.Add(-0.2, 0.2, "1.000");   // log10(1) = 0  
            chartArea.AxisX.CustomLabels.Add(-1.2, -0.8, "0.100");  // log10(0.1) = -1

            // Configurar escala Y (Tasa de Crecimiento) - MANTENER LINEAL
            chartArea.AxisY.Minimum = -10;
            chartArea.AxisY.Maximum = 20;
            chartArea.AxisY.Interval = 5; // Intervalos de 5%

            // Configurar las etiquetas personalizadas para Y
            chartArea.AxisY.CustomLabels.Clear();
            chartArea.AxisY.CustomLabels.Add(-12.5, -7.5, "-10.0%");
            chartArea.AxisY.CustomLabels.Add(-7.5, -2.5, "-5.0%");
            chartArea.AxisY.CustomLabels.Add(-2.5, 2.5, "0.0%");
            chartArea.AxisY.CustomLabels.Add(2.5, 7.5, "5.0%");
            chartArea.AxisY.CustomLabels.Add(7.5, 12.5, "10.0%");
            chartArea.AxisY.CustomLabels.Add(12.5, 17.5, "15.0%");
            chartArea.AxisY.CustomLabels.Add(17.5, 22.5, "20.0%");

            // Configurar grillas
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineWidth = 1;

            // LÍNEAS DIVISORIAS PRINCIPALES para separar los 4 cuadrantes

            // Línea vertical en X = 0 (equivale a log10(1) = 0, separar alta/baja participación)
            StripLine lineaVertical = new StripLine();
            lineaVertical.Interval = 0;
            lineaVertical.IntervalOffset = 0.0;
            lineaVertical.StripWidth = 0;
            lineaVertical.BorderColor = Color.Red;
            lineaVertical.BorderWidth = 3;
            lineaVertical.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.AxisX.StripLines.Add(lineaVertical);

            // Línea horizontal en Y = 10.0% (separar alto/bajo crecimiento)
            StripLine lineaHorizontal = new StripLine();
            lineaHorizontal.Interval = 0;
            lineaHorizontal.IntervalOffset = 10.0;
            lineaHorizontal.StripWidth = 0;
            lineaHorizontal.BorderColor = Color.Red;
            lineaHorizontal.BorderWidth = 3;
            lineaHorizontal.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.AxisY.StripLines.Add(lineaHorizontal);

            chartBCG2.ChartAreas.Add(chartArea);

            // Configurar la leyenda
            Legend leyenda = new Legend("LeyendaProductos");
            leyenda.Docking = Docking.Right;
            leyenda.Alignment = StringAlignment.Center;
            leyenda.Title = "Productos";
            leyenda.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chartBCG2.Legends.Add(leyenda);
        }

        private double TransformarParticipacionALog(decimal participacion)
        {
            // Evitar valores <= 0 que causarían problemas con log10
            if (participacion <= 0)
                return -2; // Valor mínimo del eje

            // Transformar a escala logarítmica: log10(participacion)
            return Math.Log10((double)participacion);
        }

        private void GenerarMatrizBCGDesdeBD()
        {
            try
            {
                // Obtener la información de la sesión
                int empresaId = Sesion.EmpresaId;

                // Validar que tengamos información de sesión
                if (empresaId <= 0)
                {
                    MessageBox.Show("Error: No se ha identificado la empresa. Por favor, inicie sesión nuevamente.",
                                  "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    // Obtener productos BCG desde la base de datos
                    var productosBCG = dc.SP_ObtenerProductosBCG(empresaId).ToList();

                    if (productosBCG.Count == 0)
                    {
                        MessageBox.Show("No hay productos BCG registrados para esta empresa.",
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Generar colores dinámicamente
                    Color[] coloresProductos = GenerarColoresProductos(productosBCG.Count);

                    for (int i = 0; i < productosBCG.Count; i++)
                    {
                        var producto = productosBCG[i];

                        string nombreProducto = producto.producto;
                        decimal participacion = producto.participacion_mercado;
                        decimal tasaCrecimiento = producto.tasa_crecimiento;
                        string cuadrante = producto.cuadrante ?? "";

                        // Crear serie para cada producto
                        Series serie = new Series(nombreProducto);
                        serie.ChartType = SeriesChartType.Bubble;
                        serie.Color = coloresProductos[i];
                        serie.MarkerStyle = MarkerStyle.Circle;

                        // El tamaño de la burbuja será proporcional a la participación (como no tenemos porcentaje de ventas)
                        double tamanioBurbuja = Math.Max(50, Math.Min(500, (double)participacion * 100));

                        // TRANSFORMAR LA PARTICIPACIÓN A ESCALA LOGARÍTMICA
                        double participacionLog = TransformarParticipacionALog(participacion);

                        // Crear punto con valores transformados para gráfico de burbuja
                        int puntoIndex = serie.Points.AddXY(participacionLog, (double)tasaCrecimiento);
                        DataPoint punto = serie.Points[puntoIndex];

                        // Configurar el tamaño de la burbuja (tercer valor)
                        punto.YValues = new double[] { (double)tasaCrecimiento, tamanioBurbuja };

                        // Configurar etiqueta del punto
                        punto.Label = $"{nombreProducto}";
                        punto.LabelForeColor = Color.Black;
                        punto.Font = new Font("Arial", 8, FontStyle.Bold);

                        // Configurar tooltip con información detallada
                        punto.ToolTip = $"Producto: {nombreProducto}\n" +
                                       $"Participación: {participacion:F3}\n" +
                                       $"Crecimiento: {tasaCrecimiento:F1}%\n" +
                                       $"Cuadrante: {cuadrante}";

                        chartBCG2.Series.Add(serie);
                    }

                    chartBCG2.Invalidate(); // Forzar redibujado
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos BCG: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Buscar el formulario padre (Dashboard)
            Form dashboard = this.ParentForm;
            if (dashboard == null)
            {
                // Si no hay padre, buscar en formularios abiertos
                foreach (Form form in Application.OpenForms)
                {
                    if (form is FrmDashBoard2)
                    {
                        dashboard = form;
                        break;
                    }
                }
            }

            // Si encontramos el dashboard, abrir FrmBCG3 usando su método
            if (dashboard is FrmDashBoard2)
            {
                FrmDashBoard2 dash = (FrmDashBoard2)dashboard;
                // Llamar al método público que acabamos de crear
                dash.AbrirFormularioBCG3();
            }
            else
            {
                // Fallback: abrir FrmBCG3 independientemente
                FrmBCG3 frmBCG3 = new FrmBCG3();
                frmBCG3.Show();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            this.Hide();

            FrmMatrizDePorter frm = new FrmMatrizDePorter();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            this.Show();
            this.TopMost = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
