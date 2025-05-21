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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(33, 41);
            this.dgvPrevision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPrevision.Name = "dgvPrevision";
            this.dgvPrevision.RowHeadersWidth = 51;
            this.dgvPrevision.RowTemplate.Height = 24;
            this.dgvPrevision.Size = new System.Drawing.Size(527, 234);
            this.dgvPrevision.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(402, 298);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(163, 32);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(220, 298);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(163, 32);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(38, 298);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(163, 32);
            this.btnAgregarProducto.TabIndex = 4;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // dgvVLC
            // 
            this.dgvVLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVLC.Location = new System.Drawing.Point(646, 41);
            this.dgvVLC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvVLC.Name = "dgvVLC";
            this.dgvVLC.RowHeadersWidth = 51;
            this.dgvVLC.RowTemplate.Height = 24;
            this.dgvVLC.Size = new System.Drawing.Size(527, 234);
            this.dgvVLC.TabIndex = 7;
            // 
            // btnLimpiarCompetidor
            // 
            this.btnLimpiarCompetidor.Location = new System.Drawing.Point(1010, 298);
            this.btnLimpiarCompetidor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarCompetidor.Name = "btnLimpiarCompetidor";
            this.btnLimpiarCompetidor.Size = new System.Drawing.Size(163, 32);
            this.btnLimpiarCompetidor.TabIndex = 10;
            this.btnLimpiarCompetidor.Text = "Limpiar";
            this.btnLimpiarCompetidor.UseVisualStyleBackColor = true;
            this.btnLimpiarCompetidor.Click += new System.EventHandler(this.btnLimpiarCompetidor_Click);
            // 
            // btnActualizarCompetidor
            // 
            this.btnActualizarCompetidor.Location = new System.Drawing.Point(828, 298);
            this.btnActualizarCompetidor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarCompetidor.Name = "btnActualizarCompetidor";
            this.btnActualizarCompetidor.Size = new System.Drawing.Size(163, 32);
            this.btnActualizarCompetidor.TabIndex = 9;
            this.btnActualizarCompetidor.Text = "Actualizar";
            this.btnActualizarCompetidor.UseVisualStyleBackColor = true;
            this.btnActualizarCompetidor.Click += new System.EventHandler(this.btnActualizarCompetidor_Click);
            // 
            // btnAgregarCompetidor
            // 
            this.btnAgregarCompetidor.Location = new System.Drawing.Point(646, 298);
            this.btnAgregarCompetidor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarCompetidor.Name = "btnAgregarCompetidor";
            this.btnAgregarCompetidor.Size = new System.Drawing.Size(163, 32);
            this.btnAgregarCompetidor.TabIndex = 8;
            this.btnAgregarCompetidor.Text = "Agregar Competidor";
            this.btnAgregarCompetidor.UseVisualStyleBackColor = true;
            this.btnAgregarCompetidor.Click += new System.EventHandler(this.btnAgregarCompetidor_Click);
            // 
            // FrmBCG3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 876);
            this.Controls.Add(this.btnLimpiarCompetidor);
            this.Controls.Add(this.btnActualizarCompetidor);
            this.Controls.Add(this.btnAgregarCompetidor);
            this.Controls.Add(this.dgvVLC);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvPrevision);
            this.Name = "FrmBCG3";
            this.Text = "FrmBCG3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).EndInit();
            this.ResumeLayout(false);

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
    }
}