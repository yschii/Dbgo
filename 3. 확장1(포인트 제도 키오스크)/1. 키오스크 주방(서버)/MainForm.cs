using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics; 
using System.Drawing; 
using System.Net; 
using System.Net.NetworkInformation; 
using System.Net.Sockets; 
using System.Text;
using System.Threading; 
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class MainForm : Form
    {
        TcpListener listener;
        TcpClient client;
        string ip = "";
        string port = "";
        int index = 0;


        public MainForm()
        {
            InitializeComponent();
            Dictionary<string, string> ipAddressDict = GetAllIPAddresses();

            foreach (KeyValuePair<string, string> pair in ipAddressDict)
            {
                string ipAddress = pair.Key;
                cbIp.Items.Add(ipAddress);
            }
        }


        // ip주소와 인터페이스명 가져오기
        private Dictionary<string, string> GetAllIPAddresses()
        {
            Dictionary<string, string> ipAddressDict = new Dictionary<string, string>();

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    foreach (UnicastIPAddressInformation address in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            string ipAddress = address.Address.ToString();
                            string interfaceName = networkInterface.Name;
                            ipAddressDict[ipAddress] = interfaceName;
                        }
                    }
                }
            }
            return ipAddressDict;
        }


        private void connect_btn_Click(object sender, EventArgs e)
        {
            ip = cbIp.SelectedItem.ToString();
            port = tb_port.Text;

            if (string.IsNullOrEmpty(ip) || ip.Split('.').Length != 4 || string.IsNullOrEmpty(port))
            {
                ip = "";
                port = "";
                return;
            }

            Thread connectThread = new Thread(new ThreadStart(Connect));
            connectThread.IsBackground = true;
            connectThread.Start();
        }


        private void Connect()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(ip), int.Parse(port));
                listener.Start();

                Invoke((Action)(() =>
                {
                    lbStatus.Text = "연결중...";
                }));

                while (true)
                {
                    client = listener.AcceptTcpClient();
                    ClientHandler.AddClient(client);

                    Invoke((Action)(() =>
                    {
                        lbStatus.Text = "연결됨";
                        lbStatus.BackColor = Color.Green;
                    }));

                    Thread receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.ToString());
            }
        }


        private void Receive()
        {
            while (true)
            {
                if (client != null && client.Connected)
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
                        WriteLog(" [주문] " + index + "번 " + message);
                        // 클라이언트로 받은 주문 출력 로직
                        index++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }


        public static class ClientHandler
        {
            private static List<TcpClient> clients = new List<TcpClient>();

            public static void AddClient(TcpClient client)
            {
                lock (clients)
                {
                    clients.Add(client);
                }
            }

            public static void CloseAllClients()
            {
                lock (clients)
                {
                    foreach (TcpClient client in clients)
                    {
                        try
                        {
                            client.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    clients.Clear();
                }
            }

            public static void SendMessageToAll(string message)
            {
                lock (clients)
                {
                    foreach (TcpClient client in clients)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            byte[] buffer = Encoding.UTF8.GetBytes(message);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }


        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            if (listener != null)
            {
                listener.Stop();
                lbStatus.Text = "서버 닫힘";
                lbStatus.BackColor = Color.Orange;
            }
            ClientHandler.SendMessageToAll("out");
            ClientHandler.CloseAllClients();
        }


        private void Disconnect()
        {
            if (listener != null)
            {
                listener.Stop();
                lbStatus.Text = "서버 닫힘";
                lbStatus.BackColor = Color.Orange;
            }
            ClientHandler.SendMessageToAll("out");
            ClientHandler.CloseAllClients();
        }


        private void WriteLog(string text)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lvOrder.Items.Add(date + " / " + text + "\r\n");
            lbOrder.Text = lvOrder.Items.Count.ToString();
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvIng.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvIng.SelectedItems[0];
                lvIng.Items.Remove(selectedItem);
                lbIng.Text = lvIng.Items.Count.ToString();

                lvComplete.Items.Add(selectedItem);
                selectedItem.BackColor = Color.LightYellow;
            }
        }


        private void btnIng_Click(object sender, EventArgs e)
        {
            if (lvOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvOrder.SelectedItems[0];
                lvOrder.Items.Remove(selectedItem);
                lbOrder.Text = lvOrder.Items.Count.ToString();

                lvIng.Items.Add(selectedItem);
                selectedItem.BackColor = Color.LightYellow;
                lbIng.Text = lvIng.Items.Count.ToString();

                string message = selectedItem.Text + "[조리중...]";
                int index = message.IndexOf('/');
                if (index >= 0)
                    message = message.Substring(index + 1).Trim();

                ClientHandler.SendMessageToAll(message);
            }
        }


        private void btnPass_Click(object sender, EventArgs e)
        {
            if (lvComplete.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvComplete.SelectedItems[0];
                lvComplete.Items.Remove(selectedItem);

                string message = selectedItem.Text + "[조리 완료!]";
                int index = message.IndexOf('/');
                if (index >= 0)
                    message = message.Substring(index + 1).Trim();

                ClientHandler.SendMessageToAll(message);
            }
        }
    }
}
