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
    public partial class panel : Form
    {
        public panel()
        {
            InitializeComponent();

            // Tabla 1: Previsión de Ventas
            dgvVentas.Columns.Add("colProductos", "PRODUCTOS");
            dgvVentas.Columns.Add("colVentas", "VENTAS");
            dgvVentas.Columns.Add("colPorcentaje", "% S/ TOTAL");
            dgvVentas.Rows.Add("Producto 1", "", "0,00%");
            dgvVentas.Rows.Add("Producto 2", "", "0,00%");
            dgvVentas.Rows.Add("Producto 3", "", "0,00%");
            dgvVentas.Rows.Add("Producto 4", "", "0,00%");
            dgvVentas.Rows.Add("Producto 5", "", "0,00%");
            dgvVentas.Rows.Add("TOTAL", "0", "0,00%");

            // Tabla 2: Tasas de Crecimiento
            dgvTasasCrecimiento.Columns.Add("colPeriodos", "PERIODOS");
            for (int i = 1; i <= 5; i++)
                dgvTasasCrecimiento.Columns.Add($"colProducto{i}", $"Producto {i}");
            dgvTasasCrecimiento.Rows.Add("2012 - 2013", "", "", "", "", "");
            dgvTasasCrecimiento.Rows.Add("2013 - 2014", "", "", "", "", "");
            dgvTasasCrecimiento.Rows.Add("2014 - 2015", "", "", "", "", "");
            dgvTasasCrecimiento.Rows.Add("2015 - 2016", "", "", "", "", "");
            dgvTasasCrecimiento.Rows.Add("2016 - 2017", "", "", "", "", "");
            dgvTasasCrecimiento.Rows.Add("2017 - 2018", "", "", "", "", "");

            // Tabla 3: Matriz BCG
            dgvBCG.Columns.Add("colBCG", "BCG");
            for (int i = 1; i <= 5; i++)
                dgvBCG.Columns.Add($"colProducto{i}", $"Producto {i}");
            dgvBCG.Rows.Add("TCM", "0,00%", "0,00%", "0,00%", "0,00%", "0,00%");
            dgvBCG.Rows.Add("PRM", "0,00", "0,00", "0,00", "0,00", "0,00");
            dgvBCG.Rows.Add("% S/VTAS", "0%", "0%", "0%", "0%", "0%");

            // Tabla 4: Matriz BCG

            // Columnas
            dgvDemandaGlobal.Columns.Add("Años", "AÑOS");
            for (int i = 1; i <= 5; i++)
                dgvDemandaGlobal.Columns.Add($"Producto{i}", $"Producto {i}");

            // Filas (años 2012-2017)
            string[] años = { "2012", "2013", "2014", "2015", "2016", "2017" };
            foreach (var año in años)
                dgvDemandaGlobal.Rows.Add(año, "", "", "", "", "");

            // Tabla 5: Matriz BCG
            // Columnas (una por producto)
            for (int i = 1; i <= 5; i++)
            {
                dgvCompetidores.Columns.Add($"Competidor{i}", $"Producto {i} - Competidor");
                dgvCompetidores.Columns.Add($"Ventas{i}", $"Ventas");
            }

            // Fila de totales
            dgvCompetidores.Rows.Add("EMPRESA", "0", "EMPRESA", "0", "EMPRESA", "0", "EMPRESA", "0", "EMPRESA", "0");

            // Filas de competidores (CP1-1, CP1-2, etc.)
            for (int i = 1; i <= 9; i++)
            {
                dgvCompetidores.Rows.Add(
                    $"CP1-{i}", "", $"CP2-{i}", "", $"CP3-{i}", "", $"CP4-{i}", "", $"CP5-{i}", ""
                );
            }

            // Fila "Mayor"
            dgvCompetidores.Rows.Add("Mayor", "0", "Mayor", "0", "Mayor", "0", "Mayor", "0", "Mayor", "0");
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
