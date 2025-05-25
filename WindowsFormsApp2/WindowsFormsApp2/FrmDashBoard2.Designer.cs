namespace WindowsFormsApp2
{
    partial class FrmDashBoard2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashBoard2));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnInformacionEmpresa = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnMision = new FontAwesome.Sharp.IconButton();
            this.btnVision = new FontAwesome.Sharp.IconButton();
            this.btnValores = new FontAwesome.Sharp.IconButton();
            this.btnAnalisisIyE = new FontAwesome.Sharp.IconButton();
            this.btnObjetivos = new FontAwesome.Sharp.IconButton();
            this.btnInicio = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btMax = new FontAwesome.Sharp.IconPictureBox();
            this.btnMin = new FontAwesome.Sharp.IconPictureBox();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.lblhora = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInicio)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelMenu.Controls.Add(this.btnObjetivos);
            this.panelMenu.Controls.Add(this.btnAnalisisIyE);
            this.panelMenu.Controls.Add(this.btnValores);
            this.panelMenu.Controls.Add(this.btnVision);
            this.panelMenu.Controls.Add(this.btnMision);
            this.panelMenu.Controls.Add(this.btnInformacionEmpresa);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(255, 700);
            this.panelMenu.TabIndex = 74;
            // 
            // btnInformacionEmpresa
            // 
            this.btnInformacionEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInformacionEmpresa.FlatAppearance.BorderSize = 0;
            this.btnInformacionEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformacionEmpresa.IconChar = FontAwesome.Sharp.IconChar.Briefcase;
            this.btnInformacionEmpresa.IconColor = System.Drawing.Color.White;
            this.btnInformacionEmpresa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInformacionEmpresa.IconSize = 32;
            this.btnInformacionEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformacionEmpresa.Location = new System.Drawing.Point(0, 97);
            this.btnInformacionEmpresa.Name = "btnInformacionEmpresa";
            this.btnInformacionEmpresa.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnInformacionEmpresa.Size = new System.Drawing.Size(255, 50);
            this.btnInformacionEmpresa.TabIndex = 156;
            this.btnInformacionEmpresa.Text = "Infor. de la Empresa";
            this.btnInformacionEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformacionEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInformacionEmpresa.UseVisualStyleBackColor = true;
            this.btnInformacionEmpresa.Click += new System.EventHandler(this.btnInformacionEmpresa_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnInicio);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(255, 97);
            this.panelLogo.TabIndex = 155;
            // 
            // btnMision
            // 
            this.btnMision.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMision.FlatAppearance.BorderSize = 0;
            this.btnMision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMision.IconChar = FontAwesome.Sharp.IconChar.Bullseye;
            this.btnMision.IconColor = System.Drawing.Color.White;
            this.btnMision.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMision.IconSize = 32;
            this.btnMision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMision.Location = new System.Drawing.Point(0, 147);
            this.btnMision.Name = "btnMision";
            this.btnMision.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnMision.Size = new System.Drawing.Size(255, 50);
            this.btnMision.TabIndex = 157;
            this.btnMision.Text = "Mision";
            this.btnMision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMision.UseVisualStyleBackColor = true;
            this.btnMision.Click += new System.EventHandler(this.btnMision_Click);
            // 
            // btnVision
            // 
            this.btnVision.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVision.FlatAppearance.BorderSize = 0;
            this.btnVision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVision.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnVision.IconColor = System.Drawing.Color.White;
            this.btnVision.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVision.IconSize = 32;
            this.btnVision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVision.Location = new System.Drawing.Point(0, 197);
            this.btnVision.Name = "btnVision";
            this.btnVision.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnVision.Size = new System.Drawing.Size(255, 50);
            this.btnVision.TabIndex = 158;
            this.btnVision.Text = "Vision";
            this.btnVision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVision.UseVisualStyleBackColor = true;
            this.btnVision.Click += new System.EventHandler(this.btnVision_Click);
            // 
            // btnValores
            // 
            this.btnValores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnValores.FlatAppearance.BorderSize = 0;
            this.btnValores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValores.IconChar = FontAwesome.Sharp.IconChar.Heart;
            this.btnValores.IconColor = System.Drawing.Color.White;
            this.btnValores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnValores.IconSize = 32;
            this.btnValores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValores.Location = new System.Drawing.Point(0, 247);
            this.btnValores.Name = "btnValores";
            this.btnValores.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnValores.Size = new System.Drawing.Size(255, 50);
            this.btnValores.TabIndex = 159;
            this.btnValores.Text = "Valores";
            this.btnValores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnValores.UseVisualStyleBackColor = true;
            this.btnValores.Click += new System.EventHandler(this.btnValores_Click);
            // 
            // btnAnalisisIyE
            // 
            this.btnAnalisisIyE.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalisisIyE.FlatAppearance.BorderSize = 0;
            this.btnAnalisisIyE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalisisIyE.IconChar = FontAwesome.Sharp.IconChar.RectangleList;
            this.btnAnalisisIyE.IconColor = System.Drawing.Color.White;
            this.btnAnalisisIyE.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnalisisIyE.IconSize = 32;
            this.btnAnalisisIyE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalisisIyE.Location = new System.Drawing.Point(0, 297);
            this.btnAnalisisIyE.Name = "btnAnalisisIyE";
            this.btnAnalisisIyE.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnAnalisisIyE.Size = new System.Drawing.Size(255, 50);
            this.btnAnalisisIyE.TabIndex = 160;
            this.btnAnalisisIyE.Text = "Analisis Int. y Ext.";
            this.btnAnalisisIyE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalisisIyE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnalisisIyE.UseVisualStyleBackColor = true;
            this.btnAnalisisIyE.Click += new System.EventHandler(this.btnAnalisisIyE_Click);
            // 
            // btnObjetivos
            // 
            this.btnObjetivos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnObjetivos.FlatAppearance.BorderSize = 0;
            this.btnObjetivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObjetivos.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.btnObjetivos.IconColor = System.Drawing.Color.White;
            this.btnObjetivos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnObjetivos.IconSize = 32;
            this.btnObjetivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObjetivos.Location = new System.Drawing.Point(0, 347);
            this.btnObjetivos.Name = "btnObjetivos";
            this.btnObjetivos.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnObjetivos.Size = new System.Drawing.Size(255, 50);
            this.btnObjetivos.TabIndex = 161;
            this.btnObjetivos.Text = "Objetivos";
            this.btnObjetivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObjetivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnObjetivos.UseVisualStyleBackColor = true;
            this.btnObjetivos.Click += new System.EventHandler(this.btnObjetivos_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.Location = new System.Drawing.Point(25, 17);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(2);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(200, 60);
            this.btnInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnInicio.TabIndex = 75;
            this.btnInicio.TabStop = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnMin);
            this.panelTitleBar.Controls.Add(this.btMax);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(255, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(858, 77);
            this.panelTitleBar.TabIndex = 75;
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 43;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(15, 15);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(43, 45);
            this.iconCurrentChildForm.TabIndex = 76;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Location = new System.Drawing.Point(64, 26);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(56, 21);
            this.lblTitleChildForm.TabIndex = 77;
            this.lblTitleChildForm.Text = "Home";
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelDesktop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDesktop.BackgroundImage")));
            this.panelDesktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDesktop.Controls.Add(this.lblfecha);
            this.panelDesktop.Controls.Add(this.lblhora);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDesktop.ForeColor = System.Drawing.Color.Black;
            this.panelDesktop.Location = new System.Drawing.Point(255, 77);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(858, 623);
            this.panelDesktop.TabIndex = 76;
            // 
            // btMax
            // 
            this.btMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMax.BackColor = System.Drawing.Color.Transparent;
            this.btMax.IconChar = FontAwesome.Sharp.IconChar.Expand;
            this.btMax.IconColor = System.Drawing.Color.White;
            this.btMax.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMax.IconSize = 21;
            this.btMax.Location = new System.Drawing.Point(804, 5);
            this.btMax.Name = "btMax";
            this.btMax.Size = new System.Drawing.Size(21, 23);
            this.btMax.TabIndex = 78;
            this.btMax.TabStop = false;
            this.btMax.Click += new System.EventHandler(this.btMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMin.IconColor = System.Drawing.Color.White;
            this.btnMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMin.IconSize = 21;
            this.btnMin.Location = new System.Drawing.Point(779, 5);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(21, 23);
            this.btnMin.TabIndex = 79;
            this.btnMin.TabStop = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 21;
            this.btnClose.Location = new System.Drawing.Point(830, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 23);
            this.btnClose.TabIndex = 80;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblhora
            // 
            this.lblhora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhora.BackColor = System.Drawing.Color.Transparent;
            this.lblhora.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhora.ForeColor = System.Drawing.Color.Black;
            this.lblhora.Location = new System.Drawing.Point(48, 189);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(756, 112);
            this.lblhora.TabIndex = 0;
            this.lblhora.Text = "label1";
            this.lblhora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblfecha
            // 
            this.lblfecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblfecha.BackColor = System.Drawing.Color.Transparent;
            this.lblfecha.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.Color.White;
            this.lblfecha.Location = new System.Drawing.Point(46, 313);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(758, 88);
            this.lblfecha.TabIndex = 1;
            this.lblfecha.Text = "label1";
            this.lblfecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // horafecha
            // 
            this.horafecha.Enabled = true;
            this.horafecha.Tick += new System.EventHandler(this.horafecha_Tick);
            // 
            // FrmDashBoard2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 700);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1113, 700);
            this.Name = "FrmDashBoard2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDashBoard2";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnInicio)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnInformacionEmpresa;
        private FontAwesome.Sharp.IconButton btnAnalisisIyE;
        private FontAwesome.Sharp.IconButton btnValores;
        private FontAwesome.Sharp.IconButton btnVision;
        private FontAwesome.Sharp.IconButton btnMision;
        private FontAwesome.Sharp.IconButton btnObjetivos;
        private System.Windows.Forms.PictureBox btnInicio;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private FontAwesome.Sharp.IconPictureBox btnMin;
        private FontAwesome.Sharp.IconPictureBox btMax;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Timer horafecha;
    }
}