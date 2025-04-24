using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmMision : Form
    {
        public FrmMision()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string descripcion = txtMision.Text.Trim();

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor ingresa una descripción para la misión.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    dc.SP_RegistrarMision(descripcion, Sesion.UsuarioId);
                }

                MessageBox.Show("Misión registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la misión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            FrmVision frmVision = new FrmVision();
            frmVision.Show();
            this.Close(); 
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            FrmVision frmVision = new FrmVision();
            frmVision.Show();
            this.Close();
        }
    }
}
