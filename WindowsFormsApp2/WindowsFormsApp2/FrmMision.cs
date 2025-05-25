using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CustomMessageBox;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class Mision : Form
    {
        public Mision()
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
                    dc.SP_RegistrarMision(descripcion, Sesion.EmpresaId);
                }

                //MessageBox.Show("Misión registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = RJMessageBox.Show("Misión registrada correctamente",
                 "Éxito");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la misión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            Vision frmVision = new Vision();
            frmVision.Show();
            this.Close(); 
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Vision frmVision = new Vision();
            frmVision.Show();
            this.Close();
        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Indice
        private void button1_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio(); 
            frmInicio.Show();                      
            this.Hide();                           
        }

        private void btnIndice_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void btnVision_Click_1(object sender, EventArgs e)
        {
            Vision frmVision = new Vision();
            frmVision.Show();
            this.Hide();
        }
    }
}
