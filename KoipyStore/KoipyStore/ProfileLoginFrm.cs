using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using com.google.zxing;

namespace KoipyStore
{
    public partial class ProfileLoginFrm : TouchForm
    {
        private CamWorker _camWorker = null;
        string _directory = "cache";
        private int _failedCount = 0;
        private int _doCount = 0;
        CamPanel camPanel;
        LoginFrm m_loginFrm;
        CurrentPerkFrm m_currentPerkFrm;
        HoverFrm m_hoverFrm;
        bool m_bFirstScan = true;
        WaitFrm m_waitFrm;
        KeyboardFrm m_keyboardFrm;
        bool m_bInputChanged = false;
        bool m_bFirstShow = true;

        public ProfileLoginFrm()
        {
            InitializeComponent();
        }

        private void ProfileLoginFrm_Load(object sender, EventArgs e)
        {
            camPanel = new CamPanel(this);
            camPanel.Hide();
            m_currentPerkFrm = new CurrentPerkFrm(this);
            m_currentPerkFrm.Reload();
            m_currentPerkFrm.Hide();
            m_hoverFrm = new HoverFrm(this);
            m_hoverFrm.Hide();
            m_keyboardFrm = new KeyboardFrm();
            m_keyboardFrm.setParentForm(this);
            m_keyboardFrm.Hide();
            Reload();
        }

        public void Reload()
        {
            this.Text = Program._L("Koipy");
            txtPlease.Text = Program._L("Please enter Kcode/handphone number or scan Kcard") + ":";
            radioKCode.Text = Program._L("Kcode") + "(&K)";
            radioMobile.Text = Program._L("Mobile") + "(&M)";
            txtInput.Text = Program._L("Handphone number");
            btnSubmit.Text = Program._L("Submit") + "(&S)";
            btnCancel.Text = Program._L("Close") + "(&C)";
            btnSetting.Text = Program._L("Setting") + "(&T)";
            btnScan.Text = Program._L("Scan") + "(&A)";
            notifyIcon1.Text = Program._L("Koipy");
            menuItem_Hide.Text = Program._L("Hide") + "(&H)";
            menuItem_Show.Text = Program._L("Show") + "(&S)";
            menuItem_About.Text = Program._L("About") + "(&A)";
            menuItem_Exit.Text = Program._L("Exit") + "(&X)";

            radioKCode.Checked = false;
            radioMobile.Checked = true;
            radioMobile.BackColor = Color.Blue;
            m_bInputChanged = false;
        }

        private void radioKCode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKCode.Checked)
            {
                if (m_bInputChanged == false)
                {
                    txtInput.Text = Program._L("KCode");
                }
                radioKCode.BackColor = Color.Blue;
            }
            else
            {
                radioKCode.BackColor = SystemColors.Control;
            }
        }

        private void radioMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMobile.Checked)
            {
                if (m_bInputChanged == false)
                {
                    txtInput.Text = Program._L("Handphone number");
                }
                radioMobile.BackColor = Color.Blue;
            }
            else
            {
                radioMobile.BackColor = SystemColors.Control;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        public override void Submit()
        {
            m_waitFrm = new WaitFrm();
            m_waitFrm.ShowWait();
            string strType = "";
            if (radioKCode.Checked == true)
            {
                strType = "kcode";
                Program.type = "1";
            }
            else if (radioMobile.Checked == true)
            {
                strType = "mobile";
                Program.type = "2";
            }
            profileLogin(txtInput.Text, strType);
        }

        private void profileLogin(string parameter,string strType)
        {
            string url = Program.urlroot + "/store/api/checkVisit/?token=" + Program.token 
                + "&branch_id=" + Program.branch_id 
                + "&parameter=" + parameter 
                + "&type=" + strType
                + "&language=" + Program.lang;
            string response = KoipyAPIHelper.Instance.getAPI(url);
            MessageFrm msgFrm = new MessageFrm();
            if (response == "")
            {
                m_waitFrm.CloseWait();
                this.Activate();
                Program.log.Error("Cannot call API: " + url);
                string message = Program._L("Cannot connect to Koipy server") + "!";
                string caption = Program._L("Koipy");
                /*MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);*/
                msgFrm.SetText(message);
                msgFrm.ShowDialog();
            }
            else
            {   //Parse json string
                //read json response
                try
                {
                    JObject o = (JObject)JsonConvert.DeserializeObject(response);
                    if (o["status"].ToString() == "-1")
                    {
                        m_waitFrm.CloseWait();
                        this.Activate();
                        /*string caption = Program._L("Koipy");
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show(o["description"].ToString(), caption, buttons, icon);*/
                        msgFrm.SetText(o["description"].ToString());
                        msgFrm.ShowDialog();
                    }
                    else if (o["status"].ToString() == "-2")
                    {
                        m_waitFrm.CloseWait();
                        this.Activate();
                        /*string caption = Program._L("Koipy");
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        MessageBox.Show(o["description"].ToString(), caption, buttons, icon);*/
                        msgFrm.SetText(o["description"].ToString());
                        msgFrm.ShowDialog();
                        Logout();
                    }
                    else
                    {
                        Program.profileInfo.status = o["status"] != null ? o["status"].ToString() : "";
                        Program.profileInfo.description = o["description"] != null ? o["description"].ToString() : "";
                        Program.profileInfo.total_perk = o["total_perk"] != null ? o["total_perk"].ToString() : "";
                        Program.profileInfo.total_perk_without_last_visit = o["total_perk_without_last_visit"] != null ? o["total_perk_without_last_visit"].ToString() : "";
                        Program.profileInfo.default_people_no = o["default_people_no"] != null ? o["default_people_no"].ToString() : "";
                        Program.profileInfo.default_spending = o["default_spending"] != null ? o["default_spending"].ToString() : "";
                        Program.profileInfo.default_extra_point = o["default_extra_point"] != null ? o["default_extra_point"].ToString() : "";
                        Program.profileInfo.status_bar = o["status_bar"] != null ? o["status_bar"].ToString() : "";
                        Program.profileInfo.max_average_spending_per_person = o["max_average_spending_per_person"] != null ? o["max_average_spending_per_person"].ToString() : "";
                        //assign visit, it is a object
                        if (o["visit"]["id"] != null)
                        {
                            //string str = o["visit"]["id"].ToString();
                            Program.profileInfo.visit.id = o["visit"]["id"] != null ? o["visit"]["id"].ToString() : "";
                            Program.profileInfo.visit.created = o["visit"]["created"] != null ? o["visit"]["created"].ToString() : "";
                            Program.profileInfo.visit.spending = o["visit"]["spending"] != null ? o["visit"]["spending"].ToString() : "";
                            Program.profileInfo.visit.perk = o["visit"]["perk"] != null ? o["visit"]["perk"].ToString() : "";
                            Program.profileInfo.visit.status = o["visit"]["status"] != null ? o["visit"]["status"].ToString() : "";
                            Program.profileInfo.visit.people_no = o["visit"]["people_no"] != null ? o["visit"]["people_no"].ToString() : "";
                            Program.profileInfo.visit.invoice_no = o["visit"]["invoice_no"] != null ? o["visit"]["invoice_no"].ToString() : "";
                            Program.profileInfo.visit.variable = o["visit"]["variable"] != null ? o["visit"]["variable"].ToString() : "";
                            Program.profileInfo.visit.modified = o["visit"]["modified"] != null ? o["visit"]["modified"].ToString() : "";
                            Program.profileInfo.visit.profile_id = o["visit"]["profile_id"] != null ? o["visit"]["profile_id"].ToString() : "";
                            Program.profileInfo.visit.store_id = o["visit"]["store_id"] != null ? o["visit"]["store_id"].ToString() : "";
                            Program.profileInfo.visit.branch_id = o["visit"]["status"] != null ? o["visit"]["status"].ToString() : "";
                            Program.profileInfo.visit.score = o["visit"]["score"] != null ? o["visit"]["score"].ToString() : "";
                            Program.profileInfo.visit.review = o["visit"]["review"] != null ? o["visit"]["review"].ToString() : "";
                        }
                        //assign profile, it is a object
                        Program.profileInfo.profile.id = o["profile"]["id"] != null ? o["profile"]["id"].ToString() : "";
                        Program.profileInfo.profile.name = o["profile"]["name"] != null ? o["profile"]["name"].ToString() : "";
                        Program.profileInfo.profile.gender = o["profile"]["gender"] != null ? o["profile"]["gender"].ToString() : "";
                        Program.profileInfo.profile.username = o["profile"]["username"] != null ? o["profile"]["username"].ToString() : "";
                        Program.profileInfo.profile.prefered_to_be_called = o["profile"]["prefered_to_be_called"] != null ? o["profile"]["prefered_to_be_called"].ToString() : "";
                        Program.profileInfo.profile.mobile = o["profile"]["mobile"] != null ? o["profile"]["mobile"].ToString() : "";
                        Program.profileInfo.profile.dob = o["profile"]["dob"] != null ? o["profile"]["dob"].ToString() : "";
                        Program.profileInfo.profile.note = o["profile"]["note"] != null ? o["profile"]["note"].ToString() : "";
                        //assign promotions, it is a array of object
                        JArray oa = (JArray)JsonConvert.DeserializeObject(o["promotions"].ToString());
                        int i = 0;
                        Program.profileInfo.promotions.Clear();
                        foreach (var token in oa)
                        {
                            Promotion v = new Promotion();
                            v.id = token["id"] != null ? token["id"].ToString() : "";
                            v.name = token["name"] != null ? token["name"].ToString() : "";
                            v.condition = token["condition"] != null ? token["condition"].ToString() : "";
                            v.thumbnail = token["thumbnail"] != null ? token["thumbnail"].ToString() : "";
                            v.status = token["status"] != null ? token["status"].ToString() : "";
                            v.perk = token["perk"] != null ? token["perk"].ToString() : "";
                            v.created = token["created"] != null ? token["created"].ToString() : "";
                            v.modified = token["modified"] != null ? token["modified"].ToString() : "";
                            v.redemption_quantity = token["redemption_quantity"] != null ? token["redemption_quantity"].ToString() : "";
                            Program.profileInfo.promotions.Add(v);
                            i++;
                        }
                        //assign buttoninfos, it is a array of object
                        oa = (JArray)JsonConvert.DeserializeObject(o["buttons"].ToString());
                        Program.profileInfo.koipyButtons.Clear();
                        foreach (var token in oa)
                        {
                            KoipyButton v = new KoipyButton();
                            v.enabled = token["enabled"] != null ? token["enabled"].ToString() : "";
                            v.text = token["text"] != null ? token["text"].ToString() : "";
                            v.url = token["url"] != null ? token["url"].ToString() : "";
                            Program.profileInfo.koipyButtons.Add(v);
                        }
                        Program.profileInfo.show_xp = o["show_xp"] != null ? Convert.ToInt32(o["show_xp"].ToString()) : 0;
                        Program.profileInfo.show_invoice = o["show_invoice"] != null ? Convert.ToInt32(o["show_invoice"].ToString()) : 0;
                        m_currentPerkFrm.Show();
                        m_currentPerkFrm.Reload();
                        m_waitFrm.CloseWait();
                        this.Hide();
                    }
                }
                catch(Exception ex)
                {
                    Program.log.Error(ex.ToString());
                    //MessageBox.Show(Program._L("Koipy API format error") + "!");
                    msgFrm.SetText(Program._L("Koipy API format error"));
                    msgFrm.ShowDialog();
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            radioMobile.Checked = false;
            radioKCode.Checked = true;
            _doCount = 0;
            _camWorker = new CamWorker(camPanel.Panel1.Handle, 0, 0, camPanel.Panel1.Width, camPanel.Panel1.Height);
            _camWorker.Start();
            resetTimer();       //开启timer
        }
        //重置timer，扫描二维码
        public void resetTimer()
        {
            btnScan.Enabled = false;
            timer1.Enabled = false;
            timer1.Tag = "hongzhi";
            timer1.Interval = 1000;
            Program.log.Info("Start to Scan Kcard");
            timer1.Enabled = true;
        }

        //计数器到期，根据参数弹出对话框
        private void timer1_Tick(object sender, EventArgs e)
        {
            _doCount++;
            camPanel.LabelDoCount.Text = _doCount.ToString();
            string fileName = Path.Combine(_directory, System.Guid.NewGuid() + ".bmp");
            //string fileName = Path.Combine(_directory, "temp.bmp");
            FileInfo fileTemp = new FileInfo(fileName);
            if (fileTemp.Exists)
            {
                fileTemp.Delete(); //删除单个文件
            }
            try
            {
                _camWorker.GrabImage(fileName);
                if (File.Exists(fileName))
                {
                    if (m_bFirstScan == true)       //根据扫描出来的文件大小判断是否开启摄像头
                    {
                        FileInfo fileTemp1 = new FileInfo(fileName);
                        if (fileTemp1.Length == 0)
                        {
                            Stop();
                            Program.log.Info("No camera detected!");
                            string message = Program._L("No camera detected") + "!";
                            string caption = Program._L("Koipy");
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            MessageBoxIcon icon = MessageBoxIcon.Error;
                            MessageBox.Show(message, caption, buttons, icon);
                            return;
                        }
                    }
                    m_bFirstScan = false;
                    camPanel.Show();
                    camPanel.LabelStatus.Text = "Cameram is working...";
                    camPanel.Reload();
                    System.IO.FileInfo f = new FileInfo(fileName);
                    
                    camPanel.LabelStatus.Text = string.Format("Successed to find image: {0}, and decoding...", fileName);
                    Image img = null;
                    try
                    {
                        img = Image.FromFile(fileName);
                    }
                    catch (OutOfMemoryException)
                    {
                        _failedCount++;
                        camPanel.LabelStatus.Text = "Image format is not correct.";
                        return;
                    }
                    Bitmap bmap;
                    try
                    {
                        bmap = new Bitmap(img);
                    }
                    catch (System.IO.IOException ioe)
                    {
                        _failedCount++;
                        camPanel.LabelStatus.Text = ioe.ToString();
                        return;
                    }
                    if (bmap == null)
                    {
                        _failedCount++;
                        camPanel.LabelStatus.Text = "Could not decode image";
                        return;
                    }
                    LuminanceSource source = new RGBLuminanceSource(bmap, bmap.Width, bmap.Height);
                    com.google.zxing.BinaryBitmap bitmap = new com.google.zxing.BinaryBitmap(new com.google.zxing.common.HybridBinarizer(source));
                    try
                    {
                        Result scanResult = new MultiFormatReader().decode(bitmap);
                        string result = scanResult.Text;
                        Program.log.Info("Successed to scan kcard, result=" + result);
                        //http://www.koipy.com/kcode/750751324/
                        string strKCode = "";
                        string strStart = "www.koipy.com/kcode/";
                        int pos1 = result.IndexOf(strStart);
                        if (pos1 == -1)
                        {
                            MessageBox.Show(Program._L("Wrong Kcode format") + "!");
                            return;
                        }
                        int pos2 = result.IndexOf("/", pos1 + strStart.Length);
                        int nKcodeLen = 9;
                        if (pos2 == -1)
                        {
                            nKcodeLen = result.Length - pos1 - strStart.Length;
                        }
                        else
                        {
                            nKcodeLen = pos2 - pos1 - strStart.Length;
                        }
                        strKCode = result.Substring(pos1 + strStart.Length, nKcodeLen);

                        camPanel.LabelStatus.Text = result;
                        m_waitFrm = new WaitFrm();
                        m_waitFrm.ShowWait();
                        Stop();
                        //MessageBox.Show(string.Format("Successed to decode: {0}, kcode={1}", result.Text,strKCode));
                        Program.log.Info("kcode=" + strKCode);
                        m_bFirstScan = true;
                        profileLogin(strKCode, "kcode");
                        foreach (string file in Directory.GetFiles(_directory))
                        {
                            try
                            {
                                File.Delete(file);
                            }
                            catch (System.Exception)
                            {   //do nothing, just try to delete the file
                            	
                            }
                        }
                        camPanel.Visible = false;
                    }
                    catch (ReaderException re)
                    {
                        _failedCount++;
                        camPanel.LabelStatus.Text = re.ToString();
                        return;
                    }
                }
                camPanel.LabelStatus.Text = string.Format("Failed to find image: {0}...", fileName);
            }
            finally
            {
                if (_failedCount >= 100)
                {
                    _failedCount = 0;
                    Stop();
                    camPanel.LabelStatus.Text = string.Format("Application Force stop monitor,because it can not grab valid image for 100 consecutive times.", fileName);
                }
            }
        }

        public void Stop()
        {
            camPanel.Hide();
            _doCount = 0;
            timer1.Enabled = false;
            _camWorker.Stop();
            camPanel.LabelStatus.Text = "Cameram has been shutdown.";
            btnScan.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (btnScan.Enabled == true)
            {
                radioMobile.Checked = false;
                radioKCode.Checked = true;
                btnScan_Click(sender, e);
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_currentPerkFrm != null)
                {
                    if (m_currentPerkFrm.Visible == true)
                    {
                        m_currentPerkFrm.Visible = false;
                    }
                    m_currentPerkFrm.HideHistoryFrm();
                }
                ShowFrm();
            }
        }
        //隐藏主窗体
        private void HideFrm()
        {
            this.Hide();
        }

        //显示主窗体
        public void ShowFrm()
        {
            if (m_currentPerkFrm != null)
            {
                if (m_currentPerkFrm.Visible == true)
                {
                    m_currentPerkFrm.Visible = false;
                }
                m_currentPerkFrm.HideHistoryFrm();
            }
            this.Show();
            m_hoverFrm.Hide();
        }

        //关闭主窗体并退出程序
        public void CloseFrm()
        {
            Program.log.Info("Exit Koipy Store");
            this.notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            //Application.Exit();
            Environment.Exit(0);
        }

        private void menuItem_Hide_Click(object sender, EventArgs e)
        {
            m_hoverFrm.Show();
            this.HideFrm();
        }

        private void menuItem_Show_Click(object sender, EventArgs e)
        {
            this.ShowFrm();
        }

        private void menuItem_About_Click(object sender, EventArgs e)
        {
            AbtBox aboutDlg = new AbtBox();
            aboutDlg.ShowDialog();
        }

        private void menuItem_Exit_Click(object sender, EventArgs e)
        {
            CloseFrm();
        }

        //现在改为悬浮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hover();
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            if (m_bInputChanged == false)
            {
                txtInput.Text = "";
                m_bInputChanged = true;
            }
           
            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(400, -100));
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
        }

        private void ProfileLoginFrm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hover();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            OptionFrm dlg = new OptionFrm();
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)//改变语言设置
            {
                Reload();
            }
            else if(ret == DialogResult.Cancel)//退出登录
            {
                Logout();
            }
        }

        private void Logout()
        {
            Program.branch_id = "";
            Program.profileInfo.Clear();
            Program.store_user = "";
            Program.token = "";
            File.Delete("koipy");
            if (m_loginFrm == null)
            {
                m_loginFrm = new LoginFrm(this);
            }
            m_loginFrm.Reload();
            m_loginFrm.Show();
            this.Hide();
        }

        private void ProfileLoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            Hover();
        }

        public void Hover()
        {
            if (m_hoverFrm !=null && m_hoverFrm.IsDisposed == false)
            {
                m_hoverFrm.Show();
            }
            this.Hide();
            m_keyboardFrm.Hide();
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            m_keyboardFrm.Hide();
        }

        private void ProfileLoginFrm_Shown(object sender, EventArgs e)
        {
            if (m_bFirstShow)
            {
                Hover();
                m_bFirstShow = false;
            }
        }
    
    }
}
