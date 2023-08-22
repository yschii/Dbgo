using System;
using System.Drawing; // 이미지 관련
using System.IO; // 경로나 디렉터리 관련
using System.IO.Ports; // 시리얼 포트 관련
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
// 솔루션의 Nuget 패키지를 통해 설치 사용. 

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace projectKiosk
{
    public partial class kioskkkk : Form
    {
        string currentDirectory = Environment.CurrentDirectory;
        // 현재 파일 경로 값 사용 위함

        // Arduino와의 시리얼 통신에 사용할 포트 이름
        string portName = "COM6";  
        SerialPort serialPort;
        // 시리얼 포트 객체 선언
        private string receivedData;
        // 받는 데이터 객체 선언

        // mysql 사용 법.
        string _server = "mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com"; 
        //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3306; //DB 서버 포트
        string _database = "test"; //DB 이름
        string _id = "esoog"; //계정 아이디
        string _pw = ""; //계정 비밀번호
        string _connectionAddress = "";

        // 카드 결제 로직 구현 목적 변수
        int point = 0;
        int totalPrice = 0;
        int updatedPoint = 0;
        private bool isFirstDataReceived = false;
        // RFID 인식 관련 쓰레드 잡을 변수 설정

        // TCP 통신 위한 아이피 및 클라이언트 객체 선언
        private static string ip = string.Empty;
        private static string port = string.Empty;
        private static TcpClient client = new TcpClient();
        StringBuilder sb = new StringBuilder();
        // 송수신에 쓸 문자열 관리하기 위한 객체.


        public kioskkkk()
        {
            InitializeComponent();

            // 시리얼 포트 초기화 및 열기
            serialPort = new SerialPort(portName, 9600);
            serialPort.Open();

            // 데이터베이스 연결
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ip = tbIp.Text;
            port = tbPort.Text;
            if (ip.Split('.').Length != 4 || port == "")
            // or 값으로 flase면 빈값으로 반환(예외처리)
            {
                tbIp.Text = string.Empty;
                tbPort.Text = string.Empty;
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
            Invoke((Action)(() =>
            {
                lbInIng.Text = "연결중...";
            }));

            try
            {
                client.Connect(endPoint);
                // 커넥트
                Invoke((Action)(() =>
                {
                    pnIp.Visible = false;
                    Thread receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }));
            }
            catch (SocketException se)
            {
                lbInIng.Text = se.Message;
            }
        }

        private void btnBg_Click(object sender, EventArgs e)
        {   
            pb1.Visible = false;
            lvAll.Visible = true;
            lvAll.Clear();

            string directoryPath = Path.Combine(currentDirectory, "Screenshots");
            ImageList imageList = new ImageList();
            // 이미지 리스트를 담을 수 있는 객체 생성
            imageList.ImageSize = new Size(200, 200);
            string[] imageFiles = Directory.GetFiles(directoryPath, "burger*.*");
            // 이미지파일 경로 담을 객체 생성. 디렉토리 경로의 "이름"을 가진~

            foreach (string filePath in imageFiles)
            {
                Image image = Image.FromFile(filePath);
                imageList.Images.Add(image); // 이미지 추가할 때 이미지 인덱스 생략
            }

            lvAll.LargeImageList = imageList;

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageFiles[i]);
                ListViewItem item = new ListViewItem(fileName, i); // 이미지 인덱스를 i로 설정
                lvAll.Items.Add(item);
            }
        }

        private void btnSd_Click(object sender, EventArgs e)
        {
            pb1.Visible = false;
            lvAll.Visible = true;
            lvAll.Clear();

            string directoryPath = Path.Combine(currentDirectory, "Screenshots");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(200, 200);
            string[] imageFiles = Directory.GetFiles(directoryPath, "side*.*");

            foreach (string filePath in imageFiles)
            {
                Image image = Image.FromFile(filePath);
                imageList.Images.Add(image); // 이미지 추가할 때 이미지 인덱스 생략
            }

            lvAll.LargeImageList = imageList;

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageFiles[i]);
                ListViewItem item = new ListViewItem(fileName, i); // 이미지 인덱스를 i로 설정
                lvAll.Items.Add(item);
            }
        }

        private void btnDr_Click(object sender, EventArgs e)
        {
            pb1.Visible = false;
            lvAll.Visible = true;
            lvAll.Clear();

            string directoryPath = Path.Combine(currentDirectory, "Screenshots");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(200, 200);
            string[] imageFiles = Directory.GetFiles(directoryPath, "drink*.*");

            foreach (string filePath in imageFiles)
            {
                Image image = Image.FromFile(filePath);
                imageList.Images.Add(image); // 이미지 추가할 때 이미지 인덱스 생략
            }

            lvAll.LargeImageList = imageList;

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageFiles[i]);
                ListViewItem item = new ListViewItem(fileName, i); // 이미지 인덱스를 i로 설정
                lvAll.Items.Add(item);
            }
        }

        private void lvAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAll.SelectedItems.Count > 0)
            {
                string selectedName = Path.GetFileNameWithoutExtension(lvAll.SelectedItems[0].Text);

                if (selectedName == "burger1")
                {
                    // 이름1에 대한 동작 설정
                    lbName.Text = selectedName;
                    lbPrice.Text = "50";
                }
                else if (selectedName == "side1")
                {
                    // 이름2에 대한 동작 설정
                    lbName.Text = selectedName;
                    lbPrice.Text = "30";
                }
                else
                {
                    // 기본 동작 설정
                    lbName.Text = selectedName;
                    lbPrice.Text = "1";
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (lvAll.SelectedItems.Count == 0)
            {
                MessageBox.Show("항목을 선택해주세요.");
                return;
            }

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 30); // 이미지 크기를 200x200으로 설정
            lvCustom.LargeImageList = imageList;

            string itemName = lbName.Text;
            int itemPrice = int.Parse(lbPrice.Text);

            ListViewItem item = new ListViewItem(itemName + "  " + itemPrice.ToString());
            lvCustom.Items.Add(item);
            lbMenu.Text = lvCustom.Items.Count.ToString();

            totals();
            // 토탈 가격
        }

        private void totals()
        {
            int totalPrice = 0;
            foreach (ListViewItem listItem in lvCustom.Items)
            {
                string[] priceParts = listItem.Text.Split(' ');
                if (priceParts.Length > 1)
                {
                    int price = int.Parse(priceParts[priceParts.Length - 1]);
                    totalPrice += price;
                }
            }
            lbAllPrice.Text = totalPrice.ToString() + " 원";
            lbMenu.Text = lvCustom.Items.Count.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvCustom.SelectedItems.Count == 0)
            {
                MessageBox.Show("항목을 선택해주세요.");
                return;
            }

            // 선택된 항목이 있는 경우에만 제거
            ListViewItem selectedItem = lvCustom.SelectedItems[0];
            lvCustom.Items.Remove(selectedItem);
            // 제거된 메뉴에 해당하는 가격을 토탈 가격에서 차감
            
            totals();
        }

        private void sbString()
        {
            foreach (ListViewItem item in lvCustom.Items)
            {
                sb.Append(item.Text + " ");
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (lvCustom.Items.Count == 0)
            {
                MessageBox.Show("항목을 선택해주세요.");
                return;
            }

            DialogResult result = MessageBox.Show("결제 금액: " + lbAllPrice.Text + "\n금액이 맞으면 확인을 눌러주세요.", "결제 요청", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                isFirstDataReceived = true;
                pb2.Visible = true;
                serialPort.DataReceived += SerialPort_DataReceived;
            }
            else
            {
                // 취소 버튼이 눌렸을 때 목록 초기화
                lvCustom.Items.Clear();
                lvAll.Items.Clear();
                lbAllPrice.Text = "";
                lbMenu.Text = "";
                lbPrice.Text = "";
                lbName.Text = "";
                pb1.Visible = true;
            }
        }

        private async void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            receivedData = serialPort.ReadLine().ToString().Trim();
            // 첫 번째 데이터 수신 이벤트만 처리하고 나머지는 무시

            if (isFirstDataReceived)
            {
                selectTable();
                updateTable();
                // db업데이트
                MessageBox.Show("결제 완료: 카드ID -- " + receivedData + " \n" + lbAllPrice.Text + " 결제가 완료 되었습니다.");

                Invoke((Action)(() =>
                // 쓰레드 처리
                {
                    if (client != null)
                    {
                        sbString();
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = Encoding.UTF8.GetBytes(" " + sb.ToString());
                        stream.Write(buffer, 0, buffer.Length);
                        sb.Clear(); // sb 객체 초기화
                    }
                    lvCustom.Items.Clear();
                    lvAll.Items.Clear();
                    lbAllPrice.Text = "";
                    lbMenu.Text = "";
                    lbPrice.Text = "";
                    lbName.Text = "";
                    pb1.Visible = true;
                    pb2.Visible= false;
                }));
                isFirstDataReceived = false;
            }
        }

        private void selectTable()
            // mysql 관리
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string selectQuery = $"SELECT * FROM member WHERE nuid = '{receivedData}'";
                    MySqlCommand command = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        point = int.Parse(reader["point"].ToString());
                        totalPrice = int.Parse(lbAllPrice.Text.Replace(" 원", ""));
                        updatedPoint = point - totalPrice;
                    }
                    reader.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void updateTable()
        {
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();

                    string updateQuery = $"UPDATE member SET point = '{updatedPoint}' WHERE nuid = '{receivedData}'";
                    MySqlCommand command2 = new MySqlCommand(updateQuery, mysql);
                    command2.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
            // 초기화 버튼
        {
            lvCustom.Items.Clear();
            lvAll.Items.Clear();
            lbAllPrice.Text = "";
            lbMenu.Text = "";
            lbPrice.Text = "";
            lbName.Text = "";
            pb1.Visible = true;
            pb2.Visible = false;
            isFirstDataReceived = false;
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
                        if (message.Equals("out"))
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
    }
}
