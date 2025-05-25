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
    public partial class Vision : Form
    {
        public Vision()
        {
            InitializeComponent();
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string descripcion = txtVision.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Ingrese una descripción para la visión.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (DataClasses3DataContext dc = new DataClasses3DataContext())
            {
                dc.SP_RegistrarVision(descripcion, Sesion.EmpresaId);
                MessageBox.Show("Visión registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnValores_Click(object sender, EventArgs e)
        {
            FrmValores frmValores = new FrmValores();
            frmValores.Show();
            this.Close();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            FrmValores frmValores = new FrmValores();
            frmValores.Show();
            this.Close();
        }

        private void btnIndice_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Close();
        }

        //boton indice
        private void button1_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void btnMision_Click(object sender, EventArgs e)
        {
            //FrmMision frmMision = new FrmMision();
            //frmMision.Show();
            //this.Hide();
        }

        private void btnValores_Click_1(object sender, EventArgs e)
        {
            FrmValores frmValores = new FrmValores();
            frmValores.Show();
            this.Hide();
        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
