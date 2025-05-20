using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmBCG2 : Form
    {
        public FrmBCG2()
        {
            InitializeComponent();
            ConfigurarTablaPrevision();
            ConfigurarTablaTCM();
        }

        #region Configuración inicial

        private void ConfigurarTablaPrevision()
        {
            dgvPrevision.ColumnCount = 3;
            dgvPrevision.Columns[0].Name = "Producto";
            dgvPrevision.Columns[1].Name = "Ventas";
            dgvPrevision.Columns[2].Name = "% S/ Total";

            dgvPrevision.Columns[1].ValueType = typeof(int);
            dgvPrevision.Columns[2].ReadOnly = true;
            dgvPrevision.Columns[2].DefaultCellStyle.Format = "P2";

            dgvPrevision.AllowUserToAddRows = false;
            dgvPrevision.CellValueChanged += dgvPrevision_CellValueChanged;
            dgvPrevision.EditingControlShowing += dgvPrevision_EditingControlShowing;

            AgregarFilaTotal();
        }

        private void ConfigurarTablaTCM()
        {
            dgvTCM.Columns.Clear();
            dgvTCM.Rows.Clear();

            dgvTCM.AllowUserToAddRows = false;

            // Crear columnas de Periodos (año inicial y final)
            DataGridViewTextBoxColumn colPeriodoInicio = new DataGridViewTextBoxColumn();
            colPeriodoInicio.Name = "AñoInicio";
            colPeriodoInicio.HeaderText = "Periodo Inicio";

            DataGridViewTextBoxColumn colPeriodoFin = new DataGridViewTextBoxColumn();
            colPeriodoFin.Name = "AñoFin";
            colPeriodoFin.HeaderText = "Periodo Fin";

            dgvTCM.Columns.Add(colPeriodoInicio);
            dgvTCM.Columns.Add(colPeriodoFin);

            // Agregar columnas de productos desde la primera tabla
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                {
                    string producto = row.Cells[0].Value?.ToString();
                    var col = new DataGridViewTextBoxColumn();
                    col.Name = producto;
                    col.HeaderText = producto;
                    col.DefaultCellStyle.Format = "P2";
                    dgvTCM.Columns.Add(col);
                }
            }

            // Agregar periodos por defecto
            string[,] periodos = { { "2020", "2021" }, { "2021", "2022" }, { "2022", "2023" }, { "2023", "2024" }, { "2024", "2025" } };
            for (int i = 0; i < periodos.GetLength(0); i++)
            {
                object[] fila = new object[dgvTCM.Columns.Count];
                fila[0] = periodos[i, 0];
                fila[1] = periodos[i, 1];
                for (int j = 2; j < fila.Length; j++)
                    fila[j] = "0.00%";
                dgvTCM.Rows.Add(fila);
            }

            dgvTCM.CellValueChanged += dgvTCM_CellValueChanged;
            dgvTCM.EditingControlShowing += dgvTCM_EditingControlShowing;
        }


        #endregion

        #region Botón Agregar Producto

        #endregion

        #region Cálculos

        private void RecalcularTotales()
        {
            int totalVentas = 0;
            for (int i = 0; i < dgvPrevision.Rows.Count - 1; i++)
            {
                int ventas = 0;
                int.TryParse(dgvPrevision.Rows[i].Cells[1].Value?.ToString(), out ventas);
                totalVentas += ventas;
            }

            for (int i = 0; i < dgvPrevision.Rows.Count - 1; i++)
            {
                int ventas = 0;
                int.TryParse(dgvPrevision.Rows[i].Cells[1].Value?.ToString(), out ventas);
                double porcentaje = totalVentas == 0 ? 0 : (double)ventas / totalVentas;
                dgvPrevision.Rows[i].Cells[2].Value = porcentaje.ToString("P2");
            }

            int totalIndex = dgvPrevision.Rows.Count - 1;
            dgvPrevision.Rows[totalIndex].Cells[1].Value = totalVentas;
            dgvPrevision.Rows[totalIndex].Cells[2].Value = "100.00%";
        }

        #endregion

        #region Validación de entrada numérica

        private void dgvPrevision_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvPrevision.CurrentCell.ColumnIndex == 1)
            {
                e.Control.KeyPress -= SoloNumeros_KeyPress;
                e.Control.KeyPress += SoloNumeros_KeyPress;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        #endregion

        #region Eventos de tabla

        private void dgvPrevision_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && e.RowIndex < dgvPrevision.Rows.Count - 1)
            {
                RecalcularTotales();
            }
        }

        private void AgregarFilaTotal()
        {
            dgvPrevision.Rows.Add("TOTAL", 0, "100.00%");
            int totalIndex = dgvPrevision.Rows.Count - 1;
            dgvPrevision.Rows[totalIndex].ReadOnly = true;
            dgvPrevision.Rows[totalIndex].DefaultCellStyle.BackColor = Color.LightGray;
        }

        #endregion

        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            int indexTotal = dgvPrevision.Rows.Count - 1;
            dgvPrevision.Rows.Insert(indexTotal, $"Producto {indexTotal + 1}", 0, "0.00%");
            RecalcularTotales();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvPrevision.Rows.Clear(); // Elimina todas las filas
            AgregarFilaTotal(); // Vuelve a agregar la fila TOTAL
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RecalcularTotales();
        }

        private void dgvTCM_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvTCM.CurrentCell.ColumnIndex >= 2)
            {
                e.Control.KeyPress -= SoloNumeros_KeyPressTCM;
                e.Control.KeyPress += SoloNumeros_KeyPressTCM;
            }
        }
        private void SoloNumeros_KeyPressTCM(object sender, KeyPressEventArgs e)
        {
            // Permitir números, punto decimal y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void dgvTCM_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.RowIndex >= 0)
            {
                var celda = dgvTCM.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Si el valor es texto, intentar convertirlo
                if (celda.Value is string valorString)
                {
                    // Eliminar el símbolo de porcentaje si existe
                    valorString = valorString.Replace("%", "").Trim();

                    // Intentar convertir a número
                    if (double.TryParse(valorString, out double valorNumerico))
                    {
                        // Asignar valor como decimal para formato de porcentaje
                        celda.Value = valorNumerico / 100.0;
                    }
                }
            }
        }

        private void btnAgregarPeriodo_Click(object sender, EventArgs e)
        {
            object[] fila = new object[dgvTCM.Columns.Count];
            fila[0] = "";
            fila[1] = "";
            for (int j = 2; j < fila.Length; j++)
                fila[j] = "0.00%";
            dgvTCM.Rows.Add(fila);
        }

        private void btnLimpiarTCM_Click(object sender, EventArgs e)
        {
            dgvTCM.Rows.Clear();
        }

        private void btnActualizarTCM_Click(object sender, EventArgs e)
        {
            ConfigurarTablaTCM();
        }
    }
}
