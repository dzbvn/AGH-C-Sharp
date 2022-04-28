using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Task2_Car_Chooser
{
    public partial class AddForm : Form
    {
        Form1 f;
        List<Car> carList;
        bool flag;
        public AddForm(Form1 f)
        {
            InitializeComponent();
            this.f = f;
            flag = false;
        }
        public class Car
        {
            public string brand { get; set; }
            public string model { get; set; }
            public string engine { get; set; }
            public string color { get; set; }

            public Car(string brand, string model, string engine, string color)
            {
                this.brand = brand;
                this.model = model;
                this.engine = engine;
                this.color = color;
            }

        }
        OpenFileDialog opnfd;

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBoxBrand.Text == "" ||
            textBoxModel.Text == "" ||
            textBoxEngine.Text == "" ||
            textBoxColor.Text == "" ||
            flag == false)
            {
                return;
            }
            else
            {
                carList = new List<Car>();


                using (StreamReader r = new StreamReader(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\carList.json"))
                {
                    string json = r.ReadToEnd();
                    carList = JsonConvert.DeserializeObject<List<Car>>(json);
                }
                carList.Add(new Car(textBoxBrand.Text, textBoxModel.Text, textBoxEngine.Text, textBoxColor.Text));

                using (StreamWriter file = File.CreateText(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\carList.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, carList);
                    string source = opnfd.FileName;
                    string dest = @"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\" + textBoxBrand.Text + textBoxModel.Text + textBoxEngine.Text + textBoxColor.Text + ".png";
                    File.Copy(source, dest);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = opnfd.FileName;
                pictureBox1.Load();
                pictureBox1.Refresh();
                flag = true;
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxBrand.Text = "";
            textBoxModel.Text = "";
            textBoxEngine.Text = "";
            textBoxColor.Text = "";

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
