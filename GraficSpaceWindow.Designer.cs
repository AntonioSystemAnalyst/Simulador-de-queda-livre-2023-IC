namespace freeFall
{
    partial class GraficSpaceWindow
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
            this.chartSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSpace
            // 
            this.chartSpace.BackColor = System.Drawing.Color.Black;
            this.chartSpace.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartSpace.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpace.Legends.Add(legend1);
            this.chartSpace.Location = new System.Drawing.Point(3, 3);
            this.chartSpace.Name = "chartSpace";
            this.chartSpace.Size = new System.Drawing.Size(367, 304);
            this.chartSpace.TabIndex = 1;
            this.chartSpace.Text = "chart1";
            this.chartSpace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartSpace_MouseClick);
            // 
            // GraficSpaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(378, 310);
            this.Controls.Add(this.chartSpace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GraficSpaceWindow";
            this.Text = "GraficSpaceWindow";
            this.Load += new System.EventHandler(this.GraficSpaceWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpace;
    }
}