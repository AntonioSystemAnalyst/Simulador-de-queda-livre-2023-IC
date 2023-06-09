namespace freeFall
{
    partial class Space
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Space));
            this.chartSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sfdSalve = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SalveTXT = new System.Windows.Forms.Button();
            this.SalveXLS = new System.Windows.Forms.Button();
            this.SalveImage = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox3D = new System.Windows.Forms.CheckBox();
            this.timerFocus = new System.Windows.Forms.Timer(this.components);
            this.Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EspaçoBóla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EspaçoPapel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EspaçoVácuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartSpace
            // 
            this.chartSpace.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartSpace.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpace.Legends.Add(legend1);
            this.chartSpace.Location = new System.Drawing.Point(6, 15);
            this.chartSpace.Name = "chartSpace";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSpace.Series.Add(series1);
            this.chartSpace.Size = new System.Drawing.Size(739, 456);
            this.chartSpace.TabIndex = 1;
            this.chartSpace.Text = "chart1";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tempo,
            this.EspaçoBóla,
            this.EspaçoPapel,
            this.EspaçoVácuo});
            this.dataGridView.Location = new System.Drawing.Point(6, 15);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(356, 352);
            this.dataGridView.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.SalveImage);
            this.groupBox1.Controls.Add(this.SalveXLS);
            this.groupBox1.Controls.Add(this.SalveTXT);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox1.Location = new System.Drawing.Point(760, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 99);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salvar dados";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox2.Location = new System.Drawing.Point(760, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 376);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // SalveTXT
            // 
            this.SalveTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalveTXT.ForeColor = System.Drawing.Color.Black;
            this.SalveTXT.Location = new System.Drawing.Point(132, 37);
            this.SalveTXT.Name = "SalveTXT";
            this.SalveTXT.Size = new System.Drawing.Size(112, 33);
            this.SalveTXT.TabIndex = 28;
            this.SalveTXT.Text = "Salvar em txt";
            this.SalveTXT.UseVisualStyleBackColor = true;
            this.SalveTXT.Click += new System.EventHandler(this.SalveTXT_Click);
            // 
            // SalveXLS
            // 
            this.SalveXLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalveXLS.ForeColor = System.Drawing.Color.Black;
            this.SalveXLS.Location = new System.Drawing.Point(250, 37);
            this.SalveXLS.Name = "SalveXLS";
            this.SalveXLS.Size = new System.Drawing.Size(112, 33);
            this.SalveXLS.TabIndex = 29;
            this.SalveXLS.Text = "Salvar em xls";
            this.SalveXLS.UseVisualStyleBackColor = true;
            this.SalveXLS.Click += new System.EventHandler(this.SalveXLS_Click);
            // 
            // SalveImage
            // 
            this.SalveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalveImage.ForeColor = System.Drawing.Color.Black;
            this.SalveImage.Location = new System.Drawing.Point(14, 37);
            this.SalveImage.Name = "SalveImage";
            this.SalveImage.Size = new System.Drawing.Size(112, 33);
            this.SalveImage.TabIndex = 30;
            this.SalveImage.Text = "Salvar imagem";
            this.SalveImage.UseVisualStyleBackColor = true;
            this.SalveImage.Click += new System.EventHandler(this.SalveImage_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.checkBox3D);
            this.groupBox3.Controls.Add(this.chartSpace);
            this.groupBox3.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox3.Location = new System.Drawing.Point(3, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(751, 477);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // checkBox3D
            // 
            this.checkBox3D.AutoSize = true;
            this.checkBox3D.Location = new System.Drawing.Point(707, 450);
            this.checkBox3D.Name = "checkBox3D";
            this.checkBox3D.Size = new System.Drawing.Size(38, 17);
            this.checkBox3D.TabIndex = 36;
            this.checkBox3D.Text = "3d";
            this.checkBox3D.UseVisualStyleBackColor = true;
            this.checkBox3D.CheckStateChanged += new System.EventHandler(this.checkBox3D_CheckStateChanged);
            // 
            // timerFocus
            // 
            this.timerFocus.Tick += new System.EventHandler(this.timerFocus_Tick);
            // 
            // Tempo
            // 
            this.Tempo.HeaderText = "Tempo";
            this.Tempo.Name = "Tempo";
            // 
            // EspaçoBóla
            // 
            this.EspaçoBóla.HeaderText = "EspaçoBóla";
            this.EspaçoBóla.Name = "EspaçoBóla";
            // 
            // EspaçoPapel
            // 
            this.EspaçoPapel.HeaderText = "EspaçoPapel";
            this.EspaçoPapel.Name = "EspaçoPapel";
            // 
            // EspaçoVácuo
            // 
            this.EspaçoVácuo.HeaderText = "EspaçoVácuo";
            this.EspaçoVácuo.Name = "EspaçoVácuo";
            this.EspaçoVácuo.ReadOnly = true;
            // 
            // Space
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1136, 480);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Space";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfico do espaço pelo tempo";
            this.Load += new System.EventHandler(this.Space_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpace;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.SaveFileDialog sfdSalve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SalveXLS;
        private System.Windows.Forms.Button SalveTXT;
        private System.Windows.Forms.Button SalveImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox3D;
        private System.Windows.Forms.Timer timerFocus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspaçoBóla;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspaçoPapel;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspaçoVácuo;
    }
}