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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.button1.Location = new Point((this.Width - 140) / 2 , (this.Height - 57)/2);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int curX = e.X;
            int curY = e.Y;
            if (button1.Left - curX < 10 && button1.Left - curX >= 0 && button1.Top - 5 < curY && curY < button1.Bottom + 5)
            {
                if ((button1.Left + button1.Width + 30) > this.ClientSize.Width)
                {
                    button1.Top = button1.Top + 30;
                    button1.Left = curX - 30;
                }
                else
                    button1.Left = curX + 30;
            }

            if (button1.Top - curY < 10 && button1.Top - curY >= 0 && button1.Left - 5 < curX && curX < button1.Right + 5)
            {
                if ((button1.Top + button1.Height + 30) > this.ClientSize.Height)
                {
                    button1.Top = button1.Top - 30;
                    button1.Left = curX - 30;
                }
                else
                    button1.Top = curY + 30;
            }

            if (curX - button1.Right < 10 && curX - button1.Right >= 0 && button1.Top - 5 < curY && curY < button1.Bottom + 5)
            {
                if ((button1.Left - 30) < 0)
                {
                    button1.Top = button1.Top + 30;
                    button1.Left = curX + 30;
                }
                else
                button1.Left = curX - 30 - button1.Width;
            }

            if (curY - button1.Bottom < 10 && curY - button1.Bottom >= 0 && button1.Left - 5 < curX && curX < button1.Right + 5)
            {
                if ((button1.Top - 30) < 0)
                {
                    button1.Top = button1.Top + 30;
                    button1.Left = curX + 30;
                }
                else
                    button1.Top = curY - 30 - button1.Height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Поздравляем! Вы смогли нажать на кнопку!",
                "Сообщение");
        }
    }
}
