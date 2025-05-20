using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmAutodiagnosticoBCG_2 : Form
    {
        public FrmAutodiagnosticoBCG_2()
        {
            InitializeComponent();
            ConfigurarTextBoxesTCM();
            ConfigurarTextBoxesBCG();
            AgregarEventosActualizacionBCG();
            // Configurar TextBoxes para que no sean editables
            ConfigurarTextBoxesDeValoresDuplicados();

            // Agregar eventos para calcular el valor máximo
            AgregarEventosParaValorMaximo();

            // Agregar eventos para duplicar valores
            AgregarEventosParaDuplicacion();
            // Configurar los textbox de porcentajes y totales como de solo lectura
            txtbox6.ReadOnly = true;
            txtbox7.ReadOnly = true;
            txtbox8.ReadOnly = true;
            txtbox9.ReadOnly = true;
            txtbox10.ReadOnly = true;
            txttotal1.ReadOnly = true;
            txttotal2.ReadOnly = true;
            txtmayp1.ReadOnly = true;
            txtmayp2.ReadOnly = true;
            txtmayp3.ReadOnly = true;
            txtmayp4.ReadOnly = true;
            txtmayp5.ReadOnly = true;

            // Inicializar los porcentajes a 0.0%
            txtbox6.Text = "0.0%";
            txtbox7.Text = "0.0%";
            txtbox8.Text = "0.0%";
            txtbox9.Text = "0.0%";
            txtbox10.Text = "0.0%";

            // Inicializar los totales a 0
            txttotal1.Text = "0";
            txttotal2.Text = "0.0%";
        }

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerrar formulario activo si ya hay uno
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls[0].Dispose();

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.Show();
        }
        private void ConfigurarTextBoxesBCG()
        {
            // Configurar los TextBoxes de resultados de BCG para que sean de solo lectura
            txtbox36.ReadOnly = true;
            txtbox37.ReadOnly = true;
            txtbox38.ReadOnly = true;
            txtbox39.ReadOnly = true;
            txtbox40.ReadOnly = true;

            txtbox41.ReadOnly = true;
            txtbox42.ReadOnly = true;
            txtbox43.ReadOnly = true;
            txtbox44.ReadOnly = true;
            txtbox45.ReadOnly = true;

            txtbox46.ReadOnly = true;
            txtbox47.ReadOnly = true;
            txtbox48.ReadOnly = true;
            txtbox49.ReadOnly = true;
            txtbox50.ReadOnly = true;
        }

        private void AgregarEventosActualizacionBCG()
        {
            // Agregar evento Leave a todos los TextBoxes de TCM para actualizar resultados BCG
            // Producto 1
            txtbox11.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox16.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox21.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox26.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox31.Leave += new EventHandler(ActualizarResultadosBCG);

            // Producto 2
            txtbox12.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox17.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox22.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox27.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox32.Leave += new EventHandler(ActualizarResultadosBCG);

            // Producto 3
            txtbox13.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox18.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox23.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox28.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox33.Leave += new EventHandler(ActualizarResultadosBCG);

            // Producto 4
            txtbox14.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox19.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox24.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox29.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox34.Leave += new EventHandler(ActualizarResultadosBCG);

            // Producto 5
            txtbox15.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox20.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox25.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox30.Leave += new EventHandler(ActualizarResultadosBCG);
            txtbox35.Leave += new EventHandler(ActualizarResultadosBCG);

            // Agregar eventos para los campos que afectan al PRM
            txtbox1.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox2.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox3.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox4.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox5.TextChanged += new EventHandler(ActualizarResultadosBCG);

            // Agregar eventos para los valores de mayores participantes
            txtmayp1.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtmayp2.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtmayp3.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtmayp4.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtmayp5.TextChanged += new EventHandler(ActualizarResultadosBCG);

            // Agregar eventos para los porcentajes de ventas
            txtbox6.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox7.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox8.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox9.TextChanged += new EventHandler(ActualizarResultadosBCG);
            txtbox10.TextChanged += new EventHandler(ActualizarResultadosBCG);
        }

        private void ActualizarResultadosBCG(object sender, EventArgs e)
        {
            // Calcular y actualizar todos los resultados BCG
            CalcularYActualizarTCM();
            CalcularYActualizarPRM();
            ActualizarPorcentajeVentas();
        }

        private void CalcularYActualizarTCM()
        {
            // TCM Producto 1
            double tcmProducto1 = CalcularTCM(txtbox11, txtbox16, txtbox21, txtbox26, txtbox31);
            txtbox36.Text = tcmProducto1.ToString("0.00") + "%";

            // TCM Producto 2
            double tcmProducto2 = CalcularTCM(txtbox12, txtbox17, txtbox22, txtbox27, txtbox32);
            txtbox37.Text = tcmProducto2.ToString("0.00") + "%";

            // TCM Producto 3
            double tcmProducto3 = CalcularTCM(txtbox13, txtbox18, txtbox23, txtbox28, txtbox33);
            txtbox38.Text = tcmProducto3.ToString("0.00") + "%";

            // TCM Producto 4
            double tcmProducto4 = CalcularTCM(txtbox14, txtbox19, txtbox24, txtbox29, txtbox34);
            txtbox39.Text = tcmProducto4.ToString("0.00") + "%";

            // TCM Producto 5
            double tcmProducto5 = CalcularTCM(txtbox15, txtbox20, txtbox25, txtbox30, txtbox35);
            txtbox40.Text = tcmProducto5.ToString("0.00") + "%";
        }

        private double CalcularTCM(TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, TextBox tb5)
        {
            // Fórmula: SI(SUMA(valores)/5>0.2;0.2;SUMA(valores)/5)
            double suma = 0;
            int contadorValidos = 0;

            // Sumar los valores de los TextBoxes (quitando el símbolo %)
            suma += ObtenerValorNumerico(tb1, ref contadorValidos);
            suma += ObtenerValorNumerico(tb2, ref contadorValidos);
            suma += ObtenerValorNumerico(tb3, ref contadorValidos);
            suma += ObtenerValorNumerico(tb4, ref contadorValidos);
            suma += ObtenerValorNumerico(tb5, ref contadorValidos);

            // Evitar división por cero
            if (contadorValidos == 0)
                return 0;

            double promedio = suma / contadorValidos;

            // Aplicar la condición: si el promedio es mayor a 20%, devolver 20%
            return (promedio > 20) ? 20 : promedio;
        }

        private double ObtenerValorNumerico(TextBox tb, ref int contadorValidos)
        {
            if (!string.IsNullOrWhiteSpace(tb.Text))
            {
                string valorTexto = tb.Text.Replace("%", "").Trim();
                if (double.TryParse(valorTexto, out double valor))
                {
                    contadorValidos++;
                    return valor;
                }
            }
            return 0;
        }

        private void CalcularYActualizarPRM()
        {
            // PRM Producto 1: =SI(C57=0;0;SI(D13/C57>2;2;D13/C57))
            txtbox41.Text = CalcularPRM(txtbox1, txtmayp1).ToString("0.00");

            // PRM Producto 2: =SI(E57=0;0;SI(D14/E57>2;2;D14/E57))
            txtbox42.Text = CalcularPRM(txtbox2, txtmayp2).ToString("0.00");

            // PRM Producto 3
            txtbox43.Text = CalcularPRM(txtbox3, txtmayp3).ToString("0.00");

            // PRM Producto 4
            txtbox44.Text = CalcularPRM(txtbox4, txtmayp4).ToString("0.00");

            // PRM Producto 5
            txtbox45.Text = CalcularPRM(txtbox5, txtmayp5).ToString("0.00");
        }

        private double CalcularPRM(TextBox txtValor, TextBox txtMayor)
        {
            double valor = 0;
            double mayor = 0;

            // Obtener el valor del producto
            if (!string.IsNullOrWhiteSpace(txtValor.Text))
            {
                double.TryParse(txtValor.Text.Replace("%", "").Trim(), out valor);
            }

            // Obtener el valor del mayor participante
            if (!string.IsNullOrWhiteSpace(txtMayor.Text))
            {
                double.TryParse(txtMayor.Text.Replace("%", "").Trim(), out mayor);
            }

            // Aplicar la fórmula: SI(mayor=0;0;SI(valor/mayor>2;2;valor/mayor))
            if (mayor == 0)
                return 0;

            double resultado = valor / mayor;
            return (resultado > 2) ? 2 : resultado;
        }

        private void ActualizarPorcentajeVentas()
        {
            // Para producto 1 (usar txtbox6 y redondear a entero)
            txtbox46.Text = RedondearPorcentajeVentas(txtbox6);

            // Para producto 2 (usar txtbox7 y redondear a entero)
            txtbox47.Text = RedondearPorcentajeVentas(txtbox7);

            // Para producto 3 (usar txtbox8 y redondear a entero)
            txtbox48.Text = RedondearPorcentajeVentas(txtbox8);

            // Para producto 4 (usar txtbox9 y redondear a entero)
            txtbox49.Text = RedondearPorcentajeVentas(txtbox9);

            // Para producto 5 (usar txtbox10 y redondear a entero)
            txtbox50.Text = RedondearPorcentajeVentas(txtbox10);
        }

        private string RedondearPorcentajeVentas(TextBox tb)
        {
            if (!string.IsNullOrWhiteSpace(tb.Text))
            {
                string valorTexto = tb.Text.Replace("%", "").Trim();
                if (double.TryParse(valorTexto, out double valor))
                {
                    // Redondear a número entero y agregar símbolo %
                    return Math.Round(valor).ToString() + "%";
                }
            }
            return "0%";
        }

        // Validación para aceptar solo números enteros en los textbox 1-5
        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ActualizarCalculos()
        {
            // Obtener valores de los textbox 1-5
            int valor1 = string.IsNullOrEmpty(txtbox1.Text) ? 0 : int.Parse(txtbox1.Text);
            int valor2 = string.IsNullOrEmpty(txtbox2.Text) ? 0 : int.Parse(txtbox2.Text);
            int valor3 = string.IsNullOrEmpty(txtbox3.Text) ? 0 : int.Parse(txtbox3.Text);
            int valor4 = string.IsNullOrEmpty(txtbox4.Text) ? 0 : int.Parse(txtbox4.Text);
            int valor5 = string.IsNullOrEmpty(txtbox5.Text) ? 0 : int.Parse(txtbox5.Text);

            // Calcular el total
            int total = valor1 + valor2 + valor3 + valor4 + valor5;
            txttotal1.Text = total.ToString();

            // Calcular y mostrar los porcentajes si el total no es cero
            if (total > 0)
            {
                double porcentaje1 = (double)valor1 / total * 100;
                double porcentaje2 = (double)valor2 / total * 100;
                double porcentaje3 = (double)valor3 / total * 100;
                double porcentaje4 = (double)valor4 / total * 100;
                double porcentaje5 = (double)valor5 / total * 100;

                txtbox6.Text = porcentaje1.ToString("0.00") + "%";
                txtbox7.Text = porcentaje2.ToString("0.00") + "%";
                txtbox8.Text = porcentaje3.ToString("0.00") + "%";
                txtbox9.Text = porcentaje4.ToString("0.00") + "%";
                txtbox10.Text = porcentaje5.ToString("0.00") + "%";

                // El total de los porcentajes siempre debe ser 100%
                txttotal2.Text = "100.00%";
            }
            else
            {
                // Si el total es cero, todos los porcentajes serán 0.0%
                txtbox6.Text = "0.0%";
                txtbox7.Text = "0.0%";
                txtbox8.Text = "0.0%";
                txtbox9.Text = "0.0%";
                txtbox10.Text = "0.0%";
                txttotal2.Text = "0.0%";
            }
        }
        private void FrmAutodiagnosticoBCG_2_Load(object sender, EventArgs e)
        {

        }

        private void txtbox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotal1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotal2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfigurarTextBoxesTCM()
        {
            // Asignar eventos a cada TextBox de TCM
            // TextBox del 11 al 35
            txtbox11.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox12.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox13.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox14.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox15.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox16.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox17.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox18.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox19.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox20.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox21.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox22.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox23.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox24.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox25.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox26.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox27.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox28.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox29.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox30.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox31.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox32.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox33.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox34.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);
            txtbox35.KeyPress += new KeyPressEventHandler(ValidarNumeroDecimal);

            txtbox11.Leave += new EventHandler(FormatearPorcentaje);
            txtbox12.Leave += new EventHandler(FormatearPorcentaje);
            txtbox13.Leave += new EventHandler(FormatearPorcentaje);
            txtbox14.Leave += new EventHandler(FormatearPorcentaje);
            txtbox15.Leave += new EventHandler(FormatearPorcentaje);
            txtbox16.Leave += new EventHandler(FormatearPorcentaje);
            txtbox17.Leave += new EventHandler(FormatearPorcentaje);
            txtbox18.Leave += new EventHandler(FormatearPorcentaje);
            txtbox19.Leave += new EventHandler(FormatearPorcentaje);
            txtbox20.Leave += new EventHandler(FormatearPorcentaje);
            txtbox21.Leave += new EventHandler(FormatearPorcentaje);
            txtbox22.Leave += new EventHandler(FormatearPorcentaje);
            txtbox23.Leave += new EventHandler(FormatearPorcentaje);
            txtbox24.Leave += new EventHandler(FormatearPorcentaje);
            txtbox25.Leave += new EventHandler(FormatearPorcentaje);
            txtbox26.Leave += new EventHandler(FormatearPorcentaje);
            txtbox27.Leave += new EventHandler(FormatearPorcentaje);
            txtbox28.Leave += new EventHandler(FormatearPorcentaje);
            txtbox29.Leave += new EventHandler(FormatearPorcentaje);
            txtbox30.Leave += new EventHandler(FormatearPorcentaje);
            txtbox31.Leave += new EventHandler(FormatearPorcentaje);
            txtbox32.Leave += new EventHandler(FormatearPorcentaje);
            txtbox33.Leave += new EventHandler(FormatearPorcentaje);
            txtbox34.Leave += new EventHandler(FormatearPorcentaje);
            txtbox35.Leave += new EventHandler(FormatearPorcentaje);

            txtbox11.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox12.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox13.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox14.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox15.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox16.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox17.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox18.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox19.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox20.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox21.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox22.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox23.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox24.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox25.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox26.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox27.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox28.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox29.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox30.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox31.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox32.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox33.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox34.Enter += new EventHandler(PrepararCampoParaEdicion);
            txtbox35.Enter += new EventHandler(PrepararCampoParaEdicion);
        }

        // Valida que solo se ingresen números decimales (con un máximo de 2 decimales)
        private void ValidarNumeroDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Permitir dígitos, punto decimal y teclas de control
            bool esDigito = char.IsDigit(e.KeyChar);
            bool esPunto = e.KeyChar == '.';
            bool esControl = char.IsControl(e.KeyChar);

            // Permitir solo un punto decimal
            bool yaTienePunto = textBox.Text.Contains(".");

            // Si no es dígito, ni punto, ni tecla de control, rechazar
            if (!esDigito && !esControl && (!esPunto || yaTienePunto))
            {
                e.Handled = true;
                return;
            }

            // Si es un punto, verificar que no sea el primer carácter
            if (esPunto && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            // Controlar que solo haya 2 decimales
            if (esDigito && yaTienePunto)
            {
                int puntoIndex = textBox.Text.IndexOf(".");
                if (puntoIndex >= 0 && textBox.Text.Length - puntoIndex > 2)
                {
                    // Ya hay 2 decimales, rechazar más dígitos
                    e.Handled = true;
                    return;
                }
            }
        }

        // Formatea el texto para agregar el símbolo % cuando el usuario sale del campo
        private void FormatearPorcentaje(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Quitar cualquier símbolo % que pudiera tener
                string valorTexto = textBox.Text.Replace("%", "").Trim();

                if (double.TryParse(valorTexto, out double valor))
                {
                    // Formatear con 2 decimales y agregar símbolo %
                    textBox.Text = valor.ToString("0.00") + "%";
                }
            }
        }

        // Quita el símbolo % cuando el usuario entra al campo para editar
        private void PrepararCampoParaEdicion(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Quitar el símbolo % para facilitar la edición
                textBox.Text = textBox.Text.Replace("%", "").Trim();

                // Posicionar el cursor al final
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void txtbox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfigurarTextBoxesDeValoresDuplicados()
        {
            // Configurar los TextBoxes de valores duplicados para que sean de solo lectura
            txtemp1.ReadOnly = true;
            txtemp2.ReadOnly = true;
            txtemp3.ReadOnly = true;
            txtemp4.ReadOnly = true;
            txtemp5.ReadOnly = true;
        }

        private void AgregarEventosParaValorMaximo()
        {
            // Para txtmayp1 (txt1 a txt9)
            txt1.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt2.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt3.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt4.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt5.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt6.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt7.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt8.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);
            txt9.TextChanged += new EventHandler(ActualizarValorMaximoGrupo1);

            // Para txtmayp2 (txt11 a txt19)
            txt11.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt12.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt13.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt14.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt15.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt16.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt17.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt18.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);
            txt19.TextChanged += new EventHandler(ActualizarValorMaximoGrupo2);

            // Para txtmayp3 (txt21 a txt29)
            txt21.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt22.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt23.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt24.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt25.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt26.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt27.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt28.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);
            txt29.TextChanged += new EventHandler(ActualizarValorMaximoGrupo3);

            // Para txtmayp4 (txt31 a txt39)
            txt31.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt32.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt33.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt34.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt35.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt36.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt37.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt38.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);
            txt39.TextChanged += new EventHandler(ActualizarValorMaximoGrupo4);

            // Para txtmayp5 (txt41 a txt49)
            txt41.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt42.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt43.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt44.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt45.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt46.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt47.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt48.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
            txt49.TextChanged += new EventHandler(ActualizarValorMaximoGrupo5);
        }

        private void AgregarEventosParaDuplicacion()
        {
            // Duplicar valores cuando cambien los TextBoxes origen
            txtbox1.TextChanged += new EventHandler(DuplicarValor1);
            txtbox2.TextChanged += new EventHandler(DuplicarValor2);
            txtbox3.TextChanged += new EventHandler(DuplicarValor3);
            txtbox4.TextChanged += new EventHandler(DuplicarValor4);
            txtbox5.TextChanged += new EventHandler(DuplicarValor5);
        }

        private void ActualizarValorMaximoGrupo1(object sender, EventArgs e)
        {
            // Calcular el valor máximo entre txt1 y txt9
            int maximo = CalcularValorMaximo(new TextBox[] {
            txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9
        });

            // Guardar el valor actual para detectar cambios
            string valorAnterior = txtmayp1.Text;

            // Mostrar el resultado en txtmayp1
            txtmayp1.Text = maximo.ToString();

            // Si el valor cambió, forzar una actualización de los cálculos BCG manualmente
            if (valorAnterior != txtmayp1.Text)
            {
                // Llamar directamente a la función de actualización de BCG
                ActualizarResultadosBCG(txtmayp1, EventArgs.Empty);
            }
        }

        private void ActualizarValorMaximoGrupo2(object sender, EventArgs e)
        {
            // Calcular el valor máximo entre txt11 y txt19
            int maximo = CalcularValorMaximo(new TextBox[] {
            txt11, txt12, txt13, txt14, txt15, txt16, txt17, txt18, txt19
        });

            // Guardar el valor actual para detectar cambios
            string valorAnterior = txtmayp2.Text;

            // Mostrar el resultado en txtmayp2
            txtmayp2.Text = maximo.ToString();

            // Si el valor cambió, forzar una actualización de los cálculos BCG manualmente
            if (valorAnterior != txtmayp2.Text)
            {
                // Llamar directamente a la función de actualización de BCG
                ActualizarResultadosBCG(txtmayp2, EventArgs.Empty);
            }
        }

        private void ActualizarValorMaximoGrupo3(object sender, EventArgs e)
        {
            // Calcular el valor máximo entre txt21 y txt29
            int maximo = CalcularValorMaximo(new TextBox[] {
            txt21, txt22, txt23, txt24, txt25, txt26, txt27, txt28, txt29
        });

            // Guardar el valor actual para detectar cambios
            string valorAnterior = txtmayp3.Text;

            // Mostrar el resultado en txtmayp3
            txtmayp3.Text = maximo.ToString();

            // Si el valor cambió, forzar una actualización de los cálculos BCG manualmente
            if (valorAnterior != txtmayp3.Text)
            {
                // Llamar directamente a la función de actualización de BCG
                ActualizarResultadosBCG(txtmayp3, EventArgs.Empty);
            }
        }

        private void ActualizarValorMaximoGrupo4(object sender, EventArgs e)
        {
            // Calcular el valor máximo entre txt31 y txt39
            int maximo = CalcularValorMaximo(new TextBox[] {
            txt31, txt32, txt33, txt34, txt35, txt36, txt37, txt38, txt39
        });

            // Guardar el valor actual para detectar cambios
            string valorAnterior = txtmayp4.Text;

            // Mostrar el resultado en txtmayp4
            txtmayp4.Text = maximo.ToString();

            // Si el valor cambió, forzar una actualización de los cálculos BCG manualmente
            if (valorAnterior != txtmayp4.Text)
            {
                // Llamar directamente a la función de actualización de BCG
                ActualizarResultadosBCG(txtmayp4, EventArgs.Empty);
            }
        }

        private void ActualizarValorMaximoGrupo5(object sender, EventArgs e)
        {
            // Calcular el valor máximo entre txt41 y txt49
            int maximo = CalcularValorMaximo(new TextBox[] {
            txt41, txt42, txt43, txt44, txt45, txt46, txt47, txt48, txt49
        });

            // Guardar el valor actual para detectar cambios
            string valorAnterior = txtmayp5.Text;

            // Mostrar el resultado en txtmayp5
            txtmayp5.Text = maximo.ToString();

            // Si el valor cambió, forzar una actualización de los cálculos BCG manualmente
            if (valorAnterior != txtmayp5.Text)
            {
                // Llamar directamente a la función de actualización de BCG
                ActualizarResultadosBCG(txtmayp5, EventArgs.Empty);
            }
        }

        private int CalcularValorMaximo(TextBox[] textBoxes)
        {
            int maximo = 0;
            bool hayValido = false;

            foreach (TextBox tb in textBoxes)
            {
                if (!string.IsNullOrWhiteSpace(tb.Text))
                {
                    if (int.TryParse(tb.Text, out int valor))
                    {
                        if (!hayValido || valor > maximo)
                        {
                            maximo = valor;
                            hayValido = true;
                        }
                    }
                }
            }

            return maximo;
        }

        private void DuplicarValor1(object sender, EventArgs e)
        {
            // Duplicar valor de txtbox1 a txtemp1
            txtemp1.Text = txtbox1.Text;
        }

        private void DuplicarValor2(object sender, EventArgs e)
        {
            // Duplicar valor de txtbox2 a txtemp2 y txtemp6
            txtemp2.Text = txtbox2.Text;
        }

        private void DuplicarValor3(object sender, EventArgs e)
        {
            // Duplicar valor de txtbox3 a txtemp3
            txtemp3.Text = txtbox3.Text;
        }

        private void DuplicarValor4(object sender, EventArgs e)
        {
            // Duplicar valor de txtbox4 a txtemp4
            txtemp4.Text = txtbox4.Text;
        }

        private void DuplicarValor5(object sender, EventArgs e)
        {
            // Duplicar valor de txtbox5 a txtemp5
            txtemp5.Text = txtbox5.Text;
        }

        private void FrmAutodiagnosticoBCG_2_Load_1(object sender, EventArgs e)
        {

        }

        private void txtbox1_TextChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void txtbox2_TextChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void txtbox3_TextChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void txtbox4_TextChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void txtbox5_TextChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valoresPRM = new string[5];

            // Convertir los valores a formato numérico (quitar el posible formato)
            valoresPRM[0] = ConvertirAValorNumerico(txtbox41.Text);
            valoresPRM[1] = ConvertirAValorNumerico(txtbox42.Text);
            valoresPRM[2] = ConvertirAValorNumerico(txtbox43.Text);
            valoresPRM[3] = ConvertirAValorNumerico(txtbox44.Text);
            valoresPRM[4] = ConvertirAValorNumerico(txtbox45.Text);

            // Crear y abrir el formulario con los valores
            FrmBCGgenerado frmBCG = new FrmBCGgenerado(valoresPRM);
            AbrirFormularioHijo(frmBCG);
        }
        private string ConvertirAValorNumerico(string texto)
        {
            // Quitar cualquier símbolo que no sea número o punto decimal
            string valorNumerico = texto.Replace("%", "").Trim();

            // Verificar si se puede convertir a double (para validar el formato)
            if (double.TryParse(valorNumerico, out double valor))
            {
                // Devolver el valor como string
                return valor.ToString();
            }

            // Si no se puede convertir, devolver "0"
            return "0";
        }

        private void txttotal1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
