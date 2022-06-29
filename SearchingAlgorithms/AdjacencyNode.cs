using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchingAlgorithms
{
    public class AdjacencyNode
    {
        public int m_StartVertex { get; set; }
        public int m_EndVertex { get; set; }




        public AdjacencyNode(int i_StartVertex, int i_EndVertex)
        {
            m_StartVertex = i_StartVertex;
            m_EndVertex = i_EndVertex;
        }
    }
}
