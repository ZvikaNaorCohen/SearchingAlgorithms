using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchingAlgorithms
{
    class UpgradedPictureBox : PictureBox
    {
        public Point m_PositionOnBoard { get; set; }
        public Color m_DefaultBackColor = Color.AntiqueWhite;
        public Color m_StartColor = Color.Aqua, m_EndColor = Color.Orange;

        public Point m_XYPosition { get; set; }

        public UpgradedPictureBox(Point i_PointOnBoard)
        {
            m_PositionOnBoard = i_PointOnBoard;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if(BackColor != m_StartColor && BackColor != m_EndColor)
            {
                if (MouseButtons == MouseButtons.Left)
                {
                    BackColor = Color.Black;

                }
                else if (MouseButtons == MouseButtons.Right)
                {
                    BackColor = m_DefaultBackColor;
                }
            }
            
            Capture = false;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (BackColor != m_StartColor && BackColor != m_EndColor)
            {
                if(MouseButtons == MouseButtons.Left)
                {
                    BackColor = Color.Black;
                }
                else if(MouseButtons == MouseButtons.Right)
                {
                    BackColor = m_DefaultBackColor;
                }
            }
        }
    }
}
