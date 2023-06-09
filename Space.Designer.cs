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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Space));
            this.chartSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewPlanets = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlanets)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSpace
            // 
            this.chartSpace.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartSpace.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpace.Legends.Add(legend1);
            this.chartSpace.Location = new System.Drawing.Point(2, 1);
            this.chartSpace.Name = "chartSpace";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSpace.Series.Add(series1);
            this.chartSpace.Size = new System.Drawing.Size(780, 488);
            this.chartSpace.TabIndex = 1;
            this.chartSpace.Text = "chart1";
            // 
            // dataGridViewPlanets
            // 
            this.dataGridViewPlanets.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlanets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlanets.ColumnHeadersVisible = false;
            this.dataGridViewPlanets.Location = new System.Drawing.Point(788, 1);
            this.dataGridViewPlanets.Name = "dataGridViewPlanets";
            this.dataGridViewPlanets.RowHeadersVisible = false;
            this.dataGridViewPlanets.Size = new System.Drawing.Size(360, 361);
            this.dataGridViewPlanets.TabIndex = 16;
            // 
            // Space
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1149, 501);
            this.Controls.Add(this.dataGridViewPlanets);
            this.Controls.Add(this.chartSpace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Space";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfico do espaço pelo tempo";
            this.Load += new System.EventHandler(this.Space_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlanets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpace;
        private System.Windows.Forms.DataGridView dataGridViewPlanets;
    }
}