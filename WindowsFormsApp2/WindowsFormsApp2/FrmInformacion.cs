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
            DataClasses3DataContext user = new DataClasses3DataContext();
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
            try
            {
                // Obtener el ID del usuario de la sesión
                string nombreEmpresa = txtNombre.Text;
                string descripcion = txtDescripcion.Text;

                // Verificar si se ingresó un nombre y descripción
                if (string.IsNullOrEmpty(nombreEmpresa) || string.IsNullOrEmpty(descripcion))
                {
                    MessageBox.Show("Debe ingresar un nombre y descripción para la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir si no se ingresó nombre
                }

                int? nuevoIdEmpresa = 0; // Declarar como nullable int
                using (var db = new DataClasses3DataContext())
                {
                    db.SP_RegistrarEmpresa(nombreEmpresa, Sesion.UsuarioId, descripcion, ref nuevoIdEmpresa);
                }

                if (nuevoIdEmpresa.HasValue)
                {
                    int empresaId = nuevoIdEmpresa.Value;
                    Sesion.EmpresaId = empresaId;
                    // Mostrar el ID generado
                    //MessageBox.Show("ID de empresa registrado: " + empresaId, "ID Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    //Form objFrmMision = new FrmMision();
                    //objFrmMision.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID de la empresa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmInicio().Show();
        }
    }
}
