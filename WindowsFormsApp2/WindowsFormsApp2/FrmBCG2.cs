using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            txtAnioInicio.KeyPress += txtAnio_KeyPress;
            txtAnioFin.KeyPress += txtAnio_KeyPress;
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

        private void ConfigurarColumnasTCM()
        {
            dgvTCM.AllowUserToAddRows = false;
            dgvTCM.Columns.Clear();

            // Columnas fijas de periodo
            dgvTCM.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AñoInicio",
                HeaderText = "Periodo Inicio"
            });

            dgvTCM.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AñoFin",
                HeaderText = "Periodo Fin"
            });

            // Columnas productos desde dgvPrevision
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                {
                    string producto = row.Cells[0].Value?.ToString();
                    var col = new DataGridViewTextBoxColumn()
                    {
                        Name = producto,
                        HeaderText = producto,
                        DefaultCellStyle = { Format = "P2" }
                    };
                    dgvTCM.Columns.Add(col);
                }
            }
        }

        private void ConfigurarTablaTCM()
        {
            dgvTCM.Rows.Clear();
            ConfigurarColumnasTCM();

            // Agregar solo los periodos iniciales (una fila 2024-2025)
            string[,] periodos = { { "2024", "2025" } };

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

        private void ConfigurarTablaEvolucionDemanda()
        {
            dgvEvolucionDemanda.AllowUserToAddRows = false;
            dgvEvolucionDemanda.Columns.Clear();

            // Columna de años
            dgvEvolucionDemanda.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Anio",
                HeaderText = "Año",
                ReadOnly = true
            });

            // Añadir columnas de productos desde dgvPrevision
            ActualizarColumnasEvolucionDemanda();

            // Configurar validación de entrada
            dgvEvolucionDemanda.EditingControlShowing += dgvEvolucionDemanda_EditingControlShowing;
            dgvEvolucionDemanda.CellValueChanged += dgvEvolucionDemanda_CellValueChanged;
        }

        private void ActualizarColumnasEvolucionDemanda()
        {
            // Preservar los datos existentes si los hay
            var datosExistentes = new Dictionary<string, Dictionary<string, object>>();
            if (dgvEvolucionDemanda.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvEvolucionDemanda.Rows)
                {
                    string anio = row.Cells["Anio"].Value?.ToString();
                    if (!string.IsNullOrEmpty(anio))
                    {
                        datosExistentes[anio] = new Dictionary<string, object>();
                        for (int i = 1; i < dgvEvolucionDemanda.Columns.Count; i++)
                        {
                            string columnName = dgvEvolucionDemanda.Columns[i].Name;
                            datosExistentes[anio][columnName] = row.Cells[i].Value;
                        }
                    }
                }
            }

            // Mantener primera columna (Año) y reorganizar las demás
            string primeraColumna = dgvEvolucionDemanda.Columns.Count > 0 ?
                                    dgvEvolucionDemanda.Columns[0].Name : "Anio";

            dgvEvolucionDemanda.Columns.Clear();
            dgvEvolucionDemanda.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = primeraColumna,
                HeaderText = "Año",
                ReadOnly = true
            });

            // Añadir columnas de productos desde dgvPrevision
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                {
                    string producto = row.Cells[0].Value?.ToString();
                    dgvEvolucionDemanda.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = producto,
                        HeaderText = producto,
                        DefaultCellStyle = { Format = "N2" } // Formato con 2 decimales
                    });
                }
            }

            // Rellenar filas con años de la tabla TCM
            ActualizarFilasEvolucionDemanda(datosExistentes);
        }

        private void ActualizarFilasEvolucionDemanda(Dictionary<string, Dictionary<string, object>> datosExistentes = null)
        {
            // Limpiar filas
            dgvEvolucionDemanda.Rows.Clear();

            // Si no hay periodos en la tabla TCM, no hay nada que hacer
            if (dgvTCM.Rows.Count == 0)
                return;

            // Obtener lista de años únicos desde la tabla TCM
            var anios = new HashSet<string>();
            foreach (DataGridViewRow row in dgvTCM.Rows)
            {
                anios.Add(row.Cells[0].Value?.ToString());
                anios.Add(row.Cells[1].Value?.ToString());
            }

            // Ordenar años y añadirlos a la tabla
            var aniosOrdenados = anios.Where(a => !string.IsNullOrEmpty(a))
                                       .Select(int.Parse)
                                       .OrderBy(a => a)
                                       .Select(a => a.ToString())
                                       .ToList();

            foreach (string anio in aniosOrdenados)
            {
                var rowIndex = dgvEvolucionDemanda.Rows.Add();
                dgvEvolucionDemanda.Rows[rowIndex].Cells["Anio"].Value = anio;

                // Restaurar datos si existen
                if (datosExistentes != null && datosExistentes.ContainsKey(anio))
                {
                    for (int i = 1; i < dgvEvolucionDemanda.Columns.Count; i++)
                    {
                        string columnName = dgvEvolucionDemanda.Columns[i].Name;
                        if (datosExistentes[anio].ContainsKey(columnName))
                        {
                            dgvEvolucionDemanda.Rows[rowIndex].Cells[i].Value = datosExistentes[anio][columnName];
                        }
                    }
                }
            }
        }

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
            ActualizarColumnasEvolucionDemanda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvPrevision.Rows.Clear(); // Elimina todas las filas
            AgregarFilaTotal(); // Vuelve a agregar la fila TOTAL
            ActualizarColumnasEvolucionDemanda();
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
            // Validar entrada numérica
            if (!int.TryParse(txtAnioInicio.Text, out int anioInicio) ||
                !int.TryParse(txtAnioFin.Text, out int anioFin))
            {
                MessageBox.Show("Ambos campos deben ser años numéricos.");
                return;
            }

            // Validar rango
            if (anioInicio < 1800 || anioInicio > 3000 || anioFin < 1800 || anioFin > 3000)
            {
                MessageBox.Show("Año fuera del rango de 1800 - 3000");
                return;
            }

            if (anioInicio >= anioFin)
            {
                MessageBox.Show("El año inicial debe ser menor al año final.");
                return;
            }

            // Limpiar solo filas, no columnas
            dgvTCM.Rows.Clear();

            // Generar nuevos periodos ordenados
            for (int anio = anioInicio; anio < anioFin; anio++)
            {
                object[] fila = new object[dgvTCM.Columns.Count];
                fila[0] = anio.ToString();
                fila[1] = (anio + 1).ToString();
                for (int j = 2; j < fila.Length; j++)
                    fila[j] = "0.00%";
                dgvTCM.Rows.Add(fila);
            }
            ActualizarFilasEvolucionDemanda();
        }

        private void btnLimpiarTCM_Click(object sender, EventArgs e)
        {
            dgvTCM.Rows.Clear();
            ActualizarColumnasEvolucionDemanda();
        }

        private void btnActualizarTCM_Click(object sender, EventArgs e)
        {
            // Guardar datos existentes de filas
            var filasDatos = new System.Collections.Generic.List<object[]>();

            foreach (DataGridViewRow row in dgvTCM.Rows)
            {
                if (!row.IsNewRow)
                {
                    object[] fila = new object[dgvTCM.Columns.Count];
                    for (int i = 0; i < dgvTCM.Columns.Count; i++)
                        fila[i] = row.Cells[i].Value;
                    filasDatos.Add(fila);
                }
            }

            // Actualizar columnas (productos)
            ConfigurarColumnasTCM();

            // Reestablecer filas guardadas en la tabla
            foreach (var fila in filasDatos)
            {
                // Ajustar tamaño del array si columnas cambiaron
                if (fila.Length < dgvTCM.Columns.Count)
                {
                    var nuevoFila = new object[dgvTCM.Columns.Count];
                    Array.Copy(fila, nuevoFila, fila.Length);
                    for (int i = fila.Length; i < nuevoFila.Length; i++)
                        nuevoFila[i] = "0.00%";  // valores nuevos inicializados
                    dgvTCM.Rows.Add(nuevoFila);
                }
                else
                {
                    dgvTCM.Rows.Add(fila);
                }
            }
            ActualizarFilasEvolucionDemanda();
        }
        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvEvolucionDemanda_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvEvolucionDemanda.CurrentCell.ColumnIndex > 0)
            {
                e.Control.KeyPress -= SoloNumerosDecimales_KeyPress;
                e.Control.KeyPress += SoloNumerosDecimales_KeyPress;
            }
        }
        private void SoloNumerosDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void dgvEvolucionDemanda_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Formatear valores ingresados con dos decimales
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                var celda = dgvEvolucionDemanda.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Si es texto, convertir a decimal
                if (celda.Value is string valorString)
                {
                    if (decimal.TryParse(valorString, out decimal valor))
                    {
                        celda.Value = valor;
                    }
                }
            }
        }

        private void btnLimpiarDemanda_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEvolucionDemanda.Rows)
            {
                for (int i = 1; i < dgvEvolucionDemanda.Columns.Count; i++)
                {
                    row.Cells[i].Value = null;
                }
            }
        }

        private void btnActualizarDemanda_Click(object sender, EventArgs e)
        {
            ActualizarColumnasEvolucionDemanda();
        }
    }
}
