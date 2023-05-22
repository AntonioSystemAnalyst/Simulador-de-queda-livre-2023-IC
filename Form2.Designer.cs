namespace freeFall
{
    partial class programView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(programView));
            this.richTextBoxConsoleView = new System.Windows.Forms.RichTextBox();
            this.buttonFocus = new System.Windows.Forms.Button();
            this.timerFocus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // richTextBoxConsoleView
            // 
            this.richTextBoxConsoleView.BackColor = System.Drawing.Color.Black;
            this.richTextBoxConsoleView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxConsoleView.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBoxConsoleView.Location = new System.Drawing.Point(4, 4);
            this.richTextBoxConsoleView.Name = "richTextBoxConsoleView";
            this.richTextBoxConsoleView.ReadOnly = true;
            this.richTextBoxConsoleView.Size = new System.Drawing.Size(551, 403);
            this.richTextBoxConsoleView.TabIndex = 0;
            this.richTextBoxConsoleView.Text = "";
            // 
            // buttonFocus
            // 
            this.buttonFocus.Location = new System.Drawing.Point(605, 24);
            this.buttonFocus.Name = "buttonFocus";
            this.buttonFocus.Size = new System.Drawing.Size(75, 23);
            this.buttonFocus.TabIndex = 1;
            this.buttonFocus.Text = "button1";
            this.buttonFocus.UseVisualStyleBackColor = true;
            // 
            // timerFocus
            // 
            this.timerFocus.Tick += new System.EventHandler(this.timerFocus_Tick);
            // 
            // programView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::freeFall.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(558, 418);
            this.Controls.Add(this.buttonFocus);
            this.Controls.Add(this.richTextBoxConsoleView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "programView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxConsoleView;
        private System.Windows.Forms.Button buttonFocus;
        private System.Windows.Forms.Timer timerFocus;
    }
}