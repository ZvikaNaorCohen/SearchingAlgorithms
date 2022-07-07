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

        private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void WidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            HeightTextBox_KeyPress(sender, e);
        }

        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(CustomRadioButton.Checked)
            {
                WidthTextBox.Enabled = true;
                HeightTextBox.Enabled = true;
                WidthTextBox.Text = "";
                HeightTextBox.Text = "";
            }
            else
            {
                WidthTextBox.Text = "Width";
                HeightTextBox.Text = "Height";
                WidthTextBox.Enabled = false;
                HeightTextBox.Enabled = false;
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

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            if((DFSButton.Checked || BFSButton.Checked || AStarButton.Checked)
               && (FirstSizeButton.Checked || SecondSizeButton.Checked || CustomRadioButton.Checked))
            {
                AlgorithmTypes.eAlgorithmType algoType = getAlgorithmType();
                getHeightAndWidth(out int height, out int width);
                if(algoType != AlgorithmTypes.eAlgorithmType.NoChoice)
                {
                    Visualizer startVisualizer = new Visualizer(algoType, height, width);

                    startVisualizer.ShowDialog(this);
                }
            }
        }

        private AlgorithmTypes.eAlgorithmType getAlgorithmType()
        {
            AlgorithmTypes.eAlgorithmType typeToReturn = AlgorithmTypes.eAlgorithmType.NoChoice;
            if(DFSButton.Checked)
            {
                typeToReturn = AlgorithmTypes.eAlgorithmType.Dfs;
            }
            else if(BFSButton.Checked)
            {
                typeToReturn = AlgorithmTypes.eAlgorithmType.Bfs;
            }
            else if(AStarButton.Checked)
            {
                typeToReturn = AlgorithmTypes.eAlgorithmType.AStar;
            }

            return typeToReturn;
        }

        private void getHeightAndWidth(out int o_Height, out int o_Width)
        {
            if(FirstSizeButton.Checked)
            {
                o_Height = o_Width = 20;
            }
            else if(SecondSizeButton.Checked)
            {
                o_Height = o_Width = 20;
            }
            else if(CustomRadioButton.Checked && HeightTextBox.Text != "" && WidthTextBox.Text != "")
            {
                o_Height = int.Parse(HeightTextBox.Text);
                o_Width = int.Parse(WidthTextBox.Text);
                if(o_Height > 50)
                {
                    o_Height = 45;
                }

                if(o_Width > 50)
                {
                    o_Width = 45;
                }
            }
            else
            {
                o_Height = 45;
                o_Width = 45;
            }
        }
    }
}
