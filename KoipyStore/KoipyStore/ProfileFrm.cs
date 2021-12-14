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
    public partial class ProfileFrm : Form
    {
        public ProfileFrm()
        {
            InitializeComponent();
        }

        private void ProfileFrm_Load(object sender, EventArgs e)
        {
            txtName.Text = Program.profileInfo.profile.name;
            txtGender.Text = Program.profileInfo.profile.gender;
            txtUsername.Text = Program.profileInfo.profile.username;
            txtPrefer.Text = Program.profileInfo.profile.prefered_to_be_called;
            txtMobile.Text = Program.profileInfo.profile.mobile;
            txtDob.Text = Program.profileInfo.profile.dob;
            txtNote.Text = Program.profileInfo.profile.note;

            this.Text = Program._L("Profile");
            lblName.Text = Program._L("Name");
            lblGender.Text = Program._L("Gender");
            lblUsername.Text = Program._L("Username");
            lblPrefer.Text = Program._L("Prefered_to_be_called");
            lblMobile.Text = Program._L("Mobile");
            lblDob.Text = Program._L("Dob");
            lblNote.Text = Program._L("Note");
            btnClose.Text = Program._L("Close") + "(&C)";
        }
    }
}
