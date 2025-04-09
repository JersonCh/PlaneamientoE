using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2.Clases
{
    internal class clsUsuario
    {
        // Propiedades
        public int id { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }

        // Lista de usuarios predefinidos para la prueba
        private static List<clsUsuario> usuarios = new List<clsUsuario>
        {
            // Hash SHA-256 de '123'
            new clsUsuario { id = 1, email = "jf",
                password_hash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3" }
        };

        // Método para autenticar al usuario
        public bool Autenticar(string email, string password)
        {
            foreach (var usuario in usuarios)
            {
                // Compara los correos de manera insensible a mayúsculas/minúsculas
                if (usuario.email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    // Verificar si la contraseña proporcionada es correcta
                    if (VerifyPasswordHash(password, usuario.password_hash))
                    {
                        this.id = usuario.id;
                        this.email = usuario.email;
                        return true;
                    }
                }
            }
            return false;
        }

        // Método para verificar si el hash de la contraseña ingresada coincide con el hash guardado
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Calcular el hash de la contraseña ingresada
            string hashedPassword = ComputeSha256Hash(password);

            // Depuración: mostrar los hashes calculado y almacenado
            Console.WriteLine("Hash calculado: " + hashedPassword);
            Console.WriteLine("Hash almacenado: " + storedHash);

            // Comparar los hashes de las contraseñas
            return hashedPassword.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }

        // Método para calcular el hash SHA-256 de la contraseña
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - devuelve un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertir el arreglo de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte byteValue in bytes)
                {
                    builder.Append(byteValue.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
