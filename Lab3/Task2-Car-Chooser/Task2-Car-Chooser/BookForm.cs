using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Task2_Car_Chooser
{
    public partial class BookForm : Form
    {


        List<Car> boughtCarList;
        Dictionary<Car, List<DateTime>> Dates;
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
        public BookForm()
        {
            InitializeComponent();
            boughtCarList = new List<Car>();
            Dates = new Dictionary<Car, List<DateTime>>();
            readBoughtCars();
            initListView();
            fillListView();
        }
        private void enableCalendar()
        {
            if(listView1.SelectedItems.Count > 0)
            {
                monthCalendar1.Enabled = true;
            }
        }
        private void initListView()
        {
            
            listView1.View = View.Details;
            listView1.Columns.Add("Your cars", 150);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void readBoughtCars()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\boughtCarList.json"))
            {
                string json = r.ReadToEnd();
                boughtCarList = JsonConvert.DeserializeObject<List<Car>>(json);
            }
        }
        private void fillListView()
        {
         
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(120, 75);
            if (boughtCarList != null)
            {
                listView1.SmallImageList = imgs;
                int i = 0;
                foreach (Car car in boughtCarList)
                {
                    imgs.Images.Add(Image.FromFile(@"C:\Users\szymo\AGH\Semestr IV\PZ2\Lab3\Task2-Car-Chooser\cars\"
                            + car.brand + car.model + car.engine + car.color + ".png"));
                    listView1.Items.Add(car.brand + "\n" + car.model, i);
                    listView1.Items[listView1.Items.Count - 1].Tag = car;
                    i++;
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableCalendar();
            refreshCalendar();
        }

        private void refreshCalendar()
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Car selectedCar = (Car)(listView1.SelectedItems[0].Tag);
                if (Dates.ContainsKey(selectedCar))
                {
                    monthCalendar1.BoldedDates = Dates[(Car)(listView1.SelectedItems[0].Tag)].ToArray();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Car selectedCar = (Car)(listView1.SelectedItems[0].Tag);

            if (Dates.ContainsKey(selectedCar))
            {
                Dates[selectedCar].Add(monthCalendar1.SelectionRange.Start);
            }
            else
            {
                Dates.Add(selectedCar, new List<DateTime>() { monthCalendar1.SelectionRange.Start });
            }
            refreshCalendar();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.BoldedDates.Contains(e.Start))
            {
                MessageBox.Show("not available");
                
                monthCalendar1.SelectionStart = e.Start.AddDays(1);
                
            }
        }
    }


}
