using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

            // this.TopMost = true;

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
            m_StartingPoint = new Point(5, 5);
            m_EndingPoint = new Point(10, 10);
            m_VisualizerPictureBoxes[5, 5].BackColor = m_VisualizerPictureBoxes[5, 5].m_StartColor;
            m_VisualizerPictureBoxes[10, 10].BackColor = m_VisualizerPictureBoxes[10, 10].m_EndColor;

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
            Color defaultColor = i_PictureBoxes[0, 0].m_DefaultBackColor;
            foreach(AdjacencyList list in
                    i_Graph.m_GraphAdjacencyLists) // Reset all colors to white. Not sure this is necessary.
            {
                foreach(AdjacencyNode node in list.m_AdjacencyNodes)
                {
                    if(i_PictureBoxes[node.m_StartVertex, node.m_EndVertex].BackColor == defaultColor)
                    {
                        i_PictureBoxes[node.m_StartVertex, node.m_EndVertex].BackColor = Color.White;
                    }
                }
            }

            AdjacencyList startingPointList = i_Graph.m_GraphAdjacencyLists[m_StartingPoint.X, m_StartingPoint.Y];
            newVisit(i_Graph, startingPointList, i_PictureBoxes);
        }

        private async void newVisit(DirectedGraph i_Graph, AdjacencyList i_List, UpgradedPictureBox[,] i_PictureBoxes)
        {
            paintPictureBox(i_PictureBoxes, i_List.m_BoardX, i_List.m_BoardY, Color.Gray);
            await TaskEx.Delay(200);
            Color endColor = i_PictureBoxes[0, 0].m_EndColor;
            for(int i = 0; i < i_List.m_AdjacencyNodes.Count; i++)
            {
                int neighborStartVertex = i_List.m_AdjacencyNodes[i].m_StartVertex;
                int neighborEndVertex = i_List.m_AdjacencyNodes[i].m_EndVertex;
                if(i_PictureBoxes[neighborStartVertex, neighborEndVertex].BackColor == Color.White && !m_ToEnd)
                {
                    i_PictureBoxes[neighborStartVertex, neighborEndVertex].m_WhoCalledMe = i_PictureBoxes[i_List.m_BoardX, i_List.m_BoardY];
                    AdjacencyList listToVisit = i_Graph.m_GraphAdjacencyLists[neighborStartVertex, neighborEndVertex];
                    newVisit(i_Graph, listToVisit, i_PictureBoxes);
                }
                else if(i_PictureBoxes[neighborStartVertex, neighborEndVertex].BackColor == endColor && !m_ToEnd)
                {
                    i_PictureBoxes[neighborStartVertex, neighborEndVertex].m_WhoCalledMe = i_PictureBoxes[i_List.m_BoardX, i_List.m_BoardY];
                    showShortestPath(i_PictureBoxes, neighborStartVertex, neighborEndVertex);
                }
            }

            if(!m_ToEnd)
            {
                paintPictureBox(i_PictureBoxes, i_List.m_BoardX, i_List.m_BoardY, Color.Black);
            }

            await TaskEx.Delay(200);
        }

        private void showShortestPath(UpgradedPictureBox[,] i_PictureBoxes, int i_StartVertex, int i_EndVertex)
        {
            UpgradedPictureBox nextMark = i_PictureBoxes[i_StartVertex, i_EndVertex];
            while(nextMark != null)
            {
                paintPictureBox(i_PictureBoxes, nextMark.m_PositionOnBoard.X, nextMark.m_PositionOnBoard.Y, Color.ForestGreen);
                nextMark = nextMark.m_WhoCalledMe;
            }

            m_ToEnd = true;
        }

        private void paintPictureBox(UpgradedPictureBox[,] i_PictureBoxes, int i_Row, int i_Col, Color i_Color)
        {
            if(!m_ToEnd)
            {
                i_PictureBoxes[i_Row, i_Col].BackColor = i_Color;
            }
        }


        private async void runBFS(DirectedGraph i_Graph, UpgradedPictureBox[,] i_PictureBoxes)
        {
            Queue<AdjacencyList> verticesQueue = new Queue<AdjacencyList>();
            int[,] verticesArray = new int[m_BoardHeight, m_BoardWidth];
            AdjacencyList startVertex = i_Graph.m_GraphAdjacencyLists[m_StartingPoint.X, m_StartingPoint.Y];
            Color endColor = i_PictureBoxes[0, 0].m_EndColor;
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
                await TaskEx.Delay(20);
                for(int i = 0; i < outOfQueue.m_AdjacencyNodes.Count; i++)
                {
                    int neighborStartVertex = outOfQueue.m_AdjacencyNodes[i].m_StartVertex;
                    int neighborEndVertex = outOfQueue.m_AdjacencyNodes[i].m_EndVertex;

                    if(verticesArray[neighborStartVertex, neighborEndVertex] == Int32.MaxValue)
                    {
                        if(i_PictureBoxes[neighborStartVertex, neighborEndVertex].BackColor == endColor)
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
    }
}
