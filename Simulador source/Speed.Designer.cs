﻿namespace freeFall
{
    partial class Speed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Speed));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox3D = new System.Windows.Forms.CheckBox();
            this.labelTextColor = new System.Windows.Forms.Label();
            this.trackBarColors = new System.Windows.Forms.TrackBar();
            this.chartSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxSalve = new System.Windows.Forms.GroupBox();
            this.buttonTableForDot = new System.Windows.Forms.Button();
            this.SalveImage = new System.Windows.Forms.Button();
            this.SalveXLS = new System.Windows.Forms.Button();
            this.SalveTXT = new System.Windows.Forms.Button();
            this.timerFocus = new System.Windows.Forms.Timer(this.components);
            this.Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bóla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Papel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vácuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).BeginInit();
            this.groupBoxResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxSalve.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.checkBox3D);
            this.groupBox3.Controls.Add(this.labelTextColor);
            this.groupBox3.Controls.Add(this.trackBarColors);
            this.groupBox3.Controls.Add(this.chartSpeed);
            this.groupBox3.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox3.Location = new System.Drawing.Point(3, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(751, 477);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // checkBox3D
            // 
            this.checkBox3D.AutoSize = true;
            this.checkBox3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3D.Location = new System.Drawing.Point(705, 457);
            this.checkBox3D.Name = "checkBox3D";
            this.checkBox3D.Size = new System.Drawing.Size(40, 17);
            this.checkBox3D.TabIndex = 36;
            this.checkBox3D.Text = "3d";
            this.checkBox3D.UseVisualStyleBackColor = true;
            this.checkBox3D.CheckStateChanged += new System.EventHandler(this.checkBox3D_CheckStateChanged);
            // 
            // labelTextColor
            // 
            this.labelTextColor.AutoSize = true;
            this.labelTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextColor.ForeColor = System.Drawing.Color.Cyan;
            this.labelTextColor.Location = new System.Drawing.Point(661, 400);
            this.labelTextColor.Name = "labelTextColor";
            this.labelTextColor.Size = new System.Drawing.Size(84, 15);
            this.labelTextColor.TabIndex = 44;
            this.labelTextColor.Text = "Cor do texto";
            // 
            // trackBarColors
            // 
            this.trackBarColors.BackColor = System.Drawing.Color.Black;
            this.trackBarColors.Location = new System.Drawing.Point(660, 418);
            this.trackBarColors.Maximum = 9;
            this.trackBarColors.Minimum = 1;
            this.trackBarColors.Name = "trackBarColors";
            this.trackBarColors.Size = new System.Drawing.Size(85, 45);
            this.trackBarColors.TabIndex = 43;
            this.trackBarColors.Value = 1;
            this.trackBarColors.Scroll += new System.EventHandler(this.trackBarColors_Scroll);
            // 
            // chartSpeed
            // 
            this.chartSpeed.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartSpeed.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpeed.Legends.Add(legend1);
            this.chartSpeed.Location = new System.Drawing.Point(6, 15);
            this.chartSpeed.Name = "chartSpeed";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSpeed.Series.Add(series1);
            this.chartSpeed.Size = new System.Drawing.Size(739, 456);
            this.chartSpeed.TabIndex = 1;
            this.chartSpeed.Text = "chart1";
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxResults.Controls.Add(this.dataGridView);
            this.groupBoxResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxResults.ForeColor = System.Drawing.Color.Cyan;
            this.groupBoxResults.Location = new System.Drawing.Point(760, 1);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(368, 376);
            this.groupBoxResults.TabIndex = 22;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Dados do experimento";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tempo,
            this.Bóla,
            this.Papel,
            this.Vácuo});
            this.dataGridView.GridColor = System.Drawing.Color.Black;
            this.dataGridView.Location = new System.Drawing.Point(6, 15);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(356, 352);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // groupBoxSalve
            // 
            this.groupBoxSalve.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSalve.Controls.Add(this.buttonTableForDot);
            this.groupBoxSalve.Controls.Add(this.SalveImage);
            this.groupBoxSalve.Controls.Add(this.SalveXLS);
            this.groupBoxSalve.Controls.Add(this.SalveTXT);
            this.groupBoxSalve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSalve.ForeColor = System.Drawing.Color.Cyan;
            this.groupBoxSalve.Location = new System.Drawing.Point(760, 379);
            this.groupBoxSalve.Name = "groupBoxSalve";
            this.groupBoxSalve.Size = new System.Drawing.Size(368, 99);
            this.groupBoxSalve.TabIndex = 21;
            this.groupBoxSalve.TabStop = false;
            this.groupBoxSalve.Text = "Exportar dados";
            // 
            // buttonTableForDot
            // 
            this.buttonTableForDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTableForDot.ForeColor = System.Drawing.Color.Black;
            this.buttonTableForDot.Location = new System.Drawing.Point(280, 37);
            this.buttonTableForDot.Name = "buttonTableForDot";
            this.buttonTableForDot.Size = new System.Drawing.Size(84, 33);
            this.buttonTableForDot.TabIndex = 31;
            this.buttonTableForDot.Text = "CSV";
            this.buttonTableForDot.UseVisualStyleBackColor = true;
            this.buttonTableForDot.Click += new System.EventHandler(this.buttonTableForDot_Click);
            // 
            // SalveImage
            // 
            this.SalveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalveImage.ForeColor = System.Drawing.Color.Black;
            this.SalveImage.Location = new System.Drawing.Point(4, 37);
            this.SalveImage.Name = "SalveImage";
            this.SalveImage.Size = new System.Drawing.Size(84, 33);
            this.SalveImage.TabIndex = 30;
            this.SalveImage.Text = "Imagem";
            this.SalveImage.UseVisualStyleBackColor = true;
            this.SalveImage.Click += new System.EventHandler(this.SalveImage_Click);
            // 
            // SalveXLS
            // 
            this.SalveXLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalveXLS.ForeColor = System.Drawing.Color.Black;
            this.SalveXLS.Location = new System.Drawing.Point(191, 37);
            this.SalveXLS.Name = "SalveXLS";
            this.SalveXLS.Size = new System.Drawing.Size(84, 33);
            this.SalveXLS.TabIndex = 29;
            this.SalveXLS.Text = "Tabelas";
            this.SalveXLS.UseVisualStyleBackColor = true;
            this.SalveXLS.Click += new System.EventHandler(this.SalveXLS_Click);
            // 
            // SalveTXT
            // 
            this.SalveTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalveTXT.ForeColor = System.Drawing.Color.Black;
            this.SalveTXT.Location = new System.Drawing.Point(93, 37);
            this.SalveTXT.Name = "SalveTXT";
            this.SalveTXT.Size = new System.Drawing.Size(93, 33);
            this.SalveTXT.TabIndex = 28;
            this.SalveTXT.Text = "Parâmetros";
            this.SalveTXT.UseVisualStyleBackColor = true;
            this.SalveTXT.Click += new System.EventHandler(this.SalveTXT_Click);
            // 
            // timerFocus
            // 
            this.timerFocus.Tick += new System.EventHandler(this.timerFocus_Tick);
            // 
            // Tempo
            // 
            this.Tempo.HeaderText = "t (s)";
            this.Tempo.Name = "Tempo";
            this.Tempo.Width = 60;
            // 
            // Bóla
            // 
            this.Bóla.HeaderText = "Bola           v (m/s)";
            this.Bóla.Name = "Bóla";
            this.Bóla.Width = 85;
            // 
            // Papel
            // 
            this.Papel.HeaderText = "Papel         v (m/s)";
            this.Papel.Name = "Papel";
            this.Papel.Width = 85;
            // 
            // Vácuo
            // 
            this.Vácuo.HeaderText = "C. Vácuo    v (m/s)";
            this.Vácuo.Name = "Vácuo";
            this.Vácuo.ReadOnly = true;
            this.Vácuo.Width = 85;
            // 
            // Speed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1132, 480);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxSalve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Speed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfico da velocidade em função do tempo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Speed_FormClosing);
            this.Load += new System.EventHandler(this.Speed_Load);
            this.Resize += new System.EventHandler(this.Speed_Resize);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).EndInit();
            this.groupBoxResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxSalve.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox3D;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpeed;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBoxSalve;
        private System.Windows.Forms.Button SalveImage;
        private System.Windows.Forms.Button SalveXLS;
        private System.Windows.Forms.Button SalveTXT;
        private System.Windows.Forms.Timer timerFocus;
        private System.Windows.Forms.Label labelTextColor;
        private System.Windows.Forms.TrackBar trackBarColors;
        private System.Windows.Forms.Button buttonTableForDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bóla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Papel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vácuo;
    }
}