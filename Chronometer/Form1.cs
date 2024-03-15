using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronometer
{
    public partial class Form1 : Form
    {
        private int timeMs;
        private int timeSec;
        private int timeMin;
        bool isActive;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetTime();
            
        }

        private void ResetTime()
        {
            timeMs = 0;
            timeSec = 0;
            timeMin = 0;
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                timeMs+=500;
                if (timeMs >= 1000)
                {
                    timeSec++;
                    timeMs = 0;

                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }
            
            DrawTime();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isActive = true;
            timer1.Start();
        }

        private void DrawTime()
        {
            clockLabel3.Text = String.Format("{0:000}", timeMs);
            clockLabel2.Text = String.Format("{0:00}", timeSec);
            clockLabel1.Text = String.Format("{0:00}", timeMin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isActive = false;
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isActive = false;
            timer1.Stop();
            ResetTime();
            DrawTime();
        }
    }
}
