using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        string port;
        string path;
        string line;
        string dane;
        int licznik; //licznik wykonanych pomiarow - uzywane w pliku txt

        public Form1()
        {

            InitializeComponent();
            x = 0;
            y = 0;
            X = x * 2;
            Y = 200 - (y * 20);
            licznik = 1;
            dane = null;
        }

        private void button_START_Click(object sender, EventArgs e)
        {
            start();
        }

        private void start()
        {
            port = textBox_port.Text;

            if (port == "COMx")
            {
                MessageBox.Show("Wrong COMx value");
            }
            else
            {
                button_START.Visible = false;
                button_SAVE.Visible = true;
                buttonON.Visible = true;
                button_W.Visible = true;
                button_A.Visible = true;
                button_S.Visible = true;
                button_D.Visible = true;

                serialPort1.PortName = port;
                serialPort1.BaudRate = 9600;

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        mapa[i, j] = 0;
                    }
                }

                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);

                podglad();
                text_X_value.Text += String.Format("{0,5} ", Convert.ToString(X));
                text_Y_value.Text += String.Format("{0,5} ", Convert.ToString(Y));
            }
        }

        /*ustawianie wartosci 1 lub 0 dla wykrycia obiektu lub tez nie*/
        private void map()
        {
            if (wartosc < Y + 10)
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

                dane = spl.ReadLine();
                wartosc = Convert.ToInt32(dane);
                Console.WriteLine("dane: " + dane);
                Console.WriteLine("wartosc: " + wartosc);
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
            path = textBox_path.Text;
            FileInfo file1 = new FileInfo(path);
            try
            {
                using (StreamWriter file =
                new StreamWriter(@path, true))
                {
                    file.WriteLine("Numer pomiaru: " + licznik);
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        line = Convert.ToString(mapa[j, i]);
                        using (StreamWriter file =
                        new StreamWriter(@path, true))
                        {
                            file.Write(line);
                        }
                    }

                    using (StreamWriter file =
                    new StreamWriter(@path, true))
                    {
                        file.WriteLine("");
                    }
                }

                licznik++;
                using (StreamWriter file =
                new StreamWriter(@path, true))
                {
                    file.WriteLine("" + "");
                }
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Wrong path");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Wrong path");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Wrong path");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Wrong path");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Wrong path");
            }
        }
    }
}
