using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoipyStore
{
    public partial class BroswerFrm : Form
    {
        private CurrentPerkFrm m_currentPerkFrm;

        public BroswerFrm(CurrentPerkFrm currentPerkFrm)
        {
            InitializeComponent();
            m_currentPerkFrm = currentPerkFrm;
            Reload();
        }

        public void Reload()
        {
            btnClose.Text = Program._L("Close") + "(&C)";
        }

        // Navigates to the given URL if it is valid.
        public void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void BroswerFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Visible = false;
            m_currentPerkFrm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            m_currentPerkFrm.Show();
        }
    }
}
