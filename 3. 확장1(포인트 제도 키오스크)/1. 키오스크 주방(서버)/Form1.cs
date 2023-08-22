using System;
using System.Collections.Generic;
using System.Diagnostics; // 디버깅 네임스페이스
using System.Drawing; // 칼라 등 사용 네임스페이스
using System.Net; // 네트워크 관련 네임스페이스
using System.Net.NetworkInformation; // 네트워크 정보 추출 네임스페이스
using System.Net.Sockets; // TCP 등 소켓 통신 관련
using System.Text;
using System.Threading; // Thread 사용
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static TcpListener listener;
        private static TcpClient client;
        // TCP 통신 리스너(서버용), 클라이언트 변수 선언
        private static string ip = string.Empty;
        private static string port = string.Empty;
        int index = 0;
        // 변수 초기화


        public Form1()
        {
            InitializeComponent();

            Dictionary<string, string> ipAddressDict = GetAllIPAddresses();
            // 제네릭 형태의 딕셔너리 사용해서 IPAddress 모으기
            
            foreach (KeyValuePair<string, string> pair in ipAddressDict)
            {
                string ipAddress = pair.Key;
                cbIp.Items.Add(ipAddress);
                // 콤보 박스에 정렬
            }
        }


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
                            // 네트워크 주소와 인터페이스 이름 구현 함수
                            ipAddressDict[ipAddress] = interfaceName;
                        }
                    }
                }
            }
            return ipAddressDict;
        }


        private string GetInterfaceName(string ipAddress)
            // IP주소의 인터페이스 이름을 추출하는 함수
        {
            Dictionary<string, string> ipAddressDict = GetAllIPAddresses();
            if (ipAddressDict.ContainsKey(ipAddress))
            {
                return ipAddressDict[ipAddress];
            }
            return string.Empty;
        }


        private void cbIp_SelectedIndexChanged(object sender, EventArgs e)
            // 콤보박스 인덱스값 변경되면,
        {
            string selectedIp = cbIp.SelectedItem.ToString();
            string interfaceName = GetInterfaceName(selectedIp);
            lbIP.Text = interfaceName;
            // 라벨에 IP주소 이름 표시
        }


        private void connect_btn_Click(object sender, EventArgs e)
        {
            ip = cbIp.SelectedItem?.ToString();
            port = tb_port.Text;

            if (string.IsNullOrEmpty(ip) || ip.Split('.').Length != 4 || string.IsNullOrEmpty(port))
            {
                ip = string.Empty;
                port = string.Empty;
                return;
            }

            // 스레드 사용법
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
                    // 수락된 리스너를 클라이언트로 대입
                    ClientHandler.AddClient(client);
                    // 클라이언트 핸들러에 추가(다중접속)
                    Invoke((Action)(() =>
                    {
                        lbStatus.Text = "연결됨";
                        lbStatus.BackColor = Color.Green;
                    }));

                    Thread receiveThread = new Thread(new ThreadStart(() => Receive()));
                    // 새로운 쓰레드로 통신 시작
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
                        Debug.WriteLine(ex.ToString());
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
                            Debug.WriteLine(ex.ToString());
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
                            Debug.WriteLine(ex.ToString());
                            // 클라이언트가 연결이 끊겼을 때 처리
                        }
                    }
                }
            }
        }

        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            Disconnect();
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
            lvOrder.Items.Add(date +" / "+ text + "\r\n");
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
