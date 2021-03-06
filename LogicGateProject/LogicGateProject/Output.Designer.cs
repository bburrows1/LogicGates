﻿namespace LogicGateProject
{
    partial class Output : LogicGates
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
            this.In = new System.Windows.Forms.Button();
            this.Gate = new System.Windows.Forms.PictureBox();
            this.OutputBox = new System.Windows.Forms.PictureBox();
            this.IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DragBox
            // 
            this.DragBox.BackColor = System.Drawing.Color.Transparent;
            this.DragBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DragBox.Location = new System.Drawing.Point(45, 4);
            this.DragBox.Name = "DragBox";
            this.DragBox.Size = new System.Drawing.Size(64, 66);
            this.DragBox.TabIndex = 4;
            this.DragBox.TabStop = false;
            this.DragBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseDown);
            this.DragBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseMove);
            // 
            // In
            // 
            this.In.BackColor = System.Drawing.Color.Transparent;
            this.In.FlatAppearance.BorderSize = 0;
            this.In.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.In.ForeColor = System.Drawing.Color.Transparent;
            this.In.Location = new System.Drawing.Point(0, 0);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(75, 75);
            this.In.TabIndex = 3;
            this.In.UseVisualStyleBackColor = false;
            this.In.Click += new System.EventHandler(this.In_Click);
            // 
            // Gate
            // 
            this.Gate.BackColor = System.Drawing.Color.Transparent;
            this.Gate.Image = global::LogicGateProject.Properties.Resources.Output;
            this.Gate.Location = new System.Drawing.Point(0, 0);
            this.Gate.Name = "Gate";
            this.Gate.Size = new System.Drawing.Size(150, 75);
            this.Gate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Gate.TabIndex = 0;
            this.Gate.TabStop = false;
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.Color.Red;
            this.OutputBox.Location = new System.Drawing.Point(62, 23);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(30, 30);
            this.OutputBox.TabIndex = 5;
            this.OutputBox.TabStop = false;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.Location = new System.Drawing.Point(46, 8);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(0, 18);
            this.IDLabel.TabIndex = 6;
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.DragBox);
            this.Controls.Add(this.In);
            this.Controls.Add(this.Gate);
            this.Name = "Output";
            this.Size = new System.Drawing.Size(150, 89);
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Gate;
        private System.Windows.Forms.Button In;
        private System.Windows.Forms.PictureBox DragBox;
        private System.Windows.Forms.PictureBox OutputBox;
        private System.Windows.Forms.Label IDLabel;
    }
}
