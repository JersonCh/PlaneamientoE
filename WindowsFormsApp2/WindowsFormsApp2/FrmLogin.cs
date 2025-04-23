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

namespace WindowsFormsApp2
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string email = txtCorreo.Text.Trim();
            string password = txtPass.Text.Trim();

            if (ValidarUsuario(email, password))
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form objFrmInicio = new FrmInicio();
                objFrmInicio.Show();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarUsuario(string usuario, string password)
        {
            // Crear una instancia de tu clase de usuario
            clsUsuario user = new clsUsuario();

            // Usar el método Autenticar que ya tienes en tu clase
            //return user.Autenticar(usuario, password);

            // O si prefieres hacer la consulta directamente aquí:
            
            try
            {
                using (var dc = new SOFTPETIDataSet())
                {
                    var consulta = dc.SP_Autenticar(usuario, password).SingleOrDefault();
                    
                    if (consulta != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


    }
}
