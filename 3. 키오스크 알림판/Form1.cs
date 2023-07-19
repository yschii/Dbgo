using System;
using System.Net; // ip주소 관련
using System.Net.Sockets; // 네트워크 소켓 통신 관련
using System.Text; // 텍스트 인코딩 관련
using System.Threading; // 스레드 관련
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private static string ip = string.Empty;
        private static string port = string.Empty;
        private static TcpClient client = new TcpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            ip = tb_ip.Text;
            port = tb_port.Text;

            if (ip.Split('.').Length != 4 || port == "")
                // ip주소를 .으로 나눈 파트가 4개?
                // or 값으로 flase면 빈값으로 반환(예외처리)
            {
                tb_ip.Text = string.Empty;
                tb_port.Text = string.Empty;
                return;
            }

            // 연결 누를 때 마다 클라이언트 객체 초기화
            client = new TcpClient();

            // 통과하면 커넥트 스레드 실행
            Thread connectThread = new Thread(new ThreadStart(Connect));
            connectThread.IsBackground = true;
            connectThread.Start();
        }

        private void Connect()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            // .Net의 엔드포인트 생성 클래스
            // ip주소의 유효값을 보장해준다.
            WriteLog("Connecting...");

            try
            {
                client.Connect(endPoint);
                // 클라이언트 연결
                WriteLog("Connected...");

                Invoke((Action)(() =>
                {
                    pnIp.Visible = false;
                    // 연결 되면 응답 받기 스레드 생성
                    Thread receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }));
            }
            catch (SocketException se)
            // 유효값 검증 시 에러 해결
            {
                WriteLog(se.Message);
            }
        }

        private void WriteLog(string text)
        {
            //string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Invoke((Action)(() =>
            // 윈폼 내부 멀티 크로스 스레드 문제 해결 위한 문법
            {
                tb_log.AppendText(text + "\r\n");
            }));
        }

        private void Invoking()
            // invoke 함수 사용 위해 커스텀
        {
            Invoke((Action)(() =>
            {
                client.Close();
                MessageBox.Show("서버와 연결이 끊어졌습니다.");
                Application.Exit();
                // 앱 종료
            }));
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
                            WriteLog(message);
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

        private void btnDicon_Click(object sender, EventArgs e)
        {
            client.Close();
        }
    }
}
