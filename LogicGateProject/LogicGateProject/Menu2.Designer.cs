namespace LogicGateProject
{
    partial class Menu2
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
            this.Back = new System.Windows.Forms.Button();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModePanel = new System.Windows.Forms.Panel();
            this.Quiz = new System.Windows.Forms.Button();
            this.Design = new System.Windows.Forms.Button();
            this.TableToCircuit = new System.Windows.Forms.Button();
            this.CircuitToTable = new System.Windows.Forms.Button();
            this.ExpressionToCircuit = new System.Windows.Forms.Button();
            this.CircuitToExpression = new System.Windows.Forms.Button();
            this.Header.SuspendLayout();
            this.ModePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(66)))), ((int)(((byte)(130)))));
            this.Header.Controls.Add(this.Quit);
            this.Header.Controls.Add(this.Back);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(660, 62);
            this.Header.TabIndex = 2;
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
            this.Quit.TabIndex = 6;
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
            this.Back.Size = new System.Drawing.Size(64, 62);
            this.Back.TabIndex = 5;
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ModeLabel.Location = new System.Drawing.Point(3, 0);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(172, 30);
            this.ModeLabel.TabIndex = 0;
            this.ModeLabel.Text = "Select Mode:";
            // 
            // ModePanel
            // 
            this.ModePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.ModePanel.Controls.Add(this.ModeLabel);
            this.ModePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModePanel.Location = new System.Drawing.Point(0, 62);
            this.ModePanel.Name = "ModePanel";
            this.ModePanel.Size = new System.Drawing.Size(660, 33);
            this.ModePanel.TabIndex = 8;
            // 
            // Quiz
            // 
            this.Quiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.Quiz.FlatAppearance.BorderSize = 0;
            this.Quiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quiz.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quiz.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Quiz.Location = new System.Drawing.Point(330, 95);
            this.Quiz.Name = "Quiz";
            this.Quiz.Size = new System.Drawing.Size(330, 330);
            this.Quiz.TabIndex = 10;
            this.Quiz.Text = "Quiz";
            this.Quiz.UseVisualStyleBackColor = false;
            this.Quiz.Click += new System.EventHandler(this.Quiz_Click);
            // 
            // Design
            // 
            this.Design.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.Design.Dock = System.Windows.Forms.DockStyle.Left;
            this.Design.FlatAppearance.BorderSize = 0;
            this.Design.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Design.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Design.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Design.Location = new System.Drawing.Point(0, 95);
            this.Design.Name = "Design";
            this.Design.Size = new System.Drawing.Size(330, 330);
            this.Design.TabIndex = 9;
            this.Design.Text = "Design";
            this.Design.UseVisualStyleBackColor = false;
            this.Design.Click += new System.EventHandler(this.Design_Click);
            // 
            // TableToCircuit
            // 
            this.TableToCircuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.TableToCircuit.FlatAppearance.BorderSize = 0;
            this.TableToCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TableToCircuit.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableToCircuit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TableToCircuit.Location = new System.Drawing.Point(330, 95);
            this.TableToCircuit.Name = "TableToCircuit";
            this.TableToCircuit.Size = new System.Drawing.Size(330, 165);
            this.TableToCircuit.TabIndex = 11;
            this.TableToCircuit.Text = "Truth Table to Circuit";
            this.TableToCircuit.UseVisualStyleBackColor = false;
            this.TableToCircuit.Visible = false;
            this.TableToCircuit.Click += new System.EventHandler(this.TableToCircuit_Click);
            // 
            // CircuitToTable
            // 
            this.CircuitToTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.CircuitToTable.FlatAppearance.BorderSize = 0;
            this.CircuitToTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CircuitToTable.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircuitToTable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CircuitToTable.Location = new System.Drawing.Point(330, 260);
            this.CircuitToTable.Name = "CircuitToTable";
            this.CircuitToTable.Size = new System.Drawing.Size(330, 165);
            this.CircuitToTable.TabIndex = 12;
            this.CircuitToTable.Text = "Circuit to Truth Table";
            this.CircuitToTable.UseVisualStyleBackColor = false;
            this.CircuitToTable.Visible = false;
            this.CircuitToTable.Click += new System.EventHandler(this.CircuitToTable_Click);
            // 
            // ExpressionToCircuit
            // 
            this.ExpressionToCircuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.ExpressionToCircuit.FlatAppearance.BorderSize = 0;
            this.ExpressionToCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExpressionToCircuit.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpressionToCircuit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ExpressionToCircuit.Location = new System.Drawing.Point(330, 95);
            this.ExpressionToCircuit.Name = "ExpressionToCircuit";
            this.ExpressionToCircuit.Size = new System.Drawing.Size(330, 165);
            this.ExpressionToCircuit.TabIndex = 13;
            this.ExpressionToCircuit.Text = "Expression to Circuit";
            this.ExpressionToCircuit.UseVisualStyleBackColor = false;
            this.ExpressionToCircuit.Visible = false;
            this.ExpressionToCircuit.Click += new System.EventHandler(this.ExpressionToCircuit_Click);
            // 
            // CircuitToExpression
            // 
            this.CircuitToExpression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.CircuitToExpression.FlatAppearance.BorderSize = 0;
            this.CircuitToExpression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CircuitToExpression.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircuitToExpression.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CircuitToExpression.Location = new System.Drawing.Point(330, 260);
            this.CircuitToExpression.Name = "CircuitToExpression";
            this.CircuitToExpression.Size = new System.Drawing.Size(330, 165);
            this.CircuitToExpression.TabIndex = 14;
            this.CircuitToExpression.Text = "Circuit to Expression";
            this.CircuitToExpression.UseVisualStyleBackColor = false;
            this.CircuitToExpression.Visible = false;
            this.CircuitToExpression.Click += new System.EventHandler(this.CircuitToExpression_Click);
            // 
            // Menu2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 425);
            this.Controls.Add(this.Quiz);
            this.Controls.Add(this.CircuitToExpression);
            this.Controls.Add(this.ExpressionToCircuit);
            this.Controls.Add(this.CircuitToTable);
            this.Controls.Add(this.TableToCircuit);
            this.Controls.Add(this.Design);
            this.Controls.Add(this.ModePanel);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu2";
            this.Header.ResumeLayout(false);
            this.ModePanel.ResumeLayout(false);
            this.ModePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.Panel ModePanel;
        private System.Windows.Forms.Button Quiz;
        private System.Windows.Forms.Button Design;
        private System.Windows.Forms.Button TableToCircuit;
        private System.Windows.Forms.Button CircuitToTable;
        private System.Windows.Forms.Button ExpressionToCircuit;
        private System.Windows.Forms.Button CircuitToExpression;
    }
}