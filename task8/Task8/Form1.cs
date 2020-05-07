using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Task8
{
    public partial class Form1 : Form
    {
        private DataWorker worker;

        public Form1()
        {
            InitializeComponent();

            try
            {
                worker = new DataWorker("test.xml");
            }
            catch
            {
                MessageBox.Show("Xml file data has incorrect syntax", "Fatal error");
                this.Close();
            }


            /*  foreach (Payment item in worker.selectAllData())
              {
                  dataGridView1.Rows.Add(item.House, item.Flat, item.Name, item.Type, item.Date, item.Amount.ToString().Replace(',','.'), item.Penalty.ToString().Replace(',', '.'), item.Delay);
              } */
            refreshTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            
            try
            {
                int house = 0;
                if (textBox1.Text != "")
                {
                    house = Int32.Parse(textBox1.Text);
                }

                int flat = 0;
                if (textBox2.Text != "")
                {
                    flat = Int32.Parse(textBox2.Text);
                }

                string name = textBox3.Text;
                string type = comboBox1.Text;
                DateTime date = default(DateTime);
                if (checkBox1.Checked)
                {
                    date = DateTime.Parse(dateTimePicker1.Text);
                }
                
                if (house < 0 || house >= 1000 || flat < 0 || flat >= 5000)
                {
                    throw new ArgumentException("Incorrect parameters were given.");
                }
                else
                {

                    refreshTable(worker.selectData(house, flat, name, type, date));
                    /* dataGridView1.Rows.Clear();
                    var result = worker.selectData(house, flat, name, type, date);
                    foreach (Payment item in result)
                    {
                        dataGridView1.Rows.Add(item.House, item.Flat, item.Name, item.Type, item.Date, item.Amount, item.Penalty, item.Delay);
                    } */
                }
            }
            catch
            {
                MessageBox.Show("Incorrect parameters were given.", "Error");
            }      
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[ind];

            if (row.Cells["house"].Value != null)
            {
                 worker.deleteElement(row.Cells["house"].Value.ToString(),
                    row.Cells["flat"].Value.ToString(),
                    row.Cells["name"].Value.ToString(),
                    row.Cells["type"].Value.ToString(),
                    row.Cells["date"].Value.ToString(),
                    row.Cells["amount"].Value.ToString(),
                    row.Cells["penalty"].Value.ToString(),
                    row.Cells["delay"].Value.ToString());

                dataGridView1.Rows.RemoveAt(ind);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[ind];

            int rows = dataGridView1.RowCount;
            try
            {
                int house = Convert.ToInt32(row.Cells["house"].Value);
                int flat = Convert.ToInt32(row.Cells["flat"].Value);
                string name = row.Cells["name"].Value.ToString();
                string type = row.Cells["type"].Value.ToString();
                DateTime date = Convert.ToDateTime(row.Cells["date"].Value).Date;
                double amount = Convert.ToDouble(row.Cells["amount"].Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                double penalty = Convert.ToDouble(row.Cells["penalty"].Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                int delay = Convert.ToInt32(row.Cells["delay"].Value);

                if (house <= 0 || house >= 1000 || flat <= 0 || 
                    flat >= 5000 || date == default(DateTime) || 
                    (type != "газ" && type != "квартплата" && type != "электричество" && type != "вода")||
                    amount <= 0 || penalty < 0 || delay < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    worker.AddElement(house, flat, name, type, date,
                    amount, penalty, delay);
                }
            }
            catch
            {
                MessageBox.Show("Incorrect parameters were given.", "Error");
            }

            refreshTable();
        }

        private void refreshTable()
        {
            dataGridView1.Rows.Clear();
            foreach (Payment item in worker.selectAllData())
            {
                dataGridView1.Rows.Add(item.House, item.Flat, item.Name, item.Type, item.Date, item.Amount.ToString().Replace(',', '.'), item.Penalty.ToString().Replace(',', '.'), item.Delay);
            }
        }

        private void refreshTable(List<Payment> data)
        {
            dataGridView1.Rows.Clear();
            foreach (Payment item in data)
            {
                dataGridView1.Rows.Add(item.House, item.Flat, item.Name, item.Type, item.Date, item.Amount.ToString().Replace(',', '.'), item.Penalty.ToString().Replace(',', '.'), item.Delay);
            }
        }

    }
}
