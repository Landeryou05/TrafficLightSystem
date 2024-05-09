using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalAggTask
{
    public partial class Form1 : Form
    {
        // Instancing the singal box and declaring variables.
        private SignalBox m_signalBox1;
        private SignalBox2 m_signalBox2;
        private int m_signalState1;
        private int m_signalState2;
        private int m_buttonPressed = 0;

        public int SignalState
        {
            get { return m_signalState1; }
            set { m_signalState1 = value;}
        }

        public int SignalState2
        {
            get { return m_signalState2; }
            set { m_signalState2 = value; }
        }

        public int ButtonPressed
        {
            get { return m_buttonPressed; }
            set { m_buttonPressed = value; }
        }

        public Form1()
        {
            InitializeComponent();

            // This class changes the light when Form1 is instanced (From the start).
            m_signalBox1 = new SignalBox(20, 0);
            m_signalBox1.ChangeLights(0);

            m_signalBox2 = new SignalBox2(20, 0);
            m_signalBox2.ChangeLights(0);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            m_signalBox1.Display(g);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            m_signalBox2.Display(g);
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            m_buttonPressed = 1;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void lightChangeTimer_Tick(object sender, EventArgs e)
        {
            if (m_buttonPressed == 1)
            {
                // Toggle lamp on and off
                m_signalState1 = m_signalBox1.ChangeLights(m_signalState1);
                m_signalState2 = m_signalBox2.ChangeLights(m_signalState2);

                // Force picture box to be redrawn
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
        }
    }
}
