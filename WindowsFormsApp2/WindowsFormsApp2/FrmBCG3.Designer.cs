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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtD3 = new System.Windows.Forms.TextBox();
            this.txtD4 = new System.Windows.Forms.TextBox();
            this.txtF3 = new System.Windows.Forms.TextBox();
            this.txtF4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarResultado = new System.Windows.Forms.Button();
            this.btnSiguiente = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBCG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrevision
            // 
            this.dgvPrevision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevision.Location = new System.Drawing.Point(32, 67);
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
            this.btnLimpiar.BackColor = System.Drawing.Color.Black;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(308, 216);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Black;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(171, 216);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(122, 26);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.Black;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(34, 216);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(122, 26);
            this.btnAgregarProducto.TabIndex = 4;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // dgvVLC
            // 
            this.dgvVLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVLC.Location = new System.Drawing.Point(491, 67);
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
            this.btnLimpiarCompetidor.BackColor = System.Drawing.Color.Black;
            this.btnLimpiarCompetidor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCompetidor.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarCompetidor.Location = new System.Drawing.Point(764, 216);
            this.btnLimpiarCompetidor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarCompetidor.Name = "btnLimpiarCompetidor";
            this.btnLimpiarCompetidor.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiarCompetidor.TabIndex = 10;
            this.btnLimpiarCompetidor.Text = "Limpiar";
            this.btnLimpiarCompetidor.UseVisualStyleBackColor = false;
            this.btnLimpiarCompetidor.Click += new System.EventHandler(this.btnLimpiarCompetidor_Click);
            // 
            // btnActualizarCompetidor
            // 
            this.btnActualizarCompetidor.BackColor = System.Drawing.Color.Black;
            this.btnActualizarCompetidor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarCompetidor.ForeColor = System.Drawing.Color.White;
            this.btnActualizarCompetidor.Location = new System.Drawing.Point(627, 216);
            this.btnActualizarCompetidor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarCompetidor.Name = "btnActualizarCompetidor";
            this.btnActualizarCompetidor.Size = new System.Drawing.Size(122, 26);
            this.btnActualizarCompetidor.TabIndex = 9;
            this.btnActualizarCompetidor.Text = "Actualizar";
            this.btnActualizarCompetidor.UseVisualStyleBackColor = false;
            this.btnActualizarCompetidor.Click += new System.EventHandler(this.btnActualizarCompetidor_Click);
            // 
            // btnAgregarCompetidor
            // 
            this.btnAgregarCompetidor.BackColor = System.Drawing.Color.Black;
            this.btnAgregarCompetidor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCompetidor.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCompetidor.Location = new System.Drawing.Point(490, 216);
            this.btnAgregarCompetidor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarCompetidor.Name = "btnAgregarCompetidor";
            this.btnAgregarCompetidor.Size = new System.Drawing.Size(122, 26);
            this.btnAgregarCompetidor.TabIndex = 8;
            this.btnAgregarCompetidor.Text = "Agregar Competidor";
            this.btnAgregarCompetidor.UseVisualStyleBackColor = false;
            this.btnAgregarCompetidor.Click += new System.EventHandler(this.btnAgregarCompetidor_Click);
            // 
            // dgvVSA
            // 
            this.dgvVSA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVSA.Location = new System.Drawing.Point(36, 309);
            this.dgvVSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVSA.Name = "dgvVSA";
            this.dgvVSA.RowHeadersWidth = 51;
            this.dgvVSA.RowTemplate.Height = 24;
            this.dgvVSA.Size = new System.Drawing.Size(395, 149);
            this.dgvVSA.TabIndex = 11;
            // 
            // btnLimpiarVSA
            // 
            this.btnLimpiarVSA.BackColor = System.Drawing.Color.Black;
            this.btnLimpiarVSA.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarVSA.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarVSA.Location = new System.Drawing.Point(256, 502);
            this.btnLimpiarVSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarVSA.Name = "btnLimpiarVSA";
            this.btnLimpiarVSA.Size = new System.Drawing.Size(122, 31);
            this.btnLimpiarVSA.TabIndex = 13;
            this.btnLimpiarVSA.Text = "Limpiar";
            this.btnLimpiarVSA.UseVisualStyleBackColor = false;
            this.btnLimpiarVSA.Click += new System.EventHandler(this.btnLimpiarVSA_Click);
            // 
            // btnActualizarVSA
            // 
            this.btnActualizarVSA.BackColor = System.Drawing.Color.Black;
            this.btnActualizarVSA.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarVSA.ForeColor = System.Drawing.Color.White;
            this.btnActualizarVSA.Location = new System.Drawing.Point(119, 502);
            this.btnActualizarVSA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarVSA.Name = "btnActualizarVSA";
            this.btnActualizarVSA.Size = new System.Drawing.Size(122, 31);
            this.btnActualizarVSA.TabIndex = 12;
            this.btnActualizarVSA.Text = "Actualizar";
            this.btnActualizarVSA.UseVisualStyleBackColor = false;
            this.btnActualizarVSA.Click += new System.EventHandler(this.btnActualizarVSA_Click);
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(57, 471);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtInicio.TabIndex = 14;
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(174, 471);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 15;
            // 
            // btnAnios
            // 
            this.btnAnios.BackColor = System.Drawing.Color.Black;
            this.btnAnios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnios.ForeColor = System.Drawing.Color.White;
            this.btnAnios.Location = new System.Drawing.Point(293, 467);
            this.btnAnios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnios.Name = "btnAnios";
            this.btnAnios.Size = new System.Drawing.Size(122, 31);
            this.btnAnios.TabIndex = 16;
            this.btnAnios.Text = "Agregar Años";
            this.btnAnios.UseVisualStyleBackColor = false;
            this.btnAnios.Click += new System.EventHandler(this.btnAnios_Click);
            // 
            // btnActualizarResultado
            // 
            this.btnActualizarResultado.BackColor = System.Drawing.Color.Black;
            this.btnActualizarResultado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarResultado.ForeColor = System.Drawing.Color.White;
            this.btnActualizarResultado.Location = new System.Drawing.Point(564, 479);
            this.btnActualizarResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarResultado.Name = "btnActualizarResultado";
            this.btnActualizarResultado.Size = new System.Drawing.Size(122, 32);
            this.btnActualizarResultado.TabIndex = 20;
            this.btnActualizarResultado.Text = "Actualizar Resultado";
            this.btnActualizarResultado.UseVisualStyleBackColor = false;
            this.btnActualizarResultado.Click += new System.EventHandler(this.btnActualizarResultado_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(491, 309);
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
            this.chartBCG2.Location = new System.Drawing.Point(177, 560);
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
            this.btnLimpiarChart.BackColor = System.Drawing.Color.Black;
            this.btnLimpiarChart.FlatAppearance.BorderSize = 0;
            this.btnLimpiarChart.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarChart.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarChart.Location = new System.Drawing.Point(475, 993);
            this.btnLimpiarChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarChart.Name = "btnLimpiarChart";
            this.btnLimpiarChart.Size = new System.Drawing.Size(122, 33);
            this.btnLimpiarChart.TabIndex = 24;
            this.btnLimpiarChart.Text = "Limpiar";
            this.btnLimpiarChart.UseVisualStyleBackColor = false;
            this.btnLimpiarChart.Click += new System.EventHandler(this.btnLimpiarChart_Click);
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.Black;
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChart.ForeColor = System.Drawing.Color.White;
            this.btnChart.Location = new System.Drawing.Point(338, 993);
            this.btnChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(122, 33);
            this.btnChart.TabIndex = 23;
            this.btnChart.Text = "Actualizar";
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(270, 1202);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(384, 50);
            this.btnGuardar.TabIndex = 60;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtD3
            // 
            this.txtD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtD3.Location = new System.Drawing.Point(51, 26);
            this.txtD3.Name = "txtD3";
            this.txtD3.Size = new System.Drawing.Size(319, 27);
            this.txtD3.TabIndex = 45;
            // 
            // txtD4
            // 
            this.txtD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtD4.Location = new System.Drawing.Point(51, 73);
            this.txtD4.Name = "txtD4";
            this.txtD4.Size = new System.Drawing.Size(319, 27);
            this.txtD4.TabIndex = 44;
            // 
            // txtF3
            // 
            this.txtF3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtF3.Location = new System.Drawing.Point(47, 23);
            this.txtF3.Name = "txtF3";
            this.txtF3.Size = new System.Drawing.Size(395, 27);
            this.txtF3.TabIndex = 45;
            // 
            // txtF4
            // 
            this.txtF4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtF4.Location = new System.Drawing.Point(47, 72);
            this.txtF4.Name = "txtF4";
            this.txtF4.Size = new System.Drawing.Size(395, 27);
            this.txtF4.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(27, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(294, 45);
            this.label9.TabIndex = 62;
            this.label9.Text = "Previsión de ventas";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 45);
            this.label2.TabIndex = 64;
            this.label2.Text = "Evolución de la demanda global sector";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(487, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 45);
            this.label3.TabIndex = 65;
            this.label3.Text = "Resultados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(487, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 45);
            this.label1.TabIndex = 66;
            this.label1.Text = "Ventas líder por competidor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardarResultado
            // 
            this.btnGuardarResultado.BackColor = System.Drawing.Color.Black;
            this.btnGuardarResultado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarResultado.ForeColor = System.Drawing.Color.White;
            this.btnGuardarResultado.Location = new System.Drawing.Point(704, 479);
            this.btnGuardarResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardarResultado.Name = "btnGuardarResultado";
            this.btnGuardarResultado.Size = new System.Drawing.Size(122, 32);
            this.btnGuardarResultado.TabIndex = 67;
            this.btnGuardarResultado.Text = "Guardar Resultado";
            this.btnGuardarResultado.UseVisualStyleBackColor = false;
            this.btnGuardarResultado.Click += new System.EventHandler(this.btnGuardarResultado_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSiguiente.IconColor = System.Drawing.Color.Black;
            this.btnSiguiente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSiguiente.Location = new System.Drawing.Point(37, 774);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(120, 33);
            this.btnSiguiente.TabIndex = 33;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(762, 560);
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
            this.pictureBox2.Location = new System.Drawing.Point(762, 921);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(48, 560);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(136, 83);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(48, 921);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(136, 83);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(919, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 45);
            this.label4.TabIndex = 69;
            this.label4.Text = "Lista de mis productos registrados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvListar
            // 
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Location = new System.Drawing.Point(922, 67);
            this.dgvListar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.RowHeadersWidth = 51;
            this.dgvListar.RowTemplate.Height = 24;
            this.dgvListar.Size = new System.Drawing.Size(496, 1213);
            this.dgvListar.TabIndex = 68;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.label66);
            this.groupBox3.Controls.Add(this.txtF3);
            this.groupBox3.Controls.Add(this.txtF4);
            this.groupBox3.Controls.Add(this.label76);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 1053);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 123);
            this.groupBox3.TabIndex = 1004;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fortalezas";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(6, 72);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(35, 21);
            this.label66.TabIndex = 51;
            this.label66.Text = "F4 :";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(6, 22);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(35, 21);
            this.label76.TabIndex = 50;
            this.label76.Text = "F3 :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtD3);
            this.groupBox1.Controls.Add(this.txtD4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(500, 1053);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 123);
            this.groupBox1.TabIndex = 1005;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debilidades";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 21);
            this.label5.TabIndex = 51;
            this.label5.Text = "D4 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 21);
            this.label6.TabIndex = 50;
            this.label6.Text = "D3 :";
            // 
            // FrmBCG3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1455, 894);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvListar);
            this.Controls.Add(this.btnGuardarResultado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSiguiente);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private FontAwesome.Sharp.IconButton btnSiguiente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtD3;
        private System.Windows.Forms.TextBox txtD4;
        private System.Windows.Forms.TextBox txtF3;
        private System.Windows.Forms.TextBox txtF4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarResultado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        //private System.Windows.Forms.DataVisualization.Charting.Chart chartBCG;
    }
}