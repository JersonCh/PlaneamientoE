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
    public partial class FrmAutoCadenaValor : Form
    {
        public FrmAutoCadenaValor()
        {
            InitializeComponent();
            CargarAutoCadenaValorExistente();
        }
        string f1;
        string f2;
        string d1;
        string d2;
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarAutoCadenaValorExistente()
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    var resultado = dc.SP_ObtenerAutoCadenaValor(Sesion.EmpresaId);

                    foreach (var autoCadena in resultado)
                    {
                        // Array con los valores de las 25 preguntas
                        int[] valores = {
                            autoCadena.p1, autoCadena.p2, autoCadena.p3, autoCadena.p4, autoCadena.p5,
                            autoCadena.p6, autoCadena.p7, autoCadena.p8, autoCadena.p9, autoCadena.p10,
                            autoCadena.p11, autoCadena.p12, autoCadena.p13, autoCadena.p14, autoCadena.p15,
                            autoCadena.p16, autoCadena.p17, autoCadena.p18, autoCadena.p19, autoCadena.p20,
                            autoCadena.p21, autoCadena.p22, autoCadena.p23, autoCadena.p24, autoCadena.p25
                        };

                        // Marcar los RadioButtons correspondientes
                        for (int i = 1; i <= 25; i++)
                        {
                            int valorPregunta = valores[i - 1];

                            // Buscar el panel de la pregunta i
                            Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                            if (panel != null)
                            {
                                // Buscar el RadioButton con el valor correspondiente
                                string nombreRadioButton = $"p{i}_{valorPregunta}";
                                RadioButton rb = panel.Controls.Find(nombreRadioButton, false).FirstOrDefault() as RadioButton;
                                if (rb != null)
                                {
                                    rb.Checked = true;
                                }
                            }
                        }

                        // Mostrar el total
                        txtTotal.Text = autoCadena.total.ToString() + "%";

                        return; // Solo tomar el primer resultado
                    }

                    // Si no hay datos, limpiar todo
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar AutoCadenaValor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            // Desmarcar todos los RadioButtons
            for (int i = 1; i <= 25; i++)
            {
                Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
                    {
                        rb.Checked = false;
                    }
                }
            }

            // Limpiar el total
            txtTotal.Text = "";
        }






        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int total = 0;
            double total2 = 0;

            // Array para almacenar los valores de cada pregunta
            int[] valoresPreguntas = new int[25];

            for (int i = 1; i <= 25; i++)
            {
                Panel panel = this.Controls.Find($"p{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
                    {
                        if (rb.Checked)
                        {
                            // Extrae el valor del nombre, por ejemplo "p1_4" -> 4
                            string[] parts = rb.Name.Split('_');
                            if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                            {
                                total += value;
                                valoresPreguntas[i - 1] = value; // Guardar el valor de esta pregunta
                            }
                            break; // Ya encontramos el seleccionado en este panel
                        }
                    }
                }
            }

            total2 = 1 - (total / 100.0);
            int total3;
            total3 = (int)(total2 * 100);
            txtTotal.Text = (total2 * 100).ToString() + "%";

            // Guardar en base de datos
            GuardarAutoCadenaValor(valoresPreguntas, total3);
        }

        private void GuardarAutoCadenaValor(int[] valores, int total3)
        {
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    // Llamar al procedimiento almacenado
                    var resultado = dc.SP_InsertarOActualizarAutoCadenaValor(
                        Sesion.EmpresaId,  // empresa_id
                        valores[0],   // p1
                        valores[1],   // p2
                        valores[2],   // p3
                        valores[3],   // p4
                        valores[4],   // p5
                        valores[5],   // p6
                        valores[6],   // p7
                        valores[7],   // p8
                        valores[8],   // p9
                        valores[9],   // p10
                        valores[10],  // p11
                        valores[11],  // p12
                        valores[12],  // p13
                        valores[13],  // p14
                        valores[14],  // p15
                        valores[15],  // p16
                        valores[16],  // p17
                        valores[17],  // p18
                        valores[18],  // p19
                        valores[19],  // p20
                        valores[20],  // p21
                        valores[21],  // p22
                        valores[22],  // p23
                        valores[23],  // p24
                        valores[24],  // p25
                        total3         // total
                    );

                    // Mostrar mensaje según el resultado
                    var primerResultado = resultado.FirstOrDefault();
                    if (primerResultado != null)
                    {
                        string accion = primerResultado.Resultado;
                        if (accion == "INSERTADO")
                        {
                            MessageBox.Show("AutoCadenaValor registrada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (accion == "ACTUALIZADO")
                        {
                            MessageBox.Show("AutoCadenaValor actualizada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar AutoCadenaValor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtF1.Text) || string.IsNullOrWhiteSpace(txtF2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    string f1 = txtF1.Text.Trim();
                    string f2 = txtF2.Text.Trim();

                    dc.SP_RegistrarFortaleza(f1, Sesion.EmpresaId);
                    dc.SP_RegistrarFortaleza(f2, Sesion.EmpresaId);
                }

                MessageBox.Show("Fortalezas registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar las Fortalezas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrWhiteSpace(txtD1.Text) || string.IsNullOrWhiteSpace(txtD2.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    string D1 = txtD1.Text.Trim();
                    string D2 = txtD2.Text.Trim();

                    dc.SP_RegistrarDebilidad(D1, Sesion.EmpresaId);
                    dc.SP_RegistrarDebilidad(D2, Sesion.EmpresaId);
                }

                MessageBox.Show("Debilidades registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar las debilidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmAutoCadenaValor_Load(object sender, EventArgs e)
        {

        }
    }
}
