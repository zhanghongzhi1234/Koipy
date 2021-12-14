namespace KoipyStore
{
    partial class ProfileLoginFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileLoginFrm));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.radioMobile = new System.Windows.Forms.RadioButton();
            this.radioKCode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlease = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.NicontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.NicontextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Green;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(151, 364);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(180, 180);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "&Submit(&S)";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(452, 364);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(180, 180);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Scan(&A)";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(596, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 184);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtInput
            // 
            this.txtInput.AcceptsReturn = true;
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(9, 114);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(546, 62);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = "KCode";
            this.txtInput.Click += new System.EventHandler(this.txtInput_Click);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // radioMobile
            // 
            this.radioMobile.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioMobile.Checked = true;
            this.radioMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMobile.Location = new System.Drawing.Point(302, 22);
            this.radioMobile.Name = "radioMobile";
            this.radioMobile.Size = new System.Drawing.Size(180, 68);
            this.radioMobile.TabIndex = 1;
            this.radioMobile.TabStop = true;
            this.radioMobile.Text = "Mobile";
            this.radioMobile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioMobile.UseVisualStyleBackColor = true;
            this.radioMobile.CheckedChanged += new System.EventHandler(this.radioMobile_CheckedChanged);
            // 
            // radioKCode
            // 
            this.radioKCode.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioKCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioKCode.Location = new System.Drawing.Point(69, 22);
            this.radioKCode.Name = "radioKCode";
            this.radioKCode.Size = new System.Drawing.Size(180, 68);
            this.radioKCode.TabIndex = 0;
            this.radioKCode.Text = "KCode";
            this.radioKCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioKCode.UseVisualStyleBackColor = true;
            this.radioKCode.CheckedChanged += new System.EventHandler(this.radioKCode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioKCode);
            this.groupBox1.Controls.Add(this.radioMobile);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 190);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtPlease
            // 
            this.txtPlease.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlease.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPlease.Location = new System.Drawing.Point(12, 99);
            this.txtPlease.Multiline = true;
            this.txtPlease.Name = "txtPlease";
            this.txtPlease.ReadOnly = true;
            this.txtPlease.Size = new System.Drawing.Size(565, 42);
            this.txtPlease.TabIndex = 7;
            this.txtPlease.Text = "Please enter Kcode/handphone number or scan Kcard:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(600, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 68);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Close(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.NicontextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Koipy";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // NicontextMenu
            // 
            this.NicontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Hide,
            this.menuItem_Show,
            this.menuItem_About,
            this.menuItem_Exit});
            this.NicontextMenu.Name = "NicontextMenu";
            this.NicontextMenu.Size = new System.Drawing.Size(119, 92);
            // 
            // menuItem_Hide
            // 
            this.menuItem_Hide.Name = "menuItem_Hide";
            this.menuItem_Hide.Size = new System.Drawing.Size(118, 22);
            this.menuItem_Hide.Text = "Hide(&H)";
            this.menuItem_Hide.Click += new System.EventHandler(this.menuItem_Hide_Click);
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Name = "menuItem_Show";
            this.menuItem_Show.Size = new System.Drawing.Size(118, 22);
            this.menuItem_Show.Text = "Show(&S)";
            this.menuItem_Show.Click += new System.EventHandler(this.menuItem_Show_Click);
            // 
            // menuItem_About
            // 
            this.menuItem_About.Name = "menuItem_About";
            this.menuItem_About.Size = new System.Drawing.Size(118, 22);
            this.menuItem_About.Text = "About(&A)";
            this.menuItem_About.Click += new System.EventHandler(this.menuItem_About_Click);
            // 
            // menuItem_Exit
            // 
            this.menuItem_Exit.Name = "menuItem_Exit";
            this.menuItem_Exit.Size = new System.Drawing.Size(118, 22);
            this.menuItem_Exit.Text = "Exit(&E)";
            this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Location = new System.Drawing.Point(12, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(180, 68);
            this.btnSetting.TabIndex = 9;
            this.btnSetting.Text = "Setting(&T)";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // ProfileLoginFrm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPlease);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("SimSun", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileLoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Koipy";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProfileLoginFrm_Load);
            this.SizeChanged += new System.EventHandler(this.ProfileLoginFrm_SizeChanged);
            this.Shown += new System.EventHandler(this.ProfileLoginFrm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileLoginFrm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.NicontextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.RadioButton radioMobile;
        private System.Windows.Forms.RadioButton radioKCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPlease;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip NicontextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Hide;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Show;
        private System.Windows.Forms.ToolStripMenuItem menuItem_About;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Exit;
        private System.Windows.Forms.Button btnSetting;
    }
}