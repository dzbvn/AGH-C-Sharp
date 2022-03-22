using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("a is empty");
            }

            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("b is empty");
            }

            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("c is empty");
            }

            else
            {

                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double c = Convert.ToDouble(textBox3.Text);

                double d = b * b - 4 * a * c;
                if (d > 0)
                {
                    double x1 = (-b - Math.Sqrt(d)) / 2 * a;
                    double x2 = (-b + Math.Sqrt(d)) / 2 * a;
                    label1.Text = "Delta > 0\n X1 = " + x1 + "\nX2 = " + x2;
                }
                else if (d == 0)
                {
                    double x1 = (-b) / 2 * a;
                    label1.Text = "Delta = 0, X = " + x1;
                }
                else
                {
                    label1.Text = "Delta < 0, brak rozwiązań";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
