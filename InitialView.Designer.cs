namespace freeFall
{
    partial class InitialView
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialView));
            this.labelSimulador = new System.Windows.Forms.Label();
            this.buttonSimulator = new System.Windows.Forms.Button();
            this.timerCarousel = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCarrocel = new System.Windows.Forms.PictureBox();
            this.richTextBoxPlanetsData = new System.Windows.Forms.RichTextBox();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.trackBarColors = new System.Windows.Forms.TrackBar();
            this.trackBarPlanets = new System.Windows.Forms.TrackBar();
            this.timerWindowControl = new System.Windows.Forms.Timer(this.components);
            this.labellogon = new System.Windows.Forms.Label();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.labelTextColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarrocel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlanets)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSimulador
            // 
            this.labelSimulador.AutoSize = true;
            this.labelSimulador.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSimulador.ForeColor = System.Drawing.Color.Cyan;
            this.labelSimulador.Location = new System.Drawing.Point(14, 25);
            this.labelSimulador.Name = "labelSimulador";
            this.labelSimulador.Size = new System.Drawing.Size(99, 33);
            this.labelSimulador.TabIndex = 5;
            this.labelSimulador.Text = "Física";
            // 
            // buttonSimulator
            // 
            this.buttonSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimulator.Location = new System.Drawing.Point(951, 507);
            this.buttonSimulator.Name = "buttonSimulator";
            this.buttonSimulator.Size = new System.Drawing.Size(154, 35);
            this.buttonSimulator.TabIndex = 3;
            this.buttonSimulator.Text = "Iniciar Simulador";
            this.buttonSimulator.UseVisualStyleBackColor = true;
            this.buttonSimulator.Click += new System.EventHandler(this.buttonSimulador_Click);
            // 
            // timerCarousel
            // 
            this.timerCarousel.Interval = 2000;
            this.timerCarousel.Tick += new System.EventHandler(this.timerCarousel_Tick);
            // 
            // pictureBoxCarrocel
            // 
            this.pictureBoxCarrocel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCarrocel.Image = global::freeFall.Properties.Resources.planetMercury;
            this.pictureBoxCarrocel.Location = new System.Drawing.Point(366, 25);
            this.pictureBoxCarrocel.Name = "pictureBoxCarrocel";
            this.pictureBoxCarrocel.Size = new System.Drawing.Size(394, 364);
            this.pictureBoxCarrocel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCarrocel.TabIndex = 4;
            this.pictureBoxCarrocel.TabStop = false;
            // 
            // richTextBoxPlanetsData
            // 
            this.richTextBoxPlanetsData.BackColor = System.Drawing.Color.Black;
            this.richTextBoxPlanetsData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxPlanetsData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPlanetsData.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBoxPlanetsData.Location = new System.Drawing.Point(406, 426);
            this.richTextBoxPlanetsData.Name = "richTextBoxPlanetsData";
            this.richTextBoxPlanetsData.ReadOnly = true;
            this.richTextBoxPlanetsData.Size = new System.Drawing.Size(329, 138);
            this.richTextBoxPlanetsData.TabIndex = 6;
            this.richTextBoxPlanetsData.Text = "";
            this.richTextBoxPlanetsData.MouseEnter += new System.EventHandler(this.richTextBoxPlanetsData_MouseEnter);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.Location = new System.Drawing.Point(951, 456);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(154, 35);
            this.buttonAbout.TabIndex = 12;
            this.buttonAbout.Text = "Sobre";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonCredits_Click);
            // 
            // trackBarColors
            // 
            this.trackBarColors.Location = new System.Drawing.Point(979, 586);
            this.trackBarColors.Maximum = 9;
            this.trackBarColors.Minimum = 1;
            this.trackBarColors.Name = "trackBarColors";
            this.trackBarColors.Size = new System.Drawing.Size(104, 45);
            this.trackBarColors.TabIndex = 12;
            this.trackBarColors.Value = 1;
            this.trackBarColors.Scroll += new System.EventHandler(this.trackBarColors_Scroll);
            // 
            // trackBarPlanets
            // 
            this.trackBarPlanets.Location = new System.Drawing.Point(520, 586);
            this.trackBarPlanets.Maximum = 8;
            this.trackBarPlanets.Name = "trackBarPlanets";
            this.trackBarPlanets.Size = new System.Drawing.Size(104, 45);
            this.trackBarPlanets.TabIndex = 12;
            this.trackBarPlanets.Scroll += new System.EventHandler(this.trackBarPlanets_Scroll);
            // 
            // timerWindowControl
            // 
            this.timerWindowControl.Tick += new System.EventHandler(this.timerWindowControl_Tick);
            // 
            // labellogon
            // 
            this.labellogon.AutoSize = true;
            this.labellogon.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellogon.ForeColor = System.Drawing.Color.Cyan;
            this.labellogon.Location = new System.Drawing.Point(15, 69);
            this.labellogon.Name = "labellogon";
            this.labellogon.Size = new System.Drawing.Size(327, 30);
            this.labellogon.TabIndex = 13;
            this.labellogon.Text = "Simulando a queda dos corpos";
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.BackColor = System.Drawing.Color.Black;
            this.richTextBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxText.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBoxText.Location = new System.Drawing.Point(786, 25);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.Size = new System.Drawing.Size(349, 364);
            this.richTextBoxText.TabIndex = 14;
            this.richTextBoxText.Text = "";
            this.richTextBoxText.Visible = false;
            // 
            // labelTextColor
            // 
            this.labelTextColor.AutoSize = true;
            this.labelTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextColor.ForeColor = System.Drawing.Color.Cyan;
            this.labelTextColor.Location = new System.Drawing.Point(990, 565);
            this.labelTextColor.Name = "labelTextColor";
            this.labelTextColor.Size = new System.Drawing.Size(82, 15);
            this.labelTextColor.TabIndex = 15;
            this.labelTextColor.Text = "cor do texto";
            // 
            // InitialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1149, 621);
            this.Controls.Add(this.labelTextColor);
            this.Controls.Add(this.richTextBoxText);
            this.Controls.Add(this.labellogon);
            this.Controls.Add(this.trackBarPlanets);
            this.Controls.Add(this.trackBarColors);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.richTextBoxPlanetsData);
            this.Controls.Add(this.labelSimulador);
            this.Controls.Add(this.pictureBoxCarrocel);
            this.Controls.Add(this.buttonSimulator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InitialView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UFSCAR - Simulador de queda livre";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarrocel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlanets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSimulador;
        private System.Windows.Forms.PictureBox pictureBoxCarrocel;
        private System.Windows.Forms.Button buttonSimulator;
        private System.Windows.Forms.Timer timerCarousel;
        private System.Windows.Forms.RichTextBox richTextBoxPlanetsData;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.TrackBar trackBarColors;
        private System.Windows.Forms.TrackBar trackBarPlanets;
        private System.Windows.Forms.Timer timerWindowControl;
        private System.Windows.Forms.Label labellogon;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.Label labelTextColor;
    }
}

