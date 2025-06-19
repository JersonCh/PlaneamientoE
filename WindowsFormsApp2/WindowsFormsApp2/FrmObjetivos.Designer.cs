namespace WindowsFormsApp2
{
    partial class FrmObjetivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObjetivos));
            this.txtUnidadEstrategica = new System.Windows.Forms.TextBox();
            this.txtMision = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvObjE = new System.Windows.Forms.DataGridView();
            this.dgvObjG = new System.Windows.Forms.DataGridView();
            this.btnGuardarGenerales = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUnidadEstrategica
            // 
            this.txtUnidadEstrategica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnidadEstrategica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnidadEstrategica.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidadEstrategica.Location = new System.Drawing.Point(27, 75);
            this.txtUnidadEstrategica.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUnidadEstrategica.Multiline = true;
            this.txtUnidadEstrategica.Name = "txtUnidadEstrategica";
            this.txtUnidadEstrategica.Size = new System.Drawing.Size(1124, 165);
            this.txtUnidadEstrategica.TabIndex = 58;
            // 
            // txtMision
            // 
            this.txtMision.BackColor = System.Drawing.Color.White;
            this.txtMision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMision.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMision.Location = new System.Drawing.Point(136, 409);
            this.txtMision.Margin = new System.Windows.Forms.Padding(2);
            this.txtMision.Multiline = true;
            this.txtMision.Name = "txtMision";
            this.txtMision.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMision.Size = new System.Drawing.Size(247, 253);
            this.txtMision.TabIndex = 61;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRegistrar.BackColor = System.Drawing.Color.Black;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(658, 689);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(264, 42);
            this.btnRegistrar.TabIndex = 106;
            this.btnRegistrar.Text = "REGISTRAR ESPECIFICO";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(134, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 42);
            this.label1.TabIndex = 107;
            this.label1.Text = "MISION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.RoyalBlue;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(389, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 42);
            this.label3.TabIndex = 108;
            this.label3.Text = "OBJETIVOS GENERALES O ESTRATÉGICOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.RoyalBlue;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(744, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(350, 42);
            this.label7.TabIndex = 109;
            this.label7.Text = "OBJETIVOS ESPECÍFICOS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1124, 50);
            this.label2.TabIndex = 110;
            this.label2.Text = "En su caso, comente en este apartado las distintas UEN que tiene su empresa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 260);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1124, 75);
            this.label4.TabIndex = 111;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvObjE
            // 
            this.dgvObjE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjE.Location = new System.Drawing.Point(744, 409);
            this.dgvObjE.Name = "dgvObjE";
            this.dgvObjE.Size = new System.Drawing.Size(350, 253);
            this.dgvObjE.TabIndex = 113;
            // 
            // dgvObjG
            // 
            this.dgvObjG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjG.Location = new System.Drawing.Point(388, 410);
            this.dgvObjG.Name = "dgvObjG";
            this.dgvObjG.Size = new System.Drawing.Size(350, 253);
            this.dgvObjG.TabIndex = 112;
            // 
            // btnGuardarGenerales
            // 
            this.btnGuardarGenerales.BackColor = System.Drawing.Color.Black;
            this.btnGuardarGenerales.FlatAppearance.BorderSize = 0;
            this.btnGuardarGenerales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardarGenerales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGuardarGenerales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarGenerales.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarGenerales.ForeColor = System.Drawing.Color.White;
            this.btnGuardarGenerales.Location = new System.Drawing.Point(301, 689);
            this.btnGuardarGenerales.Name = "btnGuardarGenerales";
            this.btnGuardarGenerales.Size = new System.Drawing.Size(265, 42);
            this.btnGuardarGenerales.TabIndex = 114;
            this.btnGuardarGenerales.Text = "REGISTRAR GENERAL";
            this.btnGuardarGenerales.UseVisualStyleBackColor = false;
            this.btnGuardarGenerales.Click += new System.EventHandler(this.btnGuardarGenerales_Click);
            // 
            // FrmObjetivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1175, 802);
            this.Controls.Add(this.btnGuardarGenerales);
            this.Controls.Add(this.dgvObjE);
            this.Controls.Add(this.dgvObjG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtMision);
            this.Controls.Add(this.txtUnidadEstrategica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmObjetivos";
            this.Text = "FrmObjetivos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUnidadEstrategica;
        private System.Windows.Forms.TextBox txtMision;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvObjE;
        private System.Windows.Forms.DataGridView dgvObjG;
        private System.Windows.Forms.Button btnGuardarGenerales;
    }
}