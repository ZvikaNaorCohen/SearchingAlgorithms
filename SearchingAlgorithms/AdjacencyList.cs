using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchingAlgorithms
{
    class AdjacencyList
    {

        public List<AdjacencyNode> m_AdjacencyNodes = new List<AdjacencyNode>();
        public int m_BoardX, m_BoardY;

        public AdjacencyList()
        {
            m_AdjacencyNodes.Capacity = 1000;
        }

        public int NumberOfElementsInAdjacencyList()
        {
            return m_AdjacencyNodes.Count;
        }

        public void AddNodeToEndOfList(AdjacencyNode i_NodeToAdd)
        {
            m_AdjacencyNodes.Add(i_NodeToAdd);
        }
    }
}
