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
            this.Out = new System.Windows.Forms.Button();
            this.DragBox = new System.Windows.Forms.PictureBox();
            this.Gate = new System.Windows.Forms.PictureBox();
            this.In = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).BeginInit();
            this.SuspendLayout();
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
            // DragBox
            // 
            this.DragBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DragBox.Location = new System.Drawing.Point(39, 3);
            this.DragBox.Name = "DragBox";
            this.DragBox.Size = new System.Drawing.Size(66, 68);
            this.DragBox.TabIndex = 4;
            this.DragBox.TabStop = false;
            this.DragBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseDown);
            this.DragBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseMove);
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
            // In
            // 
            this.In.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.In.Location = new System.Drawing.Point(54, 18);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(37, 37);
            this.In.TabIndex = 5;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.In);
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
        private System.Windows.Forms.TextBox In;
    }
}
