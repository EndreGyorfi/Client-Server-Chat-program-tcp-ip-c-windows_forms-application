using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);

        string readdata = null;

        public bool bejelentkezve = false;

        public int type = 0;

        public string felado;
        public string cimzett;

        public Form1()
        {
            InitializeComponent();
            textBox2.Visible = false;

            label3.Visible = false;
            textBox4.Visible = false;
            create.Visible = false;
            addPeople.Visible = false;

            label4.Visible = false;
            textBox5.Visible = false;
            add.Visible = false;
        }

        public byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect("127.0.0.1", 27015);
                label1.Text = "Status: Connected...";
                connectButton.Visible = false;

                felado = textBox1.Text;
                serverStream = clientSocket.GetStream();
                cimzett = felado;
                byte[] outstream = Encoding.ASCII.GetBytes(type + "/" + felado + "/" + cimzett + "/" + textBox1.Text);
                listBox1.Items.Add(">> Your user name is: " + textBox1.Text);
                serverStream.Write(outstream, 0, outstream.Length);
                publicButton_Click(sender, e);
                serverStream.Flush();
            }
            catch
            {
                label1.Text = "Cant connect to the server...";
            }



            Thread ctThread = new Thread(getMessages);
            ctThread.Start();
        }

        public void getMessages()
        {
            string returnData;

            while (true)
            {
               // serverStream = clientSocket.GetStream();
                var buffersize = clientSocket.ReceiveBufferSize;
                byte[] instream = new byte[buffersize];

                serverStream.Read(instream, 0, buffersize);
                returnData = System.Text.Encoding.ASCII.GetString(instream);
                readdata = returnData;

                string[] words = returnData.Split('/');

                if (words[0] == "6")
                {
                    byte[] writeData = System.Text.Encoding.ASCII.GetBytes(words[4]);

                    readdata =words[3] + "/" + words[4];

                    string filenev = "ki.txt";

                    FileStream fs = File.Create(filenev);

                    fs.Write(writeData, 0, writeData.Length);
                }
                UpdateReceivedPressureLabelText(readdata);
                //msg();
            }
        }

        void UpdateReceivedPressureLabelText(string value)
        {
            Action action = () => listBox1.Items.Add(value);
            this.Invoke(action);
        }

        private void publicButton_Click(object sender, EventArgs e)
        {
            ReadAllBytes("a.txt");
            type = 1;
            textBox2.Visible = false;
        }

        private void privateButton_Click(object sender, EventArgs e)
        {
            type = 2;
            textBox2.Visible = true;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            cimzett = textBox2.Text;
            byte[] outstream = Encoding.ASCII.GetBytes(type + "/" + felado + "/" + cimzett + "/" + textBox3.Text);
            listBox1.Items.Add(">>" +textBox3.Text);
            textBox3.Text = "";

            serverStream.Write(outstream, 0, outstream.Length);
            serverStream.Flush();
        }

        private void createGroup_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox4.Visible = true;
            create.Visible = true;
            addPeople.Visible = true;
        }

        private void addPeople_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            textBox5.Visible = true;
            add.Visible = true;
        }

        private void create_Click(object sender, EventArgs e)
        {
            type = 3;
            felado = textBox1.Text;
            //serverStream = clientSocket.GetStream();
            cimzett = felado;
            byte[] outstream = Encoding.ASCII.GetBytes(type + "/" + felado + "/" + cimzett + "/" + textBox4.Text);
            serverStream.Write(outstream, 0, outstream.Length);
        }

        private void add_Click(object sender, EventArgs e)
        {
            type = 4;
            felado = textBox1.Text;
            //serverStream = clientSocket.GetStream();
            cimzett = textBox5.Text; ;
            byte[] outstream = Encoding.ASCII.GetBytes(type + "/" + felado + "/" + cimzett + "/" + textBox5.Text);
            serverStream.Write(outstream, 0, outstream.Length);
        }

        private void toGroup_Click(object sender, EventArgs e)
        {
            type = 5;
            cimzett = textBox4.Text;
            byte[] outstream = Encoding.ASCII.GetBytes(type + "/" + felado + "/" + cimzett + "/" + textBox3.Text);
            listBox1.Items.Add(">>" + textBox3.Text);
            textBox3.Text = "";

            serverStream.Write(outstream, 0, outstream.Length);
            serverStream.Flush();
        }

        private void sendFile_Click(object sender, EventArgs e)
        {
            type = 6;
            cimzett = textBox2.Text;
            felado = textBox1.Text;
            string fname = "a.txt";
            byte[] fileData = ReadAllBytes(fname);

            //byte[] fnameData = 

            byte[] outstream = Encoding.ASCII.GetBytes(type + "/" + felado + "/" + cimzett + "/" + fname + "/");

            byte[] combined = Combine(outstream, fileData);

            serverStream.Write(combined, 0, combined.Length);

        }
    }
}