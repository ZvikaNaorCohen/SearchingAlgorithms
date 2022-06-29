using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Timer = System.Timers.Timer;

namespace SearchingAlgorithms
{
    class DirectedGraph
    {
        public List<AdjacencyList> m_StartOfVectorList = new List<AdjacencyList>(1000);
        private int m_NumberOfVertices = -1;

        DirectedGraph(List<AdjacencyNode> i_NodesArray, int i_NumOfVertices, int i_NumOfEdges)
        {
            m_StartOfVectorList.Capacity = (i_NumOfVertices);
            m_NumberOfVertices = i_NumOfVertices;
            for (int i = 0; i < i_NumOfVertices; i++)
            {
                m_StartOfVectorList.Add(new AdjacencyList());
            }

            for (int i = 0; i < i_NumOfVertices; i++)
            {
                int startVertex = i_NodesArray[i].m_StartVertex;
                int endVertex = i_NodesArray[i].m_EndVertex;
                AdjacencyNode newNode = new AdjacencyNode(startVertex, endVertex);
                m_StartOfVectorList[startVertex].AddNodeToEndOfList(newNode);
            }
        }

        public static DirectedGraph GetBoardGraph(UpgradedPictureBox[,] i_BoardPictureBoxes, int i_BoardHeight, int i_BoardWidth)
        {
            int numOfEdges = 0, numOfVertices = 0;
            List<AdjacencyNode> listOfNodes = new List<AdjacencyNode>();
            Color defaultColor = i_BoardPictureBoxes[0, 0].m_DefaultBackColor;
            for(int i = 0; i < i_BoardWidth; i++)
            {
                for(int j = 0; j < i_BoardHeight; j++)
                {
                    if(i_BoardPictureBoxes[i, j].BackColor == defaultColor)
                    {
                        numOfVertices++;
                        listOfNodes.Add(new AdjacencyNode(i,j));
                        numOfEdges += getNumOfEdgesAroundNode(i_BoardPictureBoxes, i, j, i_BoardHeight, i_BoardWidth);
                    }
                }
            }

            return new DirectedGraph(listOfNodes, numOfVertices, numOfEdges);
        }

        private static int getNumOfEdgesAroundNode(
            UpgradedPictureBox[,] i_BoardPictureBoxes,
            int i_CurrentRow,
            int i_CurrentCol, int i_BoardHeight, int i_BoardWidth)
        {
            int counter = 0;
            Color defaultColor = i_BoardPictureBoxes[0, 0].m_DefaultBackColor;
            // i-1 j-1
            if (i_CurrentRow - 1 >= 0 && i_CurrentCol - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol - 1].BackColor == defaultColor) // i-1, j-1
            {
                counter++;
            }

            // i-1 j
            if (i_CurrentRow - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol].BackColor == defaultColor)
            {
                counter++;
            }

            // i-1 j+1
            if (i_CurrentRow -1 >= 0 && i_CurrentCol + 1 < i_BoardWidth && i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol + 1].BackColor == defaultColor) // i-1, j+1
            {
                counter++;
            }

            // i j-1
            if (i_CurrentCol - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol - 1].BackColor == defaultColor) // i, j-1
            {
                counter++;
            }

            // i j+1
            if (i_CurrentCol + 1 < i_BoardWidth && i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol + 1].BackColor == defaultColor) // i, j+1
            {
                counter++;
            }

            // i+1 j-1
            if (i_CurrentRow + 1 < i_BoardHeight && i_CurrentCol - 1 >= 0 && i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol - 1].BackColor == defaultColor) // i+1, j-1
            {
                counter++;
            }

            // i+1 j
            if (i_CurrentRow + 1 < i_BoardHeight && i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol].BackColor == defaultColor) // i+1, j
            {
                counter++;
            }

            // i+1 j+1
            if (i_CurrentRow + 1 < i_BoardHeight && i_CurrentCol + 1 < i_BoardWidth && i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol + 1].BackColor == defaultColor) // i+1, j+1
            {
                counter++;
            }

            return counter;
        }

        public void RunAStar(UpgradedPictureBox[,] i_PictureBoxes)
        {

        }

        public void RunBFS(UpgradedPictureBox[,] i_PictureBoxes)
        {

        }

        public void RunDFS(UpgradedPictureBox[,] i_PictureBoxes)
        {
            int size = m_StartOfVectorList.Count;
            foreach (AdjacencyList list in m_StartOfVectorList) // Reset all colors to white. Not sure this is necessary.
            {
                foreach(AdjacencyNode node in list.m_AdjacencyNodes)
                {
                    i_PictureBoxes[node.m_StartVertex, node.m_EndVertex].BackColor = Color.White;
                }
            }

            foreach(AdjacencyList list in m_StartOfVectorList)
            {
                if(list.m_AdjacencyNodes.Count > 0 && i_PictureBoxes[list.m_AdjacencyNodes[0].m_StartVertex, list.m_AdjacencyNodes[0].m_EndVertex]
                       .BackColor == Color.White)
                {
                    Visit(list.m_AdjacencyNodes[0], i_PictureBoxes);
                }
            }
        }

        public void Visit(AdjacencyNode i_Vertex, UpgradedPictureBox[,] i_PictureBoxes)
        {
            i_PictureBoxes[i_Vertex.m_StartVertex, i_Vertex.m_EndVertex].BackColor = Color.Gray;

            AdjacencyList vertexNeighbors = m_StartOfVectorList[i_Vertex.m_EndVertex];
            foreach(AdjacencyNode node in vertexNeighbors.m_AdjacencyNodes)
            {
                if (i_PictureBoxes[node.m_StartVertex, node.m_EndVertex].BackColor == Color.White)
                {
                    Visit(node, i_PictureBoxes);
                }
            }

            //if (i_Vertex->getNextNode() != nullptr)
            //{
            //    Visit(i_Vertex->getNextNode());
            //}

            i_PictureBoxes[i_Vertex.m_StartVertex, i_Vertex.m_EndVertex].BackColor = Color.Black;
        }
    }
}
