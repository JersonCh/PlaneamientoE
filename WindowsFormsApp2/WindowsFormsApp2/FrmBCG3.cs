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
    public partial class FrmBCG3 : Form
    {
        private DataTable dtPrevision;
        private DataTable dtVLC;
        private int contadorCompetidores = 1;
        private DataTable dtVSA;
        private int anioInicio = 2024;
        private int anioFinal = 2025;

        private const string COL_PRODUCTOS = "PRODUCTOS";
        private const string COL_VENTAS = "VENTAS";
        private const string COL_PORCENTAJE = "% S/ TOTAL";
        private const string COL_LIDER = "Ventas líder competidor";
        private const string COMPETIDOR_BASE = "Competidor";
        private const string FILA_TOTAL = "TOTAL";
        public FrmBCG3()
        {
            InitializeComponent();
            ConfigurarTablaPrevision();
            ConfigurarTablaVLC();
            ConfigurarTablaVSA();
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
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CalcularPorcentajes();
            dgvPrevision.Refresh();
            SincronizarProductosVSA();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            dtPrevision.Clear();
            AgregarProductosIniciales();
            AgregarFilaTotal();
            CalcularPorcentajes();
            SincronizarProductos();
            SincronizarProductosVSA();
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
                if (index < dtVLC.Rows.Count)
                {
                    dtVLC.Rows[index][COL_PRODUCTOS] = e.Row[COL_PRODUCTOS];
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
    }
}
