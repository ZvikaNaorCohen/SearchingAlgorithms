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
        private UpgradedPictureBox[,] m_VisualizerPictureBoxes;
        private Size m_ButtonSize = new Size(20, 20);
        


        public Visualizer(AlgorithmTypes.eAlgorithmType i_AlgorithmType, int i_BoardHeight, int i_BoardWidth)
        {
            m_BoardHeight = i_BoardHeight;
            m_BoardWidth = i_BoardWidth;
            m_algorithmType = i_AlgorithmType;
            if(m_BoardHeight > 40 || m_BoardWidth > 40)
            {
                m_ButtonSize = new Size(15, 15);
            }
            else if(m_BoardHeight > 30 || m_BoardWidth > 30)
            {
                m_ButtonSize = new Size(18, 18);
            }
            
            InitializeComponent();
            this.TopMost = true;
            
        }

        private void VisualizerForm_Load(object sender, EventArgs e)
        {
            resetBoard();
        }

        private void resetBoard()
        {
            Left = m_ButtonSize.Width * 10;
            Top = m_ButtonSize.Height * 10;
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
               }

               top += m_ButtonSize.Height;
            }

            Button startButton = new Button();
            startButton.Location = new Point(top, left);
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
            runAlgorithm(boardGraph, m_algorithmType);
            //foreach(AdjacencyList list in boardGraph.m_StartOfVectorList)
            //{
            //    foreach(AdjacencyNode node in list.m_AdjacencyNodes)
            //    {
            //        int row = node.m_StartVertex;
            //        int col = node.m_EndVertex;
            //        m_VisualizerPictureBoxes[row,col].BackColor = Color.Pink;
            //    }
            //}
        }

        private void runAlgorithm(DirectedGraph i_Graph, AlgorithmTypes.eAlgorithmType i_AlgorithmType)
        {
            switch(i_AlgorithmType)
            {
                case AlgorithmTypes.eAlgorithmType.AStar:
                    {
                        i_Graph.RunAStar(m_VisualizerPictureBoxes);
                        break;
                    }
                case AlgorithmTypes.eAlgorithmType.Bfs:
                    {
                        i_Graph.RunBFS(m_VisualizerPictureBoxes);
                        break;
                    }
                case AlgorithmTypes.eAlgorithmType.Dfs:
                    {
                        i_Graph.RunDFS(m_VisualizerPictureBoxes);
                        break;
                    }
            }
        }


        private void buttonClicked(int i_Row, int i_Col)
        {
        }
    }
}
