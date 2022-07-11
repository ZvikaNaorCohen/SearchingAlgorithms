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
        public AdjacencyList[,] m_GraphAdjacencyLists;

        public DirectedGraph(UpgradedPictureBox[,] i_BoardPictureBoxes, int i_BoardHeight, int i_BoardWidth)
        {
            m_GraphAdjacencyLists = new AdjacencyList[i_BoardHeight, i_BoardWidth];
            int numOfVertices = 0, numOfEdges = 0;
            for (int i = 0; i < i_BoardWidth; i++)
            {
                for(int j = 0; j < i_BoardHeight; j++)
                {
                    AdjacencyList nodeNeighbors = new AdjacencyList();
                    if(i_BoardPictureBoxes[i, j].BackColor == Colors.DefaultColor || i_BoardPictureBoxes[i,j].BackColor == Colors.StartPointColor)
                    {
                        numOfVertices++;
                        numOfEdges += getEdgesAroundNode(ref nodeNeighbors, i_BoardPictureBoxes, i, j, i_BoardHeight, i_BoardWidth);
                    }
                    m_GraphAdjacencyLists[i, j] = nodeNeighbors;
                    m_GraphAdjacencyLists[i, j].m_BoardX = i;
                    m_GraphAdjacencyLists[i, j].m_BoardY = j;
                }
            }
        }

        private static int getEdgesAroundNode(ref AdjacencyList i_NodeNeighbors,
            UpgradedPictureBox[,] i_BoardPictureBoxes,
            int i_CurrentRow,
            int i_CurrentCol, int i_BoardHeight, int i_BoardWidth)
        {
            int counter = 0;

            // i j+1 RIGHT
            if (i_CurrentCol + 1 < i_BoardWidth && (i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol + 1].BackColor == Colors.DefaultColor || i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol + 1].BackColor == Colors.EndPointColor)) // i, j+1
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow, i_CurrentCol + 1));
            }

            // i+1 j DOWN
            if (i_CurrentRow + 1 < i_BoardHeight && (i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol].BackColor == Colors.DefaultColor || i_BoardPictureBoxes[i_CurrentRow + 1, i_CurrentCol].BackColor == Colors.EndPointColor)) // i+1, j
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow + 1, i_CurrentCol));
            }

            // i j-1 LEFT
            if (i_CurrentCol - 1 >= 0 && (i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol - 1].BackColor == Colors.DefaultColor || i_BoardPictureBoxes[i_CurrentRow, i_CurrentCol - 1].BackColor == Colors.EndPointColor)) // i, j-1
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow, i_CurrentCol - 1));
            }

            // i-1 j UP
            if (i_CurrentRow - 1 >= 0 && (i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol].BackColor == Colors.DefaultColor || i_BoardPictureBoxes[i_CurrentRow - 1, i_CurrentCol].BackColor == Colors.EndPointColor))
            {
                counter++;
                i_NodeNeighbors.AddNodeToEndOfList(new AdjacencyNode(i_CurrentRow - 1, i_CurrentCol));
            }

            return counter;
        }

        public void RunAStar(UpgradedPictureBox[,] i_PictureBoxes)
        {

        }
    }
}
