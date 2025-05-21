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
            this.dgvCompetidores = new System.Windows.Forms.DataGridView();
            this.btnAgregarCompetidores = new System.Windows.Forms.Button();
            this.txtNumeroCompetidores = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvBCG = new System.Windows.Forms.DataGridView();
            this.btnActualizarBCG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvolucionDemanda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetidores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCG)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(53, 76);
            this.dgvPrevision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPrevision.Name = "dgvPrevision";
            this.dgvPrevision.RowHeadersWidth = 51;
            this.dgvPrevision.RowTemplate.Height = 24;
            this.dgvPrevision.Size = new System.Drawing.Size(527, 234);
            this.dgvPrevision.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(53, 334);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(163, 32);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(235, 334);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(163, 32);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(417, 334);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Previsión de ventas";
            // 
            // dgvTCM
            // 
            this.dgvTCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTCM.Location = new System.Drawing.Point(733, 76);
            this.dgvTCM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.btnLimpiarTCM.Location = new System.Drawing.Point(1099, 394);
            this.btnLimpiarTCM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarTCM.Name = "btnLimpiarTCM";
            this.btnLimpiarTCM.Size = new System.Drawing.Size(163, 32);
            this.btnLimpiarTCM.TabIndex = 8;
            this.btnLimpiarTCM.Text = "Limpiar";
            this.btnLimpiarTCM.UseVisualStyleBackColor = true;
            this.btnLimpiarTCM.Click += new System.EventHandler(this.btnLimpiarTCM_Click);
            // 
            // btnActualizarTCM
            // 
            this.btnActualizarTCM.Location = new System.Drawing.Point(916, 394);
            this.btnActualizarTCM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarTCM.Name = "btnActualizarTCM";
            this.btnActualizarTCM.Size = new System.Drawing.Size(163, 32);
            this.btnActualizarTCM.TabIndex = 7;
            this.btnActualizarTCM.Text = "Actualizar";
            this.btnActualizarTCM.UseVisualStyleBackColor = true;
            this.btnActualizarTCM.Click += new System.EventHandler(this.btnActualizarTCM_Click);
            // 
            // btnAgregarPeriodo
            // 
            this.btnAgregarPeriodo.Location = new System.Drawing.Point(735, 394);
            this.btnAgregarPeriodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(730, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tasa de crecimiento del mercado (TCM)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(731, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Elegir rango:";
            // 
            // txtAnioInicio
            // 
            this.txtAnioInicio.Location = new System.Drawing.Point(735, 354);
            this.txtAnioInicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnioInicio.Name = "txtAnioInicio";
            this.txtAnioInicio.Size = new System.Drawing.Size(132, 22);
            this.txtAnioInicio.TabIndex = 11;
            // 
            // txtAnioFin
            // 
            this.txtAnioFin.Location = new System.Drawing.Point(896, 354);
            this.txtAnioFin.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnioFin.Name = "txtAnioFin";
            this.txtAnioFin.Size = new System.Drawing.Size(132, 22);
            this.txtAnioFin.TabIndex = 12;
            // 
            // dgvEvolucionDemanda
            // 
            this.dgvEvolucionDemanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvolucionDemanda.Location = new System.Drawing.Point(53, 521);
            this.dgvEvolucionDemanda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEvolucionDemanda.Name = "dgvEvolucionDemanda";
            this.dgvEvolucionDemanda.RowHeadersWidth = 51;
            this.dgvEvolucionDemanda.RowTemplate.Height = 24;
            this.dgvEvolucionDemanda.Size = new System.Drawing.Size(527, 234);
            this.dgvEvolucionDemanda.TabIndex = 13;
            this.dgvEvolucionDemanda.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvolucionDemanda_CellValueChanged);
            this.dgvEvolucionDemanda.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvEvolucionDemanda_EditingControlShowing);
            // 
            // btnLimpiarDemanda
            // 
            this.btnLimpiarDemanda.Location = new System.Drawing.Point(315, 787);
            this.btnLimpiarDemanda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarDemanda.Name = "btnLimpiarDemanda";
            this.btnLimpiarDemanda.Size = new System.Drawing.Size(163, 32);
            this.btnLimpiarDemanda.TabIndex = 15;
            this.btnLimpiarDemanda.Text = "Limpiar";
            this.btnLimpiarDemanda.UseVisualStyleBackColor = true;
            this.btnLimpiarDemanda.Click += new System.EventHandler(this.btnLimpiarDemanda_Click);
            // 
            // btnActualizarDemanda
            // 
            this.btnActualizarDemanda.Location = new System.Drawing.Point(132, 787);
            this.btnActualizarDemanda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarDemanda.Name = "btnActualizarDemanda";
            this.btnActualizarDemanda.Size = new System.Drawing.Size(163, 32);
            this.btnActualizarDemanda.TabIndex = 14;
            this.btnActualizarDemanda.Text = "Actualizar";
            this.btnActualizarDemanda.UseVisualStyleBackColor = true;
            this.btnActualizarDemanda.Click += new System.EventHandler(this.btnActualizarDemanda_Click);
            // 
            // dgvCompetidores
            // 
            this.dgvCompetidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetidores.Location = new System.Drawing.Point(733, 521);
            this.dgvCompetidores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCompetidores.Name = "dgvCompetidores";
            this.dgvCompetidores.RowHeadersWidth = 51;
            this.dgvCompetidores.RowTemplate.Height = 24;
            this.dgvCompetidores.Size = new System.Drawing.Size(527, 234);
            this.dgvCompetidores.TabIndex = 16;
            this.dgvCompetidores.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompetidores_CellValueChanged);
            this.dgvCompetidores.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCompetidores_EditingControlShowing);
            // 
            // btnAgregarCompetidores
            // 
            this.btnAgregarCompetidores.Location = new System.Drawing.Point(894, 774);
            this.btnAgregarCompetidores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarCompetidores.Name = "btnAgregarCompetidores";
            this.btnAgregarCompetidores.Size = new System.Drawing.Size(163, 32);
            this.btnAgregarCompetidores.TabIndex = 17;
            this.btnAgregarCompetidores.Text = "Agregar Competidores";
            this.btnAgregarCompetidores.UseVisualStyleBackColor = true;
            this.btnAgregarCompetidores.Click += new System.EventHandler(this.btnAgregarCompetidores_Click);
            // 
            // txtNumeroCompetidores
            // 
            this.txtNumeroCompetidores.Location = new System.Drawing.Point(731, 779);
            this.txtNumeroCompetidores.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroCompetidores.Name = "txtNumeroCompetidores";
            this.txtNumeroCompetidores.Size = new System.Drawing.Size(132, 22);
            this.txtNumeroCompetidores.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(515, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Evolución de la demanda global sector (en miles de soles)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(728, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(491, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Niveles de venta de los competidores de cada producto";
            // 
            // dgvBCG
            // 
            this.dgvBCG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBCG.Location = new System.Drawing.Point(53, 936);
            this.dgvBCG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBCG.Name = "dgvBCG";
            this.dgvBCG.RowHeadersWidth = 51;
            this.dgvBCG.RowTemplate.Height = 24;
            this.dgvBCG.Size = new System.Drawing.Size(527, 234);
            this.dgvBCG.TabIndex = 21;
            // 
            // btnActualizarBCG
            // 
            this.btnActualizarBCG.Location = new System.Drawing.Point(622, 969);
            this.btnActualizarBCG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarBCG.Name = "btnActualizarBCG";
            this.btnActualizarBCG.Size = new System.Drawing.Size(163, 32);
            this.btnActualizarBCG.TabIndex = 22;
            this.btnActualizarBCG.Text = "Actualizar";
            this.btnActualizarBCG.UseVisualStyleBackColor = true;
            this.btnActualizarBCG.Click += new System.EventHandler(this.btnActualizarBCG_Click);
            // 
            // FrmBCG2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 1415);
            this.Controls.Add(this.btnActualizarBCG);
            this.Controls.Add(this.dgvBCG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumeroCompetidores);
            this.Controls.Add(this.btnAgregarCompetidores);
            this.Controls.Add(this.dgvCompetidores);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmBCG2";
            this.Text = "FrmBCG2";
            this.Load += new System.EventHandler(this.FrmBCG2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvolucionDemanda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetidores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCG)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvCompetidores;
        private System.Windows.Forms.Button btnAgregarCompetidores;
        private System.Windows.Forms.TextBox txtNumeroCompetidores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvBCG;
        private System.Windows.Forms.Button btnActualizarBCG;
    }
}