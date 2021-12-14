namespace KoipyStore
{
    partial class OptionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionFrm));
            this.grpLang = new System.Windows.Forms.GroupBox();
            this.radZh_cn = new System.Windows.Forms.RadioButton();
            this.radEn_us = new System.Windows.Forms.RadioButton();
            this.IDOK = new System.Windows.Forms.Button();
            this.IDLogout = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.grpLang.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLang
            // 
            this.grpLang.Controls.Add(this.radZh_cn);
            this.grpLang.Controls.Add(this.radEn_us);
            this.grpLang.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpLang.Location = new System.Drawing.Point(12, 11);
            this.grpLang.Name = "grpLang";
            this.grpLang.Size = new System.Drawing.Size(468, 91);
            this.grpLang.TabIndex = 0;
            this.grpLang.TabStop = false;
            this.grpLang.Text = "Language";
            // 
            // radZh_cn
            // 
            this.radZh_cn.AutoSize = true;
            this.radZh_cn.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radZh_cn.Location = new System.Drawing.Point(200, 42);
            this.radZh_cn.Name = "radZh_cn";
            this.radZh_cn.Size = new System.Drawing.Size(138, 31);
            this.radZh_cn.TabIndex = 1;
            this.radZh_cn.TabStop = true;
            this.radZh_cn.Text = "简体中文";
            this.radZh_cn.UseVisualStyleBackColor = true;
            // 
            // radEn_us
            // 
            this.radEn_us.AutoSize = true;
            this.radEn_us.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radEn_us.Location = new System.Drawing.Point(19, 43);
            this.radEn_us.Name = "radEn_us";
            this.radEn_us.Size = new System.Drawing.Size(100, 31);
            this.radEn_us.TabIndex = 0;
            this.radEn_us.TabStop = true;
            this.radEn_us.Text = "en_us";
            this.radEn_us.UseVisualStyleBackColor = true;
            // 
            // IDOK
            // 
            this.IDOK.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IDOK.Location = new System.Drawing.Point(31, 199);
            this.IDOK.Name = "IDOK";
            this.IDOK.Size = new System.Drawing.Size(180, 74);
            this.IDOK.TabIndex = 1;
            this.IDOK.Text = "&OK";
            this.IDOK.UseVisualStyleBackColor = true;
            this.IDOK.Click += new System.EventHandler(this.IDOK_Click);
            // 
            // IDLogout
            // 
            this.IDLogout.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IDLogout.Location = new System.Drawing.Point(280, 198);
            this.IDLogout.Name = "IDLogout";
            this.IDLogout.Size = new System.Drawing.Size(180, 74);
            this.IDLogout.TabIndex = 2;
            this.IDLogout.Text = "&Logout";
            this.IDLogout.UseVisualStyleBackColor = true;
            this.IDLogout.Click += new System.EventHandler(this.IDLogout_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(26, 141);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(85, 25);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyright.Location = new System.Drawing.Point(207, 141);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(104, 25);
            this.labelCopyright.TabIndex = 4;
            this.labelCopyright.Text = "Copyright";
            // 
            // OptionFrm
            // 
            this.AcceptButton = this.IDOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 292);
            this.ControlBox = false;
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.IDLogout);
            this.Controls.Add(this.IDOK);
            this.Controls.Add(this.grpLang);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Koipy";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OptionFrm_Load);
            this.grpLang.ResumeLayout(false);
            this.grpLang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLang;
        private System.Windows.Forms.RadioButton radZh_cn;
        private System.Windows.Forms.RadioButton radEn_us;
        private System.Windows.Forms.Button IDOK;
        private System.Windows.Forms.Button IDLogout;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
    }
}