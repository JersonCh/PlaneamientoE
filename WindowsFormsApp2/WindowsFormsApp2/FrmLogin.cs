using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomMessageBox;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                //MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult result = RJMessageBox.Show("Inicio de sesión exitoso, Bienvenido Usuario",
                    "Bienvenido");
                

                this.Hide();
                Form objFrmDashBoard = new FrmDashBoard();
                objFrmDashBoard.Show();
            }
            else
            {
                //MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                var result = RJMessageBox.Show("Correo y/o contraseña son incorrectos",
                "Error",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
            }
        }
        //Aparecer o no el texto USUARIO y CONTRASEÑA
        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "USUARIO")
            {
                txtCorreo.Text = "";
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "USUARIO";
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = false;
            }

        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.UseSystemPasswordChar = false;
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
