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
    public partial class FrmLogin : Form
    {
        
        public FrmLogin()
        {
            InitializeComponent();
            //Instancia de dataset con objeto user
            DataClasses3DataContext user = new DataClasses3DataContext();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = txtCorreo.Text.Trim();
            string password = txtPass.Text.Trim();

            clsUsuario usuario = new clsUsuario();

            if (usuario.Autenticar(email, password))
            {
                // Guardamos el ID del usuario en la clase estática Sesion
                Sesion.UsuarioId = usuario.id;

                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form objFrmEmpresas = new FrmEmpresas();
                objFrmEmpresas.Show();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
