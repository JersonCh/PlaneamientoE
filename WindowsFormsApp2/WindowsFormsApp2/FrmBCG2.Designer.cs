namespace WindowsFormsApp2
{
    partial class FrmBCG2
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
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTCM = new System.Windows.Forms.DataGridView();
            this.btnLimpiarTCM = new System.Windows.Forms.Button();
            this.btnActualizarTCM = new System.Windows.Forms.Button();
            this.btnAgregarPeriodo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(53, 76);
            this.dgvPrevision.Name = "dgvPrevision";
            this.dgvPrevision.RowHeadersWidth = 51;
            this.dgvPrevision.RowTemplate.Height = 24;
            this.dgvPrevision.Size = new System.Drawing.Size(527, 234);
            this.dgvPrevision.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(53, 333);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(163, 32);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(234, 333);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(163, 32);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(417, 333);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(163, 32);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Previsión de ventas";
            // 
            // dgvTCM
            // 
            this.dgvTCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTCM.Location = new System.Drawing.Point(734, 76);
            this.dgvTCM.Name = "dgvTCM";
            this.dgvTCM.RowHeadersWidth = 51;
            this.dgvTCM.RowTemplate.Height = 24;
            this.dgvTCM.Size = new System.Drawing.Size(527, 234);
            this.dgvTCM.TabIndex = 5;
            this.dgvTCM.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTCM_CellValueChanged);
            this.dgvTCM.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTCM_EditingControlShowing);
            // 
            // btnLimpiarTCM
            // 
            this.btnLimpiarTCM.Location = new System.Drawing.Point(1100, 333);
            this.btnLimpiarTCM.Name = "btnLimpiarTCM";
            this.btnLimpiarTCM.Size = new System.Drawing.Size(163, 32);
            this.btnLimpiarTCM.TabIndex = 8;
            this.btnLimpiarTCM.Text = "Limpiar";
            this.btnLimpiarTCM.UseVisualStyleBackColor = true;
            this.btnLimpiarTCM.Click += new System.EventHandler(this.btnLimpiarTCM_Click);
            // 
            // btnActualizarTCM
            // 
            this.btnActualizarTCM.Location = new System.Drawing.Point(917, 333);
            this.btnActualizarTCM.Name = "btnActualizarTCM";
            this.btnActualizarTCM.Size = new System.Drawing.Size(163, 32);
            this.btnActualizarTCM.TabIndex = 7;
            this.btnActualizarTCM.Text = "Actualizar";
            this.btnActualizarTCM.UseVisualStyleBackColor = true;
            this.btnActualizarTCM.Click += new System.EventHandler(this.btnActualizarTCM_Click);
            // 
            // btnAgregarPeriodo
            // 
            this.btnAgregarPeriodo.Location = new System.Drawing.Point(736, 333);
            this.btnAgregarPeriodo.Name = "btnAgregarPeriodo";
            this.btnAgregarPeriodo.Size = new System.Drawing.Size(163, 32);
            this.btnAgregarPeriodo.TabIndex = 6;
            this.btnAgregarPeriodo.Text = "Agregar Periodo";
            this.btnAgregarPeriodo.UseVisualStyleBackColor = true;
            this.btnAgregarPeriodo.Click += new System.EventHandler(this.btnAgregarPeriodo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(740, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tasa de crecimiento del mercado (TCM)";
            // 
            // FrmBCG2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 1257);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLimpiarTCM);
            this.Controls.Add(this.btnActualizarTCM);
            this.Controls.Add(this.btnAgregarPeriodo);
            this.Controls.Add(this.dgvTCM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.dgvPrevision);
            this.Name = "FrmBCG2";
            this.Text = "FrmBCG2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrevision;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTCM;
        private System.Windows.Forms.Button btnLimpiarTCM;
        private System.Windows.Forms.Button btnActualizarTCM;
        private System.Windows.Forms.Button btnAgregarPeriodo;
        private System.Windows.Forms.Label label2;
    }
}