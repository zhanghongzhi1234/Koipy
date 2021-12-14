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
    public partial class CamPanel : Form
    {
        public Panel Panel1   //历史预警数据源
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        ProfileLoginFrm profileLoginFrm;

        public Label LabelStatus   //历史预警数据源
        {
            get { return labelStatus; }
            set { labelStatus = value; }
        }
        public Label LabelDoCount   //历史预警数据源
        {
            get { return labelDoCount; }
            set { labelDoCount = value; }
        }

        public CamPanel(ProfileLoginFrm profileLoginFrm)
        {
            InitializeComponent();
            this.profileLoginFrm = profileLoginFrm;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Hide();
            profileLoginFrm.Stop();
        }

        private void CamPanel_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            this.Text = Program._L("Koipy");
            btnStop.Text = Program._L("Stop Scan") + "(&S)";
        }

        private void CamPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
            profileLoginFrm.Stop();
        }
    }
}
