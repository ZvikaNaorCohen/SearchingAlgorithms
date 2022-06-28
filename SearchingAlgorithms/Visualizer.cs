using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;
using System.Windows;


namespace SearchingAlgorithms
{
    public partial class Visualizer : Form
    {
        private int m_BoardHeight = 0;
        private int m_BoardWidth = 0;
        private AlgorithmTypes.eAlgorithmType m_algorithmType = AlgorithmTypes.eAlgorithmType.NoChoice;
        private bool m_FirstClick = false;
        private UpgradedPictureBox[,] m_VisualizerPictureBoxes;
        private bool m_MouseIsDown = false, m_MouseIsUp = true;
        private Size m_ButtonSize = new Size(20, 20);
        


        public Visualizer(AlgorithmTypes.eAlgorithmType i_AlgorithmType, int i_BoardHeight, int i_BoardWidth)
        {
            m_BoardHeight = i_BoardHeight;
            m_BoardWidth = i_BoardWidth;
            m_algorithmType = i_AlgorithmType;
            InitializeComponent();
        }

        private void VisualizerForm_Load(object sender, EventArgs e)
        {
            resetBoard();
        }

        private void resetBoard()
        {
            Left = 80;
            Top = 100;
            int newHeight = Top + m_BoardHeight * m_ButtonSize.Height;
            int newWidth = Left + m_BoardWidth * m_ButtonSize.Width;
            Size = new Size(newWidth, newHeight);
            m_VisualizerPictureBoxes = new UpgradedPictureBox[m_BoardHeight, m_BoardWidth];
            initBoard();
        }

        private void initBoard()
        {
            m_VisualizerPictureBoxes = new UpgradedPictureBox[m_BoardHeight, m_BoardWidth];
            int left = 0, top = (Top / 2 - m_BoardHeight);
            for (int i = 0; i < m_BoardHeight; i++)
            {
               left = Left / 2 - (m_BoardWidth - 1);
               for(int j = 0; j < m_BoardWidth; j++)
               {
                   m_VisualizerPictureBoxes[i, j] = new UpgradedPictureBox(new Point(i, j))
                                                        {
                                                            Size = m_ButtonSize,
                                                            Top = (i * m_ButtonSize.Width),
                                                            Left = (j * m_ButtonSize.Width),
                                                            Location = new Point(left, top),
                                                            BorderStyle = BorderStyle.FixedSingle
                                                        };
                   m_VisualizerPictureBoxes[i, j].BackColor = m_VisualizerPictureBoxes[i, j].m_DefaultBackColor;
                   left += m_ButtonSize.Width;
                   m_VisualizerPictureBoxes[i, j].m_PositionOnBoard = new Point(i, j);
                   int x = ((i + 1) * top) + left;
                   int y = ((j + 1) * left) + top;
                   Point XYPoint = new Point(x, y);
                   m_VisualizerPictureBoxes[i, j].m_XYPosition = XYPoint;
                   Controls.Add(m_VisualizerPictureBoxes[i, j]);
                   int copyOfI = i, copyOfJ = j;
                   m_VisualizerPictureBoxes[i, j].Click += (sender, e) => buttonClicked(copyOfI, copyOfJ);
                   //m_VisualizerRectangles[i, j].MouseDown += (MouseDownEvent);
                   //m_VisualizerRectangles[i, j].MouseUp += (MouseUpEvent);
                   // m_VisualizerRectangles[i, j].MouseMove += (mouseEnterEvent);
               }

               top += m_ButtonSize.Height;
            }

            Button startButton = new Button();
            startButton.Location = new Point(top + 30, left + 30);
            startButton.Text = "RUN FINDER";
            startButton.Size = new Size(70, 40);
            startButton.Click += (sender, e) => startButtonClicked();
            Controls.Add(startButton);
            m_VisualizerPictureBoxes[10,10].BackColor = m_VisualizerPictureBoxes[10, 10].m_StartColor;
            m_VisualizerPictureBoxes[20, 20].BackColor = m_VisualizerPictureBoxes[20, 20].m_EndColor;

            Height = top + 50 + startButton.Size.Height;
            Width = left + 20 + startButton.Size.Width;

        }

        private void startButtonClicked()
        { 
            DirectedGraph boardGraph = DirectedGraph.GetBoardGraph(m_VisualizerPictureBoxes, m_BoardHeight, m_BoardWidth);
            foreach(AdjacencyList list in boardGraph.m_StartOfVectorList)
            {
                foreach(AdjacencyNode node in list.m_AdjacencyNodes)
                {
                    int row = node.m_StartVertex;
                    int col = node.m_EndVertex;
                    m_VisualizerPictureBoxes[row,col].BackColor = Color.Pink;
                }
            }
        }


        private void buttonClicked(int i_Row, int i_Col)
        {

            //UpgradedPictureBox buttonClicked = m_VisualizerRectangles[i_Row, i_Col];
            //if(m_VisualizerRectangles[i_Row,i_Col].BackColor == buttonClicked.m_DefaultBackColor)
            //{
            //    m_VisualizerRectangles[i_Row, i_Col].BackColor = Color.Black;
            //}
            //else
            //{
            //    m_VisualizerRectangles[i_Row, i_Col].BackColor = buttonClicked.m_DefaultBackColor;
            //}
        }

        //private void MouseDownEvent(object sender, EventArgs e)
        //{
        //    m_MouseIsDown = true;
        //    m_MouseIsUp = false;
        //}

        //private void MouseUpEvent(object sender, EventArgs e)
        //{
        //    m_MouseIsUp = true;
        //    m_MouseIsDown = false;
        //}

        //private void mouseEnterEvent(object sender, EventArgs e)
        //{
        //    if(m_MouseIsDown)
        //    {
        //        UpgradedPictureBox pictureClicked = sender as UpgradedPictureBox;
        //        int row = pictureClicked.m_PositionOnBoard.X;
        //        int col = pictureClicked.m_PositionOnBoard.Y;
        //        if(m_VisualizerRectangles[row, col].BackColor == pictureClicked.m_DefaultBackColor)
        //        {
        //            m_VisualizerRectangles[row, col].BackColor = Color.Black;
        //        }
        //        else
        //        {
        //            m_VisualizerRectangles[row, col].BackColor = pictureClicked.m_DefaultBackColor;
        //        }
        //    }
        //}

        //private void getButtonRowCol(out int o_Row, out int o_Col, int i_X, int i_Y)
        //{
        //    o_Row = (i_X - Top) / (i_X * m_ButtonSize.Width);
        //    o_Col = (i_Y - Left) / (i_Y * m_ButtonSize.Width);

        //    o_Row = i_X / m_ButtonSize.Width;
        //    o_Col = i_Y / m_ButtonSize.Width;
        //}
    }
}
