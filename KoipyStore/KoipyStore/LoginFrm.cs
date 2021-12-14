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
    public partial class LoginFrm : TouchForm
    {
        ProfileLoginFrm m_profileLoginFrm;
        WaitFrm m_waitFrm;
        FullKeyboardFrm m_keyboardFrm;
        bool m_bInputChanged = false;

        public LoginFrm()
        {
            InitializeComponent();
        }

        public LoginFrm(ProfileLoginFrm profileLoginFrm)
        {
            InitializeComponent();
            m_profileLoginFrm = profileLoginFrm;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            m_keyboardFrm = new FullKeyboardFrm();
            m_keyboardFrm.setParentForm(this);
            m_keyboardFrm.Hide();
            Reload();
        }

        public void Reload()
        {
            this.Text = Program._L("Koipy");
            lblUsername.Text = Program._L("Username") + ":";
            txtUsername.Text = Program._L("Plese enter username here") + "!";
            lblPassword.Text = Program._L("Password") + ":";
            txtPassword.Text = "";
            btnSummit.Text = Program._L("Login") + "(&L)";
            btnClose.Text = Program._L("Close") + "(&C)";
        }

        private void btnSummit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        public override void Submit()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show(Program._L("Please enter your username") + "!");
                m_keyboardFrm.Location = txtUsername.PointToScreen(new Point(-272, 135));
                m_keyboardFrm.Show();
                m_keyboardFrm.BringToFront();
                m_keyboardFrm.setTxtBox(txtUsername);
                return;
            }
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
            string url = Program.urlroot + "/store/api/login/?loginname=" + txtUsername.Text.Trim()
                + "&loginpassword=" + txtPassword.Text.Trim()
                + "&language=" + Program.lang;
            string response = KoipyAPIHelper.Instance.getAPI(url);
            m_waitFrm.CloseWait();
            if (response == "")
            {
                this.Activate();    //因为waitingFrm在另外一个线程也是topmost属性，所以必须先Activate，否则messagebox会弹在后面
                Program.log.Error("Login Failed, username=" + txtUsername.Text.Trim());
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
                    string message = Program._L("Wrong username or password") + "!";
                    string caption = Program._L("Koipy");
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, buttons, icon);
                }
                else
                {
                    try
                    {
                        Program.branch_id = o["branch_id"].ToString();
                        Program.token = o["token"].ToString();
                        Program.store_user = txtUsername.Text.Trim();
                        String strData = "branch_id=" + Program.branch_id + "\r\ntoken=" + Program.token + "\r\nstore_user=" + Program.store_user;
                        //把token, branch_id写入koipy
                        // Create or open the specified file.
                        FileStream fStream = File.Open("koipy", FileMode.OpenOrCreate);

                        // Create a CryptoStream using the FileStream 
                        // and the passed key and initialization vector (IV).
                        CryptoStream cStream = new CryptoStream(fStream,
                            new TripleDESCryptoServiceProvider().CreateEncryptor(Program.tdesKey, Program.tdesIV),
                            CryptoStreamMode.Write);

                        // Create a StreamWriter using the CryptoStream.
                        StreamWriter sWriter = new StreamWriter(cStream);

                        // Write the data to the stream 
                        // to encrypt it.
                        sWriter.WriteLine(strData);

                        // Close the streams and
                        // close the file.
                        sWriter.Close();
                        cStream.Close();
                        fStream.Close();
                    }
                    catch (CryptographicException ex)
                    {
                        Program.log.Error("A Cryptographic error occurred: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Program.log.Error("A file access error occurred: " + ex.Message);
                    }
                    catch (System.Exception ex)
                    {
                        Program.log.Error(ex.ToString());
                    }

                    if (m_profileLoginFrm == null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                        m_profileLoginFrm.Show();
                    }
                }
            }
//            m_waitFrm.CloseWait();
        }

        private void SavetoFile(string branch_id, string strToken)
        {
            StreamReader sr = new StreamReader(@"config.ini");
            string strOri = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter(@"config.ini");
            sw.WriteLine(strOri);
            sw.WriteLine("branch_id=" + branch_id);
            sw.WriteLine("token=" + strToken);
            sw.Close();
            /*
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("config.ini"))
            {
                file.WriteLine("branch_id=" + branch_id);
                file.WriteLine("token=" + strToken);
                file.Flush();
                file.Close();
            }*/
        }

        public static void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Create a StreamWriter using the CryptoStream.
                StreamWriter sWriter = new StreamWriter(cStream);

                // Write the data to the stream 
                // to encrypt it.
                sWriter.WriteLine(Data);

                // Close the streams and
                // close the file.
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file access error occurred: {0}", e.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (m_profileLoginFrm !=null)
            {
                m_profileLoginFrm.Close();
                m_profileLoginFrm.Dispose();
            }
            this.Close();
            this.Dispose();
            Environment.Exit(0);
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (m_bInputChanged == false)
            {
                txtUsername.Text = "";
                m_bInputChanged = true;
            }

            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(-272, 135));
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            m_keyboardFrm.Hide();
        }

        private void LoginFrm_MouseClick(object sender, MouseEventArgs e)
        {
            bool isInUsername = e.X > txtUsername.Location.X 
                && e.Y > txtUsername.Location.Y 
                && e.X < txtUsername.Location.X+txtUsername.Width 
                && e.Y<txtUsername.Location.Y+txtUsername.Height;
            bool isInPassword = e.X > txtPassword.Location.X
                && e.Y > txtPassword.Location.Y
                && e.X < txtPassword.Location.X + txtPassword.Width
                && e.Y < txtPassword.Location.Y + txtPassword.Height;
            if (!isInUsername && !isInPassword)
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
