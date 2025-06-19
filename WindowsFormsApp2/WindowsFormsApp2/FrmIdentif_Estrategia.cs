using CustomMessageBox;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmIdentif_Estrategia : Form
    {
        private string estrategiaDescripcionAlta; // Variable para guardar la descripción de la estrategia más alta
        private int empresaId = Sesion.EmpresaId; // ID de la empresa (asumiendo que está disponible en la sesión)

        public FrmIdentif_Estrategia()
        {
            InitializeComponent();
            this.Load += FrmIdentif_Estrategia_Load;
        }

        private void FrmIdentif_Estrategia_Load(object sender, EventArgs e)
        {
            AsociarEventosGrupoFO();
            AsociarEventosGrupoFA();
            AsociarEventosGrupoDO();
            AsociarEventosGrupoDA();
        }

        private void AsociarEventosGrupoFO()
        {
            AsociarEventosGrupo("FO", "O");
        }

        private void AsociarEventosGrupoFA()
        {
            AsociarEventosGrupo("FA", "A");
        }

        private void AsociarEventosGrupoDO()
        {
            AsociarEventosGrupo("DO", "O");
        }

        private void AsociarEventosGrupoDA()
        {
            AsociarEventosGrupo("DA", "A");
        }

        private void AsociarEventosGrupo(string grupo, string prefijo)
        {
            int filas = 4;
            int columnas = 4;

            for (int fila = 1; fila <= filas; fila++)
            {
                for (int col = 1; col <= columnas; col++)
                {
                    string nombre = $"txt{prefijo}{col}_F{fila}_{grupo}";
                    Control[] controles = this.Controls.Find(nombre, true);
                    if (controles.Length > 0 && controles[0] is TextBox txt)
                    {
                        txt.TextChanged += (s, e) => CalcularTotalesGrupo(grupo, prefijo);
                    }
                }
            }
        }

        private void CalcularTotalesGrupo(string grupo, string prefijo)
        {
            int columnas = 4;
            int filas = 4;

            double[] totalColumnas = new double[columnas];
            double totalGeneral = 0;

            for (int col = 1; col <= columnas; col++)
            {
                double sumaColumna = 0;
                for (int fila = 1; fila <= filas; fila++)
                {
                    string nombre = $"txt{prefijo}{col}_F{fila}_{grupo}";
                    Control[] controles = this.Controls.Find(nombre, true);
                    if (controles.Length > 0 && controles[0] is TextBox txt)
                    {
                        if (double.TryParse(txt.Text, out double valor))
                        {
                            sumaColumna += valor;
                        }
                    }
                }

                string nombreTotalCol = $"txtTotal{prefijo}{col}_{grupo}";
                Control[] controlesTotal = this.Controls.Find(nombreTotalCol, true);
                if (controlesTotal.Length > 0 && controlesTotal[0] is TextBox txtTotalCol)
                {
                    txtTotalCol.Text = sumaColumna.ToString("0.##");
                }

                totalColumnas[col - 1] = sumaColumna;
            }

            totalGeneral = totalColumnas.Sum();

            Control[] controlesTotalGeneral = this.Controls.Find($"txtTotalF1234_{grupo}", true);
            if (controlesTotalGeneral.Length > 0 && controlesTotalGeneral[0] is TextBox txtTotalGeneral)
            {
                txtTotalGeneral.Text = totalGeneral.ToString("0.##");
            }

            string nombreResumen = $"txt{grupo}";
            Control[] controlesResumen = this.Controls.Find(nombreResumen, true);
            if (controlesResumen.Length > 0 && controlesResumen[0] is TextBox txtResumen)
            {
                txtResumen.Text = totalGeneral.ToString("0.##");
            }

            ActualizarEstrategiaDescripcionAlta();
        }

        private void ActualizarEstrategiaDescripcionAlta()
        {
            double puntuacionFO = ObtenerPuntuacion("FO");
            double puntuacionFA = ObtenerPuntuacion("FA");
            double puntuacionDO = ObtenerPuntuacion("DO");
            double puntuacionDA = ObtenerPuntuacion("DA");

            estrategiaDescripcionAlta = DeterminarDescripcionEstrategiaMasAlta(puntuacionFO, puntuacionFA, puntuacionDO, puntuacionDA);
        }

        private double ObtenerPuntuacion(string grupo)
        {
            Control[] controles = this.Controls.Find($"txt{grupo}", true);
            if (controles.Length > 0 && controles[0] is TextBox txt)
            {
                if (double.TryParse(txt.Text, out double valor))
                {
                    return valor;
                }
            }
            return 0;
        }

        private string DeterminarDescripcionEstrategiaMasAlta(double puntuacionFO, double puntuacionFA, double puntuacionDO, double puntuacionDA)
        {
            double puntuacionMaxima = Math.Max(Math.Max(puntuacionFO, puntuacionFA), Math.Max(puntuacionDO, puntuacionDA));

            if (puntuacionMaxima == puntuacionFO) return "Debera adoptar estrategias de crecimiento.";
            if (puntuacionMaxima == puntuacionFA) return "La empresa está preparada para enfrentarse a las amenazas.";
            if (puntuacionMaxima == puntuacionDO) return "La empresa no puede aprovechar las oportunidades porque carece de preparación adecuada.";
            if (puntuacionMaxima == puntuacionDA) return "Se enfrenta a amenazas externas sin las fortalezas necesarias para luchar con la competencia.";

            return string.Empty;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string descripcion = estrategiaDescripcionAlta?.Trim();

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor, seleccione una estrategia válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    dc.SP_RegistrarIDENT_ESTRA(descripcion, empresaId);
                }

                // Mostrar mensaje de éxito utilizando RJMessageBox
                DialogResult result = RJMessageBox.Show("Estrategia registrada correctamente", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la estrategia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmIdentif_Estrategia_Load_1(object sender, EventArgs e)
        {
            AsociarEventosGrupoFO();
            AsociarEventosGrupoFA();
            AsociarEventosGrupoDO();
            AsociarEventosGrupoDA();
        }
    }
}