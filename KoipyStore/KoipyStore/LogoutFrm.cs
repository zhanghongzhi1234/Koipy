using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace KoipyStore
{
    public partial class LogoutFrm : TouchForm
    {
        WaitFrm m_waitFrm;
        FullKeyboardFrm m_keyboardFrm;

        public LogoutFrm()
        {
            InitializeComponent();
        }

        private void LogoutFrm_Load(object sender, EventArgs e)
        {
            m_keyboardFrm = new FullKeyboardFrm();
            m_keyboardFrm.setParentForm(this);
            m_keyboardFrm.Hide();
            Reload();
        }

        public void Reload()
        {
            this.Text = Program._L("Koipy");
            lblPassword.Text = Program._L("Password") + ":";
            txtPassword.Text = "";
            btnSummit.Text = Program._L("Logout") + "(&L)";
            btnClose.Text = Program._L("Cancel") + "(&C)";
        }

        private void btnSummit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        public override void Submit()
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show(Program._L("Please enter your password") + "!");
                m_keyboardFrm.Location = txtPassword.PointToScreen(new Point(-272, 45));
                m_keyboardFrm.Show();
                m_keyboardFrm.BringToFront();
                m_keyboardFrm.setTxtBox(txtPassword);
                return;
            }
            m_waitFrm = new WaitFrm();  //每次必须new，创建新的线程，因为CloseWait后就会终止线程
            m_waitFrm.ShowWait();
            string url = Program.urlroot + "/store/api/login/?loginname=" + Program.store_user
                + "&loginpassword=" + txtPassword.Text.Trim()
                + "&language=" + Program.lang;
            string response = KoipyAPIHelper.Instance.getAPI(url);
            m_waitFrm.CloseWait();
            if (response == "")
            {
                this.Activate();    //因为waitingFrm在另外一个线程也是topmost属性，所以必须先Activate，否则messagebox会弹在后面
                Program.log.Error("Logout Failed, username=" + Program.store_user);
                string message = Program._L("Cannot connect to Koipy server") + "!";
                string caption = Program._L("Koipy");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
            else
            {   //Parse json string
                JObject o = (JObject)JsonConvert.DeserializeObject(response);
                if (o["status"].ToString() == "-2")
                {
                    this.Activate();
                    string message = Program._L("Wrong password") + "!";
                    string caption = Program._L("Koipy");
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, buttons, icon);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LogoutFrm_MouseClick(object sender, MouseEventArgs e)
        {
            bool isInPassword = e.X > txtPassword.Location.X
                && e.Y > txtPassword.Location.Y
                && e.X < txtPassword.Location.X + txtPassword.Width
                && e.Y < txtPassword.Location.Y + txtPassword.Height;
            if (!isInPassword)
            {
                m_keyboardFrm.Hide();
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(-272, 45));
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            m_keyboardFrm.Hide();
        }
    }
}
