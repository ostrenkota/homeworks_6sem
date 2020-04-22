using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Molecule[] molecules;
        private System.Threading.Timer timer;
        private int moleculesCount = 5; //TODO: использовать значение от юзера
        private int timeInterval = 100; //ms TODO: использовать значение от юзера

        public Form1()
        {
            InitializeComponent();
           
        }

        private void step()
        {
            foreach (Molecule m in molecules)
            {
                m.move();
            }

            draw();
        }

        private void draw()
        {
            Graphics gr = panel1.CreateGraphics();
            gr.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black, 3);
            foreach(Molecule m in molecules)
            { 
                Rectangle rect = new Rectangle(m.X, m.Y, Molecule.radius * 2, Molecule.radius * 2);
                gr.DrawEllipse(blackPen, rect);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                moleculesCount = Int32.Parse(comboBox1.Text);
            }
            catch
            {
                moleculesCount = 5;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (molecules == null)
            {
                comboBox1.Enabled = false;

                Random rand = new Random();
                molecules = new Molecule[moleculesCount];
                for (int i = 0; i < moleculesCount; i++)
                {
                    molecules[i] = new Molecule(panel1.Width, panel1.Height, rand);
                }
                var startTimeSpan = Timeout.Infinite;
                var periodTimeSpan = Timeout.Infinite;

                timer = new System.Threading.Timer(v => step(),
                null, startTimeSpan, periodTimeSpan);
                draw();
            }
            timer.Change(0, timeInterval);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timeInterval = timeInterval / trackBar1.Value;
            timer.Change(0, timeInterval);
        }
    }
}
