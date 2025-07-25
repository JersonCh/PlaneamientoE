﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;
using Color = System.Drawing.Color;


namespace WindowsFormsApp2
{
    public partial class FrmDashBoard2 : Form
    {
        //
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private clsUsuario usuarioActual;

        //
        private bool isInformacionEmpresaCompleted = false;
        private bool isMisionCompleted = false;
        private bool isVisionCompleted = false;
        private bool isValoresCompleted = false;
        private bool isAnalisisIyECompleted = false;
        private bool isObjetivosCompleted = false;
        private bool isCadenaValorCompleted = false;
        private bool isMatrizCompleted = false;
        private bool is5FuerzasCompleted = false;
        private bool isPestCompleted = false;
        private bool isIdentificacionECompleted = false;
        private bool isMatrizCameCompleted = false;
        //private bool isResumenCompleted = false;

        //
        public FrmDashBoard2(clsUsuario usuario)
        {
            InitializeComponent();

            // Pantalla completa sin barra de título NI barra de tareas
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.TopMost = true;

            // Opcionales para apariencia y botones
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            // Panel lateral
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftBorderBtn);

            // Guardar usuario
            this.usuarioActual = usuario;

            // Inicializar todos los botones bloqueados
            btnMision.Enabled = false;
            btnVision.Enabled = false;
            btnValores.Enabled = false;
            btnAnalisisIyE.Enabled = false;
            btnObjetivos.Enabled = false;
            btnCadenaValor.Enabled = false;
            btnMatriz.Enabled = false;
            btn5fuerzas.Enabled = false;
            btnPest.Enabled = false;
            btnIdentificacionE.Enabled = false;
            btnMatrizCame.Enabled = false;
            //iconButton1.Enabled = false;
        }


        //
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //metodos
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign=ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
                //LEFT
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location=new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }

        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
              
                currentBtn.BackColor = Color.MidnightBlue;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnInformacionEmpresa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmEmpresas());
            //
            isInformacionEmpresaCompleted = true;
            CheckAndEnableNextButton();

        }

        private void btnMision_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new Mision());
            isMisionCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnVision_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new Vision());
            isVisionCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnValores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmValores());
            isValoresCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnAnalisisIyE_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmAnalisis());
            isAnalisisIyECompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnObjetivos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmObjetivos());
            isObjetivosCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            //
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.White;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            string fecha = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            System.Globalization.CultureInfo cultura = new System.Globalization.CultureInfo("es-ES");

            // Convertimos la primera letra de cada palabra a mayúscula
            lblfecha.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fecha);


        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas cerrar sesión?",
                                          "Cerrar sesión",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Limpiar los datos de sesión
                Sesion.UsuarioId = 0;
                Sesion.EmpresaId = 0;

                // Volver al formulario de login
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();
            }
        }

        private void btnCadenaValor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmAutoCadenaValor());
            isCadenaValorCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnMatriz_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            //OpenChildForm(new FrmBCG3());
            OpenChildForm(new FrmBCGinicio());
            isMatrizCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btn5fuerzas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmAutodiagosticoPorter());
            is5FuerzasCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnPest_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmAutoPest());
            isPestCompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnIdentificacionE_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmIdentif_Estrategia());
            isIdentificacionECompleted = true;
            CheckAndEnableNextButton();
        }

        private void btnMatrizCame_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmMatrizCame());
            isMatrizCameCompleted = true;
            CheckAndEnableNextButton();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmResumen());
            //resuumen
            //isResumenCompleted = true;
            //CheckAndEnableNextButton();
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas cerrar sesión?",
                                          "Cerrar sesión",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Limpiar los datos de sesión
                Sesion.UsuarioId = 0;
                Sesion.EmpresaId = 0;

                // Volver al formulario de login
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();
            }
        }

        private void FrmDashBoard2_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = usuarioActual.nombre + " " + usuarioActual.apellido;
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }
        //Implementacion Elvicito
        public void AbrirFormularioBCG3()
        {
            // Activar el botón matriz para mantener consistencia visual (opcional)
            ActivateButton(btnMatriz, RGBColors.color6);

            // Abrir FrmBCG3 usando el método existente del dashboard
            OpenChildForm(new FrmBCG3());
        }

        // Función para habilitar el siguiente botón si el formulario anterior está completado
        private void CheckAndEnableNextButton()
        {
            if (isInformacionEmpresaCompleted)
            {
                btnMision.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnVision.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnValores.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnAnalisisIyE.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnObjetivos.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnCadenaValor.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnMatriz.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btn5fuerzas.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnPest.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnIdentificacionE.Enabled = true;
            }

            if (isInformacionEmpresaCompleted)
            {
                btnMatrizCame.Enabled = true;
            }

            //if (isMatrizCameCompleted)
            //{
            // iconButton1.Enabled = true;
            //}
        }

    }
}
