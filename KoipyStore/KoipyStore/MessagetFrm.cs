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
    public partial class MessageFrm : TouchForm
    {
        string info;
        public MessageFrm()
        {
            InitializeComponent();
        }

        public MessageFrm(string info)
        {
            InitializeComponent();
            this.info = info;
        }

        public void SetText(string info)
        {
            this.info = info;
            lblInfo.Text = info;
        }

        private void MessageFrm_Load(object sender, EventArgs e)
        {
            lblInfo.Text = info;
            this.Text = Program._L("Koipy");
            btnClose.Text = Program._L("Close") + "(&L)";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
     }
}
