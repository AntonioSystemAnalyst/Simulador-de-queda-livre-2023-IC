namespace freeFall
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelSimulador = new System.Windows.Forms.Label();
            this.buttonSimulator = new System.Windows.Forms.Button();
            this.timerCarousel = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCarrocel = new System.Windows.Forms.PictureBox();
            this.richTextBoxPlanetsData = new System.Windows.Forms.RichTextBox();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.buttonFreeFall = new System.Windows.Forms.Button();
            this.buttonGravitation = new System.Windows.Forms.Button();
            this.buttonAirResistance = new System.Windows.Forms.Button();
            this.buttonReferences = new System.Windows.Forms.Button();
            this.buttonCredits = new System.Windows.Forms.Button();
            this.trackBarColors = new System.Windows.Forms.TrackBar();
            this.trackBarPlanets = new System.Windows.Forms.TrackBar();
            this.timerWindowControl = new System.Windows.Forms.Timer(this.components);
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
            this.buttonSimulator.Location = new System.Drawing.Point(20, 536);
            this.buttonSimulator.Name = "buttonSimulator";
            this.buttonSimulator.Size = new System.Drawing.Size(184, 35);
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
            this.pictureBoxCarrocel.Location = new System.Drawing.Point(799, 36);
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
            this.richTextBoxPlanetsData.Location = new System.Drawing.Point(864, 420);
            this.richTextBoxPlanetsData.Name = "richTextBoxPlanetsData";
            this.richTextBoxPlanetsData.ReadOnly = true;
            this.richTextBoxPlanetsData.Size = new System.Drawing.Size(329, 138);
            this.richTextBoxPlanetsData.TabIndex = 6;
            this.richTextBoxPlanetsData.Text = "";
            this.richTextBoxPlanetsData.MouseEnter += new System.EventHandler(this.richTextBoxPlanetsData_MouseEnter);
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.BackColor = System.Drawing.Color.Black;
            this.richTextBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxText.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBoxText.Location = new System.Drawing.Point(278, 36);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.ReadOnly = true;
            this.richTextBoxText.Size = new System.Drawing.Size(515, 559);
            this.richTextBoxText.TabIndex = 7;
            this.richTextBoxText.Text = "";
            // 
            // buttonFreeFall
            // 
            this.buttonFreeFall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFreeFall.Location = new System.Drawing.Point(20, 100);
            this.buttonFreeFall.Name = "buttonFreeFall";
            this.buttonFreeFall.Size = new System.Drawing.Size(184, 35);
            this.buttonFreeFall.TabIndex = 8;
            this.buttonFreeFall.Text = "Queda Livre";
            this.buttonFreeFall.UseVisualStyleBackColor = true;
            this.buttonFreeFall.Click += new System.EventHandler(this.buttonFreeFall_Click);
            // 
            // buttonGravitation
            // 
            this.buttonGravitation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGravitation.Location = new System.Drawing.Point(20, 156);
            this.buttonGravitation.Name = "buttonGravitation";
            this.buttonGravitation.Size = new System.Drawing.Size(184, 35);
            this.buttonGravitation.TabIndex = 9;
            this.buttonGravitation.Text = "Gravitação";
            this.buttonGravitation.UseVisualStyleBackColor = true;
            this.buttonGravitation.Click += new System.EventHandler(this.buttonGravitation_Click);
            // 
            // buttonAirResistance
            // 
            this.buttonAirResistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAirResistance.Location = new System.Drawing.Point(20, 206);
            this.buttonAirResistance.Name = "buttonAirResistance";
            this.buttonAirResistance.Size = new System.Drawing.Size(184, 35);
            this.buttonAirResistance.TabIndex = 10;
            this.buttonAirResistance.Text = "Resistência Atmosférica";
            this.buttonAirResistance.UseVisualStyleBackColor = true;
            this.buttonAirResistance.Click += new System.EventHandler(this.buttonAirResistance_Click);
            // 
            // buttonReferences
            // 
            this.buttonReferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReferences.Location = new System.Drawing.Point(20, 258);
            this.buttonReferences.Name = "buttonReferences";
            this.buttonReferences.Size = new System.Drawing.Size(184, 35);
            this.buttonReferences.TabIndex = 11;
            this.buttonReferences.Text = "Referências";
            this.buttonReferences.UseVisualStyleBackColor = true;
            this.buttonReferences.Click += new System.EventHandler(this.buttonReferences_Click);
            // 
            // buttonCredits
            // 
            this.buttonCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCredits.Location = new System.Drawing.Point(20, 312);
            this.buttonCredits.Name = "buttonCredits";
            this.buttonCredits.Size = new System.Drawing.Size(184, 35);
            this.buttonCredits.TabIndex = 12;
            this.buttonCredits.Text = "Créditos";
            this.buttonCredits.UseVisualStyleBackColor = true;
            this.buttonCredits.Click += new System.EventHandler(this.buttonCredits_Click);
            // 
            // trackBarColors
            // 
            this.trackBarColors.Location = new System.Drawing.Point(20, 588);
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
            this.trackBarPlanets.Location = new System.Drawing.Point(955, 588);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1205, 621);
            this.Controls.Add(this.trackBarPlanets);
            this.Controls.Add(this.trackBarColors);
            this.Controls.Add(this.buttonCredits);
            this.Controls.Add(this.buttonReferences);
            this.Controls.Add(this.buttonAirResistance);
            this.Controls.Add(this.buttonGravitation);
            this.Controls.Add(this.buttonFreeFall);
            this.Controls.Add(this.richTextBoxText);
            this.Controls.Add(this.richTextBoxPlanetsData);
            this.Controls.Add(this.labelSimulador);
            this.Controls.Add(this.pictureBoxCarrocel);
            this.Controls.Add(this.buttonSimulator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
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
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.Button buttonFreeFall;
        private System.Windows.Forms.Button buttonGravitation;
        private System.Windows.Forms.Button buttonAirResistance;
        private System.Windows.Forms.Button buttonReferences;
        private System.Windows.Forms.Button buttonCredits;
        private System.Windows.Forms.TrackBar trackBarColors;
        private System.Windows.Forms.TrackBar trackBarPlanets;
        private System.Windows.Forms.Timer timerWindowControl;
    }
}

