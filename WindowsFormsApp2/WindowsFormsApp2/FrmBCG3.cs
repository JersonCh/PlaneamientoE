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
    public partial class FrmBCG3 : Form
    {
        private DataTable dtPrevision;
        private DataTable dtVLC;
        private int contadorCompetidores = 1;
        private DataTable dtVSA;
        private DataTable dtResultados;
        private int anioInicio = 2024;
        private int anioFinal = 2025;
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

        private const string COL_PRODUCTOS = "PRODUCTOS";
        private const string COL_VENTAS = "VENTAS";
        private const string COL_PORCENTAJE = "% S/ TOTAL";
        private const string COL_LIDER = "Ventas líder competidor";
        private const string COMPETIDOR_BASE = "Competidor";
        private const string FILA_TOTAL = "TOTAL";
        private const string COL_PARTICIPACION = "Participación de Mercado";
        private const string COL_TASA_CRECIMIENTO = "Tasa de Crecimiento de Mercado";
        private const string COL_CUADRANTE = "Cuadrante";
        public FrmBCG3()
        {
            InitializeComponent();
            ConfigurarTablaPrevision();
            ConfigurarTablaVLC();
            ConfigurarTablaVSA();
            ConfigurarTablaResultados();
            ConfigurarChartBCG();
            // Suscribimos eventos
            dtPrevision.RowChanged += DtPrevision_RowChanged;
            dtPrevision.TableNewRow += DtPrevision_TableNewRow;
        }
        private void ConfigurarTablaPrevision()
        {
            dtPrevision = new DataTable();
            dtPrevision.Columns.Add(COL_PRODUCTOS, typeof(string));
            dtPrevision.Columns.Add(COL_VENTAS, typeof(decimal));
            dtPrevision.Columns.Add(COL_PORCENTAJE, typeof(string));
            dgvPrevision.DataSource = dtPrevision;
            dgvPrevision.AllowUserToAddRows = false;
            dgvPrevision.AllowUserToDeleteRows = false;
            dgvPrevision.Columns[COL_PRODUCTOS].ReadOnly = false;
            dgvPrevision.Columns[COL_VENTAS].ReadOnly = false;
            dgvPrevision.Columns[COL_PORCENTAJE].ReadOnly = true;
            AgregarProductosIniciales();
            AgregarFilaTotal();
            dgvPrevision.CellEndEdit += DgvPrevision_CellEndEdit;
            FormatearTabla();
        }
        private void AgregarProductosIniciales()
        {
            for (int i = 1; i <= 3; i++)
            {
                dtPrevision.Rows.Add($"Producto {i}", 0, "0.00%");
            }
        }
        private void AgregarFilaTotal()
        {
            dtPrevision.Rows.Add(FILA_TOTAL, 0, "100.00%");
            int ultimaFila = dgvPrevision.Rows.Count - 1;
            dgvPrevision.Rows[ultimaFila].ReadOnly = true;
            dgvPrevision.Rows[ultimaFila].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
        }
        private void FormatearTabla()
        {
            dgvPrevision.Columns[COL_PRODUCTOS].Width = 150;
            dgvPrevision.Columns[COL_VENTAS].Width = 100;
            dgvPrevision.Columns[COL_VENTAS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrevision.Columns[COL_PORCENTAJE].Width = 100;
            dgvPrevision.Columns[COL_PORCENTAJE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrevision.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void DgvPrevision_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrevision.Columns[e.ColumnIndex].Name == COL_VENTAS)
            {
                CalcularPorcentajes();
            }
            else if (dgvPrevision.Columns[e.ColumnIndex].Name == COL_PRODUCTOS)
            {
                // Sincronizar el nombre del producto en todas las tablas
                SincronizarNombreProducto(e.RowIndex);
            }
        }
        private void SincronizarNombreProducto(int indiceProducto)
        {
            if (indiceProducto >= 0 && indiceProducto < dtPrevision.Rows.Count - 1) // Excluir la fila TOTAL
            {
                string nuevoNombre = dtPrevision.Rows[indiceProducto][COL_PRODUCTOS].ToString();

                // Sincronizar en tabla VLC
                if (indiceProducto < dtVLC.Rows.Count)
                {
                    dtVLC.Rows[indiceProducto][COL_PRODUCTOS] = nuevoNombre;
                }

                // Sincronizar en tabla VSA
                if (indiceProducto < dtVSA.Rows.Count)
                {
                    dtVSA.Rows[indiceProducto][COL_PRODUCTOS] = nuevoNombre;
                }

                // Sincronizar en tabla Resultados
                if (indiceProducto < dtResultados.Rows.Count)
                {
                    dtResultados.Rows[indiceProducto][COL_PRODUCTOS] = nuevoNombre;
                }

                // Refrescar las vistas
                dgvVLC.Refresh();
                dgvVSA.Refresh();
                dgvResultados.Refresh();

                // Actualizar nombres en el chart si está visible
                ActualizarNombresEnChart();
            }
        }
        private void CalcularPorcentajes()
        {
            decimal totalVentas = 0;
            int totalRowIndex = dtPrevision.Rows.Count - 1;
            for (int i = 0; i < totalRowIndex; i++)
            {
                if (dtPrevision.Rows[i][COL_VENTAS] != DBNull.Value)
                {
                    totalVentas += Convert.ToDecimal(dtPrevision.Rows[i][COL_VENTAS]);
                }
            }
            dtPrevision.Rows[totalRowIndex][COL_VENTAS] = totalVentas;
            for (int i = 0; i < totalRowIndex; i++)
            {
                if (totalVentas > 0 && dtPrevision.Rows[i][COL_VENTAS] != DBNull.Value)
                {
                    decimal porcentaje = (Convert.ToDecimal(dtPrevision.Rows[i][COL_VENTAS]) / totalVentas) * 100;
                    dtPrevision.Rows[i][COL_PORCENTAJE] = $"{porcentaje:F2}%";
                }
                else
                {
                    dtPrevision.Rows[i][COL_PORCENTAJE] = "0.00%";
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int numProducto = dtPrevision.Rows.Count;
            dtPrevision.Rows.RemoveAt(numProducto - 1);
            dtPrevision.Rows.Add($"Producto {numProducto}", 0, "0.00%");
            AgregarFilaTotal();
            CalcularPorcentajes();
            SincronizarProductos();
            SincronizarProductosVSA();
            SincronizarProductosResultados();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CalcularPorcentajes();
            dgvPrevision.Refresh();
            SincronizarProductosVSA();
            SincronizarProductosResultados();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            dtPrevision.Clear();
            AgregarProductosIniciales();
            AgregarFilaTotal();
            CalcularPorcentajes();
            SincronizarProductos();
            SincronizarProductosVSA();
            SincronizarProductosResultados();
        }
        public DataTable ObtenerDatosPrevision()
        {
            DataTable dtCopia = dtPrevision.Copy();

            // los datos sin la fila TOTAL
            // dtCopia.Rows.RemoveAt(dtCopia.Rows.Count - 1);

            return dtCopia;
        }
        /// <summary>
        /// Tabla Competidores
        /// </summary>
        private void ConfigurarTablaVLC()
        {
            dtVLC = new DataTable();
            dtVLC.Columns.Add(COL_PRODUCTOS, typeof(string));
            dtVLC.Columns.Add($"{COMPETIDOR_BASE}{contadorCompetidores}", typeof(decimal));
            dtVLC.Columns.Add(COL_LIDER, typeof(decimal));
            dgvVLC.DataSource = dtVLC;
            dgvVLC.AllowUserToAddRows = false;
            dgvVLC.AllowUserToDeleteRows = false;
            dgvVLC.CellEndEdit += DgvVLC_CellEndEdit;
            SincronizarProductos();
            FormatearTablaVLC();
        }
        private void FormatearTablaVLC()
        {
            dgvVLC.Columns[COL_PRODUCTOS].Width = 150;
            dgvVLC.Columns[COL_PRODUCTOS].ReadOnly = true;
            int colLider = dgvVLC.Columns.Count - 1;
            dgvVLC.Columns[colLider].Width = 120;
            dgvVLC.Columns[colLider].ReadOnly = true;
            dgvVLC.Columns[colLider].DefaultCellStyle.BackColor = Color.LightGray;
            dgvVLC.Columns[colLider].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVLC.Columns[colLider].DefaultCellStyle.Format = "F2";
            for (int i = 1; i < colLider; i++)
            {
                dgvVLC.Columns[i].Width = 100;
                dgvVLC.Columns[i].ReadOnly = false;
                dgvVLC.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVLC.Columns[i].DefaultCellStyle.Format = "F2";
            }
            dgvVLC.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void SincronizarProductos()
        {
            dtVLC.Rows.Clear();
            for (int i = 0; i < dtPrevision.Rows.Count - 1; i++)
            {
                DataRow nuevaFila = dtVLC.NewRow();
                nuevaFila[COL_PRODUCTOS] = dtPrevision.Rows[i][COL_PRODUCTOS];
                for (int j = 1; j < dtVLC.Columns.Count - 1; j++)
                {
                    nuevaFila[j] = 0.00m;
                }
                nuevaFila[COL_LIDER] = 0.00m;

                dtVLC.Rows.Add(nuevaFila);
            }
            ActualizarLideresCompetidores();
        }
        private void ActualizarLideresCompetidores()
        {
            for (int i = 0; i < dtVLC.Rows.Count; i++)
            {
                decimal maximo = 0;
                for (int j = 1; j < dtVLC.Columns.Count - 1; j++)
                {
                    if (dtVLC.Rows[i][j] != DBNull.Value)
                    {
                        decimal valor = Convert.ToDecimal(dtVLC.Rows[i][j]);
                        if (valor > maximo)
                        {
                            maximo = valor;
                        }
                    }
                }
                dtVLC.Rows[i][COL_LIDER] = maximo;
            }
        }
        private void DtPrevision_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Change && e.Row[COL_PRODUCTOS].ToString() != FILA_TOTAL)
            {
                int index = dtPrevision.Rows.IndexOf(e.Row);

                // Sincronizar en VLC
                if (index < dtVLC.Rows.Count)
                {
                    dtVLC.Rows[index][COL_PRODUCTOS] = e.Row[COL_PRODUCTOS];
                }

                // Sincronizar en VSA
                if (index < dtVSA.Rows.Count)
                {
                    dtVSA.Rows[index][COL_PRODUCTOS] = e.Row[COL_PRODUCTOS];
                }

                // Sincronizar en Resultados
                if (index < dtResultados.Rows.Count)
                {
                    dtResultados.Rows[index][COL_PRODUCTOS] = e.Row[COL_PRODUCTOS];
                }
            }
        }
        private void DtPrevision_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (e.Row[COL_PRODUCTOS].ToString() != FILA_TOTAL)
            {
                SincronizarProductos();
            }
        }
        private void DgvVLC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.ColumnIndex < dgvVLC.Columns.Count - 1)
            {
                ActualizarLideresCompetidores();
            }
        }

        private void btnAgregarCompetidor_Click(object sender, EventArgs e)
        {
            contadorCompetidores++;
            string nuevoNombreColumna = $"{COMPETIDOR_BASE}{contadorCompetidores}";
            int posicionColumna = dtVLC.Columns.IndexOf(COL_LIDER);
            dtVLC.Columns.Add(nuevoNombreColumna, typeof(decimal));
            dtVLC.Columns[nuevoNombreColumna].SetOrdinal(posicionColumna);
            foreach (DataRow fila in dtVLC.Rows)
            {
                fila[nuevoNombreColumna] = 0.00m;
            }
            dgvVLC.DataSource = null;
            dgvVLC.DataSource = dtVLC;

            FormatearTablaVLC();
            ActualizarLideresCompetidores();
        }

        private void btnActualizarCompetidor_Click(object sender, EventArgs e)
        {
            ActualizarLideresCompetidores();
            dgvVLC.Refresh();
            SincronizarProductosResultados();
        }

        private void btnLimpiarCompetidor_Click(object sender, EventArgs e)
        {
            contadorCompetidores = 1;
            ConfigurarTablaVLC();
        }
        public DataTable ObtenerDatosVLC()
        {
            return dtVLC.Copy();
        }

        private void dgvVLC_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.ColumnIndex < dgvVLC.Columns.Count - 1)
            {
                string nombreActual = dgvVLC.Columns[e.ColumnIndex].HeaderText;
                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                    "Introduzca el nuevo nombre para el competidor:",
                    "Editar nombre de competidor",
                    nombreActual);
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    dtVLC.Columns[e.ColumnIndex].ColumnName = nuevoNombre;
                    dgvVLC.Columns[e.ColumnIndex].HeaderText = nuevoNombre;
                }
            }
        }
        /// <summary>
        /// Tabla Ventas Sector
        /// </summary>
        private void ConfigurarTablaVSA()
        {
            dtVSA = new DataTable();
            dtVSA.Columns.Add(COL_PRODUCTOS, typeof(string));
            // Solo agregar columnas por defecto 2024 y 2025
            dtVSA.Columns.Add("2024", typeof(decimal));
            dtVSA.Columns.Add("2025", typeof(decimal));

            dgvVSA.DataSource = dtVSA;
            dgvVSA.AllowUserToAddRows = false;
            dgvVSA.AllowUserToDeleteRows = false;
            dgvVSA.Columns[COL_PRODUCTOS].ReadOnly = true;

            SincronizarProductosVSA();
            FormatearTablaVSA();
        }
        private void SincronizarProductosVSA()
        {
            dtVSA.Rows.Clear();
            for (int i = 0; i < dtPrevision.Rows.Count - 1; i++)
            {
                DataRow nuevaFila = dtVSA.NewRow();
                nuevaFila[COL_PRODUCTOS] = dtPrevision.Rows[i][COL_PRODUCTOS];

                // Inicializar valores numéricos en 0
                for (int j = 1; j < dtVSA.Columns.Count; j++)
                {
                    nuevaFila[j] = 0.00m;
                }

                dtVSA.Rows.Add(nuevaFila);
            }
        }
        private void ActualizarColumnasVSA()
        {
            // Leer años de los textbox
            if (!int.TryParse(txtInicio.Text, out anioInicio) ||
                !int.TryParse(txtFinal.Text, out anioFinal))
            {
                MessageBox.Show("Por favor ingrese años válidos");
                return;
            }

            if (anioInicio > anioFinal)
            {
                MessageBox.Show("El año inicial debe ser menor o igual al final");
                return;
            }

            // Limpiar columnas excepto PRODUCTOS
            for (int i = dtVSA.Columns.Count - 1; i > 0; i--)
            {
                dtVSA.Columns.RemoveAt(i);
            }

            // Agregar nuevas columnas de años
            for (int año = anioInicio; año <= anioFinal; año++)
            {
                dtVSA.Columns.Add(año.ToString(), typeof(decimal));
            }

            SincronizarProductosVSA();
            FormatearTablaVSA();
        }
        private void FormatearTablaVSA()
        {
            dgvVSA.Columns[COL_PRODUCTOS].Width = 150;
            dgvVSA.Columns[COL_PRODUCTOS].ReadOnly = true;

            // Formatear columnas de años
            for (int i = 1; i < dgvVSA.Columns.Count; i++)
            {
                dgvVSA.Columns[i].Width = 80;
                dgvVSA.Columns[i].ReadOnly = false;
                dgvVSA.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVSA.Columns[i].DefaultCellStyle.Format = "F2";
            }

            dgvVSA.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnActualizarVSA_Click(object sender, EventArgs e)
        {
            SincronizarProductosVSA();
            dgvVSA.Refresh();
        }

        private void btnLimpiarVSA_Click(object sender, EventArgs e)
        {
            ConfigurarTablaVSA();
            SincronizarProductosVSA();
        }

        private void btnAnios_Click(object sender, EventArgs e)
        {
            ActualizarColumnasVSA();
        }

        private void btnActualizarResultado_Click(object sender, EventArgs e)
        {
            SincronizarProductosResultados();
            dgvResultados.Refresh();
        }
        /// <summary>
        /// Tabla Resultados
        /// </summary>
        private void ConfigurarTablaResultados()
        {
            dtResultados = new DataTable();
            dtResultados.Columns.Add(COL_PRODUCTOS, typeof(string));
            dtResultados.Columns.Add(COL_PARTICIPACION, typeof(decimal));
            dtResultados.Columns.Add(COL_TASA_CRECIMIENTO, typeof(decimal));
            dtResultados.Columns.Add(COL_CUADRANTE, typeof(string));

            dgvResultados.DataSource = dtResultados;
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.ReadOnly = true;

            SincronizarProductosResultados();
            FormatearTablaResultados();
        }
        private void SincronizarProductosResultados()
        {
            dtResultados.Rows.Clear();
            for (int i = 0; i < dtPrevision.Rows.Count - 1; i++)
            {
                DataRow nuevaFila = dtResultados.NewRow();
                nuevaFila[COL_PRODUCTOS] = dtPrevision.Rows[i][COL_PRODUCTOS];
                nuevaFila[COL_PARTICIPACION] = 0.00m;
                nuevaFila[COL_TASA_CRECIMIENTO] = 0.00m;
                nuevaFila[COL_CUADRANTE] = "";
                dtResultados.Rows.Add(nuevaFila);
            }
            CalcularResultados();
        }
        private void CalcularResultados()
        {
            for (int i = 0; i < dtResultados.Rows.Count; i++)
            {
                // Calcular Participación de Mercado
                decimal participacion = CalcularParticipacionMercado(i);
                dtResultados.Rows[i][COL_PARTICIPACION] = participacion;

                // Calcular Tasa de Crecimiento usando CAGR
                decimal tasaCrecimiento = CalcularTasaCrecimiento(i);
                dtResultados.Rows[i][COL_TASA_CRECIMIENTO] = tasaCrecimiento;

                // Determinar Cuadrante
                string cuadrante = DeterminarCuadrante(tasaCrecimiento, participacion);
                dtResultados.Rows[i][COL_CUADRANTE] = cuadrante;
            }
        }

        private decimal CalcularParticipacionMercado(int indiceProducto)
        {
            if (indiceProducto >= dtPrevision.Rows.Count - 1 || indiceProducto >= dtVLC.Rows.Count)
                return 0;

            decimal ventasProducto = Convert.ToDecimal(dtPrevision.Rows[indiceProducto][COL_VENTAS]);
            decimal ventasLider = Convert.ToDecimal(dtVLC.Rows[indiceProducto][COL_LIDER]);

            if (ventasLider == 0) return 0;

            return ventasProducto / ventasLider;
        }

        private decimal CalcularTasaCrecimiento(int indiceProducto)
        {
            if (indiceProducto >= dtVSA.Rows.Count || dtVSA.Columns.Count <= 2)
                return 0;

            // Obtener valores del primer y último año
            decimal ventaInicial = Convert.ToDecimal(dtVSA.Rows[indiceProducto][1]); // Primera columna de año
            decimal ventaFinal = Convert.ToDecimal(dtVSA.Rows[indiceProducto][dtVSA.Columns.Count - 1]); // Última columna

            if (ventaInicial <= 0) return 0;

            int numAnios = dtVSA.Columns.Count - 1; // Restar columna Productos
            if (numAnios <= 1) return 0;

            // Fórmula CAGR: ((Valor Final / Valor Inicial) ^ (1/n)) - 1
            double cagr = Math.Pow((double)(ventaFinal / ventaInicial), 1.0 / (numAnios - 1)) - 1;
            return (decimal)(cagr * 100); // Convertir a porcentaje
        }

        private string DeterminarCuadrante(decimal tasaCrecimiento, decimal participacion)
        {
            if (tasaCrecimiento >= 10 && participacion >= 1)
                return "Estrella";
            else if (tasaCrecimiento >= 10 && participacion < 1)
                return "Interrogante";
            else if (tasaCrecimiento < 10 && participacion >= 1)
                return "Vaca";
            else
                return "Perro";
        }
        private void FormatearTablaResultados()
        {
            dgvResultados.Columns[COL_PRODUCTOS].Width = 150;
            dgvResultados.Columns[COL_PARTICIPACION].Width = 150;
            dgvResultados.Columns[COL_PARTICIPACION].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResultados.Columns[COL_PARTICIPACION].DefaultCellStyle.Format = "F4";

            dgvResultados.Columns[COL_TASA_CRECIMIENTO].Width = 180;
            dgvResultados.Columns[COL_TASA_CRECIMIENTO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResultados.Columns[COL_TASA_CRECIMIENTO].DefaultCellStyle.Format = "F2";

            dgvResultados.Columns[COL_CUADRANTE].Width = 120;
            dgvResultados.Columns[COL_CUADRANTE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvResultados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVLC_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            SincronizarProductosResultados();
        }

        private void dgvPrevision_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            SincronizarProductosResultados();
        }

        /* CHART CONFIGURACION */
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
            // Usaremos valores transformados internamente pero etiquetas reales
            chartArea.AxisX.Minimum = -2;     // Equivale a log10(0.01) = -2
            chartArea.AxisX.Maximum = 2;      // Equivale a log10(100) = 2
            chartArea.AxisX.IsReversed = true; // Mantener orden invertido

            // Configurar intervalos
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineWidth = 1;

            // Configurar las etiquetas personalizadas para X
            chartArea.AxisX.CustomLabels.Clear();
            // Ahora usamos valores logarítmicos transformados
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
            lineaVertical.IntervalOffset = 0.0; // En X = 0 (equivale a participación = 1.000)
            lineaVertical.StripWidth = 0;
            lineaVertical.BorderColor = Color.Red;
            lineaVertical.BorderWidth = 3;
            lineaVertical.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.AxisX.StripLines.Add(lineaVertical);

            // Línea horizontal en Y = 10.0% (separar alto/bajo crecimiento)
            StripLine lineaHorizontal = new StripLine();
            lineaHorizontal.Interval = 0;
            lineaHorizontal.IntervalOffset = 10.0; // En Y = 10%
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

            // Método auxiliar para transformar valores de participación a escala logarítmica
        }
        private double TransformarParticipacionALog(decimal participacion)
        {
            // Evitar valores <= 0 que causarían problemas con log10
            if (participacion <= 0)
                return -2; // Valor mínimo del eje

            // Transformar a escala logarítmica: log10(participacion)
            return Math.Log10((double)participacion);
        }


        private void GenerarMatrizBCG()
        {
            // Configurar el chart
            ConfigurarChartBCG();

            // Obtener cantidad de productos (sin incluir fila TOTAL)
            int cantidadProductos = dtResultados.Rows.Count;

            if (cantidadProductos == 0)
            {
                MessageBox.Show("No hay productos para mostrar en la matriz BCG.");
                return;
            }

            // Generar colores dinámicamente
            Color[] coloresProductos = GenerarColoresProductos(cantidadProductos);

            for (int i = 0; i < cantidadProductos; i++)
            {
                string nombreProducto = dtResultados.Rows[i][COL_PRODUCTOS].ToString();
                decimal participacion = Convert.ToDecimal(dtResultados.Rows[i][COL_PARTICIPACION]);
                decimal tasaCrecimiento = Convert.ToDecimal(dtResultados.Rows[i][COL_TASA_CRECIMIENTO]);

                // Obtener el porcentaje de ventas del producto para el tamaño de la burbuja
                string porcentajeVentas = "";
                if (i < dtPrevision.Rows.Count - 1) // Excluir fila TOTAL
                {
                    porcentajeVentas = dtPrevision.Rows[i][COL_PORCENTAJE].ToString();
                }

                // Crear serie para cada producto
                Series serie = new Series(nombreProducto);
                serie.ChartType = SeriesChartType.Bubble;
                serie.Color = coloresProductos[i];
                serie.MarkerStyle = MarkerStyle.Circle;

                // El tamaño de la burbuja será proporcional al porcentaje de ventas
                decimal porcentaje = 0;
                double tamanioBurbuja = 100; // Valor base más visible

                if (decimal.TryParse(porcentajeVentas.Replace("%", ""), out porcentaje))
                {
                    // Tamaño proporcional al porcentaje (mínimo 50, máximo 500)
                    tamanioBurbuja = Math.Max(50, Math.Min(500, (double)porcentaje * 10));
                }

                // TRANSFORMAR LA PARTICIPACIÓN A ESCALA LOGARÍTMICA
                double participacionLog = TransformarParticipacionALog(participacion);

                // Crear punto con valores transformados para gráfico de burbuja
                int puntoIndex = serie.Points.AddXY(participacionLog, (double)tasaCrecimiento);
                DataPoint punto = serie.Points[puntoIndex];

                // Configurar el tamaño de la burbuja (tercer valor)
                punto.YValues = new double[] { (double)tasaCrecimiento, tamanioBurbuja };

                // Configurar etiqueta del punto (opcional, puedes quitarla)
                punto.Label = $"{nombreProducto}";
                punto.LabelForeColor = Color.Black;
                punto.Font = new Font("Arial", 8, FontStyle.Bold);

                // Configurar tooltip con información detallada (mostrar valor real, no transformado)
                punto.ToolTip = $"Producto: {nombreProducto}\n" +
                               $"Participación: {participacion:F3}\n" +
                               $"Crecimiento: {tasaCrecimiento:F1}%\n" +
                               $"Ventas: {porcentajeVentas}\n" +
                               $"Cuadrante: {dtResultados.Rows[i][COL_CUADRANTE]}";

                chartBCG2.Series.Add(serie);
            }

            chartBCG2.Invalidate(); // Forzar redibujado
        }


        // Método para limpiar el gráfico
        private void LimpiarMatrizBCG()
        {
            if (chartBCG2 != null)
            {
                chartBCG2.Series.Clear();
                chartBCG2.Invalidate();
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            // Primero asegurar que los datos estén actualizados
            SincronizarProductosResultados();

            // Luego generar el gráfico
            GenerarMatrizBCG();

            MessageBox.Show("Matriz BCG generada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiarChart_Click(object sender, EventArgs e)
        {
            LimpiarMatrizBCG();
            MessageBox.Show("Matriz BCG limpiada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ActualizarNombresEnChart()
        {
            if (chartBCG2 != null && chartBCG2.Series.Count > 0)
            {
                // Solo actualizar si ya hay datos en el chart
                GenerarMatrizBCG();
            }
        }
    }
}
