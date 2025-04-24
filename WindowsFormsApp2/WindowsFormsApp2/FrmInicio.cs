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
            FrmResumen frmResumen = new FrmResumen(Sesion.UsuarioId);
            frmResumen.Show();
            this.Close();
        }
    
    }
}
