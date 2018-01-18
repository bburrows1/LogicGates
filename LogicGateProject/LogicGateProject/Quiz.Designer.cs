namespace LogicGateProject
{
    partial class Quiz
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
            this.Quit = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Panel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.gcseConvert1 = new LogicGateProject.GCSEConvert();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Quit
            // 
            this.Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Quit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Image = global::LogicGateProject.Properties.Resources.Quit;
            this.Quit.Location = new System.Drawing.Point(1236, 0);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(64, 67);
            this.Quit.TabIndex = 3;
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Back
            // 
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.Dock = System.Windows.Forms.DockStyle.Left;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Image = global::LogicGateProject.Properties.Resources.Back;
            this.Back.Location = new System.Drawing.Point(0, 0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(64, 67);
            this.Back.TabIndex = 0;
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(66)))), ((int)(((byte)(130)))));
            this.Header.Controls.Add(this.CreateButton);
            this.Header.Controls.Add(this.ConvertButton);
            this.Header.Controls.Add(this.Quit);
            this.Header.Controls.Add(this.Back);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1300, 67);
            this.Header.TabIndex = 2;
            this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            // 
            // CreateButton
            // 
            this.CreateButton.FlatAppearance.BorderSize = 0;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(650, -2);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(160, 67);
            this.CreateButton.TabIndex = 4;
            this.CreateButton.Text = "Create Circuit";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.ConvertButton.FlatAppearance.BorderSize = 0;
            this.ConvertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConvertButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertButton.Location = new System.Drawing.Point(490, -2);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(160, 67);
            this.ConvertButton.TabIndex = 4;
            this.ConvertButton.Text = "Convert Circuit";
            this.ConvertButton.UseVisualStyleBackColor = false;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // gcseConvert1
            // 
            this.gcseConvert1.Location = new System.Drawing.Point(0, 69);
            this.gcseConvert1.Name = "gcseConvert1";
            this.gcseConvert1.Size = new System.Drawing.Size(1300, 733);
            this.gcseConvert1.TabIndex = 3;
            // 
            // Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.gcseConvert1);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz";
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button ConvertButton;
        private GCSEConvert gcseConvert1;
    }
}