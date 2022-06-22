using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchingAlgorithms
{
    public partial class ApplicationSettings : Form
    {
        public ApplicationSettings()
        {
            InitializeComponent();
        }

        private void ApplicationSettings_Load(object sender, EventArgs e)
        {

        }

        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(CustomRadioButton.Checked)
            {
                WidthTextBox.Enabled = true;
                HeightTextbox.Enabled = true;
                WidthTextBox.Text = "";
                HeightTextbox.Text = "";
            }
            else
            {
                WidthTextBox.Text = "Width";
                HeightTextbox.Text = "Height";
                WidthTextBox.Enabled = false;
                HeightTextbox.Enabled = false;
            }
        }

        private void DFSButton_CheckedChanged(object sender, EventArgs e)
        {
            if(DFSButton.Checked)
            {
                DFSButton.Checked = true;
                BFSButton.Checked = false;
                AStarButton.Checked = false;
            }
        }
        private void BFSButton_CheckedChanged(object sender, EventArgs e)
        {
            if(BFSButton.Checked)
            {
                DFSButton.Checked = false;
                BFSButton.Checked = true;
                AStarButton.Checked = false;
            }
        }
        private void AStarButton_CheckedChanged(object sender, EventArgs e)
        {
            if(AStarButton.Checked)
            {
                DFSButton.Checked = false;
                BFSButton.Checked = false;
                AStarButton.Checked = true;
            }
        }

        private void FirstSizeButton_CheckedChanged(object sender, EventArgs e)
        {
            if(FirstSizeButton.Checked)
            {
                SecondSizeButton.Checked = false;
                CustomRadioButton.Checked = false;
            }

            
        }

        private void SecondSizeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SecondSizeButton.Checked)
            {
                FirstSizeButton.Checked = false;
                CustomRadioButton.Checked = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
