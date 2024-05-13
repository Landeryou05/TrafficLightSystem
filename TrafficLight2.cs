using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalAggTask
{
    internal class TrafficLight2
    {
        private Lamp m_redLamp;
        private Lamp m_amberLamp;
        private Lamp m_greenLamp;

        public TrafficLight2(int x, int y)
        {
            m_redLamp = new Lamp(Color.Red, x, y + 25);
            m_amberLamp = new Lamp(Color.Orange, x, y + 85);
            m_greenLamp = new Lamp(Color.Green, x, y + 145);
        }

        public int ChangeLights(int flag)
        {
            switch (flag)
            {
                case 0:
                    m_redLamp.OnStatus = false;
                    m_amberLamp.OnStatus = false;
                    m_greenLamp.OnStatus = true;
                    return 1;
                case 1:
                    m_redLamp.OnStatus = false;
                    m_amberLamp.OnStatus = true;
                    m_greenLamp.OnStatus = false;
                    return 2;
                case 2:
                    m_redLamp.OnStatus = true;
                    m_amberLamp.OnStatus = false;
                    m_greenLamp.OnStatus = false;
                    return 3;
                case 3:
                    m_redLamp.OnStatus = true;
                    m_amberLamp.OnStatus = true;
                    m_greenLamp.OnStatus = false;
                    return 0;
                default:
                    return 0;
            }
        }

        public void Display(Graphics g)
        {
            m_redLamp.Display(g);
            m_amberLamp.Display(g);
            m_greenLamp.Display(g);
        }
    }
}
