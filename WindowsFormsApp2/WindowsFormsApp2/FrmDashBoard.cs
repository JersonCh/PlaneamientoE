using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
        }

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerrar formulario activo si ya hay uno
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls[0].Dispose();

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.Show();
        }

        private void btnInformacionEmpresa_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmEmpresas());
        }

        private void btnMision_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Mision());
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Vision());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmObjetivos());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmValores());
        }

        private void btnAnalisisIyE_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmAnalisis());
        }

        private void btnLas5Fuerzas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmMatrizDePorter());
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmResumen());
        }

        private void btnMatriz_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmBCG());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmCadenaValor());
        }

        private void btnPest_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmPest());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmMatrizCame());
        }

        private void btnIdentificacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmIdentif_Estrategia());
        }
    }
}
