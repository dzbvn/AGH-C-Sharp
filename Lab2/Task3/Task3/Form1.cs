using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;  
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("TextBox is empty");
            }
            else if (checkBox1.Checked)
            {
                this.listBox1.Items.Add(textBox1.Text);
            }
            else
            {
               
                if (!(this.listBox1.Items.Count == 0))
                {
                    for (int n = listBox1.Items.Count - 1; n >= 0; --n)
                    {
                        string removelistitem = textBox1.Text;
                        if (listBox1.Items[n].ToString().Contains(removelistitem))
                        {
                            listBox1.Items.RemoveAt(n);
                        }
                    }
                }
            }
        }
    }
}
