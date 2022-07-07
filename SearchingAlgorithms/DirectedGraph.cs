using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms.VisualStyles;
using Timer = System.Timers.Timer;

namespace SearchingAlgorithms
{
    class DirectedGraph
    {
        public List<AdjacencyList> m_StartOfVectorList = new List<AdjacencyList>(1000);
        //public AdjacencyList[,] m_GraphAdjacencyLists = new AdjacencyList[1000,1000]; // Change to board num of pictureboxes.
        public AdjacencyList[,] m_GraphAdjacencyLists; // = new AdjacencyList[1,1];
        private int m_NumberOfVertices = -1;

        //DirectedGraph(List<AdjacencyNode> i_NodesArray, int i_NumOfVertices, int i_NumOfEdges)
        //{
        //    m_StartOfVectorList.Capacity = (i_NumOfVertices);
        //    m_NumberOfVertices = i_NumOfVertices;
        //    for (int i = 0; i < i_NumOfVertices; i++)
        //    {
        //        m_StartOfVectorList.Add(new AdjacencyList());
        //    }

        //    for (int i = 0; i < i_NumOfVertices; i++)
        //    {
        //        int startVertex = i_NodesArray[i].m_StartVertex;
        //        int endVertex = i_NodesArray[i].m_EndVertex;
        //        AdjacencyNode newNode = new AdjacencyNode(startVertex, endVertex);
        //        m_StartOfVectorList[startVertex].AddNodeToEndOfList(newNode);
        //    }
        //}

        //public static DirectedGraph GetBoardGraph(UpgradedPictureBox[,] i_BoardPictureBoxes, int i_BoardHeight, int i_BoardWidth)
        //{
        //    int numOfEdges = 0, numOfVertices = 0;
        //    List<AdjacencyNode> listOfNodes = new List<AdjacencyNode>();
        //    Color defaultColor = i_BoardPictureBoxes[0, 0].m_DefaultBackColor;
        //    for(int i = 0; i < i_BoardWidth; i++)
        //    {
        //        for(int j = 0; j < i_BoardHeight; j++)
        //        {
        //            if(i_BoardPictureBoxes[i, j].BackColor == defaultColor)
        //            {
        //                numOfVertices++;
        //                listOfNodes.Add(new AdjacencyNode(i,j));
        //                numOfEdges += getNumOfEdgesAroundNode(i_BoardPictureBoxes, i, j, i_BoardHeight, i_BoardWidth);
        //            }
        //        }
        //    }

        //    return new DirectedGraph(listOfNodes, numOfVertices, numOfEdges);
        //}

        public DirectedGraph(
            UpgradedPictureBox[,] i_BoardPictureBoxes,
            int i_BoardHeight,
            int i_BoardWidth)
        {
            m_GraphAdjacencyLists = new AdjacencyList[i_BoardHeight, i_BoardWidth];
            Color defaultColor = i_BoardPictureBoxes[0, 0].m_DefaultBackColor;
            Color startColor = i_BoardPictureBoxes[0, 0].m_StartColor;
            int numOfVertices = 0, numOfEdges = 0;
            for (int i = 0; i < i_BoardWidth; i++)
            {
                for(int j = 0; j < i_BoardHeight; j++)
                {
                    AdjacencyList nodeNeighbors = new AdjacencyList();
                    if(i_BoardPictureBoxes[i, j].BackColor == defaultColor || i_BoardPictureBoxes[i,j].BackColor == startColor)
                    {
                        numOfVertices++;
                        numOfEdges += getEdgesAroundNode(ref nodeNeighbors, i_BoardPictureBoxes, i, j, i_BoardHeight, i_BoardWidth);
                    }
                    m_GraphAdjacencyLists[i, j] = nodeNeighbors;
                    m_GraphAdjacencyLists[i, j].m_BoardX = i;
                    m_GraphAdjacencyLists[i, j].m_BoardY = j;
                }
            }

            m_NumberOfVertices = numOfVertices;
        }

        private static int getEdgesAroundNode(ref AdjacencyList i_NodeNeighbors,
            UpgradedPictureBox[,] i_BoardPictureBoxes,
            int i_CurrentRow,
            int i_CurrentCol, int i_BoardHeight, int i_BoardWidth)
        {
            int counter = 0;
            Color defaultColor = i_BoardPictureBoxes[0, 0].m_DefaultBackColor;
            // i-1 j-1
            //if (i_CurrentRow - 1 >= 0 && i_CurrentCol - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol - 1].BackColor == defaultColor) // i-1, j-1
            //{
            //    counter++;
            //}

            // i j+1 RIGHT
            if (i_CurrentCol + 1 < i_BoardWidth && i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol + 1].BackColor == defaultColor) // i, j+1
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow, i_CurrentCol + 1));
            }

            // i+1 j DOWN
            if (i_CurrentRow + 1 < i_BoardHeight && i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol].BackColor == defaultColor) // i+1, j
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow + 1, i_CurrentCol));
            }

            // i j-1 LEFT
            if (i_CurrentCol - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol - 1].BackColor == defaultColor) // i, j-1
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow, i_CurrentCol - 1));
            }

            // i-1 j UP
            if (i_CurrentRow - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol].BackColor == defaultColor)
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow - 1, i_CurrentCol));
            }

            // i-1 j+1
            //if (i_CurrentRow -1 >= 0 && i_CurrentCol + 1 < i_BoardWidth && i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol + 1].BackColor == defaultColor) // i-1, j+1
            //{
            //    counter++;
            //    i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow - 1, i_CurrentCol+1));
            //}

            

            

            //// i+1 j-1
            //if (i_CurrentRow + 1 < i_BoardHeight && i_CurrentCol - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol - 1].BackColor == defaultColor) // i+1, j-1
            //{
            //    counter++;
            //    i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow +1, i_CurrentCol-1));
            //}

            

            // i+1 j+1
            //if (i_CurrentRow + 1 < i_BoardHeight && i_CurrentCol + 1 < i_BoardWidth && i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol + 1].BackColor == defaultColor) // i+1, j+1
            //{
            //    counter++;
            //}

            return counter;
        }

        public void RunAStar(UpgradedPictureBox[,] i_PictureBoxes)
        {

        }

        public void RunBFS(UpgradedPictureBox[,] i_PictureBoxes)
        {

        }

        
    }
}
