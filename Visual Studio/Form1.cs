using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int wartosc;
        int x, y;   //nawigacja w tablicy, dla wygody prowadzenia pomiaru
        int X, Y;   //podglad polozenia pudelka

        int[,] mapa = new int[100, 10];

        string line;

        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM17";
            serialPort1.BaudRate = 9600;
            /*serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;*/
            x = 0;
            y = 0;
            X = x * 2;
            Y = 200 - (y * 20);

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapa[i, j] = 0;
                }
            }

            try
            {
                if(!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);


            podglad();
            text_X_value.Text += String.Format("{0,5} ", Convert.ToString(X));
            text_Y_value.Text += String.Format("{0,5} ", Convert.ToString(Y));
        }


        /*ustawianie wartosci 1 lub 0 dla wykrycia obiektu lub tez nie*/
        private void map()
        {
            if (wartosc < Y + 1)
            {
                mapa[x,y] = 1;
            }
            else
            {
                mapa[x,y] = 0;
            }
            text_map.ResetText();
            podglad();
        }


        /*podglad stanu mapy-tablicy*/
        private void podglad()
        {
           /* for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(mapa[j,i]+" ");
                }
                Console.Write("\n");
            }*/

            for (int i=0; i<10; i++)
            {
                for(int j=0; j<100; j++)
                {
                    text_map.Text += String.Format("{0}", mapa[j,i]);
                }
                text_map.Text += "\n";
                text_map.Text += "\n";
            }
        }

        
        /*odbieranie danych przez bluetooth*/
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           // throw new NotImplementedException();
           try
            {
                SerialPort spl = (SerialPort)sender;

                string dane = spl.ReadLine();
                wartosc = Convert.ToInt32(dane);
                Console.Write("wartosc: " + wartosc + "\n");
            }
            catch(Exception ex)
            {
         
            }
        }


        /*mapowanie*/
        private void buttonON_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button on click, x: " + x +" y: " + y);
            map();
            Console.WriteLine("zakonczono mapowanie");
        }


        /*obsluga przyciskow nawigacyjnych*/
        private void button_W_Click(object sender, EventArgs e)
        {
            if (y > 0)
            {
                y = y - 1;
            }
            Console.WriteLine("y= " + y);
            Y = 200 - (y * 20);
            text_Y_value.Text = String.Format("{0,5} ", Convert.ToString(Y));
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            if (y < 9)
            {
                y = y + 1;
            }
            Console.WriteLine("y= " + y);
            Y = 200 - (y * 20);
            text_Y_value.Text = String.Format("{0,5} ", Convert.ToString(Y));
        }

        private void button_A_Click(object sender, EventArgs e)
        {
            if (x > 0)
            {
                x = x - 1;    
            }
            Console.WriteLine("x= " + x);
            X = x * 2;
            text_X_value.Text = String.Format("{0,5} ", Convert.ToString(X));
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            if (x < 99)
            {
                x = x + 1;
            }
            Console.WriteLine("x= " + x);
            X = x * 2;
            text_X_value.Text = String.Format("{0,5} ", Convert.ToString(X));
        }


        /*obsluga zapisu pomiarow do pliku*/
        private void button_SAVE_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    line = Convert.ToString(mapa[j,i]);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\Adam\Desktop\PTM.txt", true))
                    {
                        file.Write(line);
                    }
                }

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Adam\Desktop\PTM.txt", true))
                {
                    file.WriteLine("");
                }
            }
        }
    }
}
