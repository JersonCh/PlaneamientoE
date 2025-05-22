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
    public partial class FrmDAFO : Form
    {
        public FrmDAFO()
        {
            InitializeComponent(); 
            CargarDatos();  // Llamar al método para cargar los datos

        }

        private void CargarDatos()
        {
            try
            {
                // Asumiendo que tienes un usuario logueado y su ID se obtiene de la sesión
                int usuarioId = Sesion.UsuarioId;
                int empresaId = Sesion.EmpresaId;
                MessageBox.Show("ID de empresa registrado: " + empresaId, "ID Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var dc = new DataClasses3DataContext())
                {

                    //Obtener las Fortalezas
                    var fortalezas = dc.SP_ListarFortalezas(empresaId).ToList();

                    if (fortalezas.Count > 0) txtF1.Text = fortalezas.ElementAtOrDefault(0)?.Fortaleza_Descripcion ?? "";
                    if (fortalezas.Count > 1) txtF2.Text = fortalezas.ElementAtOrDefault(1)?.Fortaleza_Descripcion ?? "";

                    //Obtener las Debilidades
                    var debilidades = dc.SP_ListarDebilidades(empresaId).ToList();

                    if (debilidades.Count > 0) txtD1.Text = debilidades.ElementAtOrDefault(0)?.Debilidad_Descripcion ?? "";
                    if (debilidades.Count > 1) txtD2.Text = debilidades.ElementAtOrDefault(1)?.Debilidad_Descripcion ?? "";

                    // Obtener las Oportunidades
                    var oportunidades = dc.SP_ListarOportunidades(empresaId).ToList();

                    if (oportunidades.Count > 0) txtO1.Text = oportunidades.ElementAtOrDefault(0)?.Oportunidad_Descripcion ?? "";
                    if (oportunidades.Count > 1) txtO2.Text = oportunidades.ElementAtOrDefault(1)?.Oportunidad_Descripcion ?? "";
                    if (oportunidades.Count > 2) txtO3.Text = oportunidades.ElementAtOrDefault(2)?.Oportunidad_Descripcion ?? "";
                    if (oportunidades.Count > 3) txtO4.Text = oportunidades.ElementAtOrDefault(3)?.Oportunidad_Descripcion ?? "";

                    // Obtener las Amenazas
                    var amenazas = dc.SP_ListarAmenazas(empresaId).ToList();

                    if (amenazas.Count > 0) txtA1.Text = amenazas.ElementAtOrDefault(0)?.Amenaza_Descripcion ?? "";
                    if (amenazas.Count > 1) txtA2.Text = amenazas.ElementAtOrDefault(1)?.Amenaza_Descripcion ?? "";
                    if (amenazas.Count > 2) txtA3.Text = amenazas.ElementAtOrDefault(2)?.Amenaza_Descripcion ?? "";
                    if (amenazas.Count > 3) txtA4.Text = amenazas.ElementAtOrDefault(3)?.Amenaza_Descripcion ?? "";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDAFO_Load(object sender, EventArgs e)
        {

        }
    }
}
