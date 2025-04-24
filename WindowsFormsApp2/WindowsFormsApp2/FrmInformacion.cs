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
    public partial class FrmInformacion : Form
    {
        public FrmInformacion()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmInformacion_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int usuarioid = Sesion.UsuarioId;
            try
            {
                // Obtener el ID del usuario de la sesión
                string nombreEmpresa = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                // Verificar si se ingresó un nombre y descripcion
                if (string.IsNullOrEmpty(nombreEmpresa) || string.IsNullOrEmpty(descripcion))
                {
                    MessageBox.Show("Debe ingresar un nombre y descripción para la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir si no se ingresó nombre
                }

                // Registrar la empresa en la base de datos
                using (var db = new DataClasses3DataContext())
                {
                    var nuevaEmpresa = new Empresa
                    {
                        nombre = nombreEmpresa,  // Usar el nombre ingresado
                        usuario_id = Sesion.UsuarioId,
                        descripcion= descripcion
                    };

                    db.Empresa.InsertOnSubmit(nuevaEmpresa);
                    db.SubmitChanges();
                }

                // Redirigir a FrmMision
                this.Hide();
                new FrmMision().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmInicio().Show();
        }
    }
}
