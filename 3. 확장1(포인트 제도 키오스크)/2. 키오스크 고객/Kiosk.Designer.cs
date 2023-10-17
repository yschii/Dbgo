namespace Customer
{
    partial class Kiosk
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kiosk));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAllPrice = new System.Windows.Forms.Label();
            this.lbMenu = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvCustom = new System.Windows.Forms.ListView();
            this.btnPay = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDr = new System.Windows.Forms.Button();
            this.btnSd = new System.Windows.Forms.Button();
            this.btnBg = new System.Windows.Forms.Button();
            this.pnBg = new System.Windows.Forms.Panel();
            this.btnInit = new System.Windows.Forms.Button();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lvAll = new System.Windows.Forms.ListView();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.lbInIng = new System.Windows.Forms.Label();
            this.pnIp = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnBg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.pnIp.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAllPrice);
            this.groupBox1.Controls.Add(this.lbMenu);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lvCustom);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(952, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "장바구니 목록";
            // 
            // lbAllPrice
            // 
            this.lbAllPrice.AutoSize = true;
            this.lbAllPrice.Location = new System.Drawing.Point(867, 63);
            this.lbAllPrice.Name = "lbAllPrice";
            this.lbAllPrice.Size = new System.Drawing.Size(0, 12);
            this.lbAllPrice.TabIndex = 3;
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Location = new System.Drawing.Point(867, 30);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(0, 12);
            this.lbMenu.TabIndex = 3;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(705, 24);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(74, 56);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "빼기";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(788, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "총액 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(788, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "메뉴 수 : ";
            // 
            // lvCustom
            // 
            this.lvCustom.HideSelection = false;
            this.lvCustom.Location = new System.Drawing.Point(12, 19);
            this.lvCustom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvCustom.Name = "lvCustom";
            this.lvCustom.Size = new System.Drawing.Size(684, 71);
            this.lvCustom.TabIndex = 0;
            this.lvCustom.UseCompatibleStateImageBehavior = false;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Black;
            this.btnPay.ForeColor = System.Drawing.Color.Yellow;
            this.btnPay.Location = new System.Drawing.Point(640, 312);
            this.btnPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(73, 51);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "결제";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDr);
            this.groupBox3.Controls.Add(this.btnSd);
            this.groupBox3.Controls.Add(this.btnBg);
            this.groupBox3.Location = new System.Drawing.Point(10, 118);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(125, 374);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "메뉴";
            // 
            // btnDr
            // 
            this.btnDr.Location = new System.Drawing.Point(16, 72);
            this.btnDr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDr.Name = "btnDr";
            this.btnDr.Size = new System.Drawing.Size(89, 22);
            this.btnDr.TabIndex = 0;
            this.btnDr.Text = "Drink";
            this.btnDr.UseVisualStyleBackColor = true;
            this.btnDr.Click += new System.EventHandler(this.btnDr_Click);
            // 
            // btnSd
            // 
            this.btnSd.Location = new System.Drawing.Point(16, 46);
            this.btnSd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSd.Name = "btnSd";
            this.btnSd.Size = new System.Drawing.Size(89, 22);
            this.btnSd.TabIndex = 0;
            this.btnSd.Text = "Side";
            this.btnSd.UseVisualStyleBackColor = true;
            this.btnSd.Click += new System.EventHandler(this.btnSd_Click);
            // 
            // btnBg
            // 
            this.btnBg.Location = new System.Drawing.Point(16, 19);
            this.btnBg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBg.Name = "btnBg";
            this.btnBg.Size = new System.Drawing.Size(89, 22);
            this.btnBg.TabIndex = 0;
            this.btnBg.Text = "Burger";
            this.btnBg.UseVisualStyleBackColor = true;
            this.btnBg.Click += new System.EventHandler(this.btnBg_Click);
            // 
            // pnBg
            // 
            this.pnBg.Controls.Add(this.btnInit);
            this.pnBg.Controls.Add(this.pb2);
            this.pnBg.Controls.Add(this.pb1);
            this.pnBg.Controls.Add(this.btnPay);
            this.pnBg.Controls.Add(this.btnCheck);
            this.pnBg.Controls.Add(this.label2);
            this.pnBg.Controls.Add(this.label1);
            this.pnBg.Controls.Add(this.lbPrice);
            this.pnBg.Controls.Add(this.lbName);
            this.pnBg.Controls.Add(this.lvAll);
            this.pnBg.Location = new System.Drawing.Point(149, 125);
            this.pnBg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnBg.Name = "pnBg";
            this.pnBg.Size = new System.Drawing.Size(814, 368);
            this.pnBg.TabIndex = 2;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(718, 312);
            this.btnInit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(74, 51);
            this.btnInit.TabIndex = 5;
            this.btnInit.Text = "처음으로";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // pb2
            // 
            this.pb2.Image = ((System.Drawing.Image)(resources.GetObject("pb2.Image")));
            this.pb2.Location = new System.Drawing.Point(21, 17);
            this.pb2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(772, 290);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 3;
            this.pb2.TabStop = false;
            this.pb2.Visible = false;
            // 
            // pb1
            // 
            this.pb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb1.Image = ((System.Drawing.Image)(resources.GetObject("pb1.Image")));
            this.pb1.Location = new System.Drawing.Point(31, 26);
            this.pb1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(752, 273);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb1.TabIndex = 4;
            this.pb1.TabStop = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(457, 312);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(72, 51);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "담기";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "가격 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "상품명 : ";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(378, 333);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(0, 12);
            this.lbPrice.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(250, 333);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 12);
            this.lbName.TabIndex = 1;
            // 
            // lvAll
            // 
            this.lvAll.HideSelection = false;
            this.lvAll.Location = new System.Drawing.Point(21, 17);
            this.lvAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvAll.Name = "lvAll";
            this.lvAll.Size = new System.Drawing.Size(772, 291);
            this.lvAll.TabIndex = 0;
            this.lvAll.UseCompatibleStateImageBehavior = false;
            this.lvAll.Visible = false;
            this.lvAll.SelectedIndexChanged += new System.EventHandler(this.lvAll_SelectedIndexChanged);
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(289, 270);
            this.tbIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(202, 21);
            this.tbIp.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "포트";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(564, 270);
            this.tbPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(78, 21);
            this.tbPort.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "서버IP";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(664, 272);
            this.btnIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(64, 18);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "접속";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lbInIng
            // 
            this.lbInIng.AutoSize = true;
            this.lbInIng.Location = new System.Drawing.Point(733, 275);
            this.lbInIng.Name = "lbInIng";
            this.lbInIng.Size = new System.Drawing.Size(0, 12);
            this.lbInIng.TabIndex = 3;
            // 
            // pnIp
            // 
            this.pnIp.BackColor = System.Drawing.Color.Yellow;
            this.pnIp.Controls.Add(this.lbInIng);
            this.pnIp.Controls.Add(this.btnIn);
            this.pnIp.Controls.Add(this.label5);
            this.pnIp.Controls.Add(this.tbPort);
            this.pnIp.Controls.Add(this.label6);
            this.pnIp.Controls.Add(this.tbIp);
            this.pnIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnIp.Location = new System.Drawing.Point(0, 0);
            this.pnIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnIp.Name = "pnIp";
            this.pnIp.Size = new System.Drawing.Size(973, 543);
            this.pnIp.TabIndex = 4;
            // 
            // Kiosk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 543);
            this.Controls.Add(this.pnIp);
            this.Controls.Add(this.pnBg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Kiosk";
            this.Text = "Kiosk";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.pnBg.ResumeLayout(false);
            this.pnBg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.pnIp.ResumeLayout(false);
            this.pnIp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnBg;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnDr;
        private System.Windows.Forms.Button btnSd;
        private System.Windows.Forms.Button btnBg;
        private System.Windows.Forms.ListView lvAll;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ListView lvCustom;
        private System.Windows.Forms.Label lbAllPrice;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label lbInIng;
        private System.Windows.Forms.Panel pnIp;
    }
}

