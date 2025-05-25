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

                    if (dgvEmpresas.Columns.Count >= 2)
                    {
                        dgvEmpresas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvEmpresas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgvEmpresas.Columns[0].FillWeight = 50;
                        dgvEmpresas.Columns[1].FillWeight = 50;
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
                .Where(emp => emp.nombre.ToLower().Contains(textoBusqueda))
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
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvEmpresas.Rows[e.RowIndex];

                // Obtener el valor de la primera celda (columna ID)
                int empresaId = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                // Guardar en la sesión
                Sesion.EmpresaId = empresaId;

                // Abrir el formulario y ocultar este
                FrmResumen frmResumen = new FrmResumen();
                frmResumen.Show();
                this.Hide();
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
                .Where(emp => emp.nombre.ToLower().Contains(textoBusqueda))
                .ToList();

            dgvEmpresas.DataSource = filtradas;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FrmInformacion formularioEmergente = new FrmInformacion();
            formularioEmergente.ShowDialog();
        }
    }
}
