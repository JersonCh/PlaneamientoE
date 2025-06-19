using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmObjetivos : Form
    {
        private int selectedObjetivoGeneralId = -1; // Variable para almacenar el ID seleccionado

        public FrmObjetivos()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadObjetivosGenerales(); // Cargar datos en dgvObjG
            CargarDatos();
            CargarUnidadEstrategica();
        }

        private void FrmObjetivos_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadObjetivosGenerales(); // Cargar datos en dgvObjG
        }
        private void CargarDatos()
        {
            try
            {
                int usuarioId = Sesion.UsuarioId;
                int empresaId = Sesion.EmpresaId;
                using (var dc = new DataClasses3DataContext())
                {
                    var mision = dc.SP_ListarMisionPorUsuario(empresaId).FirstOrDefault();
                    if (mision != null)
                    {
                        txtMision.Text = mision.descripcion; // Mostrar la misión en txtMision
                    }
                    else
                    {
                        txtMision.Text = "No se encontró una misión registrada."; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la misión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarUnidadEstrategica()
        {
            try
            {
                int empresaId = Sesion.EmpresaId;

                using (var dc = new DataClasses3DataContext())
                {
                    var unid_estrat = dc.SP_ListarUnidEstraPorEmpresa(empresaId).FirstOrDefault();
                    if (unid_estrat != null)
                    {
                        txtUnidadEstrategica.Text = unid_estrat.descripcion; // Mostrar la descripción en txtUnidadEstrategica
                    }
                    else
                    {
                        txtUnidadEstrategica.Text = ""; // Manejo de caso cuando no hay datos
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la unidad estratégica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarUnidadEstrategica()
        {
            try
            {
                int empresaId = Sesion.EmpresaId;
                string descripcionUnidad = txtUnidadEstrategica.Text;

                if (string.IsNullOrEmpty(descripcionUnidad))
                {
                    MessageBox.Show("Debe ingresar una descripción para la unidad estratégica.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dc = new DataClasses3DataContext())
                {
                    var unid_estrat = dc.SP_ListarUnidEstraPorEmpresa(empresaId).FirstOrDefault();
                    if (unid_estrat != null)
                    {
                        // Actualizar el valor existente
                        var unidadExistente = dc.UNID_ESTRA.FirstOrDefault(ue => ue.empresa_id == empresaId);
                        if (unidadExistente != null)
                        {
                            unidadExistente.descripcion = descripcionUnidad;
                        }
                    }
                    else
                    {
                        // Insertar nuevo registro
                        dc.SP_RegistrarUnidEstra(descripcionUnidad, empresaId);
                    }

                    dc.SubmitChanges();
                    MessageBox.Show("Unidad estratégica registrada o actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la unidad estratégica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Configurar dgvObjG (Objetivos Generales)
            dgvObjG.Columns.Clear();
            dgvObjG.Columns.Add("IdGeneral", "ID");
            dgvObjG.Columns.Add("DescripcionGeneral", "Descripción del Objetivo General");
            dgvObjG.Columns.Add("IsSaved", "Guardado"); // Columna oculta para identificar registros ya guardados
            dgvObjG.Columns["IsSaved"].Visible = false; // Ocultar la columna

            // Ocultar la columna "IdGeneral"
            dgvObjG.Columns["IdGeneral"].Visible = false;

            dgvObjG.Columns[1].Width = 300; // Ajustar ancho de columna para la descripción
            dgvObjG.AllowUserToAddRows = true; // Permitir añadir filas
            dgvObjG.ReadOnly = false; // Permitir edición
            dgvObjG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar dgvObjE (Objetivos Específicos)
            dgvObjE.Columns.Clear();
            dgvObjE.Columns.Add("ObjetivoEspecificoID", "ID del Objetivo Específico"); // Columna para almacenar el ID del objetivo específico
            dgvObjE.Columns.Add("DescripcionEspecifica", "Descripción del Objetivo Específico");
            dgvObjE.Columns.Add("ObjetivoGeneralID", "ID del Objetivo General"); // Columna oculta para almacenar el ID del objetivo general
            dgvObjE.Columns["ObjetivoGeneralID"].Visible = false; // Ocultar la columna del ID general
            dgvObjE.Columns["ObjetivoEspecificoID"].Visible = false; // Ocultar la columna del ID específico
            dgvObjE.Columns[1].Width = 300; // Ajustar ancho de columna para la descripción
            dgvObjE.AllowUserToAddRows = true; // Permitir añadir filas
            dgvObjE.ReadOnly = false; // Permitir edición
            dgvObjE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar evento para detectar selección en dgvObjG
            dgvObjG.CellClick += DgvObjG_CellClick;
        }

        private void LoadObjetivosGenerales()
        {
            try
            {
                int empresaId = Sesion.EmpresaId;

                using (var dc = new DataClasses3DataContext())
                {
                    var objetivosGenerales = dc.ObjetivoG
                     .Where(og => og.empresa_id == empresaId)
                     .Select(og => new
                     {
                         og.id,
                         og.descripcion
                     })
                     .ToList();
                    // Limpiar las filas existentes antes de cargar datos nuevos
                    dgvObjG.Rows.Clear();

                    // Llenar dgvObjG con los datos obtenidos
                    foreach (var objetivo in objetivosGenerales)
                    {
                        dgvObjG.Rows.Add(objetivo.id, objetivo.descripcion, true); // Marcar como guardado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar objetivos generales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadObjetivosEspecificos(int objetivoGeneralId)
        {
            try
            {
                using (var dc = new DataClasses3DataContext())
                {
                    Debug.WriteLine($"Cargando objetivos específicos para ID: {objetivoGeneralId}");

                    // Limpiar las filas existentes antes de cargar datos nuevos
                    dgvObjE.Rows.Clear();

                    var objetivosEspecificos = dc.ObjetivoE
                        .Where(oe => oe.objetivo_id == objetivoGeneralId)
                        .Select(oe => new
                        {
                            oe.id, // ID del objetivo específico
                            oe.descripcion // Descripción del objetivo específico
                        })
                        .ToList();

                    // Llenar dgvObjE con los datos obtenidos
                    foreach (var objetivo in objetivosEspecificos)
                    {
                        Debug.WriteLine($"Objetivo específico: ID = {objetivo.id}, Descripción = {objetivo.descripcion}");
                        dgvObjE.Rows.Add(objetivo.id, objetivo.descripcion, objetivoGeneralId); // Asignar ID del objetivo específico y general
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar objetivos específicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvObjG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que la fila seleccionada sea válida
                if (e.RowIndex >= 0 && dgvObjG.Rows[e.RowIndex].Cells["IdGeneral"].Value != null)
                {
                    // Obtener el ID del objetivo general seleccionado
                    selectedObjetivoGeneralId = Convert.ToInt32(dgvObjG.Rows[e.RowIndex].Cells["IdGeneral"].Value);

                    // Cargar los objetivos específicos relacionados
                    LoadObjetivosEspecificos(selectedObjetivoGeneralId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el objetivo general: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarGenerales_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarUnidadEstrategica();
                using (var dc = new DataClasses3DataContext())
                {
                    foreach (DataGridViewRow row in dgvObjG.Rows)
                    {
                        if (row.IsNewRow) continue; // Ignorar filas nuevas

                        int objetivoGeneralId = Convert.ToInt32(row.Cells["IdGeneral"].Value);
                        string descripcionGeneral = row.Cells["DescripcionGeneral"].Value?.ToString();

                        if (!string.IsNullOrEmpty(descripcionGeneral))
                        {
                            // Actualizar si ya existe, insertar si no existe
                            var objetivoGeneral = dc.ObjetivoG.SingleOrDefault(og => og.id == objetivoGeneralId);

                            if (objetivoGeneral != null)
                            {
                                objetivoGeneral.descripcion = descripcionGeneral; // Sobreescribir
                            }
                            else
                            {
                                dc.SP_InsertarObjetivoG(descripcionGeneral, Sesion.EmpresaId); // Insertar nuevo
                            }
                        }
                    }

                    dc.SubmitChanges();
                    MessageBox.Show("Objetivos generales registrados o actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar los objetivos generales
                    LoadObjetivosGenerales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar o actualizar los objetivos generales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarUnidadEstrategica();
                if (selectedObjetivoGeneralId == -1)
                {
                    MessageBox.Show("Por favor, seleccione un objetivo general antes de registrar objetivos específicos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var dc = new DataClasses3DataContext())
                {
                    // Obtener la lista actual de objetivos específicos en la base de datos
                    var objetivosEspecificosExistentes = dc.ObjetivoE
                        .Where(oe => oe.objetivo_id == selectedObjetivoGeneralId)
                        .ToList();

                    foreach (DataGridViewRow row in dgvObjE.Rows)
                    {
                        if (row.IsNewRow) continue; // Ignorar filas nuevas

                        string descripcionEspecifica = row.Cells["DescripcionEspecifica"].Value?.ToString();
                        int? objetivoEspecificoId = row.Cells["ObjetivoEspecificoID"].Value != null
                            ? Convert.ToInt32(row.Cells["ObjetivoEspecificoID"].Value)
                            : (int?)null;

                        if (!string.IsNullOrEmpty(descripcionEspecifica))
                        {
                            if (objetivoEspecificoId.HasValue)
                            {
                                // Si el objetivo específico ya tiene un ID, actualizar el registro existente
                                var objetivoExistente = objetivosEspecificosExistentes
                                    .FirstOrDefault(oe => oe.id == objetivoEspecificoId.Value);

                                if (objetivoExistente != null)
                                {
                                    // Actualizar la descripción en el modelo
                                    objetivoExistente.descripcion = descripcionEspecifica;
                                    objetivoExistente.fecha_registro = DateTime.Now;
                                }
                                else
                                {
                                    MessageBox.Show($"No se encontró el objetivo específico con ID {objetivoEspecificoId.Value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                // Si no tiene ID, insertar un nuevo registro
                                dc.ObjetivoE.InsertOnSubmit(new ObjetivoE
                                {
                                    descripcion = descripcionEspecifica,
                                    objetivo_id = selectedObjetivoGeneralId,
                                    fecha_registro = DateTime.Now
                                });
                            }
                        }
                    }

                    // Guardar los cambios en la base de datos
                    dc.SubmitChanges();

                    MessageBox.Show("Objetivos específicos registrados o actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar los objetivos específicos relacionados
                    LoadObjetivosEspecificos(selectedObjetivoGeneralId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar o actualizar los objetivos específicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}