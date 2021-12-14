using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KoipyStore
{
    public partial class WaitFrm : Form
    {
        private System.Threading.Thread tWait = null;

        public WaitFrm()
        {
            InitializeComponent();
            this.tWait = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(showWaitDlg));
            this.tWait.Name = "waiting thread";

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void WaitFrm_Load(object sender, EventArgs e)
        {
            Size newSize = new Size(50, 50);
            this.MaximumSize = this.MinimumSize = newSize;
            this.Size = newSize;
            Image image = Image.FromFile("wait.gif");
            pictureBox1.Image = image;
        }

        public void ShowMsg(string msg)
        {
            this.tWait.Start(msg);
        }

        public void ShowWait()
        {
            this.tWait.Start();
        }

        public void CloseWait()
        {
            if (this.tWait.ThreadState == System.Threading.ThreadState.Running)
            {
                this.tWait.Abort();
            }
        }

        private void showWaitDlg(object msg)
        {
            //this.lblMsg.Text = msg.ToString();
            this.ShowDialog();
        }
    }
}
