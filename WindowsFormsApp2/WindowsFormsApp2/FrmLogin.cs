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


            // Crear una instancia de la clase clsUsuario
            clsUsuario usuario = new clsUsuario();

            // Intentar autenticar al usuario
            if (usuario.Autenticar(email, password))
            {
                // Si la autenticación es exitosa
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                // Crear una nueva instancia del formulario al que quieres redirigir
                Form objFrmInicio = new FrmInicio();

                // Mostrar el otro formulario
                objFrmInicio.Show();

            }
            else
            {
                // Si la autenticación falla
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
