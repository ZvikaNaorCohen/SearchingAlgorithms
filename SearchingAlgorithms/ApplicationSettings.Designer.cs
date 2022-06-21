
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
            this.DijkstraButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DFSButton = new System.Windows.Forms.RadioButton();
            this.BFSButton = new System.Windows.Forms.RadioButton();
            this.AStarButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SecondSizeButton = new System.Windows.Forms.RadioButton();
            this.FirstSizeButton = new System.Windows.Forms.RadioButton();
            this.HeightTextbox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.CustomRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // DijkstraButton
            // 
            this.DijkstraButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DijkstraButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DijkstraButton.Location = new System.Drawing.Point(54, 68);
            this.DijkstraButton.Name = "DijkstraButton";
            this.DijkstraButton.Size = new System.Drawing.Size(144, 41);
            this.DijkstraButton.TabIndex = 0;
            this.DijkstraButton.Text = "Dijkstra";
            this.DijkstraButton.UseVisualStyleBackColor = true;
            this.DijkstraButton.CheckedChanged += new System.EventHandler(this.DijkstraButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(49, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please choose an algorithm:";
            // 
            // DFSButton
            // 
            this.DFSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DFSButton.Location = new System.Drawing.Point(54, 115);
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
            this.BFSButton.Location = new System.Drawing.Point(54, 158);
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
            this.AStarButton.Location = new System.Drawing.Point(54, 201);
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
            this.label2.Location = new System.Drawing.Point(49, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please choose map size:";
            // 
            // SecondSizeButton
            // 
            this.SecondSizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SecondSizeButton.Location = new System.Drawing.Point(54, 346);
            this.SecondSizeButton.Name = "SecondSizeButton";
            this.SecondSizeButton.Size = new System.Drawing.Size(144, 37);
            this.SecondSizeButton.TabIndex = 7;
            this.SecondSizeButton.Text = "500X500";
            this.SecondSizeButton.UseVisualStyleBackColor = true;
            this.SecondSizeButton.CheckedChanged += new System.EventHandler(this.SecondSizeButton_CheckedChanged);
            // 
            // FirstSizeButton
            // 
            this.FirstSizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FirstSizeButton.Location = new System.Drawing.Point(54, 296);
            this.FirstSizeButton.Name = "FirstSizeButton";
            this.FirstSizeButton.Size = new System.Drawing.Size(144, 41);
            this.FirstSizeButton.TabIndex = 6;
            this.FirstSizeButton.Text = "300X300";
            this.FirstSizeButton.UseVisualStyleBackColor = true;
            this.FirstSizeButton.CheckedChanged += new System.EventHandler(this.FirstSizeButton_CheckedChanged);
            // 
            // HeightTextbox
            // 
            this.HeightTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HeightTextbox.Location = new System.Drawing.Point(192, 396);
            this.HeightTextbox.Name = "HeightTextbox";
            this.HeightTextbox.Size = new System.Drawing.Size(122, 35);
            this.HeightTextbox.TabIndex = 9;
            this.HeightTextbox.Text = "Height";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WidthTextBox.Location = new System.Drawing.Point(333, 396);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(122, 35);
            this.WidthTextBox.TabIndex = 10;
            this.WidthTextBox.Text = "Width";
            // 
            // CustomRadioButton
            // 
            this.CustomRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CustomRadioButton.Location = new System.Drawing.Point(54, 394);
            this.CustomRadioButton.Name = "CustomRadioButton";
            this.CustomRadioButton.Size = new System.Drawing.Size(132, 37);
            this.CustomRadioButton.TabIndex = 11;
            this.CustomRadioButton.Text = "Custom:";
            this.CustomRadioButton.UseVisualStyleBackColor = true;
            this.CustomRadioButton += new System.EventHandler(this.CustomRadioButton_CheckedChanged);
            // 
            // ApplicationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 491);
            this.Controls.Add(this.CustomRadioButton);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.HeightTextbox);
            this.Controls.Add(this.SecondSizeButton);
            this.Controls.Add(this.FirstSizeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AStarButton);
            this.Controls.Add(this.BFSButton);
            this.Controls.Add(this.DFSButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DijkstraButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Searching Algorithms Visualiser";
            this.Load += new System.EventHandler(this.ApplicationSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton DijkstraButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton DFSButton;
        private System.Windows.Forms.RadioButton BFSButton;
        private System.Windows.Forms.RadioButton AStarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton SecondSizeButton;
        private System.Windows.Forms.RadioButton FirstSizeButton;
        private System.Windows.Forms.TextBox HeightTextbox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.RadioButton CustomRadioButton;
    }
}