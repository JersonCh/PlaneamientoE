using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2.Clases
{
    public class clsUsuario
    {
        public int id { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }


        public bool Autenticar(string email, string passwordPlano)
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    
                    var usuario = dc.USUARIO.FirstOrDefault(u => u.email == email);

                    if (usuario != null)
                    {
                        string passwordIngresadaHash = ComputeSha256Hash(passwordPlano);

                        
                        if (usuario.password_hash.Equals(passwordIngresadaHash, StringComparison.OrdinalIgnoreCase))
                        {
                            this.id = usuario.id;
                            this.email = usuario.email;
                            this.nombre = usuario.nombre;
                            this.apellido = usuario.apellido;
                            MessageBox.Show("¡Autenticación exitosa!", "Depuración");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El hash de la contraseña no coincide.", "Depuración");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un usuario con ese correo.", "Depuración");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool ActualizarPassword(string email, string nuevaPassPlano)
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    var usuario = dc.USUARIO.FirstOrDefault(u => u.email == email);
                    if (usuario == null)
                        return false;

                    usuario.password_hash = ComputeSha256Hash(nuevaPassPlano);
                    dc.SubmitChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}