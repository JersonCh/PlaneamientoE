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

namespace WindowsFormsApp2
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void ptbResumen_Click(object sender, EventArgs e)
        {
            
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMision_Click(object sender, EventArgs e)
        {
            FrmMision frmMision = new FrmMision();
            frmMision.Show();
            this.Hide();
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            FrmVision frmVision = new FrmVision();
            frmVision.Show();
            this.Hide();
        }

        private void btnInformacionEmpresa_Click(object sender, EventArgs e)
        {
            FrmInformacion frmInformacion = new FrmInformacion();
            frmInformacion.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmValores frmValores = new FrmValores();
            frmValores.Show();
            this.Hide();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            FrmResumen frmResumen = new FrmResumen(Sesion.UsuarioId);
            frmResumen.Show();
            this.Close();
        }
    }
}
