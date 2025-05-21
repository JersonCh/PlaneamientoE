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
            dgvEvolucionDemanda.AllowUserToAddRows = false;
            dgvCompetidores.AllowUserToAddRows = false;

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
        private void ConfigurarTablaBCG()
        {
            try
            {
                // Limpiar tabla
                dgvBCG.Rows.Clear();
                dgvBCG.Columns.Clear();

                // Configurar que la tabla sea de solo lectura
                dgvBCG.ReadOnly = true;
                dgvBCG.AllowUserToAddRows = false;
                dgvBCG.AllowUserToDeleteRows = false;
                dgvBCG.AllowUserToResizeRows = false;

                // Agregar primera columna para etiquetas
                dgvBCG.Columns.Add("Metrica", "BCG");

                // Verificar que hay productos para añadir
                if (dgvPrevision.Rows.Count <= 1)
                {
                    return;
                }

                // Agregar columnas para cada producto desde dgvPrevision
                foreach (DataGridViewRow row in dgvPrevision.Rows)
                {
                    if (row.Cells[0].Value?.ToString() != "TOTAL")
                    {
                        string producto = row.Cells[0].Value?.ToString();
                        if (!string.IsNullOrEmpty(producto))
                        {
                            dgvBCG.Columns.Add(producto, producto);
                        }
                    }
                }

                // Verificar que se agregaron columnas
                if (dgvBCG.Columns.Count <= 1)
                {
                    MessageBox.Show("No se pudieron agregar productos a la matriz BCG.",
                        "Configuración BCG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar filas para TCM, PRM y % S/VTAS
                dgvBCG.Rows.Add("TCM");
                dgvBCG.Rows.Add("PRM");
                dgvBCG.Rows.Add("% S/VTAS");

                // Configurar formato de celdas
                foreach (DataGridViewRow row in dgvBCG.Rows)
                {
                    row.Cells[0].Style.BackColor = Color.LightGray;
                    row.Cells[0].Style.Font = new Font(dgvBCG.Font, FontStyle.Bold);

                    // Inicializar valores en 0 para todas las celdas
                    for (int i = 1; i < dgvBCG.Columns.Count; i++)
                    {
                        if (row.Index == 0 || row.Index == 2) // TCM y % S/VTAS como porcentaje
                        {
                            row.Cells[i].Value = 0.0;
                            row.Cells[i].Style.Format = "P2";
                        }
                        else // PRM como número
                        {
                            row.Cells[i].Value = 0.0;
                            row.Cells[i].Style.Format = "N2";
                        }
                    }
                }

                // Actualizar datos iniciales
                Console.WriteLine("Configuración de tabla BCG completada. Ejecutando ActualizarDatosBCG()");
                ActualizarDatosBCG();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar la matriz BCG: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarDatosBCG()
        {
            // Si la tabla no tiene columnas o filas configuradas correctamente, salir
            if (dgvBCG.Columns.Count <= 1 || dgvBCG.Rows.Count < 3)
            {
                MessageBox.Show("La tabla BCG no está configurada correctamente. Verifique que tenga productos añadidos.");
                return;
            }

            // Verificar si hay datos para procesar
            if (dgvPrevision.Rows.Count <= 1)
            {
                MessageBox.Show("No hay productos definidos en la tabla de previsión.");
                return;
            }

            // --- 1. Obtener % S/VTAS desde dgvPrevision ---
            for (int col = 1; col < dgvBCG.Columns.Count; col++)
            {
                string producto = dgvBCG.Columns[col].Name;
                bool encontrado = false;

                // Buscar el producto en dgvPrevision
                foreach (DataGridViewRow row in dgvPrevision.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == producto)
                    {
                        // Fila % S/VTAS (índice 2)
                        double porcentaje = 0;
                        var cellValue = row.Cells[2].Value;

                        if (cellValue != null)
                        {
                            if (cellValue is double)
                                porcentaje = (double)cellValue;
                            else
                                double.TryParse(cellValue.ToString().Replace("%", ""), out porcentaje);
                        }

                        dgvBCG.Rows[2].Cells[col].Value = porcentaje / 100.0; // Formato directo como decimal para %
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine($"Producto '{producto}' no encontrado en tabla de previsión");
                }
            }

            // --- 2. Obtener TCM desde dgvTCM ---
            if (dgvTCM.Rows.Count > 0)
            {
                for (int col = 1; col < dgvBCG.Columns.Count; col++)
                {
                    string producto = dgvBCG.Columns[col].Name;
                    bool encontrado = false;

                    // Buscar la columna correspondiente en dgvTCM
                    for (int i = 2; i < dgvTCM.Columns.Count; i++)
                    {
                        // Verificar coincidencia por Name o HeaderText
                        if (dgvTCM.Columns[i].Name == producto || dgvTCM.Columns[i].HeaderText == producto)
                        {
                            if (dgvTCM.Rows.Count > 0)
                            {
                                // Tomar el valor de la primera fila
                                double tcm = 0;
                                var cellValue = dgvTCM.Rows[0].Cells[i].Value;

                                if (cellValue != null)
                                {
                                    if (cellValue is double)
                                        tcm = (double)cellValue;
                                    else
                                    {
                                        string strValue = cellValue.ToString().Replace("%", "");
                                        double.TryParse(strValue, out tcm);
                                        tcm /= 100.0; // Convertir a decimal si viene como porcentaje texto
                                    }
                                }

                                dgvBCG.Rows[0].Cells[col].Value = tcm; // Para formato porcentaje
                                encontrado = true;
                            }
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine($"TCM para producto '{producto}' no encontrado");
                        // Valor por defecto si no se encuentra
                        dgvBCG.Rows[0].Cells[col].Value = 0.0;
                    }
                }
            }

            // --- 3. Calcular PRM para cada producto (CORREGIDO) ---
            for (int col = 1; col < dgvBCG.Columns.Count; col++)
            {
                string producto = dgvBCG.Columns[col].Name;
                bool encontrado = false;

                // Buscar el producto en dgvCompetidores
                for (int i = 0; i < dgvCompetidores.Columns.Count; i += 2)
                {
                    if (i + 1 < dgvCompetidores.Columns.Count)
                    {
                        // Verificar que hay filas en la tabla de competidores
                        if (dgvCompetidores.Rows.Count < 3)
                            continue;

                        // Intentar obtener el nombre del producto de la primera fila (producto)
                        string productoCompetidor = null;
                        if (dgvCompetidores.Rows[0].Cells[i].Value != null)
                        {
                            productoCompetidor = dgvCompetidores.Rows[0].Cells[i].Value.ToString();
                        }

                        // Si coincide con el producto que buscamos
                        if (productoCompetidor == producto)
                        {
                            int columnVentas = i + 1; // Columna de ventas
                            double ventasEmpresa = 0;
                            double ventasMayor = 0;
                            int filaMayor = -1;

                            // Encontrar la fila "Mayor" (normalmente la última)
                            for (int r = 0; r < dgvCompetidores.Rows.Count; r++)
                            {
                                if (dgvCompetidores.Rows[r].Cells[i].Value?.ToString() == "Mayor")
                                {
                                    filaMayor = r;
                                    break;
                                }
                            }

                            // Obtener ventas de la empresa (primera fila)
                            if (dgvCompetidores.Rows[0].Cells[columnVentas].Value != null)
                            {
                                double.TryParse(dgvCompetidores.Rows[0].Cells[columnVentas].Value.ToString(), out ventasEmpresa);
                            }

                            // Obtener ventas del competidor mayor
                            if (filaMayor >= 0 && dgvCompetidores.Rows[filaMayor].Cells[columnVentas].Value != null)
                            {
                                double.TryParse(dgvCompetidores.Rows[filaMayor].Cells[columnVentas].Value.ToString(), out ventasMayor);
                            }

                            // Calcular PRM como ventas empresa / ventas mayor competidor
                            double prm = (ventasMayor == 0) ? 1.0 : (ventasEmpresa / ventasMayor);

                            // Asignar el valor PRM a la tabla BCG
                            dgvBCG.Rows[1].Cells[col].Value = prm;
                            encontrado = true;
                            break;
                        }
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine($"Competidores para producto '{producto}' no encontrados");
                    // Asignar valor por defecto
                    dgvBCG.Rows[1].Cells[col].Value = 0.0;
                }
            }

            // --- 4. Aplicar formato a las celdas ---
            foreach (DataGridViewRow row in dgvBCG.Rows)
            {
                for (int i = 1; i < dgvBCG.Columns.Count; i++)
                {
                    if (row.Index == 0 || row.Index == 2) // TCM y % S/VTAS como porcentaje
                    {
                        dgvBCG.Rows[row.Index].Cells[i].Style.Format = "P2";
                    }
                    else // PRM como número
                    {
                        dgvBCG.Rows[row.Index].Cells[i].Style.Format = "N2";
                    }
                }
            }

            // Log de depuración para verificar que se ejecutó completamente
            Console.WriteLine("ActualizarDatosBCG completado");
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

            // Actualizar las ventas de empresa en la tabla de competidores
            ActualizarVentasEmpresa();
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

            // Configurar validación de entrada
            dgvEvolucionDemanda.EditingControlShowing += dgvEvolucionDemanda_EditingControlShowing;
            dgvEvolucionDemanda.CellValueChanged += dgvEvolucionDemanda_CellValueChanged;

            // IMPORTANTE: Solo actualizar filas DESPUÉS de configurar columnas
            ActualizarFilasEvolucionDemanda();
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
            // VERIFICACIÓN: Si no hay columnas, configurarlas primero
            if (dgvEvolucionDemanda.Columns.Count == 0)
            {
                ActualizarColumnasEvolucionDemanda();
                return; // Salir para evitar recursión
            }

            // Limpiar filas
            dgvEvolucionDemanda.Rows.Clear();

            // Si no hay periodos en la tabla TCM, no hay nada que hacer
            if (dgvTCM.Rows.Count == 0)
                return;

            // Obtener lista de años únicos desde la tabla TCM
            var anios = new HashSet<string>();
            foreach (DataGridViewRow row in dgvTCM.Rows)
            {
                if (row.Cells[0].Value != null)
                    anios.Add(row.Cells[0].Value.ToString());
                if (row.Cells[1].Value != null)
                    anios.Add(row.Cells[1].Value.ToString());
            }

            // Ordenar años y añadirlos a la tabla
            var aniosOrdenados = anios.Where(a => !string.IsNullOrEmpty(a))
                                       .Select(int.Parse)
                                       .OrderBy(a => a)
                                       .Select(a => a.ToString())
                                       .ToList();

            foreach (string anio in aniosOrdenados)
            {
                // VERIFICACIÓN: Asegurarse de que hay columnas antes de agregar filas
                if (dgvEvolucionDemanda.Columns.Count > 0)
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

            // Actualizar TCM con el nuevo producto
            btnActualizarTCM_Click(sender, e);

            // Esto ya lo tienes para la tabla de evolución
            ActualizarColumnasEvolucionDemanda();
            ActualizarTablaCompetidores();
            ConfigurarTablaBCG();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvPrevision.Rows.Clear(); // Elimina todas las filas
            AgregarFilaTotal(); // Vuelve a agregar la fila TOTAL

            // Actualizar TCM después de limpiar
            btnActualizarTCM_Click(sender, e);

            ActualizarColumnasEvolucionDemanda();
            ActualizarTablaCompetidores();
            ConfigurarTablaBCG();
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

            // VERIFICACIÓN: Asegurarse de que hay columnas antes de agregar filas
            if (dgvTCM.Columns.Count > 0)
            {
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
                    else if (dgvTCM.Columns.Count > 0) // Verificación adicional
                    {
                        dgvTCM.Rows.Add(fila);
                    }
                }
            }

            // Si no hay filas después de configurar columnas y hay al menos dos columnas (para años)
            if (dgvTCM.Rows.Count == 0 && dgvTCM.Columns.Count >= 2)
            {
                // Agregar al menos una fila con años por defecto
                object[] nuevaFila = new object[dgvTCM.Columns.Count];
                nuevaFila[0] = "2024"; // Año por defecto inicio
                nuevaFila[1] = "2025"; // Año por defecto fin
                for (int i = 2; i < nuevaFila.Length; i++)
                    nuevaFila[i] = "0.00%";
                dgvTCM.Rows.Add(nuevaFila);
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
        private void ConfigurarTablaCompetidores()
        {
            // Limpiar tabla existente
            dgvCompetidores.Rows.Clear();
            dgvCompetidores.Columns.Clear();

            // Obtener lista de productos (excepto TOTAL)
            var productos = new List<string>();
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                {
                    string producto = row.Cells[0].Value?.ToString();
                    if (!string.IsNullOrEmpty(producto))
                        productos.Add(producto);
                }
            }

            // Si no hay productos, salir
            if (productos.Count == 0)
                return;

            // Configurar columnas para cada producto
            foreach (string producto in productos)
            {
                // Crear columna para el competidor
                DataGridViewTextBoxColumn colCompetidor = new DataGridViewTextBoxColumn
                {
                    Name = $"Competidor_{producto}",
                    HeaderText = "Competidor"
                };
                dgvCompetidores.Columns.Add(colCompetidor);

                // Crear columna para las ventas
                DataGridViewTextBoxColumn colVentas = new DataGridViewTextBoxColumn
                {
                    Name = $"Ventas_{producto}",
                    HeaderText = "Ventas"
                };
                dgvCompetidores.Columns.Add(colVentas);
            }

            // Configurar evento para validación de entrada numérica
            dgvCompetidores.EditingControlShowing += dgvCompetidores_EditingControlShowing;
            dgvCompetidores.CellValueChanged += dgvCompetidores_CellValueChanged;

            // Agregar filas para EMPRESA y MAYOR
            AgregarFilasEspecialesCompetidores();
        }

        private void AgregarFilasEspecialesCompetidores()
        {
            // Agregar fila para la EMPRESA con los valores de ventas de dgvPrevision
            int rowEmpresa = dgvCompetidores.Rows.Add();

            // Para cada producto, agregar el valor de ventas desde dgvPrevision
            int colIndex = 0;
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                {
                    // Obtener el nombre del producto y usarlo en lugar de "EMPRESA"
                    string nombreProducto = row.Cells[0].Value?.ToString();
                    dgvCompetidores.Rows[rowEmpresa].Cells[colIndex].Value = nombreProducto;

                    // Obtener ventas del producto
                    int ventas = 0;
                    int.TryParse(row.Cells[1].Value?.ToString(), out ventas);
                    dgvCompetidores.Rows[rowEmpresa].Cells[colIndex + 1].Value = ventas;

                    colIndex += 2;
                }
            }

            // Aplicar formato a la fila EMPRESA
            dgvCompetidores.Rows[rowEmpresa].DefaultCellStyle.BackColor = Color.LightGray;
            dgvCompetidores.Rows[rowEmpresa].DefaultCellStyle.Font = new Font(dgvCompetidores.Font, FontStyle.Bold);

            // Agregar fila de encabezados de columnas
            int rowHeader = dgvCompetidores.Rows.Add();
            colIndex = 0;
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                {
                    dgvCompetidores.Rows[rowHeader].Cells[colIndex].Value = "Competidor";
                    dgvCompetidores.Rows[rowHeader].Cells[colIndex + 1].Value = "Ventas";
                    colIndex += 2;
                }
            }
            dgvCompetidores.Rows[rowHeader].DefaultCellStyle.BackColor = Color.LightBlue;
            dgvCompetidores.Rows[rowHeader].DefaultCellStyle.Font = new Font(dgvCompetidores.Font, FontStyle.Bold);
        }

        private void AgregarCompetidores(int numeroCompetidores)
        {
            // Verificar que hay productos
            if (dgvCompetidores.Columns.Count == 0)
                return;

            dgvCompetidores.EndEdit();
            try
            {
                while (dgvCompetidores.Rows.Count > 2)
                {
                    if (!dgvCompetidores.Rows[2].IsNewRow)
                        dgvCompetidores.Rows.RemoveAt(2);
                    else
                        break;
                }
            }
            catch (InvalidOperationException)
            {
                // Si hay un problema con la eliminación, reconfiguramos desde cero
                ConfigurarTablaCompetidores();
                AgregarFilasEspecialesCompetidores();
                return;
            }

            // Obtener lista de productos (excepto TOTAL)
            var productos = new List<string>();
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL")
                    productos.Add(row.Cells[0].Value?.ToString());
            }

            // Agregar filas de competidores
            for (int i = 1; i <= numeroCompetidores; i++)
            {
                int rowIndex = dgvCompetidores.Rows.Add();
                int colIndexCompetidor = 0; // Nombre cambiado para evitar conflicto

                foreach (string producto in productos)
                {
                    dgvCompetidores.Rows[rowIndex].Cells[colIndexCompetidor].Value = $"CP{productos.IndexOf(producto) + 1}-{i}";
                    dgvCompetidores.Rows[rowIndex].Cells[colIndexCompetidor + 1].Value = 0;
                    colIndexCompetidor += 2;
                }
            }

            // Agregar fila para MAYOR
            int rowMayor = dgvCompetidores.Rows.Add();
            int colIndex = 0;
            foreach (string producto in productos)
            {
                dgvCompetidores.Rows[rowMayor].Cells[colIndex].Value = "Mayor";
                dgvCompetidores.Rows[rowMayor].Cells[colIndex + 1].Value = 0;
                colIndex += 2;
            }

            // Aplicar formato a la fila MAYOR
            dgvCompetidores.Rows[rowMayor].DefaultCellStyle.BackColor = Color.LightGray;
            dgvCompetidores.Rows[rowMayor].DefaultCellStyle.Font = new Font(dgvCompetidores.Font, FontStyle.Bold);

            // Calcular valores máximos iniciales
            ActualizarValoresMayores();
        }

        private void ActualizarValoresMayores()
        {
            // Obtener índice de la fila MAYOR (última fila)
            int mayorRowIndex = -1;

            // Buscar la fila que contiene "Mayor"
            for (int i = 0; i < dgvCompetidores.Rows.Count; i++)
            {
                if (dgvCompetidores.Rows[i].Cells[0].Value?.ToString() == "Mayor")
                {
                    mayorRowIndex = i;
                    break;
                }
            }

            // Si no se encontró la fila "Mayor", salir
            if (mayorRowIndex == -1)
                return;

            // Para cada producto (cada par de columnas)
            for (int colIndex = 0; colIndex < dgvCompetidores.Columns.Count; colIndex += 2)
            {
                int ventasColIndex = colIndex + 1;
                int maxVentas = 0;

                // Buscar el valor máximo en todas las filas excepto la de EMPRESA (0), encabezados (1) y Mayor
                for (int rowIndex = 2; rowIndex < dgvCompetidores.Rows.Count; rowIndex++)
                {
                    // Saltar la fila Mayor
                    if (rowIndex == mayorRowIndex)
                        continue;

                    if (dgvCompetidores.Rows[rowIndex].Cells[ventasColIndex].Value != null)
                    {
                        int ventas = 0;
                        int.TryParse(dgvCompetidores.Rows[rowIndex].Cells[ventasColIndex].Value.ToString(), out ventas);
                        if (ventas > maxVentas)
                            maxVentas = ventas;
                    }
                }

                // Asignar el valor máximo a la celda correspondiente en la fila MAYOR
                dgvCompetidores.Rows[mayorRowIndex].Cells[ventasColIndex].Value = maxVentas;
            }
        }

        private void dgvCompetidores_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCompetidores.CurrentCell.ColumnIndex % 2 == 1) // Índices 1, 3, 5, ... son columnas de ventas
            {
                e.Control.KeyPress -= SoloNumeros_KeyPress;
                e.Control.KeyPress += SoloNumeros_KeyPress;
            }
        }

        private void dgvCompetidores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex % 2 == 1 && e.RowIndex >= 2 && e.RowIndex < dgvCompetidores.Rows.Count - 1)
            {
                ActualizarValoresMayores();
            }
        }

        private void btnAgregarCompetidores_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumeroCompetidores.Text, out int numeroCompetidores) || numeroCompetidores < 1)
            {
                MessageBox.Show("Por favor ingrese un número válido de competidores.");
                return;
            }

            // Agregar competidores
            AgregarCompetidores(numeroCompetidores);
        }
        private void ActualizarTablaCompetidores()
        {
            ConfigurarTablaCompetidores();

            // Si hay un número válido en txtNumeroCompetidores, agregar esa cantidad de competidores
            if (int.TryParse(txtNumeroCompetidores.Text, out int numeroCompetidores) && numeroCompetidores > 0)
            {
                AgregarCompetidores(numeroCompetidores);
            }
        }
        private void ActualizarVentasEmpresa()
        {
            // Verificar que hay filas en dgvCompetidores
            if (dgvCompetidores.Rows.Count == 0)
                return;

            // La primera fila es la de EMPRESA
            int rowEmpresa = 0;

            // Actualizar ventas de cada producto
            int colIndex = 0;
            foreach (DataGridViewRow row in dgvPrevision.Rows)
            {
                if (row.Cells[0].Value?.ToString() != "TOTAL" && colIndex / 2 < dgvCompetidores.Columns.Count / 2)
                {
                    // Obtener ventas del producto
                    int ventas = 0;
                    int.TryParse(row.Cells[1].Value?.ToString(), out ventas);

                    // Actualizar valor en la tabla de competidores
                    if (colIndex + 1 < dgvCompetidores.Columns.Count)
                        dgvCompetidores.Rows[rowEmpresa].Cells[colIndex + 1].Value = ventas;

                    colIndex += 2;
                }
            }
        }

        private void FrmBCG2_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizarBCG_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que tenemos datos para actualizar
                if (dgvPrevision.Rows.Count <= 1)
                {
                    MessageBox.Show("No hay productos definidos. Añada productos primero.", "Actualización BCG",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Antes de actualizar, asegurar que la tabla BCG está configurada
                if (dgvBCG.Columns.Count <= 1)
                {
                    MessageBox.Show("La matriz BCG no está configurada. Reconfigurando...", "Actualización BCG",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigurarTablaBCG();
                }

                // Llamar a la función de actualización
                ActualizarDatosBCG();

                MessageBox.Show("Matriz BCG actualizada correctamente.", "Actualización BCG",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la matriz BCG: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
