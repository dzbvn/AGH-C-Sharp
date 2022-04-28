using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_Car_Chooser
{
    public partial class Form1 : Form
    {
        ConfigureForm conF;
        AddForm addF;
        BookForm bookF;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conF = new ConfigureForm(this);
            conF.Show();
            //this.Close();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addF = new AddForm(this);
            addF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bookF = new BookForm();
            bookF.Show();
        }
    }
}
