using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SearchingAlgorithms
{
    public partial class Visualizer : Form
    {
        private int m_BoardHeight = 0;
        private int m_BoardWidth = 0;
        private AlgorithmTypes.eAlgorithmType m_algorithmType = AlgorithmTypes.eAlgorithmType.NoChoice;
        private UpgradedPictureBox[,] m_VisualizerPictureBoxes;
        private Size m_ButtonSize = new Size(20, 20);
        private Point m_StartingPoint, m_EndingPoint;
        private bool m_ToEnd = false;
        private int m_WaitTime;
        


        public Visualizer()
        {
            InitializeComponent();
        }

        public Visualizer(AlgorithmTypes.eAlgorithmType i_AlgorithmType, int i_BoardHeight, int i_BoardWidth)
            : this()
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
        }

        private void VisualizerForm_Load(object sender, EventArgs e)
        {
            resetBoard();
            this.Location = new Point(50, 50);
        }

        private void resetBoard()
        {
            Left = m_ButtonSize.Width * 10;
            Top = m_ButtonSize.Height * 10;
            int newHeight = Top + m_BoardHeight * m_ButtonSize.Height;
            int newWidth = Left + m_BoardWidth * m_ButtonSize.Width;
            Size = new Size(newWidth, newHeight);
            m_VisualizerPictureBoxes = new UpgradedPictureBox[m_BoardHeight, m_BoardWidth];
            m_WaitTime = 30 - m_ButtonSize.Height;
            initBoard();
        }

        private void initBoard()
        {
            string buttonText = "Run Finder";
            m_VisualizerPictureBoxes = new UpgradedPictureBox[m_BoardHeight, m_BoardWidth];
            int left = 0, top = (Top / 2 - m_BoardHeight);
            for(int i = 0; i < m_BoardHeight; i++)
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
                    left += m_ButtonSize.Width;
                    m_VisualizerPictureBoxes[i, j].m_PositionOnBoard = new Point(i, j);
                    m_VisualizerPictureBoxes[i, j].BackColor = Colors.DefaultColor;
                    int x = ((i + 1) * top) + left;
                    int y = ((j + 1) * left) + top;
                    m_VisualizerPictureBoxes[i, j].m_XYPosition = new Point(x, y);
                    Controls.Add(m_VisualizerPictureBoxes[i, j]);
                    int copyOfI = i, copyOfJ = j;
                    m_VisualizerPictureBoxes[i, j].Click += (sender, e) => buttonClicked(copyOfI, copyOfJ);
                }

                top += m_ButtonSize.Height;
            }

            Button startButton = new Button();
            startButton.Location = new Point(top, left);
            startButton.Text = buttonText;
            startButton.Size = new Size(70, 40);
            startButton.Click += (sender, e) => startButtonClicked();
            Controls.Add(startButton);

            m_StartingPoint = new Point(5, 5);
            m_EndingPoint = new Point(m_BoardHeight - 3, m_BoardWidth - 3);

            m_VisualizerPictureBoxes[5, 5].BackColor = Colors.StartPointColor;
            m_VisualizerPictureBoxes[m_BoardHeight - 3, m_BoardWidth - 3].BackColor = Colors.EndPointColor;

            Height = top + 50 + startButton.Size.Height;
            Width = left + 20 + startButton.Size.Width;

        }

        private void startButtonClicked()
        {
            DirectedGraph boardGraph = new DirectedGraph(m_VisualizerPictureBoxes, m_BoardHeight, m_BoardWidth);
            runAlgorithm(boardGraph, m_algorithmType);
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
                        runBFS(i_Graph, m_VisualizerPictureBoxes);
                        break;
                    }
                case AlgorithmTypes.eAlgorithmType.Dfs:
                    {
                        runDFS(i_Graph, m_VisualizerPictureBoxes);
                        break;
                    }
            }
        }


        private void buttonClicked(int i_Row, int i_Col)
        {
        }

        private void runDFS(DirectedGraph i_Graph, UpgradedPictureBox[,] i_PictureBoxes)
        {
            foreach(AdjacencyList list in i_Graph.m_GraphAdjacencyLists) // Reset all colors to white. Not sure this is necessary.
            {
                foreach(AdjacencyNode node in list.m_AdjacencyNodes)
                {
                    if(i_PictureBoxes[node.m_StartVertex, node.m_EndVertex].BackColor == Colors.DefaultColor)
                    {
                        i_PictureBoxes[node.m_StartVertex, node.m_EndVertex].BackColor = Color.White;
                    }
                }
            }

            AdjacencyList startingPointList = i_Graph.m_GraphAdjacencyLists[m_StartingPoint.X, m_StartingPoint.Y];
            visit(i_Graph, startingPointList, i_PictureBoxes);
        }

        private void visit(DirectedGraph i_Graph, AdjacencyList i_List, UpgradedPictureBox[,] i_PictureBoxes)
        {
            paintPictureBox(i_PictureBoxes, i_List.m_BoardX, i_List.m_BoardY, Color.Gray);
            for(int i = 0; i < i_List.m_AdjacencyNodes.Count; i++)
            {
                int neighborStartVertex = i_List.m_AdjacencyNodes[i].m_StartVertex;
                int neighborEndVertex = i_List.m_AdjacencyNodes[i].m_EndVertex;
                if(i_PictureBoxes[neighborStartVertex, neighborEndVertex].BackColor == Color.White && !m_ToEnd)
                {
                    i_PictureBoxes[neighborStartVertex, neighborEndVertex].m_WhoCalledMe = i_PictureBoxes[i_List.m_BoardX, i_List.m_BoardY];
                    AdjacencyList listToVisit = i_Graph.m_GraphAdjacencyLists[neighborStartVertex, neighborEndVertex];
                    visit(i_Graph, listToVisit, i_PictureBoxes);
                }
                else if(i_PictureBoxes[neighborStartVertex, neighborEndVertex].BackColor == Colors.EndPointColor && !m_ToEnd)
                {
                    i_PictureBoxes[neighborStartVertex, neighborEndVertex].m_WhoCalledMe = i_PictureBoxes[i_List.m_BoardX, i_List.m_BoardY];
                    showShortestPath(i_PictureBoxes, neighborStartVertex, neighborEndVertex);
                }
            }

            if(!m_ToEnd)
            {
                paintPictureBox(i_PictureBoxes, i_List.m_BoardX, i_List.m_BoardY, Color.Black);
            }
        }

        private void showShortestPath(UpgradedPictureBox[,] i_PictureBoxes, int i_StartVertex, int i_EndVertex)
        {
            UpgradedPictureBox nextMark = i_PictureBoxes[i_StartVertex, i_EndVertex];
            while(nextMark != null)
            {
                paintPictureBox(i_PictureBoxes, nextMark.m_PositionOnBoard.X, nextMark.m_PositionOnBoard.Y, Colors.PathColor);
                nextMark = nextMark.m_WhoCalledMe;
            }

            m_ToEnd = true;
        }

        private void paintPictureBox(UpgradedPictureBox[,] i_PictureBoxes, int i_Row, int i_Col, Color i_Color)
        {
            Wait(m_WaitTime);
            if (!m_ToEnd && i_PictureBoxes[i_Row, i_Col].BackColor != Colors.StartPointColor && i_PictureBoxes[i_Row, i_Col].BackColor != Colors.EndPointColor)
            {
                i_PictureBoxes[i_Row, i_Col].BackColor = i_Color;
            }
        }


        private void runBFS(DirectedGraph i_Graph, UpgradedPictureBox[,] i_PictureBoxes)
        {
            Queue<AdjacencyList> verticesQueue = new Queue<AdjacencyList>();
            int[,] verticesArray = new int[m_BoardHeight, m_BoardWidth];
            AdjacencyList startVertex = i_Graph.m_GraphAdjacencyLists[m_StartingPoint.X, m_StartingPoint.Y];
            foreach(AdjacencyList list in i_Graph.m_GraphAdjacencyLists)
            {
                foreach(AdjacencyNode node in list.m_AdjacencyNodes)
                {
                    verticesArray[node.m_StartVertex, node.m_EndVertex] = Int32.MaxValue;
                }
            }

            verticesQueue.Enqueue(i_Graph.m_GraphAdjacencyLists[m_StartingPoint.X, m_StartingPoint.Y]);
            verticesArray[startVertex.m_BoardX, startVertex.m_BoardY] = 0;

            while(verticesQueue.Count > 0)
            {
                AdjacencyList outOfQueue = verticesQueue.Dequeue();
                paintPictureBox(i_PictureBoxes, outOfQueue.m_BoardX, outOfQueue.m_BoardY, Color.Black);
                for(int i = 0; i < outOfQueue.m_AdjacencyNodes.Count; i++)
                {
                    int neighborStartVertex = outOfQueue.m_AdjacencyNodes[i].m_StartVertex;
                    int neighborEndVertex = outOfQueue.m_AdjacencyNodes[i].m_EndVertex;

                    if(verticesArray[neighborStartVertex, neighborEndVertex] == Int32.MaxValue)
                    {
                        if(i_PictureBoxes[neighborStartVertex, neighborEndVertex].BackColor == Colors.EndPointColor) 
                        {
                            i_PictureBoxes[neighborStartVertex, neighborEndVertex].m_WhoCalledMe = i_PictureBoxes[outOfQueue.m_BoardX, outOfQueue.m_BoardY];
                            showShortestPath(i_PictureBoxes, neighborStartVertex, neighborEndVertex);
                        }
                        else
                        {
                            i_PictureBoxes[neighborStartVertex, neighborEndVertex].m_WhoCalledMe = i_PictureBoxes[outOfQueue.m_BoardX, outOfQueue.m_BoardY];
                            verticesArray[neighborStartVertex, neighborEndVertex] = verticesArray[outOfQueue.m_BoardX, outOfQueue.m_BoardY] + 1;
                            paintPictureBox(i_PictureBoxes, neighborStartVertex, neighborEndVertex, Color.Gray);
                            verticesQueue.Enqueue(i_Graph.m_GraphAdjacencyLists[neighborStartVertex, neighborEndVertex]);
                        }
                    }
                }
            }
        }


        public void Wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start Wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    // Console.WriteLine("stop Wait timer");
                };

            while (timer1.Enabled && !m_ToEnd)
            {
                Application.DoEvents();
            }
        }

    }
}
