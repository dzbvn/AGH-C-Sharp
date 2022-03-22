using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form

    {
        public class Person
        {
            public string firstname;
            public string lastname;
            public string phone;

            public Person(string firstname, string lastname, string phone)
            {
                this.firstname = firstname;
                this.lastname = lastname;
                this.phone = phone;
            }
        }
        List<Person> personList = new List<Person>();
        int current = 0;
        
        public Form1()
        {

            personList.Add(new Person("Adam", "Kowalski", "+48228299784"));
            personList.Add(new Person("Karol", "Nowak", "+48675223678"));
            InitializeComponent();
            textBox1.Text = personList[current].firstname;
            textBox2.Text = personList[current].lastname;
            textBox3.Text = personList[current].phone;

        }
        public void refresh()
        {
            textBox1.Text = personList[current].firstname;
            textBox2.Text = personList[current].lastname;
            textBox3.Text = personList[current].phone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("TextBox is empty");
            }
            else
            {
                personList.Add(new Person(textBox1.Text, textBox2.Text, textBox3.Text));
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("TextBox is empty");
            }
            else
            {
                personList[current].firstname = textBox1.Text;
                personList[current].lastname = textBox2.Text;
                personList[current].phone = textBox3.Text;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.current + 1 < personList.Count())
                this.current++;
            this.refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.current > 0)
            {
                this.current--;
                this.refresh();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
