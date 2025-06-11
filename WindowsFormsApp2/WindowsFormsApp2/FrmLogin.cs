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
        public int intentosFallidos = 0;
        public string ultimaTemporalGenerada = "";
        public string correoTemporal = "";

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

            // Depuración: Mostrar datos ingresados
            MessageBox.Show($"Correo ingresado: \"{email}\"\nContraseña ingresada: \"{password}\"", "Depuración");

            clsUsuario usuario = new clsUsuario();

            bool autenticado = usuario.Autenticar(email, password);

            // Depuración: Mostrar resultado de autenticación
            MessageBox.Show($"¿Autenticado?: {autenticado}", "Depuración");

            if (autenticado)
            {
                // Si el usuario ingresa la contraseña temporal (que tienes guardada)
                if (!string.IsNullOrEmpty(ultimaTemporalGenerada) &&
                    email == correoTemporal &&
                    password == ultimaTemporalGenerada)
                {
                    // Redirigir a formulario de cambio de contraseña
                    this.Hide();
                    Form frmCambio = new FrmCambioPassword(email);
                    frmCambio.Show();
                }
                else
                {
                    // Login normal
                    intentosFallidos = 0;
                    ultimaTemporalGenerada = "";
                    correoTemporal = "";
                    this.Hide();
                    Form objFrmDashBoard = new FrmDashBoard();
                    objFrmDashBoard.Show();
                }
            }
            else
            {
                intentosFallidos++;
                if (intentosFallidos >= 3)
                {
                    // Generar temporal
                    string nuevaPass = GenerarPasswordTemporal();
                    if (usuario.ActualizarPassword(email, nuevaPass))
                    {
                        RJMessageBox.Show($"Contraseña temporal generada: {nuevaPass}\nPor favor cámbiela al ingresar.", "Contraseña temporal");
                        ultimaTemporalGenerada = nuevaPass;
                        correoTemporal = email;
                    }
                    intentosFallidos = 0; // Reiniciar contador
                }
                else
                {
                    RJMessageBox.Show(
                        $"Correo y/o contraseña incorrectos\nIntento {intentosFallidos} de 3",
                        "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error
                    );
                }
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
        private string GenerarPasswordTemporal(int longitud = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, longitud)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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

        private void btnRecuperarPass_Click(object sender, EventArgs e)
        {
            string email = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(email) || email == "USUARIO")
            {
                RJMessageBox.Show("Por favor, ingrese un correo válido.", "Validación");
                return;
            }

            clsUsuario usuario = new clsUsuario();

            // Verificar si el usuario existe
            bool existeUsuario;
            using (DataClasses3DataContext dc = new DataClasses3DataContext())
            {
                existeUsuario = dc.USUARIO.Any(u => u.email == email);
            }

            if (!existeUsuario)
            {
                RJMessageBox.Show("El correo ingresado no está registrado.", "Error");
                return;
            }

            // Generar nueva contraseña temporal
            string nuevaPass = GenerarPasswordTemporal();

            // Actualizar contraseña en BD
            if (usuario.ActualizarPassword(email, nuevaPass))
            {
                // Mostrar la nueva contraseña al usuario
                RJMessageBox.Show($"Su nueva contraseña temporal es:\n\n{nuevaPass}\n\nPor favor, cámbiela al iniciar sesión.", "Contraseña Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RJMessageBox.Show("No se pudo actualizar la contraseña. Intente más tarde.", "Error");
            }
        }
    }
}