using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;  
using WindowsFormsApp2.Modelos; 

namespace WindowsFormsApp2
{
    public partial class FrmResumen : Form
    {
        private int _empresaId;

        public FrmResumen(int empresaId)
        {
            InitializeComponent();
            _empresaId = empresaId;  // Guardar el ID de la empresa
            CargarDatos();  // Llamar al método para cargar los datos
        }

        private void CargarDatos()
        {
            try
            {
                // Asumiendo que tienes un usuario logueado y su ID se obtiene de la sesión
                int usuarioId = Sesion.UsuarioId;

                using (var dc = new DataClasses3DataContext())
                {
                    // Obtener Misión del usuario
                    var mision = dc.SP_ListarMisionPorUsuarioYEmpresa(usuarioId, _empresaId).FirstOrDefault();
                    if (mision != null)
                    {
                        txtMision.Text = mision.descripcion;
                    }

                    // Obtener Visión del usuario
                    var vision = dc.SP_ListarVisionPorUsuarioYEmpresa(usuarioId, _empresaId).FirstOrDefault();
                    if (vision != null)
                    {
                        txtVision.Text = vision.descripcion;
                    }

                    // Obtener Empresa seleccionada por el usuario
                    var empresa = dc.Empresa.FirstOrDefault(e => e.id == _empresaId);  // Usar _empresaId para obtener la empresa seleccionada
                    if (empresa != null)
                    {
                        txtEmpresa.Text = empresa.nombre;  // Asignar el nombre de la empresa al TextBox
                    }

                    // Obtener la fecha de elaboración de la misión
                    if (mision != null)
                    {
                        // Mostrar la fecha actual del sistema en el formato deseado
                        txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }

                    // Obtener el correo del emprendedor (usuario)
                    var usuario = dc.USUARIO.FirstOrDefault(u => u.id == usuarioId);
                    if (usuario != null)
                    {
                        txtEmprendedor.Text = usuario.email;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Lógica para el botón, si es necesario
        }

        private void txtMision_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
