namespace LogicGateProject
{
    partial class Menu1
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
            this.Header = new System.Windows.Forms.Panel();
            this.Quit = new System.Windows.Forms.Button();
            this.GCSEButton = new System.Windows.Forms.Button();
            this.AlevelButton = new System.Windows.Forms.Button();
            this.StudyPanel = new System.Windows.Forms.Panel();
            this.StudyLabel = new System.Windows.Forms.Label();
            this.FurtherButton = new System.Windows.Forms.Button();
            this.Header.SuspendLayout();
            this.StudyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(66)))), ((int)(((byte)(130)))));
            this.Header.Controls.Add(this.Quit);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(660, 62);
            this.Header.TabIndex = 0;
            this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            // 
            // Quit
            // 
            this.Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Quit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Image = global::LogicGateProject.Properties.Resources.Quit;
            this.Quit.Location = new System.Drawing.Point(596, 0);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(64, 62);
            this.Quit.TabIndex = 4;
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // GCSEButton
            // 
            this.GCSEButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.GCSEButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.GCSEButton.FlatAppearance.BorderSize = 0;
            this.GCSEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GCSEButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCSEButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GCSEButton.Location = new System.Drawing.Point(0, 95);
            this.GCSEButton.Name = "GCSEButton";
            this.GCSEButton.Size = new System.Drawing.Size(220, 330);
            this.GCSEButton.TabIndex = 1;
            this.GCSEButton.Text = "GCSE";
            this.GCSEButton.UseVisualStyleBackColor = false;
            this.GCSEButton.Click += new System.EventHandler(this.GCSEButton_Click);
            // 
            // AlevelButton
            // 
            this.AlevelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.AlevelButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AlevelButton.FlatAppearance.BorderSize = 0;
            this.AlevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlevelButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlevelButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AlevelButton.Location = new System.Drawing.Point(220, 95);
            this.AlevelButton.Name = "AlevelButton";
            this.AlevelButton.Size = new System.Drawing.Size(220, 330);
            this.AlevelButton.TabIndex = 2;
            this.AlevelButton.Text = "A-Level";
            this.AlevelButton.UseVisualStyleBackColor = false;
            this.AlevelButton.Click += new System.EventHandler(this.AlevelButton_Click);
            // 
            // StudyPanel
            // 
            this.StudyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.StudyPanel.Controls.Add(this.StudyLabel);
            this.StudyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StudyPanel.Location = new System.Drawing.Point(0, 62);
            this.StudyPanel.Name = "StudyPanel";
            this.StudyPanel.Size = new System.Drawing.Size(660, 33);
            this.StudyPanel.TabIndex = 4;
            // 
            // StudyLabel
            // 
            this.StudyLabel.AutoSize = true;
            this.StudyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.StudyLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudyLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StudyLabel.Location = new System.Drawing.Point(3, 0);
            this.StudyLabel.Name = "StudyLabel";
            this.StudyLabel.Size = new System.Drawing.Size(267, 30);
            this.StudyLabel.TabIndex = 0;
            this.StudyLabel.Text = "Select Level of Study:";
            // 
            // FurtherButton
            // 
            this.FurtherButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.FurtherButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.FurtherButton.FlatAppearance.BorderSize = 0;
            this.FurtherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FurtherButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FurtherButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FurtherButton.Location = new System.Drawing.Point(440, 95);
            this.FurtherButton.Name = "FurtherButton";
            this.FurtherButton.Size = new System.Drawing.Size(220, 330);
            this.FurtherButton.TabIndex = 3;
            this.FurtherButton.Text = " Further Learning";
            this.FurtherButton.UseVisualStyleBackColor = false;
            this.FurtherButton.Click += new System.EventHandler(this.FurtherButton_Click);
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.FurtherButton);
            this.Controls.Add(this.AlevelButton);
            this.Controls.Add(this.GCSEButton);
            this.Controls.Add(this.StudyPanel);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Header.ResumeLayout(false);
            this.StudyPanel.ResumeLayout(false);
            this.StudyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button GCSEButton;
        private System.Windows.Forms.Button AlevelButton;
        private System.Windows.Forms.Panel StudyPanel;
        private System.Windows.Forms.Label StudyLabel;
        private System.Windows.Forms.Button FurtherButton;
    }
}