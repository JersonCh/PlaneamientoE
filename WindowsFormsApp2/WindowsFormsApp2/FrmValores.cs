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
    public partial class FrmValores : Form
    {
        public FrmValores()
        {
            InitializeComponent();
        }
        private int ObtenerEmpresaIdDeUsuario(int usuarioId)
        {
            using (DataClasses3DataContext dc = new DataClasses3DataContext())
            {
                var empresa = dc.Empresa.FirstOrDefault(e => e.usuario_id == usuarioId);
                return empresa?.id ?? 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string descripcion = txtValores.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Ingrese una descripción para los valores.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int empresaId = ObtenerEmpresaIdDeUsuario(Sesion.UsuarioId);

            if (empresaId == 0)
            {
                MessageBox.Show("No se encontró una empresa asociada a este usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (DataClasses3DataContext dc = new DataClasses3DataContext())
            {
                dc.SP_RegistrarValores(descripcion, Sesion.EmpresaId);
                MessageBox.Show("Valores registrados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnObjetivos_Click(object sender, EventArgs e)
        {
            FrmObjetivos objFrmObjetivos = new FrmObjetivos();
            objFrmObjetivos.Show();
            this.Hide();
        }
    }
}
