using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using API;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace KoipyStore
{
    public partial class CurrentPerkFrm : TouchForm
    {
        //promotion的DataTable
        private DataTable m_PromotionTable;
        private Font m_fontName;
        private Font m_fontCondition;
        private Font m_fontCount;
        private ProfileLoginFrm m_profileLoginFrm;
        private HistoryPerkFrm m_historyPerkFrm;
        private BroswerFrm m_browserFrm;
        WaitFrm m_waitFrm;
        Image[] m_imgArray;
        KeyboardFrm m_keyboardFrm;
        bool m_bConsumptionChanged = false;
        bool m_bCountChanged = false;

        public CurrentPerkFrm(ProfileLoginFrm profileLoginFrm)
        {
            InitializeComponent();
            m_profileLoginFrm = profileLoginFrm;

            m_PromotionTable = new DataTable();
            m_PromotionTable.Columns.Add("id", typeof(string));
            m_PromotionTable.Columns.Add("thumbnail", typeof(string));
            m_PromotionTable.Columns.Add("name", typeof(string));
            m_PromotionTable.Columns.Add("condition", typeof(string));
            m_PromotionTable.Columns.Add("count", typeof(string));
            m_PromotionTable.Columns.Add("perk", typeof(string));
            m_PromotionTable.Columns.Add("minus_status", typeof(string));      //0:normal,1:pressed,-1:disable
            m_PromotionTable.Columns.Add("plus_status", typeof(string));       //0:normal,1:pressed,-1:disable
        }

        private void CurrentPerkFrm_Load(object sender, EventArgs e)
        {
            this.dgvCurrent.AutoGenerateColumns = false;
            dgvCurrent.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            m_fontName = new Font("Arial", 11, FontStyle.Bold);
            m_fontCondition = new Font("Arial", 10, FontStyle.Regular);
            m_fontCount = new Font("Arial", 11, FontStyle.Bold);

            m_keyboardFrm = new KeyboardFrm();
            m_keyboardFrm.setParentForm(this);
            m_keyboardFrm.Hide();

            m_browserFrm = new BroswerFrm(this);
            m_browserFrm.Hide();

            m_historyPerkFrm = new HistoryPerkFrm(this, m_profileLoginFrm);
            m_historyPerkFrm.Location = Location;
            m_historyPerkFrm.Hide();

            Button[] buttons = new Button[Program.profileInfo.koipyButtons.Count];
            //for (int i = 0; i < Program.profileInfo.buttons.Count; i++)
            int i = 0;
            foreach (KoipyButton koipyButton in Program.profileInfo.koipyButtons)
            {
                buttons[i] = new Button();
                //this.splitContainer3.Panel2.Controls.Add(buttons[i]);

                //buttons[i].Name = "button" + i;
                buttons[i].Text = koipyButton.text;
                buttons[i].Location = new Point(10+130*i, 12);
                buttons[i].BackColor = System.Drawing.SystemColors.AppWorkspace;
                buttons[i].Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                buttons[i].ForeColor = System.Drawing.Color.White;
                buttons[i].Size = new System.Drawing.Size(90, 25);
                buttons[i].UseVisualStyleBackColor = false;
                //buttons[i].CommandArgument = i;

                buttons[i].Click += new System.EventHandler(Buttons_Click);
                i++;
            }
            this.splitContainer3.Panel2.Controls.AddRange(buttons);

            Reload();
        }

        void Buttons_Click(object sender, EventArgs e)
        {
            string text = (sender as Button).Text;
            foreach (KoipyButton koipyButton in Program.profileInfo.koipyButtons)
            {
                if (koipyButton.text == text)
                {
                    m_browserFrm.Reload();
                    string address = "http://www.koipy.com/" + koipyButton.url;
                    m_browserFrm.Navigate(address);
                    m_browserFrm.Show();
                    this.Hide();
                }
            }
        }

        public void Reload()
        {
            lblStatus.Text = Program.profileInfo.status_bar;
            txtInvoice.Text = "";
            txtConsumption.Text = Program.profileInfo.default_spending;
            txtCount.Text = Program.profileInfo.default_people_no;

            this.Text = Program._L("Koipy");
            btnReturn.Text = Program._L("Return") + "(&R)";
            btnLast.Text = Program._L("Last Visit") + "(&L)";
            btnSubmit.Text = Program._L("Submit") + "(&S)";
            btnProfile.Text = Program._L("Profile") + "(&P)";
            btnEdit.Text = Program._L("Edit") + "(&E)";
            lblTitle.Text = Program._L("This Visit");
            ckbExtra.Text = Program._L("XP") + "(&X)";
            lblInvoice.Text = Program._L("Invoice");
            lblComsumption.Text = Program._L("Spending");
            lblNum.Text = Program._L("No.of PP");
            lblPerk.Text = Program._L("Points") + ":" + Program.profileInfo.total_perk;
            btnHover.Text = Program._L("Close") + "(&C)";

            txtName.Text = Program.profileInfo.profile.name;
            txtGender.Text = Program.profileInfo.profile.gender;
            txtUsername.Text = Program.profileInfo.profile.username;
            //txtPrefer.Text = Program.profileInfo.profile.prefered_to_be_called;
            txtMobile.Text = Program.profileInfo.profile.mobile;
            txtDob.Text = Program.profileInfo.profile.dob;
            txtNote.Text = Program.profileInfo.profile.note;
            txtLastVisit.Text = Program.profileInfo.visit.created;
            txtPoints.Text = Program.profileInfo.visit.perk;

            lblProfile.Text = Program._L("Profile");
            lblName.Text = Program._L("Name");
            lblGender.Text = Program._L("Gender");
            lblUsername.Text = Program._L("Username");
            //lblPrefer.Text = Program._L("Prefered_to_be_called");
            lblVisit.Text = Program._L("Last Visit");
            lblMobile.Text = Program._L("Mobile");
            lblDob.Text = Program._L("Dob");
            lblNote.Text = Program._L("Note");
            lblLastVisit.Text = Program._L("Last Visit");
            lblPoints.Text = Program._L("Points");
            //btnClose.Text = Program._L("Close") + "(&C)";

            if (Program.profileInfo.default_extra_point == "0")
            {
                ckbExtra.Checked = false;
            }
            else
            {
                ckbExtra.Checked = false;
            }

            if (Program.profileInfo.show_xp == 1)
            {
                ckbExtra.Visible = true;
            }
            else
            {
                ckbExtra.Visible = false;
            }

            if (Program.profileInfo.show_invoice == 1)
            {
                lblInvoice.Visible = true;
                txtInvoice.Visible = true;
            } 
            else
            {
                lblInvoice.Visible = false;
                txtInvoice.Visible = false;
            }

            if (Program.profileInfo.visit.id == null)
            {
                btnLast.Visible = false;
            }
            else
            {
                btnLast.Visible = true;
            }
            m_bConsumptionChanged = false;
            m_bCountChanged = false;

            this.BindData();
            this.Refresh();
        }

        private void BindData()
        {   //先清空数据源和图片
            m_PromotionTable.Rows.Clear();
            int nLength = Program.profileInfo.promotions.Count;
            m_imgArray = new Image[nLength];
            int i = 0;
            string plus_status = "0";
            foreach (Promotion promotion in Program.profileInfo.promotions)
            {
                if (Convert.ToDouble(promotion.perk) > Convert.ToDouble(Program.profileInfo.total_perk))
                {
                    plus_status = "-1";
                }
                m_PromotionTable.Rows.Add(new string[] { promotion.id, promotion.thumbnail, promotion.name, promotion.condition, "0", promotion.perk, "-1", plus_status });
                Image imgTemp = LoadImage(promotion.thumbnail);
                if (imgTemp != null)
                {
                    m_imgArray[i] = imgTemp;
                }
                i++;
            }
            this.bdsPromotion.DataSource = m_PromotionTable;
        }

        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);

            System.Net.WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (System.Exception ex)
            {
                Program.log.Error("Cannot load image: " + url + ", ex=" + ex.ToString());
                return null;
            }

            System.IO.Stream responseStream =
                response.GetResponseStream();
            Bitmap bmp = new Bitmap(responseStream);
            responseStream.Dispose();

            return bmp;
        }

        private void dataGridViewCurrent_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    //if (m_PromotionTable.Rows[e.RowIndex]["thumbnail"] == DBNull.Value)
                    //    return;

                    string strPerk = m_PromotionTable.Rows[e.RowIndex]["perk"].ToString();
                    Image img = m_imgArray[e.RowIndex];
                    Rectangle newRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 5, 60, 60);

                    using (Brush gridBrush = new SolidBrush(this.dgvCurrent.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush, 2))
                        {
                            // Erase the cell.
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            //划线
                            Point p1 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top);
                            Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                            Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                            //Point[] ps = new Point[] { p1, p2, p3 };
                            Point[] ps = new Point[] { p2, p3 };
                            e.Graphics.DrawLines(gridLinePen, ps);

                            //画图标
                            e.Graphics.DrawImage(img, newRect);
                            //画字符串
                            e.Graphics.DrawString(strPerk, e.CellStyle.Font, Brushes.Crimson,
                                e.CellBounds.Left + 25, e.CellBounds.Top + 70, StringFormat.GenericDefault);
                            e.Handled = true;
                        }
                    }
                }
                else if (e.ColumnIndex == 1)
                {
                    string strName = m_PromotionTable.Rows[e.RowIndex]["name"].ToString();
                    string strCondition = m_PromotionTable.Rows[e.RowIndex]["condition"].ToString();

                    using (Brush gridBrush = new SolidBrush(this.dgvCurrent.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush, 2))
                        {
                            // Erase the cell.
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            //划线
                            Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                            Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                            Point[] ps = new Point[] { p2, p3 };
                            e.Graphics.DrawLines(gridLinePen, ps);

                            //画字符串
                            e.Graphics.DrawString(strName, m_fontName, Brushes.Black,
                                e.CellBounds.Left, e.CellBounds.Top + 5, StringFormat.GenericDefault);
                            e.Graphics.DrawString(strCondition, m_fontCondition, Brushes.Black,
                                e.CellBounds.Left, e.CellBounds.Top + 50, StringFormat.GenericDefault);
                            e.Handled = true;
                        }
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    string strCount = m_PromotionTable.Rows[e.RowIndex]["count"].ToString();
                    Image imgMinus;
                    Image imgPlus;
                    switch (m_PromotionTable.Rows[e.RowIndex]["minus_status"].ToString())
                    {
                        case "0":
                            imgMinus = KoipyStore.Properties.Resources.minus;
                            break;
                        case "1":
                            imgMinus = KoipyStore.Properties.Resources.minus_press;
                            break;
                        case "-1":
                            imgMinus = KoipyStore.Properties.Resources.minus_disable;
                            break;
                        default:
                            imgMinus = KoipyStore.Properties.Resources.minus_disable;
                            break;
                    }
                    switch (m_PromotionTable.Rows[e.RowIndex]["plus_status"].ToString())
                    {
                        case "0":
                            imgPlus = KoipyStore.Properties.Resources.plus;
                            break;
                        case "1":
                            imgPlus = KoipyStore.Properties.Resources.plus_press;
                            break;
                        case "-1":
                            imgPlus = KoipyStore.Properties.Resources.plus_disable;
                            break;
                        default:
                            imgPlus = KoipyStore.Properties.Resources.plus_disable;
                            break;
                    }
                    Image imgMultiply = KoipyStore.Properties.Resources.multiply;
                    Rectangle rectMinus = new Rectangle(e.CellBounds.X, e.CellBounds.Y + 50, 94, 27);
                    Rectangle rectPlus = new Rectangle(e.CellBounds.X + 100, e.CellBounds.Y + 50, 94, 27);
                    Rectangle rectMultiply = new Rectangle(e.CellBounds.X + 65, e.CellBounds.Y + 29, 8, 9);

                    using (Brush gridBrush = new SolidBrush(this.dgvCurrent.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush, 2))
                        {
                            // Erase the cell.
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            //划线
                            Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                            Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                            Point[] ps = new Point[] { p2, p3 };
                            e.Graphics.DrawLines(gridLinePen, ps);

                            //画图标
                            e.Graphics.DrawImage(imgMinus, rectMinus);       //button
                            e.Graphics.DrawImage(imgPlus, rectPlus);       //button
                            e.Graphics.DrawImage(imgMultiply, rectMultiply);       //乘号
                            //画字符串
                            e.Graphics.DrawString(strCount, m_fontCount, Brushes.Gray,
                                e.CellBounds.Left + 95, e.CellBounds.Top + 25, StringFormat.GenericDefault);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void dgvCurrent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                int nOldValue = Convert.ToInt32(m_PromotionTable.Rows[e.RowIndex]["count"].ToString());
                if (e.X > 0 && e.X < 94 && e.Y > 50 && e.Y < 77)
                {       //按下减号
                    if (nOldValue > 0)
                    {
                        nOldValue--;
                        m_PromotionTable.Rows[e.RowIndex]["count"] = Convert.ToSingle(nOldValue);
                        dgvCurrent.Refresh();
                    }
                }
                else if ((e.X > 100 && e.X < 194 && e.Y > 50 && e.Y < 77))
                {       //按下加号
                    if (checkExceed(Convert.ToDouble(m_PromotionTable.Rows[e.RowIndex]["perk"].ToString())) == false)
                    {
                        nOldValue++;
                        m_PromotionTable.Rows[e.RowIndex]["count"] = Convert.ToSingle(nOldValue);
                        dgvCurrent.Refresh();
                    }
                }
                updateStatus();
            }
        }

        private void dgvCurrent_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                if (e.X > 0 && e.X < 94 && e.Y > 50 && e.Y < 77)
                {       //按下减号
                    if (m_PromotionTable.Rows[e.RowIndex]["minus_status"].ToString() == "0")
                    {
                        m_PromotionTable.Rows[e.RowIndex]["minus_status"] = 1;
                        dgvCurrent.Refresh();
                    }
                }
                else if ((e.X > 100 && e.X < 194 && e.Y > 50 && e.Y < 77))
                {       //按下加号
                    if (m_PromotionTable.Rows[e.RowIndex]["plus_status"].ToString() == "0")
                    {
                        m_PromotionTable.Rows[e.RowIndex]["plus_status"] = 1;
                        dgvCurrent.Refresh();
                    }
                }
            }
        }

        private void dgvCurrent_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                if (e.X > 0 && e.X < 47 && e.Y > 50 && e.Y < 77)
                {       //按下减号
                    if (m_PromotionTable.Rows[e.RowIndex]["minus_status"].ToString() == "1")
                    {
                        m_PromotionTable.Rows[e.RowIndex]["minus_status"] = 0;
                        dgvCurrent.Refresh();
                    }
                }
                else if ((e.X > 47 && e.X < 94 && e.Y > 50 && e.Y < 77))
                {       //按下加号
                    if (m_PromotionTable.Rows[e.RowIndex]["plus_status"].ToString() == "1")
                    {
                        m_PromotionTable.Rows[e.RowIndex]["plus_status"] = 0;
                        dgvCurrent.Refresh();
                    }
                }
            }
        }

        //update status of button and perk
        private void updateStatus()
        {
            double redemption = 0;
            foreach (DataRow drow in m_PromotionTable.Rows)
            {
                if (drow["count"].ToString() != "0")
                {
                    redemption += Convert.ToDouble(drow["perk"].ToString()) * Convert.ToInt32(drow["count"].ToString());
                }
            }
            double dPerk = Convert.ToDouble(Program.profileInfo.total_perk) - redemption;       //剩余积分
            lblPerk.Text = Program._L("Point") + ":" + dPerk.ToString();
            foreach (DataRow drow in m_PromotionTable.Rows)
            {
                if (Convert.ToInt32(drow["count"].ToString()) > 0)
                {
                    drow["minus_status"] = "0";
                }
                else
                {
                    drow["minus_status"] = "-1";
                }
                if (dPerk >= Convert.ToDouble(drow["perk"].ToString()))
                {
                    drow["plus_status"] = "0";
                }
                else
                {
                    drow["plus_status"] = "-1";
                }
            }
            dgvCurrent.Refresh();
        }

        //check if exceed total point plus new Perk
        private bool checkExceed(double newPerk)
        {
            double redemption = 0;
            foreach (DataRow drow in m_PromotionTable.Rows)
            {
                if (drow["count"].ToString() != "0")
                {
                    redemption += Convert.ToDouble(drow["perk"].ToString()) * Convert.ToInt32(drow["count"].ToString());
                }
            }
            redemption += newPerk;
            if (redemption > Convert.ToDouble(Program.profileInfo.total_perk))
            {
                string message = Program._L("Exceed your total point") + "!";
                string caption = Program._L("Koipy");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Submit(null);
        }

        public override void Submit(string param)
        {
            if (check_Request() == false)
                return;

            if (param == "Invoice")
            {
                txtConsumption_Click((object)txtConsumption, null);
                m_keyboardFrm.setParam(null);
                return;
            }
            else if (param == "Consumption")
            {
                txtCount_Click((object)txtCount, null);
                m_keyboardFrm.setParam(null);
                return;
            }

            try
            {
                double dAvgStd = Convert.ToDouble(Program.profileInfo.max_average_spending_per_person);
                if (dAvgStd > double.Epsilon)
                {
                    double dConsumption = Convert.ToDouble(txtConsumption.Text);
                    int nCount = Convert.ToInt32(txtCount.Text);
                    if (nCount > 0)
                    {
                        double dAvg = dConsumption / nCount;
                        if (dAvg > dAvgStd)
                        {
                            string message = Program._L("The average spending is too big, confirm to submit") + "?";
                            string caption = Program._L("Koipy");
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            MessageBoxIcon icon = MessageBoxIcon.Question;
                            if (MessageBox.Show(message, caption, buttons, icon) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
                //do nothing
            }

            string redemption = "";
            string redemption_quantity = "";
            foreach (DataRow drow in m_PromotionTable.Rows)
            {
                if (drow["count"].ToString() != "0")
                {
                    redemption += "," + drow["id"].ToString();
                    redemption_quantity += "," + drow["count"].ToString();
                }
            }
            redemption = redemption.TrimStart(',');
            redemption_quantity = redemption_quantity.TrimStart(',');

            string url = Program.urlroot + "/store/api/post/?token=" + Program.token
                + "&branch_id=" + Program.branch_id
                + "&profile_id=" + Program.profileInfo.profile.id
                + "&spending=" + txtConsumption.Text
                + "&people_no=" + txtCount.Text
                + "&invoice_no=" + txtInvoice.Text
                + "&extra_point=" + (ckbExtra.Checked ? "1" : "0")
                + "&redemptions=" + redemption
                + "&redemption_quantity=" + redemption_quantity
                + "&type=" + Program.type
                + "&language=" + Program.lang;
            string response = KoipyAPIHelper.Instance.getAPI(url);
            if (response == "")
            {
                Program.log.Error("Cannot call API: " + url);
                string message = Program._L("Cannot connect to Koipy server") + "!";
                string caption = Program._L("Koipy");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
            else
            {   //Parse json string
                //read json response
                JObject o = (JObject)JsonConvert.DeserializeObject(response);
                if (o["status"].ToString() == "-1")
                {
                    string message = Program._L("Submit Fail") + "!";
                    string caption = Program._L("Koipy");
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, buttons, icon);
                }
                else
                {
                    string caption = Program._L("Koipy");
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    //MessageBoxIcon icon = MessageBoxIcon.Information;
                    //MessageBox.Show(o["description"].ToString(), caption, buttons, icon);
                    ShowMessageBoxTimeout(o["description"].ToString(), caption, buttons, 3000);
                    this.Hide();
                    m_profileLoginFrm.Hover();
                    m_profileLoginFrm.txtInput.Text = "";
                }
            }
        }

        private bool check_Request()
        {
            double dConsumption;
            int nCount;
            try
            {
                dConsumption = Convert.ToDouble(txtConsumption.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Program._L("Consumption must be a number") + "!");
                txtConsumption.Focus();
                return false;
            }
            try
            {
                nCount = Convert.ToInt32(txtCount.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Program._L("People number must be a integer") + "!");
                txtCount.Focus();
                return false;
            }

            if (txtConsumption.Text == "")
            {
                MessageBox.Show(Program._L("Please enter consumption") + "!");
                txtConsumption.Focus();
                return false;
            }
            else if (dConsumption < -Double.Epsilon)
            {
                MessageBox.Show(Program._L("Consumption must not be less than 0") + "!");
                txtConsumption.Focus();
                return false;
            }
            else if (txtCount.Text == "")
            {
                MessageBox.Show(Program._L("Please enter people number") + "!");
                txtCount.Focus();
                return false;
            }
            else if (nCount < 0)
            {
                MessageBox.Show(Program._L("People number must not be less than 0") + "!");
                txtCount.Focus();
                return false;
            }
            
            return true;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileFrm profileDlg = new ProfileFrm();
            profileDlg.ShowDialog();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            m_waitFrm = new WaitFrm();
            m_waitFrm.ShowWait();
            m_historyPerkFrm.Show();
            m_historyPerkFrm.Reload();
            this.Hide();
            m_waitFrm.CloseWait();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            m_profileLoginFrm.Reload();
            m_profileLoginFrm.Show();
            this.Hide();
        }

        private void CurrentPerkFrm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void CurrentPerkFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Visible = false;
            m_keyboardFrm.Hide();
            m_profileLoginFrm.Hover();
        }

        public void HideHistoryFrm()
        {
            if (m_historyPerkFrm != null)
            {
                if (m_historyPerkFrm.Visible == true)
                {
                    m_historyPerkFrm.Visible = false;
                }
            }
        }

        private void btnHover_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_profileLoginFrm.Hover();
        }

        private void txtConsumption_Click(object sender, EventArgs e)
        {
            if (m_bConsumptionChanged == false)
            {
                txtConsumption.Text = "";
                m_bConsumptionChanged = true;
            }

            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(-1, 45));
            m_keyboardFrm.setParam("Consumption");
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
        }

        private void txtConsumption_Leave(object sender, EventArgs e)
        {
            m_keyboardFrm.Hide();
        }

        private void txtCount_Click(object sender, EventArgs e)
        {
            if (m_bCountChanged == false)
            {
                txtCount.Text = "";
                m_bCountChanged = true;
            }
            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(-110, 45));
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
        }

        private void txtCount_Leave(object sender, EventArgs e)
        {
            m_keyboardFrm.Hide();
        }

        private void txtInvoice_Click(object sender, EventArgs e)
        {
            TextBox txtTemp = sender as TextBox;
            m_keyboardFrm.Location = txtTemp.PointToScreen(new Point(-25, 45));
            m_keyboardFrm.setParam("Invoice");
            m_keyboardFrm.Show();
            m_keyboardFrm.BringToFront();
            m_keyboardFrm.setTxtBox(txtTemp);
        }

        private void txtInvoice_Leave(object sender, EventArgs e)
        {
            m_keyboardFrm.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            m_browserFrm.Reload();
            string address = "http://www.koipy.com/store/api/profile/profile_id/" + Program.profileInfo.profile.id;
            address += "/token/" + Program.token + "/branch_id/" + Program.branch_id + "/language/" + Program.lang;
            m_browserFrm.Navigate(address);
            m_browserFrm.Show();
            this.Hide();
        }

        private void CurrentPerkFrm_Move(object sender, EventArgs e)
        {
            if(m_historyPerkFrm != null)
                m_historyPerkFrm.Location = Location;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            m_browserFrm.Reload();
            string address = "http://www.koipy.com/store/api/history/profile_id/" + Program.profileInfo.profile.id;
            address += "/token/" + Program.token + "/branch_id/" + Program.branch_id + "/language/" + Program.lang;
            m_browserFrm.Navigate(address);
            m_browserFrm.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            m_browserFrm.Reload();
            string address = "http://www.koipy.com/store/api/report/profile_id/" + Program.profileInfo.profile.id;
            address += "/token/" + Program.token + "/branch_id/" + Program.branch_id + "/language/" + Program.lang;
            m_browserFrm.Navigate(address);
            m_browserFrm.Show();
            this.Hide();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool EndDialog(IntPtr hDlg, out IntPtr nResult);
        public void ShowMessageBoxTimeout(string text, string caption,
           MessageBoxButtons buttons, int timeout)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(CloseMessageBox),
                new CloseState(caption, timeout));
            MessageBox.Show(text, caption, buttons);
        }
        private class CloseState
        {
            private int _Timeout;

            /// <summary>
            /// In millisecond
            /// </summary>
            public int Timeout
            {
                get
                {
                    return _Timeout;
                }
            }

            private string _Caption;

            /// <summary>
            /// Caption of dialog
            /// </summary>
            public string Caption
            {
                get
                {
                    return _Caption;
                }
            }

            public CloseState(string caption, int timeout)
            {
                _Timeout = timeout;
                _Caption = caption;
            }
        }
        private void CloseMessageBox(object state)
        {
            CloseState closeState = state as CloseState;

            Thread.Sleep(closeState.Timeout);
            IntPtr dlg = FindWindow(null, closeState.Caption);

            if (dlg != IntPtr.Zero)
            {
                IntPtr result;
                EndDialog(dlg, out result);
            }
        }
    }
}
