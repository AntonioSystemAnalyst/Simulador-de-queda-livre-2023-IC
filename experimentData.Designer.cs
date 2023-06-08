namespace freeFall
{
    partial class experimentData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(experimentData));
            this.buttonFocus = new System.Windows.Forms.Button();
            this.richTextBoxExperimentData = new System.Windows.Forms.RichTextBox();
            this.dataGridViewPlanets = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlanets)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFocus
            // 
            this.buttonFocus.Location = new System.Drawing.Point(387, 443);
            this.buttonFocus.Name = "buttonFocus";
            this.buttonFocus.Size = new System.Drawing.Size(70, 23);
            this.buttonFocus.TabIndex = 1;
            this.buttonFocus.Text = "button1";
            this.buttonFocus.UseVisualStyleBackColor = true;
            this.buttonFocus.Click += new System.EventHandler(this.buttonFocus_Click);
            // 
            // richTextBoxExperimentData
            // 
            this.richTextBoxExperimentData.BackColor = System.Drawing.Color.Black;
            this.richTextBoxExperimentData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxExperimentData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxExperimentData.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBoxExperimentData.Location = new System.Drawing.Point(872, 12);
            this.richTextBoxExperimentData.Name = "richTextBoxExperimentData";
            this.richTextBoxExperimentData.ReadOnly = true;
            this.richTextBoxExperimentData.Size = new System.Drawing.Size(448, 404);
            this.richTextBoxExperimentData.TabIndex = 2;
            this.richTextBoxExperimentData.Text = "";
            // 
            // dataGridViewPlanets
            // 
            this.dataGridViewPlanets.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlanets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlanets.ColumnHeadersVisible = false;
            this.dataGridViewPlanets.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewPlanets.Name = "dataGridViewPlanets";
            this.dataGridViewPlanets.RowHeadersVisible = false;
            this.dataGridViewPlanets.Size = new System.Drawing.Size(316, 352);
            this.dataGridViewPlanets.TabIndex = 15;
            // 
            // experimentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(319, 358);
            this.Controls.Add(this.dataGridViewPlanets);
            this.Controls.Add(this.richTextBoxExperimentData);
            this.Controls.Add(this.buttonFocus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "experimentData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados do experimento ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.experimentData_FormClosing);
            this.Load += new System.EventHandler(this.experimentData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlanets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFocus;
        private System.Windows.Forms.RichTextBox richTextBoxExperimentData;
        private System.Windows.Forms.DataGridView dataGridViewPlanets;
    }
}