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
    public partial class FrmObjetivos : Form
    {
        public FrmObjetivos()
        {
            InitializeComponent();
            CargarMision();
        }
        private void CargarMision()
        {
            try
            {
                // Asumiendo que tienes un usuario logueado y su ID se obtiene de la sesión
                int usuarioId = Sesion.UsuarioId;
                int empresaId = Sesion.EmpresaId;
                using (var dc = new DataClasses3DataContext())
                {
                    // Obtener Misión del usuario
                    var mision = dc.SP_ListarMisionPorUsuario(empresaId).FirstOrDefault();
                    if (mision != null)
                    {
                        txtMision.Text = mision.descripcion;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string descripcion = txtUnidadEstrategica.Text.Trim(); 

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor ingresa una descripción para la unidad estratégica.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    dc.SP_RegistrarUnidEstra(descripcion, Sesion.EmpresaId);
                }

                MessageBox.Show("Unidad Estratégica registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la unidad estratégica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Descripciones de los objetivos generales
            string descripcionG1 = txtObjetivoG1.Text.Trim();
            string descripcionG2 = txtObjetivoG2.Text.Trim();
            string descripcionG3 = txtObjetivoG3.Text.Trim();

            // Descripciones de los objetivos específicos
            string descripcionE1 = txtObjetivoE1.Text.Trim();
            string descripcionE2 = txtObjetivoE2.Text.Trim();
            string descripcionE3 = txtObjetivoE3.Text.Trim();
            string descripcionE4 = txtObjetivoE4.Text.Trim();
            string descripcionE5 = txtObjetivoE5.Text.Trim();
            string descripcionE6 = txtObjetivoE6.Text.Trim();

            // Validar que todas las descripciones estén completas
            if (string.IsNullOrEmpty(descripcionG1) || string.IsNullOrEmpty(descripcionG2) || string.IsNullOrEmpty(descripcionG3) ||
                string.IsNullOrEmpty(descripcionE1) || string.IsNullOrEmpty(descripcionE2) || string.IsNullOrEmpty(descripcionE3) ||
                string.IsNullOrEmpty(descripcionE4) || string.IsNullOrEmpty(descripcionE5) || string.IsNullOrEmpty(descripcionE6))
            {
                MessageBox.Show("Por favor ingresa las descripciones de los objetivos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    // Llamar al procedimiento almacenado para registrar los objetivos generales y específicos
                    dc.SP_RegistrarObjetivos(
                        descripcionG1, descripcionG2, descripcionG3,
                        Sesion.EmpresaId,
                        descripcionE1, descripcionE2, descripcionE3,
                        descripcionE4, descripcionE5, descripcionE6);
                }

                MessageBox.Show("Objetivos registrados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los objetivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValores_Click(object sender, EventArgs e)
        {
            FrmCadenaValor frmcadenavalor = new FrmCadenaValor();
            frmcadenavalor.Show();
            this.Hide();
        }
    }
}
