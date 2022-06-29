
using System.Windows.Forms;

namespace SearchingAlgorithms
{
    partial class ApplicationSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.DFSButton = new System.Windows.Forms.RadioButton();
            this.BFSButton = new System.Windows.Forms.RadioButton();
            this.AStarButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SecondSizeButton = new System.Windows.Forms.RadioButton();
            this.FirstSizeButton = new System.Windows.Forms.RadioButton();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.CustomRadioButton = new System.Windows.Forms.RadioButton();
            this.StartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algorithm:";
            // 
            // DFSButton
            // 
            this.DFSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DFSButton.Location = new System.Drawing.Point(12, 25);
            this.DFSButton.Name = "DFSButton";
            this.DFSButton.Size = new System.Drawing.Size(144, 37);
            this.DFSButton.TabIndex = 2;
            this.DFSButton.Text = "DFS";
            this.DFSButton.UseVisualStyleBackColor = true;
            this.DFSButton.CheckedChanged += new System.EventHandler(this.DFSButton_CheckedChanged);
            // 
            // BFSButton
            // 
            this.BFSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BFSButton.Location = new System.Drawing.Point(12, 67);
            this.BFSButton.Name = "BFSButton";
            this.BFSButton.Size = new System.Drawing.Size(144, 37);
            this.BFSButton.TabIndex = 3;
            this.BFSButton.Text = "BFS";
            this.BFSButton.UseVisualStyleBackColor = true;
            this.BFSButton.CheckedChanged += new System.EventHandler(this.BFSButton_CheckedChanged);
            // 
            // AStarButton
            // 
            this.AStarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AStarButton.Location = new System.Drawing.Point(12, 110);
            this.AStarButton.Name = "AStarButton";
            this.AStarButton.Size = new System.Drawing.Size(144, 37);
            this.AStarButton.TabIndex = 4;
            this.AStarButton.Text = "A*";
            this.AStarButton.UseVisualStyleBackColor = true;
            this.AStarButton.CheckedChanged += new System.EventHandler(this.AStarButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(49, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Map size:";
            // 
            // SecondSizeButton
            // 
            this.SecondSizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SecondSizeButton.Location = new System.Drawing.Point(13, 60);
            this.SecondSizeButton.Name = "SecondSizeButton";
            this.SecondSizeButton.Size = new System.Drawing.Size(144, 37);
            this.SecondSizeButton.TabIndex = 7;
            this.SecondSizeButton.Text = "40X40";
            this.SecondSizeButton.UseVisualStyleBackColor = true;
            this.SecondSizeButton.CheckedChanged += new System.EventHandler(this.SecondSizeButton_CheckedChanged);
            // 
            // FirstSizeButton
            // 
            this.FirstSizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FirstSizeButton.Location = new System.Drawing.Point(13, 13);
            this.FirstSizeButton.Name = "FirstSizeButton";
            this.FirstSizeButton.Size = new System.Drawing.Size(144, 41);
            this.FirstSizeButton.TabIndex = 6;
            this.FirstSizeButton.Text = "30X30";
            this.FirstSizeButton.UseVisualStyleBackColor = true;
            this.FirstSizeButton.CheckedChanged += new System.EventHandler(this.FirstSizeButton_CheckedChanged);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Enabled = false;
            this.HeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HeightTextBox.Location = new System.Drawing.Point(221, 357);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(122, 35);
            this.HeightTextBox.TabIndex = 9;
            this.HeightTextBox.Text = "Height";
            this.HeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeightTextBox_KeyPress);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Enabled = false;
            this.WidthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WidthTextBox.Location = new System.Drawing.Point(360, 357);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(122, 35);
            this.WidthTextBox.TabIndex = 10;
            this.WidthTextBox.Text = "Width";
            this.WidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WidthTextBox_KeyPress);
            // 
            // CustomRadioButton
            // 
            this.CustomRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CustomRadioButton.Location = new System.Drawing.Point(13, 103);
            this.CustomRadioButton.Name = "CustomRadioButton";
            this.CustomRadioButton.Size = new System.Drawing.Size(132, 37);
            this.CustomRadioButton.TabIndex = 11;
            this.CustomRadioButton.Text = "Custom:";
            this.CustomRadioButton.UseVisualStyleBackColor = true;
            this.CustomRadioButton.CheckedChanged += new System.EventHandler(this.CustomRadioButton_CheckedChanged);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StartButton.Location = new System.Drawing.Point(167, 407);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(200, 45);
            this.StartButton.TabIndex = 12;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Clicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BFSButton);
            this.groupBox1.Controls.Add(this.AStarButton);
            this.groupBox1.Controls.Add(this.DFSButton);
            this.groupBox1.Location = new System.Drawing.Point(42, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 153);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FirstSizeButton);
            this.groupBox2.Controls.Add(this.SecondSizeButton);
            this.groupBox2.Controls.Add(this.CustomRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(42, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 140);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // ApplicationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.label2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Searching Algorithms Visualiser";
            this.Load += new System.EventHandler(this.ApplicationSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton DFSButton;
        private System.Windows.Forms.RadioButton BFSButton;
        private System.Windows.Forms.RadioButton AStarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton SecondSizeButton;
        private System.Windows.Forms.RadioButton FirstSizeButton;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.RadioButton CustomRadioButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}