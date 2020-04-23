using System;
using System.Collections.Concurrent;
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
        private ConcurrentBag<Molecule> molecules;
        private System.Threading.Timer timer;
        private Task[] tasks;
        private CancellationTokenSource cancelTokenSource;
        private CancellationToken token;
        private int moleculesCount = 5;
        private int timeInterval = 200;
        private int standartTimeInterval = 100;
        

        public Form1()
        {
            InitializeComponent();
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
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;

            if (molecules == null)
            {
                Random rand = new Random();
                comboBox1.Enabled = false;    
                
                tasks = new Task[moleculesCount];

                molecules = new ConcurrentBag<Molecule>();
                for (int i = 0; i < moleculesCount; i++)
                {                   
                    molecules.Add(new Molecule(panel1.Width, panel1.Height, rand));
                }
                   
                timer = new System.Threading.Timer(v => draw(), null, 
                    Timeout.Infinite, Timeout.Infinite);

                draw();
            }

            timer.Change(0, timeInterval);
      
            for (int i = 0; i < moleculesCount; i++)
            {
                var index = i;
                tasks[i] = new Task(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        molecules.ElementAt(index).move();
                        Thread.Sleep(timeInterval);
                    }
                });

                tasks[i].Start();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
            timer.Change(-1, -1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           timeInterval = standartTimeInterval / trackBar1.Value;
           timer.Change(0, timeInterval);
        }
    }
}
