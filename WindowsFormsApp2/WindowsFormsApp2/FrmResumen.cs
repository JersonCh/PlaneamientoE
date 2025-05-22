using System;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;  
using WindowsFormsApp2.Modelos; 

namespace WindowsFormsApp2
{
    public partial class FrmResumen : Form
    {
       
        
        public FrmResumen()
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
                    // Obtener Misión del usuario
                    var mision = dc.SP_ListarMisionPorUsuario(empresaId).FirstOrDefault();
                    if (mision != null)
                    {
                        txtMision.Text = mision.descripcion;
                        txtMisionO.Text = mision.descripcion;
                    }

                    // Obtener Visión del usuario
                    var vision = dc.SP_ListarVisionPorUsuario(empresaId).FirstOrDefault();
                    if (vision != null)
                    {
                        txtVision.Text = vision.descripcion;
                    }

                    // Obtener valores del usuario
                    var valores = dc.SP_ListarValores(empresaId).FirstOrDefault();
                    if (valores != null)
                    {
                        txtValores.Text = valores.descripcion;
                    }


                    // Obtener Empresa seleccionada por el usuario
                    var empresa = dc.Empresa.FirstOrDefault(e => e.id == empresaId);  // Usar _empresaId para obtener la empresa seleccionada
                    if (empresa != null)
                    {
                        txtEmpresa.Text = empresa.nombre;  // Asignar el nombre de la empresa al TextBox
                    }

                    // Obtener la fecha de elaboración de la misión
                    if (mision != null)
                    {
                        // Mostrar la fecha actual del sistema en el formato deseado
                        txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }

                    // Obtener el correo del emprendedor (usuario)
                    var usuario = dc.USUARIO.FirstOrDefault(u => u.id == usuarioId);
                    if (usuario != null)
                    {
                        txtEmprendedor.Text = usuario.email;
                    }

                    // Obtener valores del usuario
                    var unid_estrat = dc.SP_ListarUnidEstraPorEmpresa(empresaId).FirstOrDefault();
                    if (unid_estrat != null)
                    {
                        txtUnidadEstrategica.Text = unid_estrat.descripcion;
                    }

                    // Obtener Objetivos Generales
                    var objetivosGenerales = dc.SP_ListarObjetivosGenerales(empresaId).ToList();

                    if (objetivosGenerales.Count > 0) txtObjetivoG1.Text = objetivosGenerales.ElementAtOrDefault(0)?.ObjetivoG_Descripcion ?? "";
                    if (objetivosGenerales.Count > 1) txtObjetivoG2.Text = objetivosGenerales.ElementAtOrDefault(1)?.ObjetivoG_Descripcion ?? "";
                    if (objetivosGenerales.Count > 2) txtObjetivoG3.Text = objetivosGenerales.ElementAtOrDefault(2)?.ObjetivoG_Descripcion ?? "";

                    // Obtener Objetivos Específicos
                    var objetivosEspecificos = dc.SP_ListarObjetivosEspecificos(empresaId).ToList();

                    if (objetivosEspecificos.Count > 0) txtObjetivoE1.Text = objetivosEspecificos.ElementAtOrDefault(0)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 1) txtObjetivoE2.Text = objetivosEspecificos.ElementAtOrDefault(1)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 2) txtObjetivoE3.Text = objetivosEspecificos.ElementAtOrDefault(2)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 3) txtObjetivoE4.Text = objetivosEspecificos.ElementAtOrDefault(3)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 4) txtObjetivoE5.Text = objetivosEspecificos.ElementAtOrDefault(4)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 5) txtObjetivoE6.Text = objetivosEspecificos.ElementAtOrDefault(5)?.ObjetivoE_Descripcion ?? "";

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

                    // Listar Matriz CAME
                    var came = dc.SP_ListarMatrizCAME(empresaId).ToList();

                    if (came.Count > 0) txtt1.Text = came.ElementAtOrDefault(0)?.descripcion?? "";
                    if (came.Count > 1) txtt2.Text = came.ElementAtOrDefault(1)?.descripcion ?? "";
                    if (came.Count > 2) txtt3.Text = came.ElementAtOrDefault(2)?.descripcion ?? "";
                    if (came.Count > 3) txtt4.Text = came.ElementAtOrDefault(3)?.descripcion ?? "";
                    if (came.Count > 4) txtt5.Text = came.ElementAtOrDefault(4)?.descripcion ?? "";
                    if (came.Count > 5) txtt6.Text = came.ElementAtOrDefault(5)?.descripcion ?? "";
                    if (came.Count > 6) txtt7.Text = came.ElementAtOrDefault(6)?.descripcion ?? "";
                    if (came.Count > 7) txtt8.Text = came.ElementAtOrDefault(7)?.descripcion ?? "";
                    if (came.Count > 8) txtt9.Text = came.ElementAtOrDefault(8)?.descripcion ?? "";
                    if (came.Count > 9) txtt10.Text = came.ElementAtOrDefault(9)?.descripcion ?? "";
                    if (came.Count > 10) txtt11.Text = came.ElementAtOrDefault(10)?.descripcion ?? "";
                    if (came.Count > 11) txtt12.Text = came.ElementAtOrDefault(11)?.descripcion ?? "";
                    if (came.Count > 12) txtt13.Text = came.ElementAtOrDefault(12)?.descripcion ?? "";
                    if (came.Count > 13) txtt14.Text = came.ElementAtOrDefault(13)?.descripcion ?? "";
                    if (came.Count > 14) txtt15.Text = came.ElementAtOrDefault(14)?.descripcion ?? "";
                    if (came.Count > 15) txtt16.Text = came.ElementAtOrDefault(15)?.descripcion ?? "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Lógica para el botón, si es necesario
        }

        private void txtMision_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void FrmResumen_Load(object sender, EventArgs e)
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

        private void txtD1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtO3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
