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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBCG3));
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
            this.btnActualizarResultado = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.chartBCG2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLimpiarChart = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBCG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(50, 15);
            this.dgvPrevision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPrevision.Name = "dgvPrevision";
            this.dgvPrevision.RowHeadersWidth = 51;
            this.dgvPrevision.RowTemplate.Height = 24;
            this.dgvPrevision.Size = new System.Drawing.Size(395, 144);
            this.dgvPrevision.TabIndex = 1;
            this.dgvPrevision.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrevision_CellEndEdit_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(326, 163);
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
            this.btnActualizar.Location = new System.Drawing.Point(189, 163);
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
            this.btnAgregarProducto.Location = new System.Drawing.Point(52, 163);
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
            this.dgvVLC.Location = new System.Drawing.Point(509, 15);
            this.dgvVLC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVLC.Name = "dgvVLC";
            this.dgvVLC.RowHeadersWidth = 51;
            this.dgvVLC.RowTemplate.Height = 24;
            this.dgvVLC.Size = new System.Drawing.Size(395, 144);
            this.dgvVLC.TabIndex = 7;
            this.dgvVLC.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVLC_CellEndEdit_1);
            this.dgvVLC.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVLC_ColumnHeaderMouseDoubleClick);
            // 
            // btnLimpiarCompetidor
            // 
            this.btnLimpiarCompetidor.Location = new System.Drawing.Point(782, 163);
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
            this.btnActualizarCompetidor.Location = new System.Drawing.Point(645, 163);
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
            this.btnAgregarCompetidor.Location = new System.Drawing.Point(508, 163);
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
            this.dgvVSA.Location = new System.Drawing.Point(54, 207);
            this.dgvVSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVSA.Name = "dgvVSA";
            this.dgvVSA.RowHeadersWidth = 51;
            this.dgvVSA.RowTemplate.Height = 24;
            this.dgvVSA.Size = new System.Drawing.Size(395, 149);
            this.dgvVSA.TabIndex = 11;
            // 
            // btnLimpiarVSA
            // 
            this.btnLimpiarVSA.Location = new System.Drawing.Point(274, 400);
            this.btnLimpiarVSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarVSA.Name = "btnLimpiarVSA";
            this.btnLimpiarVSA.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarVSA.TabIndex = 13;
            this.btnLimpiarVSA.Text = "Limpiar";
            this.btnLimpiarVSA.UseVisualStyleBackColor = true;
            this.btnLimpiarVSA.Click += new System.EventHandler(this.btnLimpiarVSA_Click);
            // 
            // btnActualizarVSA
            // 
            this.btnActualizarVSA.Location = new System.Drawing.Point(137, 400);
            this.btnActualizarVSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarVSA.Name = "btnActualizarVSA";
            this.btnActualizarVSA.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarVSA.TabIndex = 12;
            this.btnActualizarVSA.Text = "Actualizar";
            this.btnActualizarVSA.UseVisualStyleBackColor = true;
            this.btnActualizarVSA.Click += new System.EventHandler(this.btnActualizarVSA_Click);
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(75, 369);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtInicio.TabIndex = 14;
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(192, 369);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 15;
            // 
            // btnAnios
            // 
            this.btnAnios.Location = new System.Drawing.Point(311, 365);
            this.btnAnios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnios.Name = "btnAnios";
            this.btnAnios.Size = new System.Drawing.Size(122, 26);
            this.btnAnios.TabIndex = 16;
            this.btnAnios.Text = "Agregar Años";
            this.btnAnios.UseVisualStyleBackColor = true;
            this.btnAnios.Click += new System.EventHandler(this.btnAnios_Click);
            // 
            // btnActualizarResultado
            // 
            this.btnActualizarResultado.Location = new System.Drawing.Point(645, 377);
            this.btnActualizarResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarResultado.Name = "btnActualizarResultado";
            this.btnActualizarResultado.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarResultado.TabIndex = 20;
            this.btnActualizarResultado.Text = "Actualizar Resultado";
            this.btnActualizarResultado.UseVisualStyleBackColor = true;
            this.btnActualizarResultado.Click += new System.EventHandler(this.btnActualizarResultado_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(509, 207);
            this.dgvResultados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.RowTemplate.Height = 24;
            this.dgvResultados.Size = new System.Drawing.Size(395, 149);
            this.dgvResultados.TabIndex = 19;
            this.dgvResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellContentClick);
            // 
            // chartBCG2
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBCG2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBCG2.Legends.Add(legend1);
            this.chartBCG2.Location = new System.Drawing.Point(177, 430);
            this.chartBCG2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartBCG2.Name = "chartBCG2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBCG2.Series.Add(series1);
            this.chartBCG2.Size = new System.Drawing.Size(607, 422);
            this.chartBCG2.TabIndex = 22;
            this.chartBCG2.Text = "chart2";
            // 
            // btnLimpiarChart
            // 
            this.btnLimpiarChart.Location = new System.Drawing.Point(475, 863);
            this.btnLimpiarChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarChart.Name = "btnLimpiarChart";
            this.btnLimpiarChart.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarChart.TabIndex = 24;
            this.btnLimpiarChart.Text = "Limpiar";
            this.btnLimpiarChart.UseVisualStyleBackColor = true;
            this.btnLimpiarChart.Click += new System.EventHandler(this.btnLimpiarChart_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(338, 863);
            this.btnChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(122, 26);
            this.btnChart.TabIndex = 23;
            this.btnChart.Text = "Actualizar";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(762, 430);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(762, 791);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(48, 791);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(136, 83);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(48, 430);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(136, 83);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // FrmBCG3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 900);
            this.Controls.Add(this.btnLimpiarChart);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.chartBCG2);
            this.Controls.Add(this.btnActualizarResultado);
            this.Controls.Add(this.dgvResultados);
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
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBCG3";
            this.Text = "FrmBCG3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVSA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBCG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        private System.Windows.Forms.Button btnActualizarResultado;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBCG2;
        private System.Windows.Forms.Button btnLimpiarChart;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        //private System.Windows.Forms.DataVisualization.Charting.Chart chartBCG;
    }
}