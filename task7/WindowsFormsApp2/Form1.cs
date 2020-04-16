using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.Width = this.Width / 2;
            this.trackBar1.Width = this.Width / 4;
            this.trackBar2.Width = this.Width / 4;
            this.trackBar3.Width = this.Width / 4;
            this.trackBar1.Location = new Point((this.Width * 2) / 3, this.Height / 6);
            this.label1.Location = new Point(((this.Width * 2) / 3) - 50, this.Height / 6);
            this.label4.Location = new Point(((this.Width * 2) / 3), this.Height / 6 + 30);
            this.label5.Location = new Point(((this.Width * 2) / 3) + trackBar1.Width - 20, this.Height / 6 + 30);
            this.trackBar2.Location = new Point((this.Width * 2) / 3, (this.Height / 3 + this.Height / 2) / 2);
            this.label2.Location = new Point(((this.Width * 2) / 3) - 60, (this.Height / 3 + this.Height / 2) / 2);
            this.label6.Location = new Point(((this.Width * 2) / 3), (this.Height / 3 + this.Height / 2) / 2 + 30);
            this.label7.Location = new Point(((this.Width * 2) / 3) + trackBar2.Width - 20, (this.Height / 3 + this.Height / 2) / 2 + 30);
            this.trackBar3.Location = new Point((this.Width * 2) / 3, (this.Height / 3 + this.Height) / 2);
            this.label3.Location = new Point(((this.Width * 2) / 3) - 50, (this.Height / 3 + this.Height) / 2);
            this.label8.Location = new Point(((this.Width * 2) / 3), (this.Height / 3 + this.Height) / 2 + 30);
            this.label9.Location = new Point(((this.Width * 2) / 3) + trackBar3.Width - 20, (this.Height / 3 + this.Height) / 2 + 30);
            Clipboard.SetText("#7D7D7D");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            Clipboard.SetText("#" + Convert.ToString(trackBar1.Value, 16).ToUpper() + Convert.ToString(trackBar2.Value, 16).ToUpper() + Convert.ToString(trackBar3.Value, 16).ToUpper());
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            Clipboard.SetText("#" + Convert.ToString(trackBar1.Value, 16).ToUpper() + Convert.ToString(trackBar2.Value, 16).ToUpper() + Convert.ToString(trackBar3.Value, 16).ToUpper());
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            Clipboard.SetText("#" + Convert.ToString(trackBar1.Value, 16).ToUpper() + Convert.ToString(trackBar2.Value, 16).ToUpper() + Convert.ToString(trackBar3.Value, 16).ToUpper());
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label10.Text = "#" + Convert.ToString(trackBar1.Value, 16).ToUpper() + Convert.ToString(trackBar2.Value, 16).ToUpper() + Convert.ToString(trackBar3.Value, 16).ToUpper();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.pictureBox1.Width = this.Width / 2;
            this.trackBar1.Width = this.Width / 4;
            this.trackBar2.Width = this.Width / 4;
            this.trackBar3.Width = this.Width / 4;
            this.trackBar1.Location = new Point((this.Width*2)/3, this.Height/6);
            this.label1.Location = new Point(((this.Width * 2) / 3) - 50, this.Height / 6);
            this.label4.Location = new Point(((this.Width * 2) / 3), this.Height / 6 + 30);
            this.label5.Location = new Point(((this.Width * 2) / 3) + trackBar1.Width - 20, this.Height / 6 + 30);
            this.trackBar2.Location = new Point((this.Width * 2) / 3, (this.Height / 3 + this.Height / 2) / 2);
            this.label2.Location = new Point(((this.Width * 2) / 3) - 60, (this.Height / 3 + this.Height / 2) / 2);
            this.label6.Location = new Point(((this.Width * 2) / 3), (this.Height / 3 + this.Height / 2) / 2 + 30);
            this.label7.Location = new Point(((this.Width * 2) / 3) + trackBar2.Width - 20, (this.Height / 3 + this.Height / 2) / 2 + 30);
            this.trackBar3.Location = new Point((this.Width * 2) / 3, (this.Height / 3 + this.Height) / 2);
            this.label3.Location = new Point(((this.Width * 2) / 3) - 50, (this.Height / 3 + this.Height) / 2);
            this.label8.Location = new Point(((this.Width * 2) / 3), (this.Height / 3 + this.Height) / 2 + 30);
            this.label9.Location = new Point(((this.Width * 2) / 3) + trackBar3.Width - 20, (this.Height / 3 + this.Height) / 2 + 30);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label10.Text = "";
        }
    }
}
