using Display;
using Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            Form frm;
            this.button1.Click += ((ss, ee) =>
            {
                frm = new MainForm();
                button_Click(ss, ee, frm);
            });
            this.button2.Click += ((ss, ee) =>
            {
                frm = new Kiosk();
                button_Click(ss, ee, frm);
            });
            this.button3.Click += ((ss, ee) =>
            {
                frm = new Notes();
                button_Click(ss, ee, frm);
            });
        }

        private void button_Click(object sender, EventArgs e, Form frm)
        {
            frm.Show();
            frm.FormClosed += formClosed;
            this.Hide();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
