﻿namespace Display
{
    partial class Notes
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
            this.button1 = new System.Windows.Forms.Button();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lba = new System.Windows.Forms.Label();
            this.pn1 = new System.Windows.Forms.Panel();
            this.btnDicon = new System.Windows.Forms.Button();
            this.pn1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "연결";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(95, 11);
            this.tb_ip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(157, 21);
            this.tb_ip.TabIndex = 1;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(343, 11);
            this.tb_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(157, 21);
            this.tb_port.TabIndex = 1;
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(34, 84);
            this.tb_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(621, 232);
            this.tb_log.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "서버ip";
            // 
            // lba
            // 
            this.lba.AutoSize = true;
            this.lba.Location = new System.Drawing.Point(283, 19);
            this.lba.Name = "lba";
            this.lba.Size = new System.Drawing.Size(50, 12);
            this.lba.TabIndex = 3;
            this.lba.Text = "연결port";
            // 
            // pn1
            // 
            this.pn1.Controls.Add(this.lba);
            this.pn1.Controls.Add(this.label1);
            this.pn1.Controls.Add(this.tb_log);
            this.pn1.Controls.Add(this.tb_port);
            this.pn1.Controls.Add(this.tb_ip);
            this.pn1.Controls.Add(this.button1);
            this.pn1.Controls.Add(this.btnDicon);
            this.pn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn1.Location = new System.Drawing.Point(0, 0);
            this.pn1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pn1.Name = "pn1";
            this.pn1.Size = new System.Drawing.Size(700, 360);
            this.pn1.TabIndex = 4;
            // 
            // btnDicon
            // 
            this.btnDicon.Location = new System.Drawing.Point(575, 11);
            this.btnDicon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDicon.Name = "btnDicon";
            this.btnDicon.Size = new System.Drawing.Size(66, 62);
            this.btnDicon.TabIndex = 0;
            this.btnDicon.Text = "연결끊기";
            this.btnDicon.UseVisualStyleBackColor = true;
            this.btnDicon.Click += new System.EventHandler(this.btnDicon_Click);
            // 
            // Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.pn1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Notes";
            this.Text = "Form1";
            this.pn1.ResumeLayout(false);
            this.pn1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lba;
        private System.Windows.Forms.Panel pn1;
        private System.Windows.Forms.Button btnDicon;
    }
}

