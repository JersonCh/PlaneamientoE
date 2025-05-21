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
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnioInicio = new System.Windows.Forms.TextBox();
            this.txtAnioFin = new System.Windows.Forms.TextBox();
            this.dgvEvolucionDemanda = new System.Windows.Forms.DataGridView();
            this.btnLimpiarDemanda = new System.Windows.Forms.Button();
            this.btnActualizarDemanda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvolucionDemanda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(40, 62);
            this.dgvPrevision.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrevision.Name = "dgvPrevision";
            this.dgvPrevision.RowHeadersWidth = 51;
            this.dgvPrevision.RowTemplate.Height = 24;
            this.dgvPrevision.Size = new System.Drawing.Size(395, 190);
            this.dgvPrevision.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(40, 271);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(122, 26);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(176, 271);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(122, 26);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(313, 271);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Previsión de ventas";
            // 
            // dgvTCM
            // 
            this.dgvTCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTCM.Location = new System.Drawing.Point(550, 62);
            this.dgvTCM.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTCM.Name = "dgvTCM";
            this.dgvTCM.RowHeadersWidth = 51;
            this.dgvTCM.RowTemplate.Height = 24;
            this.dgvTCM.Size = new System.Drawing.Size(395, 190);
            this.dgvTCM.TabIndex = 5;
            this.dgvTCM.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTCM_CellValueChanged);
            this.dgvTCM.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTCM_EditingControlShowing);
            // 
            // btnLimpiarTCM
            // 
            this.btnLimpiarTCM.Location = new System.Drawing.Point(824, 320);
            this.btnLimpiarTCM.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarTCM.Name = "btnLimpiarTCM";
            this.btnLimpiarTCM.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarTCM.TabIndex = 8;
            this.btnLimpiarTCM.Text = "Limpiar";
            this.btnLimpiarTCM.UseVisualStyleBackColor = true;
            this.btnLimpiarTCM.Click += new System.EventHandler(this.btnLimpiarTCM_Click);
            // 
            // btnActualizarTCM
            // 
            this.btnActualizarTCM.Location = new System.Drawing.Point(687, 320);
            this.btnActualizarTCM.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizarTCM.Name = "btnActualizarTCM";
            this.btnActualizarTCM.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarTCM.TabIndex = 7;
            this.btnActualizarTCM.Text = "Actualizar";
            this.btnActualizarTCM.UseVisualStyleBackColor = true;
            this.btnActualizarTCM.Click += new System.EventHandler(this.btnActualizarTCM_Click);
            // 
            // btnAgregarPeriodo
            // 
            this.btnAgregarPeriodo.Location = new System.Drawing.Point(551, 320);
            this.btnAgregarPeriodo.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPeriodo.Name = "btnAgregarPeriodo";
            this.btnAgregarPeriodo.Size = new System.Drawing.Size(122, 26);
            this.btnAgregarPeriodo.TabIndex = 6;
            this.btnAgregarPeriodo.Text = "Agregar Periodo";
            this.btnAgregarPeriodo.UseVisualStyleBackColor = true;
            this.btnAgregarPeriodo.Click += new System.EventHandler(this.btnAgregarPeriodo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(555, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tasa de crecimiento del mercado (TCM)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 263);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Elegir rango:";
            // 
            // txtAnioInicio
            // 
            this.txtAnioInicio.Location = new System.Drawing.Point(551, 288);
            this.txtAnioInicio.Name = "txtAnioInicio";
            this.txtAnioInicio.Size = new System.Drawing.Size(100, 20);
            this.txtAnioInicio.TabIndex = 11;
            // 
            // txtAnioFin
            // 
            this.txtAnioFin.Location = new System.Drawing.Point(672, 288);
            this.txtAnioFin.Name = "txtAnioFin";
            this.txtAnioFin.Size = new System.Drawing.Size(100, 20);
            this.txtAnioFin.TabIndex = 12;
            // 
            // dgvEvolucionDemanda
            // 
            this.dgvEvolucionDemanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvolucionDemanda.Location = new System.Drawing.Point(40, 352);
            this.dgvEvolucionDemanda.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEvolucionDemanda.Name = "dgvEvolucionDemanda";
            this.dgvEvolucionDemanda.RowHeadersWidth = 51;
            this.dgvEvolucionDemanda.RowTemplate.Height = 24;
            this.dgvEvolucionDemanda.Size = new System.Drawing.Size(395, 190);
            this.dgvEvolucionDemanda.TabIndex = 13;
            this.dgvEvolucionDemanda.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvolucionDemanda_CellValueChanged);
            this.dgvEvolucionDemanda.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvEvolucionDemanda_EditingControlShowing);
            // 
            // btnLimpiarDemanda
            // 
            this.btnLimpiarDemanda.Location = new System.Drawing.Point(236, 568);
            this.btnLimpiarDemanda.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarDemanda.Name = "btnLimpiarDemanda";
            this.btnLimpiarDemanda.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarDemanda.TabIndex = 15;
            this.btnLimpiarDemanda.Text = "Limpiar";
            this.btnLimpiarDemanda.UseVisualStyleBackColor = true;
            this.btnLimpiarDemanda.Click += new System.EventHandler(this.btnLimpiarDemanda_Click);
            // 
            // btnActualizarDemanda
            // 
            this.btnActualizarDemanda.Location = new System.Drawing.Point(99, 568);
            this.btnActualizarDemanda.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizarDemanda.Name = "btnActualizarDemanda";
            this.btnActualizarDemanda.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarDemanda.TabIndex = 14;
            this.btnActualizarDemanda.Text = "Actualizar";
            this.btnActualizarDemanda.UseVisualStyleBackColor = true;
            this.btnActualizarDemanda.Click += new System.EventHandler(this.btnActualizarDemanda_Click);
            // 
            // FrmBCG2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 862);
            this.Controls.Add(this.btnLimpiarDemanda);
            this.Controls.Add(this.btnActualizarDemanda);
            this.Controls.Add(this.dgvEvolucionDemanda);
            this.Controls.Add(this.txtAnioFin);
            this.Controls.Add(this.txtAnioInicio);
            this.Controls.Add(this.label3);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBCG2";
            this.Text = "FrmBCG2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvolucionDemanda)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnioInicio;
        private System.Windows.Forms.TextBox txtAnioFin;
        private System.Windows.Forms.DataGridView dgvEvolucionDemanda;
        private System.Windows.Forms.Button btnLimpiarDemanda;
        private System.Windows.Forms.Button btnActualizarDemanda;
    }
}