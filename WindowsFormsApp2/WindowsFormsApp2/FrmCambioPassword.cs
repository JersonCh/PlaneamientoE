using System;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;

namespace WindowsFormsApp2
{
    public partial class FrmCambioPassword : Form
    {
        private string emailUsuario;

        public FrmCambioPassword(string email)
        {
            InitializeComponent();
            emailUsuario = email;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string nuevaPass = txtNuevaPass.Text.Trim();
            string confirmarPass = txtConfirmarPass.Text.Trim();

            if (nuevaPass != confirmarPass)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(nuevaPass) || nuevaPass.Length < 6)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 6 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsUsuario usuario = new clsUsuario();
            if (usuario.ActualizarPassword(emailUsuario, nuevaPass))
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar variables temporales (puedes hacerlo desde el login también)
                FrmLogin loginForm = Application.OpenForms["FrmLogin"] as FrmLogin;
                if (loginForm != null)
                {
                    loginForm.ultimaTemporalGenerada = "";
                    loginForm.correoTemporal = "";
                }

                // Redirigir a login o dashboard
                this.Close();
                Form frmLogin = new FrmLogin();
                frmLogin.Show();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}