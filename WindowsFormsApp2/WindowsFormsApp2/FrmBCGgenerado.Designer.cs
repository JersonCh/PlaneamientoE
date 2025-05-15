namespace WindowsFormsApp2
{
    partial class FrmBCGgenerado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBCGgenerado));
            this.txtVenta5 = new System.Windows.Forms.TextBox();
            this.txtVenta4 = new System.Windows.Forms.TextBox();
            this.txtVenta3 = new System.Windows.Forms.TextBox();
            this.txtVenta2 = new System.Windows.Forms.TextBox();
            this.txtVenta1 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.empresaTableAdapter1 = new WindowsFormsApp2.SOFTPETIDataSet_3TableAdapters.EmpresaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVenta5
            // 
            this.txtVenta5.Location = new System.Drawing.Point(703, 44);
            this.txtVenta5.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenta5.Name = "txtVenta5";
            this.txtVenta5.Size = new System.Drawing.Size(132, 22);
            this.txtVenta5.TabIndex = 15;
            // 
            // txtVenta4
            // 
            this.txtVenta4.Location = new System.Drawing.Point(562, 44);
            this.txtVenta4.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenta4.Name = "txtVenta4";
            this.txtVenta4.Size = new System.Drawing.Size(132, 22);
            this.txtVenta4.TabIndex = 14;
            // 
            // txtVenta3
            // 
            this.txtVenta3.Location = new System.Drawing.Point(406, 44);
            this.txtVenta3.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenta3.Name = "txtVenta3";
            this.txtVenta3.Size = new System.Drawing.Size(132, 22);
            this.txtVenta3.TabIndex = 13;
            // 
            // txtVenta2
            // 
            this.txtVenta2.Location = new System.Drawing.Point(253, 44);
            this.txtVenta2.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenta2.Name = "txtVenta2";
            this.txtVenta2.Size = new System.Drawing.Size(132, 22);
            this.txtVenta2.TabIndex = 12;
            // 
            // txtVenta1
            // 
            this.txtVenta1.Location = new System.Drawing.Point(111, 44);
            this.txtVenta1.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenta1.Name = "txtVenta1";
            this.txtVenta1.Size = new System.Drawing.Size(132, 22);
            this.txtVenta1.TabIndex = 11;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(179, 108);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(621, 405);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(755, 451);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(182, 102);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(755, 113);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(182, 102);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(39, 451);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(174, 102);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(54, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // empresaTableAdapter1
            // 
            this.empresaTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmBCGgenerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 588);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txtVenta5);
            this.Controls.Add(this.txtVenta4);
            this.Controls.Add(this.txtVenta3);
            this.Controls.Add(this.txtVenta2);
            this.Controls.Add(this.txtVenta1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBCGgenerado";
            this.Text = "FrmBCGgenerado";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtVenta5;
        private System.Windows.Forms.TextBox txtVenta4;
        private System.Windows.Forms.TextBox txtVenta3;
        private System.Windows.Forms.TextBox txtVenta2;
        private System.Windows.Forms.TextBox txtVenta1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private SOFTPETIDataSet_3TableAdapters.EmpresaTableAdapter empresaTableAdapter1;
    }
}