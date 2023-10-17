using System;
using System.Net;
using System.Net.Sockets; 
using System.Text; 
using System.Threading; 
using System.Windows.Forms;

namespace Display
{
    public partial class Notes : Form
    {
        TcpClient client = new TcpClient();
        string ip = "";
        string port = "";


        public Notes()
        {
            InitializeComponent();
        }


        private void connect_btn_Click(object sender, EventArgs e)
        {
            ip = tb_ip.Text;
            port = tb_port.Text;

            if (string.IsNullOrEmpty(ip) || ip.Split('.').Length != 4 || string.IsNullOrEmpty(port))
            {
                ip = "";
                port = "";
                return;
            }

            client = new TcpClient();

            Thread connectThread = new Thread(new ThreadStart(Connect));
            connectThread.IsBackground = true;
            connectThread.Start();
        }


        private void Connect()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));

            Invoke((Action)(() =>
            {
                tb_log.AppendText("Connecting..." + "\r\n");
            }));

            try
            {
                client.Connect(endPoint);

                Invoke((Action)(() =>
                {
                    tb_log.AppendText("Connected..." + "\r\n");
                }));

                Thread receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }


        private void Receive()
        {
            while (true)
            {
                if (client.Connected)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytes = stream.Read(buffer, 0, buffer.Length);
                        if (bytes <= 0)
                        {
                            continue;
                        }

                        string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                        if (message.EndsWith("]"))
                            // 메시지. 끝에 해당 문자를 포함 boolean
                        {
                            Invoke((Action)(() =>
                            {
                                tb_log.AppendText(message + "\r\n");
                            }));
                        }
                        else if (message.Equals("out"))
                        {
                            Invoking();
                        }
                    }
                    catch (Exception)
                    {
                        Invoking();
                    }
                }
            }
        }


        private void Invoking()
        {
            Invoke((Action)(() =>
            {
                client.Close();
                MessageBox.Show("서버와 연결이 끊어졌습니다.");
                Application.Exit();
            }));
        }


        private void btnDicon_Click(object sender, EventArgs e)
        {
            client.Close();
        }
    }
}
