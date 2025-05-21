namespace WindowsFormsApp2
{
    partial class FrmBCG3
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
            this.dgvPrevision = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.dgvVLC = new System.Windows.Forms.DataGridView();
            this.btnLimpiarCompetidor = new System.Windows.Forms.Button();
            this.btnActualizarCompetidor = new System.Windows.Forms.Button();
            this.btnAgregarCompetidor = new System.Windows.Forms.Button();
            this.dgvVSA = new System.Windows.Forms.DataGridView();
            this.btnLimpiarVSA = new System.Windows.Forms.Button();
            this.btnActualizarVSA = new System.Windows.Forms.Button();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.btnAnios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVSA)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(25, 33);
            this.dgvPrevision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPrevision.Name = "dgvPrevision";
            this.dgvPrevision.RowHeadersWidth = 51;
            this.dgvPrevision.RowTemplate.Height = 24;
            this.dgvPrevision.Size = new System.Drawing.Size(395, 190);
            this.dgvPrevision.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(302, 242);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(165, 242);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(122, 26);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(28, 242);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(122, 26);
            this.btnAgregarProducto.TabIndex = 4;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // dgvVLC
            // 
            this.dgvVLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVLC.Location = new System.Drawing.Point(484, 33);
            this.dgvVLC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVLC.Name = "dgvVLC";
            this.dgvVLC.RowHeadersWidth = 51;
            this.dgvVLC.RowTemplate.Height = 24;
            this.dgvVLC.Size = new System.Drawing.Size(395, 190);
            this.dgvVLC.TabIndex = 7;
            this.dgvVLC.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVLC_ColumnHeaderMouseDoubleClick);
            // 
            // btnLimpiarCompetidor
            // 
            this.btnLimpiarCompetidor.Location = new System.Drawing.Point(758, 242);
            this.btnLimpiarCompetidor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarCompetidor.Name = "btnLimpiarCompetidor";
            this.btnLimpiarCompetidor.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarCompetidor.TabIndex = 10;
            this.btnLimpiarCompetidor.Text = "Limpiar";
            this.btnLimpiarCompetidor.UseVisualStyleBackColor = true;
            this.btnLimpiarCompetidor.Click += new System.EventHandler(this.btnLimpiarCompetidor_Click);
            // 
            // btnActualizarCompetidor
            // 
            this.btnActualizarCompetidor.Location = new System.Drawing.Point(621, 242);
            this.btnActualizarCompetidor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarCompetidor.Name = "btnActualizarCompetidor";
            this.btnActualizarCompetidor.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarCompetidor.TabIndex = 9;
            this.btnActualizarCompetidor.Text = "Actualizar";
            this.btnActualizarCompetidor.UseVisualStyleBackColor = true;
            this.btnActualizarCompetidor.Click += new System.EventHandler(this.btnActualizarCompetidor_Click);
            // 
            // btnAgregarCompetidor
            // 
            this.btnAgregarCompetidor.Location = new System.Drawing.Point(484, 242);
            this.btnAgregarCompetidor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarCompetidor.Name = "btnAgregarCompetidor";
            this.btnAgregarCompetidor.Size = new System.Drawing.Size(122, 26);
            this.btnAgregarCompetidor.TabIndex = 8;
            this.btnAgregarCompetidor.Text = "Agregar Competidor";
            this.btnAgregarCompetidor.UseVisualStyleBackColor = true;
            this.btnAgregarCompetidor.Click += new System.EventHandler(this.btnAgregarCompetidor_Click);
            // 
            // dgvVSA
            // 
            this.dgvVSA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVSA.Location = new System.Drawing.Point(29, 301);
            this.dgvVSA.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVSA.Name = "dgvVSA";
            this.dgvVSA.RowHeadersWidth = 51;
            this.dgvVSA.RowTemplate.Height = 24;
            this.dgvVSA.Size = new System.Drawing.Size(395, 190);
            this.dgvVSA.TabIndex = 11;
            // 
            // btnLimpiarVSA
            // 
            this.btnLimpiarVSA.Location = new System.Drawing.Point(228, 552);
            this.btnLimpiarVSA.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarVSA.Name = "btnLimpiarVSA";
            this.btnLimpiarVSA.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarVSA.TabIndex = 13;
            this.btnLimpiarVSA.Text = "Limpiar";
            this.btnLimpiarVSA.UseVisualStyleBackColor = true;
            this.btnLimpiarVSA.Click += new System.EventHandler(this.btnLimpiarVSA_Click);
            // 
            // btnActualizarVSA
            // 
            this.btnActualizarVSA.Location = new System.Drawing.Point(91, 552);
            this.btnActualizarVSA.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizarVSA.Name = "btnActualizarVSA";
            this.btnActualizarVSA.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarVSA.TabIndex = 12;
            this.btnActualizarVSA.Text = "Actualizar";
            this.btnActualizarVSA.UseVisualStyleBackColor = true;
            this.btnActualizarVSA.Click += new System.EventHandler(this.btnActualizarVSA_Click);
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(29, 514);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtInicio.TabIndex = 14;
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(146, 514);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 15;
            // 
            // btnAnios
            // 
            this.btnAnios.Location = new System.Drawing.Point(265, 510);
            this.btnAnios.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnios.Name = "btnAnios";
            this.btnAnios.Size = new System.Drawing.Size(122, 26);
            this.btnAnios.TabIndex = 16;
            this.btnAnios.Text = "Agregar Años";
            this.btnAnios.UseVisualStyleBackColor = true;
            this.btnAnios.Click += new System.EventHandler(this.btnAnios_Click);
            // 
            // FrmBCG3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 712);
            this.Controls.Add(this.btnAnios);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtInicio);
            this.Controls.Add(this.btnLimpiarVSA);
            this.Controls.Add(this.btnActualizarVSA);
            this.Controls.Add(this.dgvVSA);
            this.Controls.Add(this.btnLimpiarCompetidor);
            this.Controls.Add(this.btnActualizarCompetidor);
            this.Controls.Add(this.btnAgregarCompetidor);
            this.Controls.Add(this.dgvVLC);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvPrevision);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBCG3";
            this.Text = "FrmBCG3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVSA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrevision;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridView dgvVLC;
        private System.Windows.Forms.Button btnLimpiarCompetidor;
        private System.Windows.Forms.Button btnActualizarCompetidor;
        private System.Windows.Forms.Button btnAgregarCompetidor;
        private System.Windows.Forms.DataGridView dgvVSA;
        private System.Windows.Forms.Button btnLimpiarVSA;
        private System.Windows.Forms.Button btnActualizarVSA;
        private System.Windows.Forms.TextBox txtInicio;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Button btnAnios;
    }
}