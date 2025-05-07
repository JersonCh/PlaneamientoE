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

                    // Suponiendo que tienes un procedimiento almacenado que lista empresas por usuario
                    var empresas = dc.SP_ListarEmpresasPorUsuario(idUsuario).ToList();

                    // Asignamos el resultado al DataGridView (suponiendo que se llama dgvEmpresas)
                    dgvEmpresas.DataSource = empresas;

                    // Habilitar la selección de filas
                    dgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEmpresas.MultiSelect = false;  // Solo permitir seleccionar una fila a la vez

                    // Ajustar columnas
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

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            FrmInformacion frminfo = new FrmInformacion();
            frminfo.Show();

            //try
            //{
            //    // Mostrar MessageBox para ingresar el nombre de la empresa
            //    string nombreEmpresa = Microsoft.VisualBasic.Interaction.InputBox("Por favor ingrese el nombre de la empresa:", "Registrar Empresa", "");

            //    // Verificar si se ingresó un nombre
            //    if (string.IsNullOrEmpty(nombreEmpresa))
            //    {
            //        MessageBox.Show("Debe ingresar un nombre para la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return; // Salir si no se ingresó nombre
            //    }

            //    // Registrar la empresa en la base de datos
            //    using (var db = new DataClasses3DataContext())
            //    {
            //        var nuevaEmpresa = new Empresa
            //        {
            //            nombre = nombreEmpresa,  // Usar el nombre ingresado
            //            usuario_id = Sesion.UsuarioId
            //        };

            //        db.Empresa.InsertOnSubmit(nuevaEmpresa);
            //        db.SubmitChanges();
            //    }

            //    // Redirigir a FrmMision
            //    this.Hide();
            //    new FrmMision().Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al registrar empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  
            {
                var empresaSeleccionada = dgvEmpresas.Rows[e.RowIndex].DataBoundItem as dynamic;

                if (empresaSeleccionada != null)
                {
                    int empresaId = empresaSeleccionada.id;  

                    
                    FrmResumen frmResumen = new FrmResumen();
                    frmResumen.Show();

                    this.Hide();
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
    }
}
