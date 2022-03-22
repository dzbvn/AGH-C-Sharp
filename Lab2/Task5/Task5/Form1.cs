using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form

    {
        public string prevLocation = "";
        public string prevKey = "";
        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }
        public Form1()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string currentKey = e.KeyCode.ToString();
            string res = "";
            if(prevKey == Keys.Control.ToString() || prevKey == Keys.Shift.ToString() || prevKey == Keys.Alt.ToString())
            {
                res = prevKey + currentKey;
            }
            else
            {
                res = currentKey;
            }

            label4.Text = res;
            prevKey = currentKey;


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            /*System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Current location", e.Location);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Previous location", prevLocation);
            messageBoxCS.AppendLine();
            
            MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event");
            prevLocation = e.Location.ToString();*/
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Text.StringBuilder messageBox = new System.Text.StringBuilder();
            messageBox.Append("Click!");
            messageBox.AppendLine();
            messageBox.AppendFormat("{0} = {1}", "Button", e.Button);
            messageBox.AppendLine();

            MessageBox.Show(messageBox.ToString(), "MouseClick Event");
        }
    }
}
