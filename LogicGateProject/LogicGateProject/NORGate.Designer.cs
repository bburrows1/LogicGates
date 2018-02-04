namespace LogicGateProject
{
    partial class NORGate : LogicGates
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
            this.Gate = new System.Windows.Forms.PictureBox();
            this.TopButton = new System.Windows.Forms.Button();
            this.BottomButton = new System.Windows.Forms.Button();
            this.Out = new System.Windows.Forms.Button();
            this.DragBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Gate
            // 
            this.Gate.BackColor = System.Drawing.Color.Transparent;
            this.Gate.Image = global::LogicGateProject.Properties.Resources.NOR;
            this.Gate.Location = new System.Drawing.Point(0, 0);
            this.Gate.Name = "Gate";
            this.Gate.Size = new System.Drawing.Size(150, 88);
            this.Gate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Gate.TabIndex = 0;
            this.Gate.TabStop = false;
            // 
            // TopButton
            // 
            this.TopButton.FlatAppearance.BorderSize = 0;
            this.TopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TopButton.ForeColor = System.Drawing.Color.Transparent;
            this.TopButton.Location = new System.Drawing.Point(0, 0);
            this.TopButton.Name = "TopButton";
            this.TopButton.Size = new System.Drawing.Size(75, 46);
            this.TopButton.TabIndex = 1;
            this.TopButton.UseVisualStyleBackColor = false;
            this.TopButton.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // BottomButton
            // 
            this.BottomButton.FlatAppearance.BorderSize = 0;
            this.BottomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BottomButton.Location = new System.Drawing.Point(0, 46);
            this.BottomButton.Name = "BottomButton";
            this.BottomButton.Size = new System.Drawing.Size(75, 46);
            this.BottomButton.TabIndex = 2;
            this.BottomButton.UseVisualStyleBackColor = false;
            this.BottomButton.Click += new System.EventHandler(this.BottomButton_Click);
            // 
            // Out
            // 
            this.Out.BackColor = System.Drawing.Color.Transparent;
            this.Out.FlatAppearance.BorderSize = 0;
            this.Out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Out.ForeColor = System.Drawing.Color.Transparent;
            this.Out.Location = new System.Drawing.Point(75, 0);
            this.Out.Name = "Out";
            this.Out.Size = new System.Drawing.Size(75, 89);
            this.Out.TabIndex = 3;
            this.Out.UseVisualStyleBackColor = false;
            this.Out.Click += new System.EventHandler(this.Out_Click);
            // 
            // DragBox
            // 
            this.DragBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DragBox.Location = new System.Drawing.Point(58, 29);
            this.DragBox.Name = "DragBox";
            this.DragBox.Size = new System.Drawing.Size(30, 30);
            this.DragBox.TabIndex = 4;
            this.DragBox.TabStop = false;
            this.DragBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseDown);
            this.DragBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragBox_MouseMove);
            // 
            // NORGate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DragBox);
            this.Controls.Add(this.Out);
            this.Controls.Add(this.BottomButton);
            this.Controls.Add(this.TopButton);
            this.Controls.Add(this.Gate);
            this.Name = "NORGate";
            this.Size = new System.Drawing.Size(150, 89);
            ((System.ComponentModel.ISupportInitialize)(this.Gate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DragBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Gate;
        private System.Windows.Forms.Button TopButton;
        private System.Windows.Forms.Button BottomButton;
        private System.Windows.Forms.Button Out;
        private System.Windows.Forms.PictureBox DragBox;
    }
}
