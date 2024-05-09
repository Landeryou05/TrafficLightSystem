using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalAggTask
{
    internal class Lamp
    {
        private Color m_lampColour; // Lamp Colour.
        private bool m_onStatus; // True = On. False = Off.
        private Rectangle m_pos; // Position.

        public Lamp(Color lampColour, int x, int y)
        {
            m_lampColour = lampColour; // Lamp is initally off.
            m_onStatus = false;

            m_pos = new Rectangle(x, y, 50, 50);
        }

        public bool OnStatus // Using getters and setters to set the value to the private variables.
        {
            get { return m_onStatus; }
            set { m_onStatus = value; }
        }

        public void Display(Graphics g)
        {
            SolidBrush brush;

            if (m_onStatus)
            {
                brush = new SolidBrush(m_lampColour);
            }
            else
            {
                brush = new SolidBrush(Color.Gray);
            }
            g.FillEllipse(brush, m_pos);
        }
    }
}
