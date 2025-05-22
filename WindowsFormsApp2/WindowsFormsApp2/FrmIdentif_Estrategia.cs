using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmIdentif_Estrategia : Form
    {
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
            // FO usa prefijo 'O' en txtO{col}_F{fila}_FO
            AsociarEventosGrupo("FO", "O");
        }

        private void AsociarEventosGrupoFA()
        {
            // FA usa prefijo 'A' en txtA1_F1_FA (solo 1 columna?)
            // Asumiendo que también hay hasta 4 columnas (txtA1, txtA2...) si no ajusta aquí
            AsociarEventosGrupo("FA", "A");
        }

        private void AsociarEventosGrupoDO()
        {
            // DO usa prefijo 'O'
            AsociarEventosGrupo("DO", "O");
        }

        private void AsociarEventosGrupoDA()
        {
            // DA usa prefijo 'A'
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

                // Mostrar total de columna
                string nombreTotalCol = $"txtTotal{prefijo}{col}_{grupo}";
                Control[] controlesTotal = this.Controls.Find(nombreTotalCol, true);
                if (controlesTotal.Length > 0 && controlesTotal[0] is TextBox txtTotalCol)
                {
                    txtTotalCol.Text = sumaColumna.ToString("0.##");
                }

                totalColumnas[col - 1] = sumaColumna;
            }

            // Calcular total general
            totalGeneral = totalColumnas.Sum();

            Control[] controlesTotalGeneral = this.Controls.Find($"txtTotalF1234_{grupo}", true);
            if (controlesTotalGeneral.Length > 0 && controlesTotalGeneral[0] is TextBox txtTotalGeneral)
            {
                txtTotalGeneral.Text = totalGeneral.ToString("0.##");
            }

            // También imprimir el total general en txtFO, txtFA, txtDO, txtDA según el grupo
            string nombreResumen = $"txt{grupo}";
            Control[] controlesResumen = this.Controls.Find(nombreResumen, true);
            if (controlesResumen.Length > 0 && controlesResumen[0] is TextBox txtResumen)
            {
                txtResumen.Text = totalGeneral.ToString("0.##");
            }
        }


        private void btnListar_Click(object sender, EventArgs e)
        {
            FrmDAFO formularioEmergente = new FrmDAFO();
            formularioEmergente.ShowDialog();
        }

        private void FrmIdentif_Estrategia_Load_1(object sender, EventArgs e)
        {

        }
    }

}
