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

namespace WindowsFormsApp2
{
    public partial class FrmBCGgenerado : Form
    {
        public FrmBCGgenerado(string[] valoresVenta)
        {
            InitializeComponent();
            ConfigurarFondoTransparente();

            txtVenta1.ReadOnly = true;
            txtVenta2.ReadOnly = true;
            txtVenta3.ReadOnly = true;
            txtVenta4.ReadOnly = true;
            txtVenta5.ReadOnly = true;

            if (valoresVenta != null && valoresVenta.Length >= 5)
            {
                txtVenta1.Text = valoresVenta[0];
                txtVenta2.Text = valoresVenta[1];
                txtVenta3.Text = valoresVenta[2];
                txtVenta4.Text = valoresVenta[3];
                txtVenta5.Text = valoresVenta[4];

                // Generar automáticamente el gráfico BCG con los valores recibidos
                try
                {
                    double[] ventas = new double[5];
                    for (int i = 0; i < 5; i++)
                    {
                        ventas[i] = double.Parse(valoresVenta[i]);
                    }
                    MostrarGraficoBCG(ventas);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Hubo un problema con el formato de los valores transferidos.");
                }
            }
        }

        public FrmBCGgenerado()
        {
        }

        private void ConfigurarFondoTransparente()
        {
            // Hacer transparente el control chart
            chart1.BackColor = Color.Transparent;
            // Si ya existe un ChartArea, hacerlo transparente también
            if (chart1.ChartAreas.Count > 0)
            {
                foreach (ChartArea area in chart1.ChartAreas)
                {
                    area.BackColor = Color.Transparent;
                    area.BorderColor = Color.Transparent;
                }
            }
            // Configurar el formulario para permitir transparencia
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void MostrarGraficoBCG(double[] valoresY)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear(); // Eliminar leyendas si las hay

            ChartArea area = new ChartArea("Area1");
            chart1.ChartAreas.Add(area);

            // Encontrar el valor máximo para establecer los límites del gráfico
            double maxValue = valoresY.Max();
            // Evitar problemas si todos los valores son cero
            maxValue = maxValue <= 0 ? 10 : maxValue;
            double yMax = Math.Ceiling(maxValue * 1.1); // 10% más que el valor máximo

            // Configurar los ejes aunque estén invisibles para controlar el área de dibujo
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 6; // 5 puntos + margen
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = yMax;

            // Añadir un margen en la parte inferior para evitar cortes
            area.Position.Auto = false;
            area.Position.X = 5;
            area.Position.Y = 10; // Más margen en la parte superior
            area.Position.Width = 90;
            area.Position.Height = 80;

            // Desactivar ejes, líneas, etiquetas, etc.
            area.AxisX.Enabled = AxisEnabled.False;
            area.AxisY.Enabled = AxisEnabled.False;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;
            area.AxisX.LabelStyle.Enabled = false;
            area.AxisY.LabelStyle.Enabled = false;

            // Hacer transparente el fondo del área del gráfico
            area.BackColor = Color.Transparent;
            // También hacer transparente el fondo del chart principal
            chart1.BackColor = Color.Transparent;

            // Agregar líneas divisorias para crear 4 cuadrantes
            // Línea horizontal que divide superior e inferior
            Series lineaHorizontal = new Series("LineaHorizontal")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "Area1",
                BorderWidth = 1,
                Color = Color.Gray
            };
            lineaHorizontal.Points.AddXY(0, yMax / 2.5);
            lineaHorizontal.Points.AddXY(6, yMax / 2.5);
            chart1.Series.Add(lineaHorizontal);

            // Línea vertical que divide izquierda y derecha
            Series lineaVertical = new Series("LineaVertical")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "Area1",
                BorderWidth = 1,
                Color = Color.Gray
            };
            lineaVertical.Points.AddXY(2.2, 0);
            lineaVertical.Points.AddXY(2.2, yMax);
            chart1.Series.Add(lineaVertical);

            // Serie para las burbujas
            Series serie = new Series("PRM")
            {
                ChartType = SeriesChartType.Bubble,
                ChartArea = "Area1",
                IsValueShownAsLabel = true,
                MarkerStyle = MarkerStyle.Circle,
            };
            chart1.Series.Add(serie);
            serie["BubbleMinSize"] = "23";
            serie["BubbleMaxSize"] = "23";
            // Definir los colores para las burbujas
            Color[] colores = new Color[] {
                Color.FromArgb(255, 32, 178, 170),  // Turquesa/Cyan
                Color.Gold,                         // Amarillo/Oro
                Color.Red,                          // Rojo
                Color.FromArgb(255, 107, 142, 35),  // Verde oliva
                Color.Brown                         // Marrón
            };

            for (int i = 0; i < valoresY.Length; i++)
            {
                double y = valoresY[i];
                // Asegurar que los valores de Y nunca sean exactamente 0
                if (y < 0.01) y = 0.01; // Valor mínimo para evitar cortes
                double x = i + 1;
                // Usar un valor constante para Z para que todas las burbujas tengan el mismo tamaño
                double z = 10; // Valor constante para el tamaño
                int puntoIndex = serie.Points.AddXY(x, y, z);
                serie.Points[puntoIndex].Color = colores[i % colores.Length]; // Asignar color según el índice

                // Mostrar el valor real en la etiqueta (aunque Y se ajustó para evitar cortes)
                serie.Points[puntoIndex].Label = valoresY[i].ToString();
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            double[] ventas = new double[5];
            TextBox[] cajas = { txtVenta1, txtVenta2, txtVenta3, txtVenta4, txtVenta5 };

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    ventas[i] = double.Parse(cajas[i].Text);
                }
                MostrarGraficoBCG(ventas);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa solo números válidos.");
            }
        }
    }
}