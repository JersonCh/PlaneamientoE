using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2.Clases
{
    internal class clsUsuario
    {
        public int id { get; set; }
        public string email { get; set; }

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
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
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
