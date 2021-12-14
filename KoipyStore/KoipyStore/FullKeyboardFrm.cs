using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KoipyStore
{
    public partial class FullKeyboardFrm : Form
    {
        TextBox m_txtBox;
        TouchForm m_parentForm;

        public FullKeyboardFrm()
        {
            InitializeComponent();
        }

        public void setTxtBox(TextBox txtBox)
        {
            m_txtBox = txtBox;
        }

        public void setParentForm(TouchForm parentForm)
        {
            m_parentForm = parentForm;
        }

        private void FullKeyboardFrm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetRowSpan(ckbEnter, 2);
        }

        private void FullKeyboardFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
        }

        private void ckbDel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDel.Checked == true)
            {
                string strTemp = m_txtBox.Text;
                if (strTemp.Length >= 1)
                {
                    m_txtBox.Text = strTemp.Substring(0, strTemp.Length - 1);
                }
            }
        }

        private void ckbCapsLock_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCapsLock.Checked == true)
            {
                ckbCapsLock.BackColor = System.Drawing.Color.Blue;
                ckbCapsLock.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                ckbCapsLock.BackColor = System.Drawing.SystemColors.Control;
                ckbCapsLock.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void ckb1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb1.Checked == true)
            {
                m_txtBox.Text += "1";
            }
        }

        private void ckb2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb2.Checked == true)
            {
                m_txtBox.Text += "2";
            }
        }

        private void ckb3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb3.Checked == true)
            {
                m_txtBox.Text += "3";
            }
        }

        private void ckb4_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb4.Checked == true)
            {
                m_txtBox.Text += "4";
            }
        }

        private void ckb5_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb5.Checked == true)
            {
                m_txtBox.Text += "5";
            }
        }

        private void ckb6_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb6.Checked == true)
            {
                m_txtBox.Text += "6";
            }
        }

        private void ckb7_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb7.Checked == true)
            {
                m_txtBox.Text += "7";
            }
        }

        private void ckb8_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb8.Checked == true)
            {
                m_txtBox.Text += "8";
            }
        }

        private void ckb9_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb9.Checked == true)
            {
                m_txtBox.Text += "9";
            }
        }

        private void ckb0_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb0.Checked == true)
            {
                m_txtBox.Text += "0";
            }
        }

        private void ckbq_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbq.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "Q" : "q";
            }
        }

        private void ckbw_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbw.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "W" : "w";
            }
        }

        private void ckbe_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbe.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "E" : "e";
            }
        }

        private void ckbr_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbr.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "R" : "r";
            }
        }

        private void ckbt_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbt.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "T" : "t";
            }
        }

        private void ckby_CheckedChanged(object sender, EventArgs e)
        {
            if (ckby.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "Y" : "y";
            }
        }

        private void ckbu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbu.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "U" : "u";
            }
        }

        private void ckbi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbi.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "I" : "i";
            }
        }

        private void ckbo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbo.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "O" : "o";
            }
        }

        private void ckbp_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbp.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "P" : "p";
            }
        }

        private void ckba_CheckedChanged(object sender, EventArgs e)
        {
            if (ckba.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "A" : "a";
            }
        }

        private void ckbs_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbs.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "S" : "s";
            }
        }

        private void ckbd_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbd.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "D" : "d";
            }
        }

        private void ckbf_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbf.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "F" : "f";
            }
        }

        private void ckbg_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbg.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "G" : "g";
            }
        }

        private void ckbh_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbh.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "H" : "h";
            }
        }

        private void ckbj_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbj.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "J" : "j";
            }
        }

        private void ckbk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbk.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "K" : "k";
            }
        }

        private void ckbl_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbl.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "L" : "l";
            }
        }

        private void ckbz_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbz.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "Z" : "z";
            }
        }

        private void ckbx_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbx.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "X" : "x";
            }
        }

        private void ckbc_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbc.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "C" : "c";
            }
        }

        private void ckbv_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbv.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "V" : "v";
            }
        }

        private void ckbb_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbb.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "B" : "b";
            }
        }

        private void ckbn_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbn.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "N" : "n";
            }
        }

        private void ckbm_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbm.Checked == true)
            {
                m_txtBox.Text += ckbCapsLock.Checked ? "M" : "m";
            }
        }

        private void ckbEnter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEnter.Checked == true)
            {
                this.Hide();
                m_parentForm.Submit();
            }
        }

        private void ckbEnter_MouseUp(object sender, MouseEventArgs e)
        {
            ckbEnter.Checked = false;
        }

        private void ckb1_MouseUp(object sender, MouseEventArgs e)
        {
            ckb1.Checked = false;
        }

        private void ckb2_MouseUp(object sender, MouseEventArgs e)
        {
            ckb2.Checked = false;
        }

        private void ckb3_MouseUp(object sender, MouseEventArgs e)
        {
            ckb3.Checked = false;
        }

        private void ckb4_MouseUp(object sender, MouseEventArgs e)
        {
            ckb4.Checked = false;
        }

        private void ckb5_MouseUp(object sender, MouseEventArgs e)
        {
            ckb5.Checked = false;
        }

        private void ckb6_MouseUp(object sender, MouseEventArgs e)
        {
            ckb6.Checked = false;
        }

        private void ckb7_MouseUp(object sender, MouseEventArgs e)
        {
            ckb7.Checked = false;
        }

        private void ckb8_MouseUp(object sender, MouseEventArgs e)
        {
            ckb8.Checked = false;
        }

        private void ckb9_MouseUp(object sender, MouseEventArgs e)
        {
            ckb9.Checked = false;
        }

        private void ckb0_MouseUp(object sender, MouseEventArgs e)
        {
            ckb0.Checked = false;
        }

        private void ckbq_MouseUp(object sender, MouseEventArgs e)
        {
            ckbq.Checked = false;
        }

        private void ckbw_MouseUp(object sender, MouseEventArgs e)
        {
            ckbw.Checked = false;
        }

        private void ckbe_MouseUp(object sender, MouseEventArgs e)
        {
            ckbe.Checked = false;
        }

        private void ckbr_MouseUp(object sender, MouseEventArgs e)
        {
            ckbr.Checked = false;
        }

        private void ckbt_MouseUp(object sender, MouseEventArgs e)
        {
            ckbt.Checked = false;
        }

        private void ckby_MouseUp(object sender, MouseEventArgs e)
        {
            ckby.Checked = false;
        }

        private void ckbu_MouseUp(object sender, MouseEventArgs e)
        {
            ckbu.Checked = false;
        }

        private void ckbi_MouseUp(object sender, MouseEventArgs e)
        {
            ckbi.Checked = false;
        }

        private void ckbo_MouseUp(object sender, MouseEventArgs e)
        {
            ckbo.Checked = false;
        }

        private void ckbp_MouseUp(object sender, MouseEventArgs e)
        {
            ckbp.Checked = false;
        }

        private void ckba_MouseUp(object sender, MouseEventArgs e)
        {
            ckba.Checked = false;
        }

        private void ckbs_MouseUp(object sender, MouseEventArgs e)
        {
            ckbs.Checked = false;
        }

        private void ckbd_MouseUp(object sender, MouseEventArgs e)
        {
            ckbd.Checked = false;
        }

        private void ckbf_MouseUp(object sender, MouseEventArgs e)
        {
            ckbf.Checked = false;
        }

        private void ckbg_MouseUp(object sender, MouseEventArgs e)
        {
            ckbg.Checked = false;
        }

        private void ckbh_MouseUp(object sender, MouseEventArgs e)
        {
            ckbh.Checked = false;
        }

        private void ckbj_MouseUp(object sender, MouseEventArgs e)
        {
            ckbj.Checked = false;
        }

        private void ckbk_MouseUp(object sender, MouseEventArgs e)
        {
            ckbk.Checked = false;
        }

        private void ckbl_MouseUp(object sender, MouseEventArgs e)
        {
            ckbl.Checked = false;
        }

        private void ckbz_MouseUp(object sender, MouseEventArgs e)
        {
            ckbz.Checked = false;
        }

        private void ckbx_MouseUp(object sender, MouseEventArgs e)
        {
            ckbx.Checked = false;
        }

        private void ckbc_MouseUp(object sender, MouseEventArgs e)
        {
            ckbc.Checked = false;
        }

        private void ckbv_MouseUp(object sender, MouseEventArgs e)
        {
            ckbv.Checked = false;
        }

        private void ckbb_MouseUp(object sender, MouseEventArgs e)
        {
            ckbb.Checked = false;
        }

        private void ckbn_MouseUp(object sender, MouseEventArgs e)
        {
            ckbn.Checked = false;
        }

        private void ckbm_MouseUp(object sender, MouseEventArgs e)
        {
            ckbm.Checked = false;
        }

        private void ckbDel_MouseUp(object sender, MouseEventArgs e)
        {
            ckbDel.Checked = false;
        }

        private void FullKeyboardFrm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    ckb1.Checked = true;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    ckb2.Checked = true;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    ckb3.Checked = true;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    ckb4.Checked = true;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    ckb5.Checked = true;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    ckb6.Checked = true;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    ckb7.Checked = true;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    ckb8.Checked = true;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    ckb9.Checked = true;
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    ckb0.Checked = true;
                    break;
                case Keys.Q:
                    ckbq.Checked = true;
                    break;
                case Keys.W:
                    ckbw.Checked = true;
                    break;
                case Keys.E:
                    ckbe.Checked = true;
                    break;
                case Keys.R:
                    ckbr.Checked = true;
                    break;
                case Keys.T:
                    ckbt.Checked = true;
                    break;
                case Keys.Y:
                    ckby.Checked = true;
                    break;
                case Keys.U:
                    ckbu.Checked = true;
                    break;
                case Keys.I:
                    ckbi.Checked = true;
                    break;
                case Keys.O:
                    ckbo.Checked = true;
                    break;
                case Keys.P:
                    ckbp.Checked = true;
                    break;
                case Keys.A:
                    ckba.Checked = true;
                    break;
                case Keys.S:
                    ckbs.Checked = true;
                    break;
                case Keys.D:
                    ckbd.Checked = true;
                    break;
                case Keys.F:
                    ckbf.Checked = true;
                    break;
                case Keys.G:
                    ckbg.Checked = true;
                    break;
                case Keys.H:
                    ckbh.Checked = true;
                    break;
                case Keys.J:
                    ckbj.Checked = true;
                    break;
                case Keys.K:
                    ckbk.Checked = true;
                    break;
                case Keys.L:
                    ckbl.Checked = true;
                    break;
                case Keys.Z:
                    ckbz.Checked = true;
                    break;
                case Keys.X:
                    ckbx.Checked = true;
                    break;
                case Keys.C:
                    ckbc.Checked = true;
                    break;
                case Keys.V:
                    ckbv.Checked = true;
                    break;
                case Keys.B:
                    ckbb.Checked = true;
                    break;
                case Keys.N:
                    ckbn.Checked = true;
                    break;
                case Keys.M:
                    ckbm.Checked = true;
                    break;
                case Keys.CapsLock:
                    ckbCapsLock.Checked = !ckbCapsLock.Checked;
                    break;
                case Keys.Back:
                case Keys.Delete:
                    ckbDel.Checked = true;
                    break;
                case Keys.Enter:
                    ckbEnter.Checked = true;
                    break;
            }
        }

        private void FullKeyboardFrm_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (System.Windows.Forms.Control control in this.tableLayoutPanel1.Controls)//遍历groupBox2上的所有控件  
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox chb = (System.Windows.Forms.CheckBox)control;
                    if (chb.Name != "ckbCapsLock")
                    {
                        chb.Checked = false;
                    }
                }
            }
        }
    }
}
