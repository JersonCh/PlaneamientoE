namespace WindowsFormsApp2
{
    partial class panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panel));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTasasCrecimiento = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvBCG = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.dgvDemandaGlobal = new System.Windows.Forms.DataGridView();
            this.dgvCompetidores = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasasCrecimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemandaGlobal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetidores)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(79, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 42);
            this.button1.TabIndex = 43;
            this.button1.Text = "INDICE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(819, 32);
            this.label1.TabIndex = 40;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(659, 32);
            this.label3.TabIndex = 45;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "PREVISIÓN DE VENTAS";
            // 
            // dgvTasasCrecimiento
            // 
            this.dgvTasasCrecimiento.AllowUserToAddRows = false;
            this.dgvTasasCrecimiento.AllowUserToDeleteRows = false;
            this.dgvTasasCrecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasasCrecimiento.Location = new System.Drawing.Point(166, 426);
            this.dgvTasasCrecimiento.Name = "dgvTasasCrecimiento";
            this.dgvTasasCrecimiento.ReadOnly = true;
            this.dgvTasasCrecimiento.RowHeadersWidth = 51;
            this.dgvTasasCrecimiento.RowTemplate.Height = 24;
            this.dgvTasasCrecimiento.Size = new System.Drawing.Size(842, 213);
            this.dgvTasasCrecimiento.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(473, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "Tasas de Crecimiento del Mercado";
            // 
            // dgvBCG
            // 
            this.dgvBCG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBCG.Location = new System.Drawing.Point(580, 186);
            this.dgvBCG.Name = "dgvBCG";
            this.dgvBCG.RowHeadersWidth = 51;
            this.dgvBCG.RowTemplate.Height = 24;
            this.dgvBCG.Size = new System.Drawing.Size(596, 211);
            this.dgvBCG.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 651);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(464, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "EVOLUCIÓN DE LA DEMANDA GLOBAL SECTOR (en miles de soles)";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(79, 194);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.Size = new System.Drawing.Size(437, 203);
            this.dgvVentas.TabIndex = 48;
            // 
            // dgvDemandaGlobal
            // 
            this.dgvDemandaGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemandaGlobal.Location = new System.Drawing.Point(29, 684);
            this.dgvDemandaGlobal.Name = "dgvDemandaGlobal";
            this.dgvDemandaGlobal.RowHeadersWidth = 51;
            this.dgvDemandaGlobal.RowTemplate.Height = 24;
            this.dgvDemandaGlobal.Size = new System.Drawing.Size(596, 211);
            this.dgvDemandaGlobal.TabIndex = 53;
            // 
            // dgvCompetidores
            // 
            this.dgvCompetidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetidores.Location = new System.Drawing.Point(640, 684);
            this.dgvCompetidores.Name = "dgvCompetidores";
            this.dgvCompetidores.RowHeadersWidth = 51;
            this.dgvCompetidores.RowTemplate.Height = 24;
            this.dgvCompetidores.Size = new System.Drawing.Size(596, 211);
            this.dgvCompetidores.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(694, 651);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(454, 16);
            this.label4.TabIndex = 55;
            this.label4.Text = "NIVELES DE VENTA DE LOS COMPETIDORES DE CADA PRODUCTO";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(621, 947);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 52);
            this.button5.TabIndex = 60;
            this.button5.Text = "RESULTADOS";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(471, 947);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 52);
            this.button4.TabIndex = 59;
            this.button4.Text = "VII. BCG";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(821, 960);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 28);
            this.btnSiguiente.TabIndex = 58;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(317, 960);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 28);
            this.btnAtras.TabIndex = 57;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1255, 1055);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCompetidores);
            this.Controls.Add(this.dgvDemandaGlobal);
            this.Controls.Add(this.dgvBCG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvTasasCrecimiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "panel";
            this.Text = "FrmAutodiagnosticoBCG";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasasCrecimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemandaGlobal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetidores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTasasCrecimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvBCG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridView dgvDemandaGlobal;
        private System.Windows.Forms.DataGridView dgvCompetidores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAtras;
    }
}