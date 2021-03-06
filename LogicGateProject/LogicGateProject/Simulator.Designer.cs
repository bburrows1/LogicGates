﻿namespace LogicGateProject
{
    partial class Simulator
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
            this.RightPanel = new System.Windows.Forms.Panel();
            this.NANDSimplifcation = new System.Windows.Forms.Button();
            this.StepByStep = new System.Windows.Forms.Button();
            this.CreateExpression = new System.Windows.Forms.Button();
            this.CreateTruthTable = new System.Windows.Forms.Button();
            this.AddNOR = new System.Windows.Forms.Button();
            this.AddXOR = new System.Windows.Forms.Button();
            this.AddOR = new System.Windows.Forms.Button();
            this.AddOutput = new System.Windows.Forms.Button();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.AddNAND = new System.Windows.Forms.Button();
            this.AddNOT = new System.Windows.Forms.Button();
            this.AddAND = new System.Windows.Forms.Button();
            this.AddInput = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.AddExpression = new System.Windows.Forms.TextBox();
            this.DesignerPanel = new System.Windows.Forms.Panel();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RightPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.Header.SuspendLayout();
            this.DesignerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.RightPanel.Controls.Add(this.NANDSimplifcation);
            this.RightPanel.Controls.Add(this.StepByStep);
            this.RightPanel.Controls.Add(this.CreateExpression);
            this.RightPanel.Controls.Add(this.CreateTruthTable);
            this.RightPanel.Controls.Add(this.AddNOR);
            this.RightPanel.Controls.Add(this.AddXOR);
            this.RightPanel.Controls.Add(this.AddOR);
            this.RightPanel.Controls.Add(this.AddOutput);
            this.RightPanel.Controls.Add(this.LeftPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightPanel.Location = new System.Drawing.Point(0, 67);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(300, 846);
            this.RightPanel.TabIndex = 0;
            // 
            // NANDSimplifcation
            // 
            this.NANDSimplifcation.Cursor = System.Windows.Forms.Cursors.Default;
            this.NANDSimplifcation.FlatAppearance.BorderSize = 0;
            this.NANDSimplifcation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NANDSimplifcation.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NANDSimplifcation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NANDSimplifcation.Location = new System.Drawing.Point(0, 589);
            this.NANDSimplifcation.Name = "NANDSimplifcation";
            this.NANDSimplifcation.Size = new System.Drawing.Size(300, 64);
            this.NANDSimplifcation.TabIndex = 7;
            this.NANDSimplifcation.Text = "NAND Simplification";
            this.NANDSimplifcation.UseVisualStyleBackColor = true;
            this.NANDSimplifcation.Click += new System.EventHandler(this.NANDSimplifcation_Click);
            // 
            // StepByStep
            // 
            this.StepByStep.Cursor = System.Windows.Forms.Cursors.Default;
            this.StepByStep.FlatAppearance.BorderSize = 0;
            this.StepByStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StepByStep.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepByStep.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StepByStep.Location = new System.Drawing.Point(0, 717);
            this.StepByStep.Name = "StepByStep";
            this.StepByStep.Size = new System.Drawing.Size(300, 64);
            this.StepByStep.TabIndex = 6;
            this.StepByStep.Text = "Step-By-Step";
            this.StepByStep.UseVisualStyleBackColor = true;
            this.StepByStep.Click += new System.EventHandler(this.StepByStep_Click);
            // 
            // CreateExpression
            // 
            this.CreateExpression.Cursor = System.Windows.Forms.Cursors.Default;
            this.CreateExpression.FlatAppearance.BorderSize = 0;
            this.CreateExpression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateExpression.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateExpression.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateExpression.Location = new System.Drawing.Point(0, 653);
            this.CreateExpression.Name = "CreateExpression";
            this.CreateExpression.Size = new System.Drawing.Size(300, 64);
            this.CreateExpression.TabIndex = 6;
            this.CreateExpression.Text = "Boolean Expression";
            this.CreateExpression.UseVisualStyleBackColor = true;
            this.CreateExpression.Click += new System.EventHandler(this.CreateExpression_Click);
            // 
            // CreateTruthTable
            // 
            this.CreateTruthTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.CreateTruthTable.FlatAppearance.BorderSize = 0;
            this.CreateTruthTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTruthTable.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTruthTable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CreateTruthTable.Location = new System.Drawing.Point(0, 781);
            this.CreateTruthTable.Name = "CreateTruthTable";
            this.CreateTruthTable.Size = new System.Drawing.Size(300, 64);
            this.CreateTruthTable.TabIndex = 4;
            this.CreateTruthTable.Text = "Truth Table";
            this.CreateTruthTable.UseVisualStyleBackColor = true;
            this.CreateTruthTable.Click += new System.EventHandler(this.CreateTruthTable_Click);
            // 
            // AddNOR
            // 
            this.AddNOR.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddNOR.FlatAppearance.BorderSize = 0;
            this.AddNOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNOR.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNOR.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddNOR.Image = global::LogicGateProject.Properties.Resources.NOR;
            this.AddNOR.Location = new System.Drawing.Point(150, 450);
            this.AddNOR.Name = "AddNOR";
            this.AddNOR.Size = new System.Drawing.Size(150, 150);
            this.AddNOR.TabIndex = 5;
            this.AddNOR.Text = "NOR";
            this.AddNOR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddNOR.UseVisualStyleBackColor = true;
            this.AddNOR.Click += new System.EventHandler(this.AddNOR_Click);
            // 
            // AddXOR
            // 
            this.AddXOR.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddXOR.FlatAppearance.BorderSize = 0;
            this.AddXOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddXOR.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddXOR.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddXOR.Image = global::LogicGateProject.Properties.Resources.XOR;
            this.AddXOR.Location = new System.Drawing.Point(150, 300);
            this.AddXOR.Name = "AddXOR";
            this.AddXOR.Size = new System.Drawing.Size(150, 150);
            this.AddXOR.TabIndex = 4;
            this.AddXOR.Text = "XOR";
            this.AddXOR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddXOR.UseVisualStyleBackColor = true;
            this.AddXOR.Click += new System.EventHandler(this.AddXOR_Click);
            // 
            // AddOR
            // 
            this.AddOR.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddOR.FlatAppearance.BorderSize = 0;
            this.AddOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddOR.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOR.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddOR.Image = global::LogicGateProject.Properties.Resources.OR;
            this.AddOR.Location = new System.Drawing.Point(150, 150);
            this.AddOR.Name = "AddOR";
            this.AddOR.Size = new System.Drawing.Size(150, 150);
            this.AddOR.TabIndex = 3;
            this.AddOR.Text = "OR";
            this.AddOR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddOR.UseVisualStyleBackColor = true;
            this.AddOR.Click += new System.EventHandler(this.AddOR_Click);
            // 
            // AddOutput
            // 
            this.AddOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddOutput.FlatAppearance.BorderSize = 0;
            this.AddOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddOutput.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOutput.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddOutput.Image = global::LogicGateProject.Properties.Resources.Output;
            this.AddOutput.Location = new System.Drawing.Point(150, 0);
            this.AddOutput.Name = "AddOutput";
            this.AddOutput.Size = new System.Drawing.Size(150, 150);
            this.AddOutput.TabIndex = 2;
            this.AddOutput.Text = "OUTPUT";
            this.AddOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddOutput.UseVisualStyleBackColor = true;
            this.AddOutput.Click += new System.EventHandler(this.AddOutput_Click);
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.LeftPanel.Controls.Add(this.AddNAND);
            this.LeftPanel.Controls.Add(this.AddNOT);
            this.LeftPanel.Controls.Add(this.AddAND);
            this.LeftPanel.Controls.Add(this.AddInput);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(150, 846);
            this.LeftPanel.TabIndex = 1;
            // 
            // AddNAND
            // 
            this.AddNAND.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddNAND.FlatAppearance.BorderSize = 0;
            this.AddNAND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNAND.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNAND.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddNAND.Image = global::LogicGateProject.Properties.Resources.NAND;
            this.AddNAND.Location = new System.Drawing.Point(0, 450);
            this.AddNAND.Name = "AddNAND";
            this.AddNAND.Size = new System.Drawing.Size(150, 150);
            this.AddNAND.TabIndex = 3;
            this.AddNAND.Text = "NAND";
            this.AddNAND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddNAND.UseVisualStyleBackColor = true;
            this.AddNAND.Click += new System.EventHandler(this.AddNAND_Click);
            // 
            // AddNOT
            // 
            this.AddNOT.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddNOT.FlatAppearance.BorderSize = 0;
            this.AddNOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNOT.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNOT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddNOT.Image = global::LogicGateProject.Properties.Resources.NOT;
            this.AddNOT.Location = new System.Drawing.Point(0, 300);
            this.AddNOT.Name = "AddNOT";
            this.AddNOT.Size = new System.Drawing.Size(150, 150);
            this.AddNOT.TabIndex = 2;
            this.AddNOT.Text = "NOT";
            this.AddNOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddNOT.UseVisualStyleBackColor = true;
            this.AddNOT.Click += new System.EventHandler(this.AddNOT_Click);
            // 
            // AddAND
            // 
            this.AddAND.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddAND.FlatAppearance.BorderSize = 0;
            this.AddAND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAND.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAND.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddAND.Image = global::LogicGateProject.Properties.Resources.AND;
            this.AddAND.Location = new System.Drawing.Point(0, 150);
            this.AddAND.Name = "AddAND";
            this.AddAND.Size = new System.Drawing.Size(150, 150);
            this.AddAND.TabIndex = 1;
            this.AddAND.Text = "AND";
            this.AddAND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddAND.UseVisualStyleBackColor = true;
            this.AddAND.Click += new System.EventHandler(this.AddAND_Click);
            // 
            // AddInput
            // 
            this.AddInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddInput.FlatAppearance.BorderSize = 0;
            this.AddInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddInput.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddInput.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddInput.Image = global::LogicGateProject.Properties.Resources.Input;
            this.AddInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddInput.Location = new System.Drawing.Point(0, 0);
            this.AddInput.Name = "AddInput";
            this.AddInput.Size = new System.Drawing.Size(150, 150);
            this.AddInput.TabIndex = 0;
            this.AddInput.Text = "INPUT";
            this.AddInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddInput.UseVisualStyleBackColor = true;
            this.AddInput.Click += new System.EventHandler(this.AddInput_Click);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(66)))), ((int)(((byte)(130)))));
            this.Header.Controls.Add(this.ResultLabel);
            this.Header.Controls.Add(this.SubmitButton);
            this.Header.Controls.Add(this.QuestionLabel);
            this.Header.Controls.Add(this.Quit);
            this.Header.Controls.Add(this.LoadButton);
            this.Header.Controls.Add(this.SaveButton);
            this.Header.Controls.Add(this.Back);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1441, 67);
            this.Header.TabIndex = 1;
            this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.BackColor = System.Drawing.Color.Gray;
            this.ResultLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLabel.Location = new System.Drawing.Point(823, 43);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(93, 24);
            this.ResultLabel.TabIndex = 6;
            this.ResultLabel.Text = "Correct!";
            this.ResultLabel.Visible = false;
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SubmitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SubmitButton.FlatAppearance.BorderSize = 0;
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(694, 37);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(90, 30);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Visible = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.BackColor = System.Drawing.Color.Gray;
            this.QuestionLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Location = new System.Drawing.Point(299, 43);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(344, 24);
            this.QuestionLabel.TabIndex = 4;
            this.QuestionLabel.Text = "Enter the expression of the circuit";
            this.QuestionLabel.Visible = false;
            // 
            // Quit
            // 
            this.Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Quit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Image = global::LogicGateProject.Properties.Resources.Quit;
            this.Quit.Location = new System.Drawing.Point(1377, 0);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(64, 67);
            this.Quit.TabIndex = 3;
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoadButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.LoadButton.FlatAppearance.BorderSize = 0;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Image = global::LogicGateProject.Properties.Resources.Load;
            this.LoadButton.Location = new System.Drawing.Point(128, 0);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(64, 67);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Image = global::LogicGateProject.Properties.Resources.Save;
            this.SaveButton.Location = new System.Drawing.Point(64, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(64, 67);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.Save_Click);
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
            // AddExpression
            // 
            this.AddExpression.BackColor = System.Drawing.Color.Silver;
            this.AddExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddExpression.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AddExpression.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddExpression.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddExpression.ForeColor = System.Drawing.Color.Gray;
            this.AddExpression.Location = new System.Drawing.Point(300, 67);
            this.AddExpression.Name = "AddExpression";
            this.AddExpression.Size = new System.Drawing.Size(1141, 33);
            this.AddExpression.TabIndex = 2;
            this.AddExpression.Text = "INPUT BOOLEAN EXPRESSION E.G. A.(B + C)\' (USE % FOR XOR)";
            this.AddExpression.Enter += new System.EventHandler(this.AddExpression_Enter);
            this.AddExpression.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddExpression_KeyDown);
            this.AddExpression.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddExpression_KeyPress);
            this.AddExpression.Leave += new System.EventHandler(this.AddExpression_Leave);
            // 
            // DesignerPanel
            // 
            this.DesignerPanel.BackColor = System.Drawing.Color.Transparent;
            this.DesignerPanel.Controls.Add(this.DeleteAll);
            this.DesignerPanel.Controls.Add(this.DeleteButton);
            this.DesignerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DesignerPanel.Location = new System.Drawing.Point(300, 100);
            this.DesignerPanel.Name = "DesignerPanel";
            this.DesignerPanel.Size = new System.Drawing.Size(1141, 813);
            this.DesignerPanel.TabIndex = 3;
            this.DesignerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DesignerPanel_Paint);
            this.DesignerPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DesignerPanel_MouseClick);
            // 
            // DeleteAll
            // 
            this.DeleteAll.BackColor = System.Drawing.Color.Black;
            this.DeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteAll.FlatAppearance.BorderSize = 0;
            this.DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAll.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAll.ForeColor = System.Drawing.Color.White;
            this.DeleteAll.Location = new System.Drawing.Point(1076, 73);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(64, 44);
            this.DeleteAll.TabIndex = 5;
            this.DeleteAll.Text = "All";
            this.DeleteAll.UseVisualStyleBackColor = false;
            this.DeleteAll.Visible = false;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Image = global::LogicGateProject.Properties.Resources.Delete;
            this.DeleteButton.Location = new System.Drawing.Point(1076, 0);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(64, 67);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1441, 913);
            this.Controls.Add(this.DesignerPanel);
            this.Controls.Add(this.AddExpression);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Simulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.RightPanel.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.DesignerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Button StepByStep;
        private System.Windows.Forms.Button CreateExpression;
        private System.Windows.Forms.Button CreateTruthTable;
        private System.Windows.Forms.Button AddNOR;
        private System.Windows.Forms.Button AddXOR;
        private System.Windows.Forms.Button AddOR;
        private System.Windows.Forms.Button AddOutput;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Button AddNAND;
        private System.Windows.Forms.Button AddNOT;
        private System.Windows.Forms.Button AddAND;
        private System.Windows.Forms.Button AddInput;
        private System.Windows.Forms.TextBox AddExpression;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button NANDSimplifcation;
        private System.Windows.Forms.Panel DesignerPanel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button SubmitButton;
    }
}

