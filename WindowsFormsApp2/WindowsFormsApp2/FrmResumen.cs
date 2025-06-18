using System;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public partial class FrmResumen : Form
    {
        // Variables para impresión por texto, multipágina
        private int currentLine = 0;
        private List<string> linesToPrint;
        private List<Font> lineFonts;
        private List<Brush> lineBrushes;

        public FrmResumen()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                int usuarioId = Sesion.UsuarioId;
                int empresaId = Sesion.EmpresaId;
                MessageBox.Show("ID de empresa registrado: " + empresaId, "ID Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var dc = new DataClasses3DataContext())
                {
                    var mision = dc.SP_ListarMisionPorUsuario(empresaId).FirstOrDefault();
                    if (mision != null)
                    {
                        txtMision.Text = mision.descripcion;
                        txtMisionO.Text = mision.descripcion;
                    }
                    var vision = dc.SP_ListarVisionPorUsuario(empresaId).FirstOrDefault();
                    if (vision != null)
                    {
                        txtVision.Text = vision.descripcion;
                    }
                    var valores = dc.SP_ListarValores(empresaId).FirstOrDefault();
                    if (valores != null)
                    {
                        txtValores.Text = valores.descripcion;
                    }
                    var empresa = dc.Empresa.FirstOrDefault(e => e.id == empresaId);
                    if (empresa != null)
                    {
                        txtEmpresa.Text = empresa.nombre;
                    }
                    if (mision != null)
                    {
                        txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    var usuario = dc.USUARIO.FirstOrDefault(u => u.id == usuarioId);
                    if (usuario != null)
                    {
                        txtEmprendedor.Text = usuario.email;
                    }
                    var unid_estrat = dc.SP_ListarUnidEstraPorEmpresa(empresaId).FirstOrDefault();
                    if (unid_estrat != null)
                    {
                        txtUnidadEstrategica.Text = unid_estrat.descripcion;
                    }
                    var objetivosGenerales = dc.SP_ListarObjetivosGenerales(empresaId).ToList();
                    if (objetivosGenerales.Count > 0) txtObjetivoG1.Text = objetivosGenerales.ElementAtOrDefault(0)?.ObjetivoG_Descripcion ?? "";
                    if (objetivosGenerales.Count > 1) txtObjetivoG2.Text = objetivosGenerales.ElementAtOrDefault(1)?.ObjetivoG_Descripcion ?? "";
                    if (objetivosGenerales.Count > 2) txtObjetivoG3.Text = objetivosGenerales.ElementAtOrDefault(2)?.ObjetivoG_Descripcion ?? "";
                    var objetivosEspecificos = dc.SP_ListarObjetivosEspecificos(empresaId).ToList();
                    if (objetivosEspecificos.Count > 0) txtObjetivoE1.Text = objetivosEspecificos.ElementAtOrDefault(0)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 1) txtObjetivoE2.Text = objetivosEspecificos.ElementAtOrDefault(1)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 2) txtObjetivoE3.Text = objetivosEspecificos.ElementAtOrDefault(2)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 3) txtObjetivoE4.Text = objetivosEspecificos.ElementAtOrDefault(3)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 4) txtObjetivoE5.Text = objetivosEspecificos.ElementAtOrDefault(4)?.ObjetivoE_Descripcion ?? "";
                    if (objetivosEspecificos.Count > 5) txtObjetivoE6.Text = objetivosEspecificos.ElementAtOrDefault(5)?.ObjetivoE_Descripcion ?? "";
                    var fortalezas = dc.SP_ListarFortalezas(empresaId).ToList();
                    if (fortalezas.Count > 0) txtF1.Text = fortalezas.ElementAtOrDefault(0)?.Fortaleza_Descripcion ?? "";
                    if (fortalezas.Count > 1) txtF2.Text = fortalezas.ElementAtOrDefault(1)?.Fortaleza_Descripcion ?? "";
                    var debilidades = dc.SP_ListarDebilidades(empresaId).ToList();
                    if (debilidades.Count > 0) txtD1.Text = debilidades.ElementAtOrDefault(0)?.Debilidad_Descripcion ?? "";
                    if (debilidades.Count > 1) txtD2.Text = debilidades.ElementAtOrDefault(1)?.Debilidad_Descripcion ?? "";
                    var oportunidades = dc.SP_ListarOportunidades(empresaId).ToList();
                    if (oportunidades.Count > 0) txtO1.Text = oportunidades.ElementAtOrDefault(0)?.Oportunidad_Descripcion ?? "";
                    if (oportunidades.Count > 1) txtO2.Text = oportunidades.ElementAtOrDefault(1)?.Oportunidad_Descripcion ?? "";
                    if (oportunidades.Count > 2) txtO3.Text = oportunidades.ElementAtOrDefault(2)?.Oportunidad_Descripcion ?? "";
                    if (oportunidades.Count > 3) txtO4.Text = oportunidades.ElementAtOrDefault(3)?.Oportunidad_Descripcion ?? "";
                    var amenazas = dc.SP_ListarAmenazas(empresaId).ToList();
                    if (amenazas.Count > 0) txtA1.Text = amenazas.ElementAtOrDefault(0)?.Amenaza_Descripcion ?? "";
                    if (amenazas.Count > 1) txtA2.Text = amenazas.ElementAtOrDefault(1)?.Amenaza_Descripcion ?? "";
                    if (amenazas.Count > 2) txtA3.Text = amenazas.ElementAtOrDefault(2)?.Amenaza_Descripcion ?? "";
                    if (amenazas.Count > 3) txtA4.Text = amenazas.ElementAtOrDefault(3)?.Amenaza_Descripcion ?? "";
                    var came = dc.SP_ListarMatrizCAME(empresaId).ToList();
                    if (came.Count > 0) txtt1.Text = came.ElementAtOrDefault(0)?.descripcion ?? "";
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

        // Método para preparar PrintDocument 
        private PrintDocument CrearPrintDocument()
        {
            linesToPrint = new List<string>
            {
                "RESUMEN DE PLAN ESTRATÉGICO",
                "Fecha: " + txtFecha.Text,
                "",
                "Empresa: " + txtEmpresa.Text,
                "Emprendedor: " + txtEmprendedor.Text,
                "",
                "Misión",
                txtMision.Text,
                "",
                "Visión",
                txtVision.Text,
                "",
                "Valores",
                txtValores.Text,
                "",
                "Unidad Estratégica",
                txtUnidadEstrategica.Text,
                "",
                "Objetivos Generales",
                "  1. " + txtObjetivoG1.Text,
                "  2. " + txtObjetivoG2.Text,
                "  3. " + txtObjetivoG3.Text,
                "",
                "Objetivos Específicos",
                "  1. " + txtObjetivoE1.Text,
                "  2. " + txtObjetivoE2.Text,
                "  3. " + txtObjetivoE3.Text,
                "  4. " + txtObjetivoE4.Text,
                "  5. " + txtObjetivoE5.Text,
                "  6. " + txtObjetivoE6.Text,
                "",
                "Fortalezas",
                "  1. " + txtF1.Text,
                "  2. " + txtF2.Text,
                "",
                "Debilidades",
                "  1. " + txtD1.Text,
                "  2. " + txtD2.Text,
                "",
                "Oportunidades",
                "  1. " + txtO1.Text,
                "  2. " + txtO2.Text,
                "  3. " + txtO3.Text,
                "  4. " + txtO4.Text,
                "",
                "Amenazas",
                "  1. " + txtA1.Text,
                "  2. " + txtA2.Text,
                "  3. " + txtA3.Text,
                "  4. " + txtA4.Text,
                "",
                "Matriz CAME",
                "  1. " + txtt1.Text,
                "  2. " + txtt2.Text,
                "  3. " + txtt3.Text,
                "  4. " + txtt4.Text,
                "  5. " + txtt5.Text,
                "  6. " + txtt6.Text,
                "  7. " + txtt7.Text,
                "  8. " + txtt8.Text,
                "  9. " + txtt9.Text,
                " 10. " + txtt10.Text,
                " 11. " + txtt11.Text,
                " 12. " + txtt12.Text,
                " 13. " + txtt13.Text,
                " 14. " + txtt14.Text,
                " 15. " + txtt15.Text,
                " 16. " + txtt16.Text,
            };

            lineFonts = new List<Font>();
            lineBrushes = new List<Brush>();
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font sectionFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11, FontStyle.Regular);
            Brush titleBrush = Brushes.DarkBlue;
            Brush sectionBrush = Brushes.DarkGreen;
            Brush normalBrush = Brushes.Black;

            foreach (var line in linesToPrint)
            {
                if (line == "RESUMEN DE PLAN ESTRATÉGICO")
                {
                    lineFonts.Add(titleFont);
                    lineBrushes.Add(titleBrush);
                }
                else if (
                    line == "Misión" || line == "Visión" || line == "Valores" ||
                    line == "Unidad Estratégica" || line == "Objetivos Generales" ||
                    line == "Objetivos Específicos" || line == "Fortalezas" ||
                    line == "Debilidades" || line == "Oportunidades" ||
                    line == "Amenazas" || line == "Matriz CAME"
                )
                {
                    lineFonts.Add(sectionFont);
                    lineBrushes.Add(sectionBrush);
                }
                else
                {
                    lineFonts.Add(normalFont);
                    lineBrushes.Add(normalBrush);
                }
            }

            currentLine = 0; // ¡Siempre reinicia aquí!
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage_Text;
            return printDoc;
        }

        private void PrintDoc_PrintPage_Text(object sender, PrintPageEventArgs e)
        {
            int y = e.MarginBounds.Top;
            int spacing = 2;
            while (currentLine < linesToPrint.Count)
            {
                var font = lineFonts[currentLine];
                var brush = lineBrushes[currentLine];
                int lineHeight = (int)e.Graphics.MeasureString(linesToPrint[currentLine], font).Height + spacing;

                if (currentLine > 0 && (font.Style & FontStyle.Bold) != 0 &&
                    (lineFonts[currentLine - 1].Style & FontStyle.Bold) == 0)
                {
                    y += spacing;
                    e.Graphics.DrawLine(Pens.Gray, e.MarginBounds.Left, y, e.MarginBounds.Right, y);
                    y += 4;
                }

                e.Graphics.DrawString(linesToPrint[currentLine], font, brush, e.MarginBounds.Left, y);
                y += lineHeight;
                currentLine++;
                if (y + lineHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var printDoc = CrearPrintDocument();
            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            var printDoc = CrearPrintDocument();
            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = printDoc;
            previewDlg.Width = 900;
            previewDlg.Height = 700;
            previewDlg.ShowDialog();
        }
    }
}