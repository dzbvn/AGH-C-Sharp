
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using Newtonsoft.Json;
using System;




namespace Task2_Car_Chooser

    
{
    public partial class ConfigureForm : Form
    {

        enum Brand
        {
            Audi,
            BMW,
            Mercedes,
            Toyota
        }
        enum Color
        {
            red,
            blue,
            white,
            grey,
            green,
            yellow,
            black
        }

        public class Car {
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
        List<Car> carList;
        List<Car> boughtCarsList;
   

        Form1 f;
        public ConfigureForm(Form1 f)
        {
            InitializeComponent();
            tableLayoutPanel1.RowStyles.RemoveAt(1);
            //flpList.Add(flowLayoutPanel1);
            this.f = f;
        
            initListView();
            fillListView();
            //carList = new List<Car>();
            //carList.Add(new Car("", "", "", ""));
         
            string text = System.IO.File.ReadAllText(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\carList.json");
            Console.WriteLine(text);

            

            carList = new List<Car>();
            boughtCarsList = new List<Car>();
            string output = JsonConvert.SerializeObject(carList);
            Console.WriteLine(output);

            using (StreamReader r = new StreamReader(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\carList.json"))
            {
                string json = r.ReadToEnd();
                carList = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            Console.WriteLine(carList[6].model);

            updateBrandCBox();
            updateModelCBox();
            updateEngineCBox();
            updateColorCBox();
            //updateTableLayout();

        }

        public void updateBrandCBox()
        {
            //comboBoxBrand.Text = "Brand";
            if (comboBoxColor.SelectedItem != null)
            {

                comboBoxBrand.Items.Clear();
                foreach (Car car in carList)
                {
                    if (!comboBoxBrand.Items.Contains(car.brand) && car.color == comboBoxColor.SelectedItem.ToString())
                    {
                        comboBoxBrand.Items.Add(car.brand);
                    }
                }

            }
            else
            {
                foreach (Car car in carList)
                {
                    if (!comboBoxBrand.Items.Contains(car.brand))
                    {
                        comboBoxBrand.Items.Add(car.brand);
                    }
                }
            }
        }

        public void updateModelCBox()
        {
            if (comboBoxBrand.SelectedItem != null)
            {
                comboBoxModel.Enabled = true;
                comboBoxModel.Items.Clear();
                foreach (Car car in carList)
                {
                    if (!comboBoxModel.Items.Contains(car.model) && car.brand == comboBoxBrand.SelectedItem.ToString())
                    {
                        comboBoxModel.Items.Add(car.model);
                    }
                }

            }
            else
            {
                comboBoxModel.Enabled = false;
            }
        }

        public void updateEngineCBox()
        {

            if (comboBoxModel.SelectedItem != null)
            {
                comboBoxEngine.Enabled = true;
                comboBoxEngine.Items.Clear();
                foreach (Car car in carList)
                {
                    if (!comboBoxEngine.Items.Contains(car.engine) && car.model == comboBoxModel.SelectedItem.ToString())
                    {
                        comboBoxEngine.Items.Add(car.engine);
                    }
                }

            }
            else
            {
                comboBoxEngine.Enabled = false;
            }
        }

        public void updateColorCBox()
        {
            if (comboBoxEngine.SelectedItem != null)
            {

                comboBoxColor.Items.Clear();
                foreach (Car car in carList)
                {
                    if (!comboBoxColor.Items.Contains(car.color) && car.engine == comboBoxEngine.SelectedItem.ToString() && car.model == comboBoxModel.SelectedItem.ToString() && car.brand == comboBoxBrand.SelectedItem.ToString())
                    {
                        comboBoxColor.Items.Add(car.color);
                    }
                }
            }

            else if (comboBoxModel.SelectedItem != null)
            {

                comboBoxColor.Items.Clear();
                foreach (Car car in carList)
                {
                    if (!comboBoxColor.Items.Contains(car.color) && car.model == comboBoxModel.SelectedItem.ToString() && car.brand == comboBoxBrand.SelectedItem.ToString())
                    {
                        comboBoxColor.Items.Add(car.color);
                    }
                }
            }

            else if (comboBoxBrand.SelectedItem != null)
            {

                comboBoxColor.Items.Clear();
                foreach (Car car in carList)
                {
                    if (!comboBoxColor.Items.Contains(car.color) && car.brand == comboBoxBrand.SelectedItem.ToString())
                    {
                        comboBoxColor.Items.Add(car.color);
                    }
                }
            }

            else
            {
                foreach (Car car in carList)
                {
                    if (!comboBoxColor.Items.Contains(car.color))
                    {
                        comboBoxColor.Items.Add(car.color);
                    }
                }
            }
            
        }

        public void updateFlowLayout()
        {
            for (int i = 0; i < 30; i++)
            {
                flowLayoutPanel1.Controls.Add(new Button() { Text = "test" });
            }
        }


        public void clearAllCBoxes()
        {
            comboBoxBrand.SelectedItem = null;
            comboBoxModel.SelectedItem = null;
            comboBoxEngine.SelectedItem = null;
            comboBoxColor.SelectedItem = null;
            comboBoxBrand.Items.Clear();
            comboBoxModel.Items.Clear();
            comboBoxEngine.Items.Clear();
            comboBoxColor.Items.Clear();
            updateBrandCBox();
            updateColorCBox();
        }

        private void comboBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {     
            updateModelCBox();
            updateEngineCBox();
            updateColorCBox();
            updateTableLayout();
        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEngineCBox();
            updateColorCBox();
            updateTableLayout();
        }

        private void comboBoxEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateColorCBox();
            updateTableLayout();
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBrand.SelectedItem == null)
            {
                updateBrandCBox();
                updateModelCBox();
                updateEngineCBox();
                updateTableLayout();
            }
            else
            {
                updateTableLayout();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearAllCBoxes();       
        }

        public void deleteAllPBoxes()
        {

        }
        private void PictureBoxes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
                boughtCarsList.Add((Car)(((PictureBox)sender).Tag));
                fillListView();
                saveBoughtCars();
            }
        }

        private void saveBoughtCars()
        {
            using (StreamWriter file = File.CreateText(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\boughtCarList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, boughtCarsList);
            }
        }


        Random rnd = new Random();
        Size[] sizes = new Size[] { new Size(75, 75), new Size(100, 100), new Size(125, 125) };
        //Color[] colors = new Color[] { System.Drawing.Color.AliceBlue, Color.LightGreen, Color.YellowGreen, Color.SteelBlue };
        Control selectedObject = null;
        List<PictureBox> pbList = new List<PictureBox>();
       
        private void updateTableLayout()
        {
                foreach (PictureBox pb in pbList)
                {
                    pb.Dispose();
                    Console.WriteLine(pb.Parent);
                }

            List<Car> currentCars = new List<Car>();

            if (comboBoxBrand.SelectedItem != null
                && comboBoxModel.SelectedItem != null
                && comboBoxEngine.SelectedItem != null
                && comboBoxColor.SelectedItem != null)
            {
                foreach (Car car in carList)
                {
                    if (car.brand == comboBoxBrand.SelectedItem.ToString()
                        && car.model == comboBoxModel.SelectedItem.ToString()
                        && car.engine == comboBoxEngine.SelectedItem.ToString()
                        && car.color == comboBoxColor.SelectedItem.ToString())
                        currentCars.Add(car);
                }
            }
            else if (comboBoxBrand.SelectedItem != null
                && comboBoxModel.SelectedItem != null
                && comboBoxEngine.SelectedItem != null)
            {
                foreach (Car car in carList)
                {
                    if (car.brand == comboBoxBrand.SelectedItem.ToString()
                        && car.model == comboBoxModel.SelectedItem.ToString()
                        && car.engine == comboBoxEngine.SelectedItem.ToString())
                        currentCars.Add(car);
                }
            }
            else if (comboBoxBrand.SelectedItem != null
                && comboBoxModel.SelectedItem != null)
            {
                foreach (Car car in carList)
                {
                    if (car.brand == comboBoxBrand.SelectedItem.ToString()
                        && car.model == comboBoxModel.SelectedItem.ToString())
                        currentCars.Add(car);
                }
            }
            else if (comboBoxBrand.SelectedItem != null
                && comboBoxColor.SelectedItem != null)
            {
                foreach (Car car in carList)
                {
                    if (car.brand == comboBoxBrand.SelectedItem.ToString()
                        && car.color == comboBoxColor.SelectedItem.ToString())
                        currentCars.Add(car);
                }
            }

            else if (comboBoxBrand.SelectedItem != null)
            {
                foreach (Car car in carList)
                {
                    if (car.brand == comboBoxBrand.SelectedItem.ToString())
                        currentCars.Add(car);
                }
            }
            else if (comboBoxColor.SelectedItem != null)
            {
                foreach (Car car in carList)
                {
                    if (car.color == comboBoxColor.SelectedItem.ToString())
                        currentCars.Add(car);
                }
            }



            foreach (Car car in currentCars)
            {
                Size size = new Size(200, 125);

                var pBox = new PictureBox()
                {
                    Anchor = AnchorStyles.None,
                    //BackColor = System.Drawing.Color.AliceBlue,
                    //BackColor = colors[rnd.Next(colors.Length)],
                    BackgroundImage = Image.FromFile(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\cars\"
                        + car.brand + car.model + car.engine + car.color + ".png"),
                    Tag = car,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    MinimumSize = size,
                    Size = size
          
                };
                pBox.MouseClick += PictureBoxes_MouseClick;
                pbList.Add(pBox);

                bool drawborder = false;
                // Just for testing - use standard delegates instead of Lambdas in real code
                pBox.MouseEnter += (s, evt) => { drawborder = true; pBox.Invalidate(); };
                pBox.MouseLeave += (s, evt) => { drawborder = false; pBox.Invalidate(); };
                pBox.MouseDown += (s, evt) => { selectedObject = pBox; pBox.Invalidate(); };
                pBox.Paint += (s, evt) =>
                {
                    if (drawborder)
                    {
                        ControlPaint.DrawBorder(evt.Graphics, pBox.ClientRectangle,
                                                System.Drawing.Color.Yellow, ButtonBorderStyle.Solid);
                    }
                };

                var ctl = tableLayoutPanel1.GetControlFromPosition(0, tableLayoutPanel1.RowCount - 1);
                int overallWith = ctl.Controls.OfType<Control>().Sum(c => c.Width + c.Margin.Left + c.Margin.Right);
                overallWith += (ctl.Margin.Right + ctl.Margin.Left);

                if ((overallWith + pBox.Size.Width + pBox.Margin.Left + pBox.Margin.Right) >= tableLayoutPanel1.Width)
                {
                    var flp = new FlowLayoutPanel()
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    };

                    flp.Controls.Add(pBox);

                    tableLayoutPanel1.SuspendLayout();
                    tableLayoutPanel1.RowCount += 1;
                    tableLayoutPanel1.Controls.Add(flp, 0, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.ResumeLayout(true);
                    //flpList.Add(flp);
                }
                else
                {
                    ctl.Controls.Add(pBox);
                }
                
            }
            foreach (Car car in currentCars)
            {
                Console.WriteLine(car.brand, car.model, car.color);
            }
        }


        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            PictureBox pBox = new PictureBox()
            {
                Anchor = AnchorStyles.None,
                //BackColor = Color.Orange,
                MinimumSize = new Size(125, 125),
                Size = new Size(125, 125),
            };
            flowLayoutPanel1.Controls.Add(pBox);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1);
        }

        private void initListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Your cars", 150);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            
            
        }
        private void fillListView()
        {
            listView1.Items.Clear();
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(120, 75);
            if (boughtCarsList != null)
            {
                listView1.SmallImageList = imgs;
                int i = 0;
                foreach (Car car in boughtCarsList)
                {
                    imgs.Images.Add(Image.FromFile(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\cars\"
                            + car.brand + car.model + car.engine + car.color + ".png"));
                    listView1.Items.Add(car.brand + "\n" + car.model, i);
                    i++;
                }
                
            }
        }
        private void buttonList_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxBrand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateModelCBox();
            updateEngineCBox();
            updateColorCBox();
            updateTableLayout();
        }

        private void comboBoxModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateEngineCBox();
            updateColorCBox();
            updateTableLayout();
        }

        private void comboBoxEngine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateColorCBox();
            updateTableLayout();
        }

        private void comboBoxColor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxBrand.SelectedItem == null)
            {
                updateBrandCBox();
                updateModelCBox();
                updateEngineCBox();
                updateTableLayout();
            }
            else
            {
                updateTableLayout();
            }
        }
    }
}
