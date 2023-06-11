namespace freeFall
{
    partial class Data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Data));
            this.richTextBoxPlanet = new System.Windows.Forms.RichTextBox();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlanets = new System.Windows.Forms.PictureBox();
            this.dataGridViewPlanets = new System.Windows.Forms.DataGridView();
            this.labelPlanet = new System.Windows.Forms.Label();
            this.timerFocus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlanets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlanets)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxPlanet
            // 
            this.richTextBoxPlanet.BackColor = System.Drawing.Color.Black;
            this.richTextBoxPlanet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPlanet.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBoxPlanet.Location = new System.Drawing.Point(461, 154);
            this.richTextBoxPlanet.Name = "richTextBoxPlanet";
            this.richTextBoxPlanet.ReadOnly = true;
            this.richTextBoxPlanet.Size = new System.Drawing.Size(472, 222);
            this.richTextBoxPlanet.TabIndex = 0;
            this.richTextBoxPlanet.Text = "";
            this.richTextBoxPlanet.TextChanged += new System.EventHandler(this.richTextBoxPlanet_TextChanged);
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBack.Image = global::freeFall.Properties.Resources.arrowsBlue__2_;
            this.pictureBoxBack.Location = new System.Drawing.Point(837, 382);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(35, 27);
            this.pictureBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBack.TabIndex = 13;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNext.Image = global::freeFall.Properties.Resources.arrowsBlue__1_;
            this.pictureBoxNext.Location = new System.Drawing.Point(889, 382);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(35, 27);
            this.pictureBoxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNext.TabIndex = 12;
            this.pictureBoxNext.TabStop = false;
            this.pictureBoxNext.Click += new System.EventHandler(this.pictureBoxNext_Click);
            // 
            // pictureBoxPlanets
            // 
            this.pictureBoxPlanets.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPlanets.Image = global::freeFall.Properties.Resources.planetEarth;
            this.pictureBoxPlanets.Location = new System.Drawing.Point(830, 24);
            this.pictureBoxPlanets.Name = "pictureBoxPlanets";
            this.pictureBoxPlanets.Size = new System.Drawing.Size(94, 85);
            this.pictureBoxPlanets.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlanets.TabIndex = 15;
            this.pictureBoxPlanets.TabStop = false;
            // 
            // dataGridViewPlanets
            // 
            this.dataGridViewPlanets.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewPlanets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlanets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlanets.Location = new System.Drawing.Point(-39, -43);
            this.dataGridViewPlanets.Name = "dataGridViewPlanets";
            this.dataGridViewPlanets.Size = new System.Drawing.Size(494, 556);
            this.dataGridViewPlanets.TabIndex = 14;
            // 
            // labelPlanet
            // 
            this.labelPlanet.AutoSize = true;
            this.labelPlanet.BackColor = System.Drawing.Color.Transparent;
            this.labelPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlanet.ForeColor = System.Drawing.Color.Cyan;
            this.labelPlanet.Location = new System.Drawing.Point(513, 52);
            this.labelPlanet.Name = "labelPlanet";
            this.labelPlanet.Size = new System.Drawing.Size(115, 39);
            this.labelPlanet.TabIndex = 16;
            this.labelPlanet.Text = "Planet";
            this.labelPlanet.Click += new System.EventHandler(this.labelPlanet_Click);
            // 
            // timerFocus
            // 
            this.timerFocus.Tick += new System.EventHandler(this.timerFocus_Tick);
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(945, 419);
            this.Controls.Add(this.labelPlanet);
            this.Controls.Add(this.pictureBoxPlanets);
            this.Controls.Add(this.dataGridViewPlanets);
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.pictureBoxNext);
            this.Controls.Add(this.richTextBoxPlanet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Data_FormClosing);
            this.Load += new System.EventHandler(this.Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlanets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlanets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxPlanet;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.PictureBox pictureBoxNext;
        private System.Windows.Forms.PictureBox pictureBoxPlanets;
        private System.Windows.Forms.DataGridView dataGridViewPlanets;
        private System.Windows.Forms.Label labelPlanet;
        private System.Windows.Forms.Timer timerFocus;
    }
}