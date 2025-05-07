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
            AbrirFormularioHijo(new FrmMision());
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmVision());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmObjetivos());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmValores());
        }
    }
}
