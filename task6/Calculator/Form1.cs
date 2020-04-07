using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float x, y;
        int count;
        bool znak = true;

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    y = x + float.Parse(textBox1.Text);
                    label1.Text = y.ToString();
                    break;
                case 2:
                    y = x - float.Parse(textBox1.Text);
                    label1.Text = y.ToString();
                    break;
                case 3:
                    y = x * float.Parse(textBox1.Text);
                    label1.Text = y.ToString();
                    break;
                case 4:
                    y = x / float.Parse(textBox1.Text);
                    label1.Text = y.ToString();
                    break;

                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 8;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 1;
                    label1.Text = x.ToString() + "+";
                    znak = true;
                }
            }
            else
            {
                x = float.Parse(label1.Text);
                label1.Text = "";
                count = 1;
                label1.Text = x.ToString() + "+";
                znak = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 2;
                    label1.Text = x.ToString() + "-";
                    znak = true;
                }
            }
            else
            {
                x = float.Parse(label1.Text);
                label1.Text = "";
                count = 2;
                label1.Text = x.ToString() + "-";
                znak = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 4;
                    label1.Text = x.ToString() + "/";
                    znak = true;
                }
            }
            else
            {
                x = float.Parse(label1.Text);
                label1.Text = "";
                count = 4;
                label1.Text = x.ToString() + "/";
                znak = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            { 
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 4;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 9;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Contains("+")) && !(label1.Text.Contains("-")) && !(label1.Text.Contains("*")) && !(label1.Text.Contains("/")))
            {
                label1.Text = "";
            }
            textBox1.Text = textBox1.Text + 3;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf(',') == -1)
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 3;
                    label1.Text = x.ToString() + "*";
                    znak = true;
                }
            }
            else
            {
                x = float.Parse(label1.Text);
                label1.Text = "";
                count = 3;
                label1.Text = x.ToString() + "*";
                znak = true;
            }
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }

            if (e.KeyChar == '+')
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 1;
                    label1.Text = x.ToString() + "+";
                    znak = true;
                }
            }

            if (e.KeyChar == '-')
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 2;
                    label1.Text = x.ToString() + "-";
                    znak = true;
                }
            }

            if (e.KeyChar == '*')
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 3;
                    label1.Text = x.ToString() + "*";
                    znak = true;
                }
            }

            if (e.KeyChar == '/')
            {
                if (textBox1.Text != "")
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    count = 4;
                    label1.Text = x.ToString() + "/";
                    znak = true;
                }
            }

            if (e.KeyChar == '.')
            {
                if (textBox1.Text.IndexOf(',') == -1)
                {
                    textBox1.Text = textBox1.Text + ",";
                }
            }

            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') == -1)
                {
                    textBox1.Text = textBox1.Text + ",";
                }
            }

            if (e.KeyChar == '=')
            {
                calculate();
                label1.Text = "";
            }
            e.Handled = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.seven.Location = new Point(this.Width / 18, (this.Height / 6 + this.Height / 8)/2);
            this.four.Location = new Point(this.Width / 18, (this.Height / 15 + this.Height / 4));
            this.one.Location = new Point(this.Width / 18, (this.Height / 3 + (this.Height / 7 + this.Height / 6)/2));
            this.CE.Location = new Point(this.Width / 18, ((this.Height / 5)*3 + this.Height / 19));
            this.eight.Location = new Point((this.Width / 2 + this.Width / 16) /2, (this.Height / 6 + this.Height / 8) / 2);
            this.nine.Location = new Point(this.Width / 2, (this.Height / 6 + this.Height / 8) / 2);
            this.plus.Location = new Point((this.Width / 3 + this.Width / 3 + this.Width / 15), (this.Height / 6 + this.Height / 8) / 2);
            this.five.Location = new Point((this.Width / 2 + this.Width / 16) / 2, (this.Height / 15 + this.Height / 4));
            this.six.Location = new Point(this.Width / 2, (this.Height / 15 + this.Height / 4));
            this.minus.Location = new Point((this.Width / 3 + this.Width / 3 + this.Width / 15), (this.Height / 15 + this.Height / 4));
            this.two.Location = new Point((this.Width / 2 + this.Width / 16) / 2, (this.Height / 3 + (this.Height / 7 + this.Height / 6) / 2));
            this.three.Location = new Point(this.Width / 2, (this.Height / 3 + (this.Height / 7 + this.Height / 6) / 2));
            this.multiplication.Location = new Point((this.Width / 3 + this.Width / 3 + this.Width / 15), (this.Height / 3 + (this.Height / 7 + this.Height / 6) / 2));
            this.zero.Location = new Point((this.Width / 2 + this.Width / 16) / 2, ((this.Height / 5) * 3 + this.Height / 19));
            this.dott.Location = new Point(this.Width / 2, ((this.Height / 5) * 3 + this.Height / 19));
            this.division.Location = new Point((this.Width / 3 + this.Width / 3 + this.Width / 15), ((this.Height / 5) * 3 + this.Height / 19));
            this.textBox1.Location = new Point(this.Width / 18, this.Height / 40);
            this.label1.Location = new Point(this.Width / 18 + 2, this.Height / 40 + 2);
            this.equality.Location = new Point(this.Width / 18, (this.Height / 3)*2 + this.Height / 7);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            calculate();
            textBox1.Text = "";
            Clipboard.SetText(label1.Text);
        }
    }
}
