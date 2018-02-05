namespace LogicGateProject
{
    partial class Input : LogicGates
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DragBox = new System.Windows.Forms.PictureBox();
            this.Out = new System.Windows.Forms.Button();
            this.Gate = new System.Windows.Forms.PictureBox();
            this.InputButton = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.ClockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).BeginInit();
            this.SuspendLayout();
            // 
            // DragBox
            // 
            this.DragBox.BackColor = System.Drawing.Color.Transparent;
            this.DragBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DragBox.Location = new System.Drawing.Point(39, 4);
            this.DragBox.Name = "DragBox";
            this.DragBox.Size = new System.Drawing.Size(64, 66);
            this.DragBox.TabIndex = 4;
            this.DragBox.TabStop = false;
            this.DragBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseDown);
            this.DragBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseMove);
            // 
            // Out
            // 
            this.Out.BackColor = System.Drawing.Color.Transparent;
            this.Out.FlatAppearance.BorderSize = 0;
            this.Out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Out.ForeColor = System.Drawing.Color.Transparent;
            this.Out.Location = new System.Drawing.Point(103, 0);
            this.Out.Name = "Out";
            this.Out.Size = new System.Drawing.Size(47, 75);
            this.Out.TabIndex = 3;
            this.Out.UseVisualStyleBackColor = false;
            this.Out.Click += new System.EventHandler(this.Out_Click);
            // 
            // Gate
            // 
            this.Gate.BackColor = System.Drawing.Color.Transparent;
            this.Gate.Image = global::LogicGateProject.Properties.Resources.Input;
            this.Gate.Location = new System.Drawing.Point(0, 0);
            this.Gate.Name = "Gate";
            this.Gate.Size = new System.Drawing.Size(149, 75);
            this.Gate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Gate.TabIndex = 0;
            this.Gate.TabStop = false;
            // 
            // InputButton
            // 
            this.InputButton.BackColor = System.Drawing.Color.Red;
            this.InputButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InputButton.FlatAppearance.BorderSize = 0;
            this.InputButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputButton.Location = new System.Drawing.Point(57, 22);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(30, 30);
            this.InputButton.TabIndex = 5;
            this.InputButton.UseVisualStyleBackColor = false;
            this.InputButton.Click += new System.EventHandler(this.InputButton_Click);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.IDLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.Location = new System.Drawing.Point(40, 5);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(0, 18);
            this.IDLabel.TabIndex = 6;
            // 
            // ClockButton
            // 
            this.ClockButton.BackColor = System.Drawing.Color.Transparent;
            this.ClockButton.FlatAppearance.BorderSize = 0;
            this.ClockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClockButton.ForeColor = System.Drawing.Color.Transparent;
            this.ClockButton.Image = global::LogicGateProject.Properties.Resources.Clock;
            this.ClockButton.Location = new System.Drawing.Point(86, 4);
            this.ClockButton.Name = "ClockButton";
            this.ClockButton.Size = new System.Drawing.Size(17, 17);
            this.ClockButton.TabIndex = 7;
            this.ClockButton.UseVisualStyleBackColor = false;
            this.ClockButton.Click += new System.EventHandler(this.ClockButton_Click);
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ClockButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.InputButton);
            this.Controls.Add(this.DragBox);
            this.Controls.Add(this.Out);
            this.Controls.Add(this.Gate);
            this.Name = "Input";
            this.Size = new System.Drawing.Size(150, 89);
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Gate;
        private System.Windows.Forms.Button Out;
        private System.Windows.Forms.PictureBox DragBox;
        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button ClockButton;
    }
}
