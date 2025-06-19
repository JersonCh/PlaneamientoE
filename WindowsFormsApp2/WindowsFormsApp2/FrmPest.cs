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

    public partial class FrmPest : Form
    {
        private ToolTip tooltip = new ToolTip();
        public FrmPest()
        {
            InitializeComponent();
            ConfigurarGrafico();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerrar formulario activo si ya hay uno
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls[0].Dispose();

            // Suscribirse al evento si es FrmAutoPest
            if (formularioHijo is FrmAutoPest frmAutoPest)
            {
                frmAutoPest.TotalesCalculados += FrmAutoPest_TotalesCalculados;
            }

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.Show();
        }
        private void FrmAutoPest_TotalesCalculados(object sender, List<(string factor, double porcentaje)> totales)
        {
            // Actualizar gráfico en el formulario principal
            ActualizarGrafico(totales);
        }

        // Método para configurar el control Chart (chartFactores) al iniciar
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

            Series serie = new Series("Impacto");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;  // Mostrar valor encima

            foreach (var item in totales)
            {
                int index = serie.Points.AddXY(item.factor, item.porcentaje);

                // Asignar color según el porcentaje
                if (item.porcentaje >= 70)
                    serie.Points[index].Color = Color.Red;
                else if (item.porcentaje >= 40)
                    serie.Points[index].Color = Color.Orange;
                else
                    serie.Points[index].Color = Color.Green;

                // Texto para tooltip
                string mensaje = CrearMensajeTooltip(item.porcentaje, item.factor);
                serie.Points[index].ToolTip = mensaje;
            }

            chartFactores.Series.Add(serie);
        }


        // Método para crear el mensaje que se mostrará en el tooltip
        private string CrearMensajeTooltip(double porcentaje, string factorNombre)
        {
            string mensaje;

            if (porcentaje >= 70)
                mensaje = $"HAY UN NOTABLE IMPACTO DE {factorNombre} EN EL FUNCIONAMIENTO DE LA EMPRESA";
            else
                mensaje = $"NO HAY UN NOTABLE IMPACTO DE {factorNombre} EN EL FUNCIONAMIENTO DE LA EMPRESA";

            return $"{porcentaje:0.##}% - {mensaje}";
        }


        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmAutoPest());
        }


        private void chartFactores_MouseMove_1(object sender, MouseEventArgs e)
        {
            // Detectar qué elemento está bajo el mouse
            HitTestResult result = chartFactores.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = result.PointIndex;
                Series serie = result.Series;
                var punto = serie.Points[pointIndex];

                // Mostrar tooltip con el texto que ya asignaste en la propiedad ToolTip del punto
                string mensaje = punto.ToolTip;

                // Mostrar el tooltip cerca del cursor, con duración de 2 segundos
                tooltip.Show(mensaje, chartFactores, e.X + 15, e.Y + 15, 2000);
            }
            else
            {
                // Si el mouse no está sobre un punto, ocultar tooltip
                tooltip.Hide(chartFactores);
            }
        }

        private void chartFactores_Click(object sender, EventArgs e)
        {

        }
    }
}
