using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Clases; 
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmEmpresas : Form
    {
        private List<SP_ListarEmpresasPorUsuarioResult> listaEmpresas;

        public FrmEmpresas()
        {
            InitializeComponent();
            CargarEmpresas();
        }
        private void CargarEmpresas()
        {
            try
            {
                using (var dc = new DataClasses3DataContext())
                {
                    int idUsuario = Sesion.UsuarioId;

                    listaEmpresas = dc.SP_ListarEmpresasPorUsuario(idUsuario).ToList();

                    dgvEmpresas.DataSource = listaEmpresas;

                    dgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEmpresas.MultiSelect = false;

                    // *** OCULTAR LA COLUMNA ID Y CONFIGURAR SOLO NOMBRE Y DESCRIPCIÓN ***
                    if (dgvEmpresas.Columns.Count >= 3)
                    {
                        // Ocultar la columna ID (índice 0) - MANTIENE LA FUNCIONALIDAD
                        dgvEmpresas.Columns[0].Visible = false;

                        // Configurar solo las columnas visibles: nombre y descripción
                        dgvEmpresas.Columns[1].HeaderText = "Nombre de la Empresa";
                        dgvEmpresas.Columns[2].HeaderText = "Descripción";

                        dgvEmpresas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvEmpresas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgvEmpresas.Columns[1].FillWeight = 40; // 40% para nombre
                        dgvEmpresas.Columns[2].FillWeight = 60; // 60% para descripción
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empresas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            var filtradas = listaEmpresas
                .Where(emp => emp.nombre.ToLower().Contains(textoBusqueda) ||
                             (emp.descripcion != null && emp.descripcion.ToLower().Contains(textoBusqueda)))
                .ToList();

            dgvEmpresas.DataSource = filtradas;
        }


        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerrar formulario activo si ya hay uno
            //if (panelContenedor.Controls.Count > 0)
                //panelContenedor.Controls[0].Dispose();

            //formularioHijo.TopLevel = false;
            //formularioHijo.FormBorderStyle = FormBorderStyle.None;
            //formularioHijo.Dock = DockStyle.Fill;
            //panelContenedor.Controls.Add(formularioHijo);
            //panelContenedor.Tag = formularioHijo;
            //formularioHijo.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmInformacion formularioEmergente = new FrmInformacion();
            formularioEmergente.ShowDialog();

        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow filaSeleccionada = dgvEmpresas.Rows[e.RowIndex];

                    // *** OBTENER ID (OCULTO) Y NOMBRE (VISIBLE) ***
                    int empresaId = Convert.ToInt32(filaSeleccionada.Cells[0].Value); // ID (columna oculta)
                    string nombreEmpresa = filaSeleccionada.Cells[1].Value?.ToString() ?? "Sin nombre"; // Nombre

                    // Guardar en la sesión (funcionalidad interna intacta)
                    Sesion.EmpresaId = empresaId;

                    // *** MENSAJE PROTEGIDO - SIN MOSTRAR ID ***
                    MessageBox.Show($"Empresa seleccionada: {nombreEmpresa}",
                                   "Empresa Seleccionada",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                    // *** ABRIR FORMULARIO SIN BeginInvoke ***
                    FrmResumen frmResumen = new FrmResumen();
                    frmResumen.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar empresa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            var filtradas = listaEmpresas
                .Where(emp => emp.nombre.ToLower().Contains(textoBusqueda) ||
                             (emp.descripcion != null && emp.descripcion.ToLower().Contains(textoBusqueda)))
                .ToList();

            dgvEmpresas.DataSource = filtradas;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FrmInformacion formularioEmergente = new FrmInformacion();
            formularioEmergente.ShowDialog();
            CargarEmpresas();
        }

        private void FrmEmpresas_Load(object sender, EventArgs e)
        {

        }
    }
}
