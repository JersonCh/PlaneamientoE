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
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CalcularPorcentajes();
            dgvPrevision.Refresh();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            dtPrevision.Clear();
            AgregarProductosIniciales();
            AgregarFilaTotal();
            CalcularPorcentajes();
            SincronizarProductos();
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
            // Crear el DataTable
            dtVLC = new DataTable();

            // Agregar columna de productos
            dtVLC.Columns.Add(COL_PRODUCTOS, typeof(string));

            // Agregar primera columna de competidor
            dtVLC.Columns.Add($"{COMPETIDOR_BASE}{contadorCompetidores}", typeof(decimal));

            // Agregar columna de líder
            dtVLC.Columns.Add(COL_LIDER, typeof(decimal));

            // Asignar el DataTable al DataGridView
            dgvVLC.DataSource = dtVLC;

            // Configurar propiedades del DataGridView
            dgvVLC.AllowUserToAddRows = false;
            dgvVLC.AllowUserToDeleteRows = false;

            // Configurar eventos
            dgvVLC.CellEndEdit += DgvVLC_CellEndEdit;

            // Sincronizar productos iniciales
            SincronizarProductos();

            // Formatear tabla
            FormatearTablaVLC();
        }
        private void FormatearTablaVLC()
        {
            // Formatear columnas
            dgvVLC.Columns[COL_PRODUCTOS].Width = 150;
            dgvVLC.Columns[COL_PRODUCTOS].ReadOnly = true;

            // Formatear columna de líder
            int colLider = dgvVLC.Columns.Count - 1;
            dgvVLC.Columns[colLider].Width = 120;
            dgvVLC.Columns[colLider].ReadOnly = true;
            dgvVLC.Columns[colLider].DefaultCellStyle.BackColor = Color.LightGray;
            dgvVLC.Columns[colLider].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVLC.Columns[colLider].DefaultCellStyle.Format = "F2"; // Formato con 2 decimales

            // Formatear columnas de competidores
            for (int i = 1; i < colLider; i++)
            {
                dgvVLC.Columns[i].Width = 100;
                dgvVLC.Columns[i].ReadOnly = false;
                dgvVLC.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVLC.Columns[i].DefaultCellStyle.Format = "F2"; // Formato con 2 decimales
            }

            // Ajustar el ancho de las columnas al contenido
            dgvVLC.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void SincronizarProductos()
        {
            // Limpiamos la tabla VLC manteniendo sus columnas
            dtVLC.Rows.Clear();

            // Recorremos los productos de la tabla de previsión (excluyendo la fila TOTAL)
            for (int i = 0; i < dtPrevision.Rows.Count - 1; i++)
            {
                DataRow nuevaFila = dtVLC.NewRow();
                nuevaFila[COL_PRODUCTOS] = dtPrevision.Rows[i][COL_PRODUCTOS];

                // Inicializamos los valores en cero para competidores
                for (int j = 1; j < dtVLC.Columns.Count - 1; j++)
                {
                    nuevaFila[j] = 0.00m;
                }

                // Inicializamos el líder en cero
                nuevaFila[COL_LIDER] = 0.00m;

                dtVLC.Rows.Add(nuevaFila);
            }

            // Actualizar los valores de líder
            ActualizarLideresCompetidores();
        }
        private void ActualizarLideresCompetidores()
        {
            // Para cada fila (producto)
            for (int i = 0; i < dtVLC.Rows.Count; i++)
            {
                decimal maximo = 0;

                // Buscar el valor máximo entre todos los competidores
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

                // Asignar el valor máximo a la columna de líder
                dtVLC.Rows[i][COL_LIDER] = maximo;
            }
        }
        private void DtPrevision_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            // Si no es la fila TOTAL y se ha modificado un nombre de producto
            if (e.Action == DataRowAction.Change && e.Row[COL_PRODUCTOS].ToString() != FILA_TOTAL)
            {
                // Actualizar el nombre del producto en la tabla VLC
                int index = dtPrevision.Rows.IndexOf(e.Row);
                if (index < dtVLC.Rows.Count)
                {
                    dtVLC.Rows[index][COL_PRODUCTOS] = e.Row[COL_PRODUCTOS];
                }
            }
        }
        private void DtPrevision_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            // Asegurarnos de que no estamos reaccionando a la fila TOTAL
            if (e.Row[COL_PRODUCTOS].ToString() != FILA_TOTAL)
            {
                SincronizarProductos();
            }
        }
        private void DgvVLC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Si es una columna de competidor (no es la columna de productos ni la de líder)
            if (e.ColumnIndex > 0 && e.ColumnIndex < dgvVLC.Columns.Count - 1)
            {
                ActualizarLideresCompetidores();
            }
        }

        private void btnAgregarCompetidor_Click(object sender, EventArgs e)
        {
            // Incrementar el contador de competidores
            contadorCompetidores++;

            // Agregar nueva columna de competidor (antes de la columna de líder)
            int posicionColumna = dtVLC.Columns.Count - 1;
            dtVLC.Columns.Add($"{COMPETIDOR_BASE}{contadorCompetidores}", typeof(decimal)).SetOrdinal(posicionColumna);

            // Inicializar los valores de la nueva columna en cero
            foreach (DataRow fila in dtVLC.Rows)
            {
                fila[posicionColumna] = 0.00m;
            }

            // Formatear la nueva columna
            dgvVLC.Columns[posicionColumna].Width = 100;
            dgvVLC.Columns[posicionColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVLC.Columns[posicionColumna].DefaultCellStyle.Format = "F2";

            // Actualizar los líderes por si acaso
            ActualizarLideresCompetidores();
        }

        private void btnActualizarCompetidor_Click(object sender, EventArgs e)
        {
            // Actualizar los líderes de competidores
            ActualizarLideresCompetidores();

            // Refrescar la tabla
            dgvVLC.Refresh();
        }

        private void btnLimpiarCompetidor_Click(object sender, EventArgs e)
        {
            // Reiniciar contador de competidores
            contadorCompetidores = 1;

            // Limpiar todas las columnas excepto la primera (productos) y crear una nueva de competidor
            while (dtVLC.Columns.Count > 1)
            {
                dtVLC.Columns.RemoveAt(1);
            }

            // Añadir columna de competidor
            dtVLC.Columns.Add($"{COMPETIDOR_BASE}{contadorCompetidores}", typeof(decimal));

            // Añadir columna de líder
            dtVLC.Columns.Add(COL_LIDER, typeof(decimal));

            // Inicializar los valores en cero
            foreach (DataRow fila in dtVLC.Rows)
            {
                fila[1] = 0.00m;
                fila[2] = 0.00m;
            }

            // Formatear la tabla
            FormatearTablaVLC();
        }
        public DataTable ObtenerDatosVLC()
        {
            return dtVLC.Copy();
        }
    }
}
