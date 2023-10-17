namespace Server
{
    partial class MainForm
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
            this.tb_port = new System.Windows.Forms.TextBox();
            this.btnCon = new System.Windows.Forms.Button();
            this.lbIP = new System.Windows.Forms.Label();
            this.btnDiscon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbIp = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.lvOrder = new System.Windows.Forms.ListView();
            this.btnIng = new System.Windows.Forms.Button();
            this.lvIng = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbIng = new System.Windows.Forms.Label();
            this.btnPass = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lvComplete = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_port
            // 
            this.tb_port.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_port.Location = new System.Drawing.Point(368, 42);
            this.tb_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(102, 26);
            this.tb_port.TabIndex = 0;
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(508, 16);
            this.btnCon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(88, 51);
            this.btnCon.TabIndex = 1;
            this.btnCon.Text = "서버 Open";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(80, 23);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(40, 12);
            this.lbIP.TabIndex = 4;
            this.lbIP.Text = "IP주소";
            // 
            // btnDiscon
            // 
            this.btnDiscon.Location = new System.Drawing.Point(861, 16);
            this.btnDiscon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDiscon.Name = "btnDiscon";
            this.btnDiscon.Size = new System.Drawing.Size(88, 51);
            this.btnDiscon.TabIndex = 1;
            this.btnDiscon.Text = "연결끊기";
            this.btnDiscon.UseVisualStyleBackColor = true;
            this.btnDiscon.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "포트(지정)";
            // 
            // cbIp
            // 
            this.cbIp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbIp.FormattingEnabled = true;
            this.cbIp.Location = new System.Drawing.Point(82, 43);
            this.cbIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIp.Name = "cbIp";
            this.cbIp.Size = new System.Drawing.Size(247, 24);
            this.cbIp.TabIndex = 6;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(602, 365);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(88, 50);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "조리 완료";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lvOrder
            // 
            this.lvOrder.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(82, 102);
            this.lvOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(514, 165);
            this.lvOrder.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvOrder.TabIndex = 8;
            this.lvOrder.TileSize = new System.Drawing.Size(500, 50);
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Tile;
            // 
            // btnIng
            // 
            this.btnIng.Location = new System.Drawing.Point(602, 102);
            this.btnIng.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIng.Name = "btnIng";
            this.btnIng.Size = new System.Drawing.Size(88, 50);
            this.btnIng.TabIndex = 7;
            this.btnIng.Text = "조리 진행";
            this.btnIng.UseVisualStyleBackColor = true;
            this.btnIng.Click += new System.EventHandler(this.btnIng_Click);
            // 
            // lvIng
            // 
            this.lvIng.HideSelection = false;
            this.lvIng.Location = new System.Drawing.Point(700, 103);
            this.lvIng.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvIng.Name = "lvIng";
            this.lvIng.Size = new System.Drawing.Size(249, 312);
            this.lvIng.TabIndex = 9;
            this.lvIng.TileSize = new System.Drawing.Size(200, 30);
            this.lvIng.UseCompatibleStateImageBehavior = false;
            this.lvIng.View = System.Windows.Forms.View.Tile;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(697, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "조리중...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(806, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "건";
            // 
            // lbIng
            // 
            this.lbIng.AutoSize = true;
            this.lbIng.Location = new System.Drawing.Point(790, 89);
            this.lbIng.Name = "lbIng";
            this.lbIng.Size = new System.Drawing.Size(0, 12);
            this.lbIng.TabIndex = 12;
            // 
            // btnPass
            // 
            this.btnPass.Location = new System.Drawing.Point(82, 364);
            this.btnPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(88, 50);
            this.btnPass.TabIndex = 7;
            this.btnPass.Text = "고객 호출";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "주문";
            // 
            // lvComplete
            // 
            this.lvComplete.HideSelection = false;
            this.lvComplete.Location = new System.Drawing.Point(175, 365);
            this.lvComplete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvComplete.Name = "lvComplete";
            this.lvComplete.Size = new System.Drawing.Size(420, 50);
            this.lvComplete.TabIndex = 13;
            this.lvComplete.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "건";
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Location = new System.Drawing.Point(142, 87);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(0, 12);
            this.lbOrder.TabIndex = 12;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStatus.Location = new System.Drawing.Point(601, 36);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 16);
            this.lbStatus.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 428);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lvComplete);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.lbIng);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvIng);
            this.Controls.Add(this.lvOrder);
            this.Controls.Add(this.btnIng);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.cbIp);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDiscon);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.tb_port);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Button btnDiscon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbIp;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.Button btnIng;
        private System.Windows.Forms.ListView lvIng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbIng;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvComplete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOrder;
        private System.Windows.Forms.Label lbStatus;
    }
}

