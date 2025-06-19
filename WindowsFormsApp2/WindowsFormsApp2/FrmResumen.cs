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
            CargarObjetivos();
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
                    var fortalezas = dc.SP_ListarFortalezas(empresaId).ToList();
                    if (fortalezas.Count > 0) txtF1.Text = fortalezas.ElementAtOrDefault(0)?.Fortaleza_Descripcion ?? "";
                    if (fortalezas.Count > 1) txtF2.Text = fortalezas.ElementAtOrDefault(1)?.Fortaleza_Descripcion ?? "";
                    if (fortalezas.Count > 2) txtF3.Text = fortalezas.ElementAtOrDefault(2)?.Fortaleza_Descripcion ?? "";
                    if (fortalezas.Count > 3) txtF4.Text = fortalezas.ElementAtOrDefault(3)?.Fortaleza_Descripcion ?? "";
                    var debilidades = dc.SP_ListarDebilidades(empresaId).ToList();
                    if (debilidades.Count > 0) txtD1.Text = debilidades.ElementAtOrDefault(0)?.Debilidad_Descripcion ?? "";
                    if (debilidades.Count > 1) txtD2.Text = debilidades.ElementAtOrDefault(1)?.Debilidad_Descripcion ?? "";
                    if (debilidades.Count > 2) txtD3.Text = debilidades.ElementAtOrDefault(2)?.Debilidad_Descripcion ?? "";
                    if (debilidades.Count > 3) txtD4.Text = debilidades.ElementAtOrDefault(3)?.Debilidad_Descripcion ?? "";
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


        private PrintDocument CrearPrintDocument()
        {
            try
            {
                int empresaId = Sesion.EmpresaId;

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
            "Objetivos Generales y Específicos",
        };

                using (var dc = new DataClasses3DataContext())
                {
                    // Obtener objetivos generales
                    var objetivosGenerales = dc.ObjetivoG
                        .Where(og => og.empresa_id == empresaId)
                        .Select(og => new
                        {
                            og.id,
                            og.descripcion
                        })
                        .ToList();

                    foreach (var objetivoGeneral in objetivosGenerales)
                    {
                        // Agregar descripción del objetivo general
                        linesToPrint.Add("Objetivo General: " + objetivoGeneral.descripcion);

                        // Obtener objetivos específicos relacionados
                        var objetivosEspecificos = dc.ObjetivoE
                            .Where(oe => oe.objetivo_id == objetivoGeneral.id)
                            .Select(oe => new
                            {
                                oe.descripcion
                            })
                            .ToList();

                        foreach (var objetivoEspecifico in objetivosEspecificos)
                        {
                            // Agregar descripción del objetivo específico
                            linesToPrint.Add("  - Objetivo Específico: " + objetivoEspecifico.descripcion);
                        }

                        linesToPrint.Add(""); // Espaciado entre objetivos generales
                    }
                }

                // Agregar fortalezas, debilidades, oportunidades, amenazas y matriz CAME
                linesToPrint.Add("Fortalezas");
                linesToPrint.Add("  1. " + txtF1.Text);
                linesToPrint.Add("  2. " + txtF2.Text);
                linesToPrint.Add("  3. " + txtF3.Text);
                linesToPrint.Add("  4. " + txtF4.Text);
                linesToPrint.Add("");

                linesToPrint.Add("Debilidades");
                linesToPrint.Add("  1. " + txtD1.Text);
                linesToPrint.Add("  2. " + txtD2.Text);
                linesToPrint.Add("  3. " + txtD3.Text);
                linesToPrint.Add("  4. " + txtD4.Text);
                linesToPrint.Add("");

                linesToPrint.Add("Oportunidades");
                linesToPrint.Add("  1. " + txtO1.Text);
                linesToPrint.Add("  2. " + txtO2.Text);
                linesToPrint.Add("  3. " + txtO3.Text);
                linesToPrint.Add("  4. " + txtO4.Text);
                linesToPrint.Add("");

                linesToPrint.Add("Amenazas");
                linesToPrint.Add("  1. " + txtA1.Text);
                linesToPrint.Add("  2. " + txtA2.Text);
                linesToPrint.Add("  3. " + txtA3.Text);
                linesToPrint.Add("  4. " + txtA4.Text);
                linesToPrint.Add("");

                linesToPrint.Add("Matriz CAME");
                linesToPrint.Add("  1. " + txtt1.Text);
                linesToPrint.Add("  2. " + txtt2.Text);
                linesToPrint.Add("  3. " + txtt3.Text);
                linesToPrint.Add("  4. " + txtt4.Text);
                linesToPrint.Add("  5. " + txtt5.Text);
                linesToPrint.Add("  6. " + txtt6.Text);
                linesToPrint.Add("  7. " + txtt7.Text);
                linesToPrint.Add("  8. " + txtt8.Text);
                linesToPrint.Add("  9. " + txtt9.Text);
                linesToPrint.Add(" 10. " + txtt10.Text);
                linesToPrint.Add(" 11. " + txtt11.Text);
                linesToPrint.Add(" 12. " + txtt12.Text);
                linesToPrint.Add(" 13. " + txtt13.Text);
                linesToPrint.Add(" 14. " + txtt14.Text);
                linesToPrint.Add(" 15. " + txtt15.Text);
                linesToPrint.Add(" 16. " + txtt16.Text);

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
                        line == "Unidad Estratégica" || line == "Objetivos Generales y Específicos" ||
                        line == "Fortalezas" || line == "Debilidades" || line == "Oportunidades" ||
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar el documento para impresión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Retorna null en caso de error
            }
        }
        private void CargarObjetivos()
        {
            try
            {
                int empresaId = Sesion.EmpresaId;

                using (var dc = new DataClasses3DataContext())
                {
                    // Listar objetivos generales
                    var objetivosGenerales = dc.ObjetivoG
                        .Where(og => og.empresa_id == empresaId)
                        .Select(og => new
                        {
                            og.id,
                            og.descripcion
                        })
                        .ToList();

                    // Configurar dgvObjG para visualización
                    dgvObjG.Columns.Clear();
                    dgvObjG.Columns.Add("IdGeneral", "ID");
                    dgvObjG.Columns.Add("DescripcionGeneral", "Descripción del Objetivo General");
                    dgvObjG.Columns["IdGeneral"].Visible = false; // Ocultar columna de ID
                    dgvObjG.Columns[1].Width = 300; // Ajustar ancho de columna para la descripción
                    dgvObjG.ReadOnly = true; // Solo lectura
                    dgvObjG.AllowUserToAddRows = false; // Deshabilitar añadir filas
                    dgvObjG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Limpiar y cargar datos en dgvObjG
                    dgvObjG.Rows.Clear();
                    foreach (var objetivo in objetivosGenerales)
                    {
                        dgvObjG.Rows.Add(objetivo.id, objetivo.descripcion);
                    }

                    // Configurar evento para mostrar objetivos específicos relacionados
                    dgvObjG.CellClick += dgvObjG_CellClick;

                    // Configurar dgvObjE para visualización
                    dgvObjE.Columns.Clear();
                    dgvObjE.Columns.Add("ObjetivoEspecificoID", "ID del Objetivo Específico");
                    dgvObjE.Columns.Add("DescripcionEspecifica", "Descripción del Objetivo Específico");
                    dgvObjE.Columns["ObjetivoEspecificoID"].Visible = false; // Ocultar columna de ID
                    dgvObjE.Columns[1].Width = 300; // Ajustar ancho de columna para la descripción
                    dgvObjE.ReadOnly = true; // Solo lectura
                    dgvObjE.AllowUserToAddRows = false; // Deshabilitar añadir filas
                    dgvObjE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los objetivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            var printDoc = CrearPrintDocument();
            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var printDoc = CrearPrintDocument();
            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = printDoc;
            previewDlg.Width = 900;
            previewDlg.Height = 700;
            previewDlg.ShowDialog();
        }

        private void FrmResumen_Load(object sender, EventArgs e)
        {

        }

        private void dgvObjG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que la fila seleccionada sea válida
                if (e.RowIndex >= 0 && dgvObjG.Rows[e.RowIndex].Cells["IdGeneral"].Value != null)
                {
                    int objetivoGeneralId = Convert.ToInt32(dgvObjG.Rows[e.RowIndex].Cells["IdGeneral"].Value);

                    using (var dc = new DataClasses3DataContext())
                    {
                        // Listar objetivos específicos relacionados
                        var objetivosEspecificos = dc.ObjetivoE
                            .Where(oe => oe.objetivo_id == objetivoGeneralId)
                            .Select(oe => new
                            {
                                oe.id,
                                oe.descripcion
                            })
                            .ToList();

                        // Limpiar y cargar datos en dgvObjE
                        dgvObjE.Rows.Clear();
                        foreach (var objetivo in objetivosEspecificos)
                        {
                            dgvObjE.Rows.Add(objetivo.id, objetivo.descripcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar objetivos específicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}