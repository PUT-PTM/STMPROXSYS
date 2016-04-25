using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int wartosc;


        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM8";

            //TextBox txt1 = new TextBox();
            top1.BackColor = Color.Red;



            serialPort1.BaudRate = 9600;
            try
            {
                if(!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
        }

        private void Colors()
        {
            if((wartosc>=1000)&&(wartosc<2000))
            {
                if((wartosc>=1000)&&(wartosc<1100))
                {
                    top1.BackColor = Color.DarkOrchid;
                }
                if((wartosc >= 1100) && (wartosc < 1200))
                {
                    top1.BackColor = Color.YellowGreen;
                }

            }
            if ((wartosc >= 2000) && (wartosc < 3000))
            {
                if ((wartosc >= 2000) && (wartosc < 2100))
                {
                    bottom1.BackColor = Color.DarkOrchid;
                }
                if ((wartosc >= 2100) && (wartosc < 2200))
                {
                    bottom1.BackColor = Color.YellowGreen;
                }

            }
            if ((wartosc >= 3000) && (wartosc < 4000))
            {
                if ((wartosc >= 3000) && (wartosc < 3100))
                {
                    right1.BackColor = Color.DarkOrchid;
                }
                if ((wartosc >= 3100) && (wartosc < 3200))
                {
                    right1.BackColor = Color.YellowGreen;
                }

            }
            if ((wartosc >= 4000) && (wartosc < 5000))
            {
                if ((wartosc >= 4000) && (wartosc < 4100))
                {
                    left1.BackColor = Color.DarkOrchid;
                }
                if ((wartosc >= 4100) && (wartosc < 4200))
                {
                    left1.BackColor = Color.YellowGreen;
                }

            }

        }

        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           // throw new NotImplementedException();
           try
            {
                SerialPort spl = (SerialPort)sender;

                string dane = spl.ReadLine();
                wartosc = Convert.ToInt32(dane);
                Console.Write("wartosc: " + wartosc + "\n");

                Colors();

            }
            catch(Exception ex)
            {
         
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
