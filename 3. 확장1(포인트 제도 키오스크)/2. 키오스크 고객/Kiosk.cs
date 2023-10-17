using System;
using System.Drawing;
using System.IO; 
using System.IO.Ports; 
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Customer
{
    public partial class Kiosk : Form
    {
        SerialPort serialPort;
        TcpClient client = new TcpClient();
        StringBuilder sb = new StringBuilder();

        string receivedData;
        bool isFirstDataReceived = false;
        string ip = "";
        string port = "";
        string _connectionAddress = "";
        int point = 0;
        int totalPrice = 0;
        int updatedPoint = 0;


        public Kiosk()
        {
            InitializeComponent();

            serialPort = new SerialPort(MainClass.portName, 9600);
            serialPort.Open();

            _connectionAddress = string.Format(
                "Server={0};Port={1};Database={2};Uid={3};Pwd={4}", 
                MainClass.server, MainClass.port, MainClass.database, MainClass.id, MainClass.pw);
        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            ip = tbIp.Text;
            port = tbPort.Text;
            if (string.IsNullOrEmpty(ip) || ip.Split('.').Length != 4 || string.IsNullOrEmpty(port))
            {
                tbIp.Text = "";
                tbPort.Text = "";
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
                lbInIng.Text = "연결중...";
            }));

            try
            {
                client.Connect(endPoint);

                Invoke((Action)(() =>
                {
                    pnIp.Visible = false;
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


        private void btnBg_Click(object sender, EventArgs e)
        {   
            pb1.Visible = false;
            lvAll.Visible = true;
            lvAll.Clear();

            string directoryPath = Path.Combine(MainClass.screenDirectory, "Screenshots");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(200, 200);
            string[] imageFiles = Directory.GetFiles(directoryPath, "burger*.*");

            foreach (string filePath in imageFiles)
            {
                Image image = Image.FromFile(filePath);
                imageList.Images.Add(image); 
            }

            lvAll.LargeImageList = imageList;

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageFiles[i]);
                ListViewItem item = new ListViewItem(fileName, i); 
                lvAll.Items.Add(item);
            }
        }


        private void btnSd_Click(object sender, EventArgs e)
        {
            pb1.Visible = false;
            lvAll.Visible = true;
            lvAll.Clear();

            string directoryPath = Path.Combine(MainClass.screenDirectory, "Screenshots");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(200, 200);
            string[] imageFiles = Directory.GetFiles(directoryPath, "side*.*");

            foreach (string filePath in imageFiles)
            {
                Image image = Image.FromFile(filePath);
                imageList.Images.Add(image);
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

            string directoryPath = Path.Combine(MainClass.screenDirectory, "Screenshots");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(200, 200);
            string[] imageFiles = Directory.GetFiles(directoryPath, "drink*.*");

            foreach (string filePath in imageFiles)
            {
                Image image = Image.FromFile(filePath);
                imageList.Images.Add(image); 
            }

            lvAll.LargeImageList = imageList;

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageFiles[i]);
                ListViewItem item = new ListViewItem(fileName, i); 
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
                    lbName.Text = selectedName;
                    lbPrice.Text = "50";
                }
                else if (selectedName == "side1")
                {
                    lbName.Text = selectedName;
                    lbPrice.Text = "30";
                }
                else
                {
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
            imageList.ImageSize = new Size(50, 30); 
            lvCustom.LargeImageList = imageList;

            string itemName = lbName.Text;
            int itemPrice = int.Parse(lbPrice.Text);

            ListViewItem item = new ListViewItem(itemName + "  " + itemPrice.ToString());
            lvCustom.Items.Add(item);
            lbMenu.Text = lvCustom.Items.Count.ToString();

            totals();

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

            ListViewItem selectedItem = lvCustom.SelectedItems[0];
            lvCustom.Items.Remove(selectedItem);
            
            totals();
        }


        private void sbString()
        {
            foreach (ListViewItem item in lvCustom.Items)
            {
                sb.Append(item.Text + " ");
            }
        }


        private void btnPay_Click(object sender, EventArgs e)
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
                lvCustom.Items.Clear();
                lvAll.Items.Clear();
                lbAllPrice.Text = "";
                lbMenu.Text = "";
                lbPrice.Text = "";
                lbName.Text = "";
                pb1.Visible = true;
            }
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            receivedData = serialPort.ReadLine().ToString().Trim();

            if (isFirstDataReceived)
            {
                selectTable();
                updateTable();

                MessageBox.Show("결제 완료: 카드ID -- " + receivedData + " \n" + lbAllPrice.Text + " 결제가 완료 되었습니다.");

                Invoke((Action)(() =>
                {
                    if (client != null)
                    {
                        sbString();
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = Encoding.UTF8.GetBytes(" " + sb.ToString());
                        stream.Write(buffer, 0, buffer.Length);
                        sb.Clear();
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


        private void Invoking()
        {
            Invoke((Action)(() =>
            {
                client.Close();
                MessageBox.Show("서버와 연결이 끊어졌습니다.");
                Application.Exit();
            }));
        }
    }
}
