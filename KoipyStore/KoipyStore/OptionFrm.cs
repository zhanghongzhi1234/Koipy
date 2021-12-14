using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KoipyStore
{
    public partial class OptionFrm : Form
    {
        public OptionFrm()
        {
            InitializeComponent();
        }

        private void OptionFrm_Load(object sender, EventArgs e)
        {
            radEn_us.Checked = (Program.lang == "en_us");
            radZh_cn.Checked = (Program.lang == "zh_cn");

            this.Text = Program._L("Koipy");
            grpLang.Text = Program._L("Language");
            IDOK.Text = Program._L("OK") + "(&O)";
            IDLogout.Text = Program._L("Logout") + "(&L)";

            this.labelVersion.Text = Program._L("Version") + ": 1.0";
            this.labelCopyright.Text = Program._L("Copyright") + ": " + Program._L("Koipy");
        }

        private void IDOK_Click(object sender, EventArgs e)
        {
            string strNewLang = "";
            if (radEn_us.Checked == true)
            {
                strNewLang = "en_us";
            }
            else if (radZh_cn.Checked == true)
            {
                strNewLang = "zh_cn";
            }
            if (strNewLang != Program.lang)
            {   //用户更改了语言选项，存入文件
                Program.lang = strNewLang;
                StreamWriter swFromFile = new StreamWriter("config.ini");
                swFromFile.WriteLine("lang="+strNewLang);
                swFromFile.Flush();
                swFromFile.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IDLogout_Click(object sender, EventArgs e)
        {
            LogoutFrm dlg = new LogoutFrm();
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)//登录成功就设置登录窗体的DialogResult为OK
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (ret == DialogResult.Cancel)//取消后退回
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
