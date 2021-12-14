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
    public partial class KeyboardFrm : Form
    {
        TextBox m_txtBox;
        TouchForm m_parentForm;
        string m_param = "";

        public KeyboardFrm()
        {
            InitializeComponent();
        }

        public KeyboardFrm(string param)
        {
            InitializeComponent();
            m_param = param;
        }

        private void KeyboardFrm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetRowSpan(ckbEnter, 4);
        }
        
        public void setParam(string param)
        {
            m_param = param;
        }

        public void setTxtBox(TextBox txtBox)
        {
            m_txtBox = txtBox;
        }

        public void setParentForm(TouchForm parentForm)
        {
            m_parentForm = parentForm;
        }

        private void KeyboardFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
        }

        private void ckbEnter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEnter.Checked == true)
            {
                this.Hide();
                if (m_param == "")
                {
                    m_parentForm.Submit();
                    m_param = "";
                } 
                else
                {
                    m_parentForm.Submit(m_param);
                }
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

        private void ckbDot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDot.Checked == true)
            {
                m_txtBox.Text += ".";
            }
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

        private void ckbDot_MouseUp(object sender, MouseEventArgs e)
        {
            ckbDot.Checked = false;
        }

        private void ckbDel_MouseUp(object sender, MouseEventArgs e)
        {
            ckbDel.Checked = false;
        }

        private void KeyboardFrm_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.OemPeriod:
                    ckbDot.Checked = true;
                    break;
                case Keys.Back:
                case Keys.Delete:
                    ckbDel.Checked = true;
                    break;
                case Keys.Enter:
                    ckbEnter.Checked = true;
                    break;
            }
            //m_txtBox.SelectionStart = m_txtBox.TextLength;
        }

        private void KeyboardFrm_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (System.Windows.Forms.Control control in this.tableLayoutPanel1.Controls)//遍历groupBox2上的所有控件  
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox chb = (System.Windows.Forms.CheckBox)control;
                    chb.Checked = false;
                }
            }
        }
    }
}
