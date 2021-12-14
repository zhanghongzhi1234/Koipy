namespace KoipyStore
{
    partial class HistoryPerkFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryPerkFrm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnHover = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnThis = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblPerk = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblComsumption = new System.Windows.Forms.Label();
            this.ckbExtra = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProfile = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblDob = new System.Windows.Forms.Label();
            this.txtDob = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblVisit = new System.Windows.Forms.Label();
            this.lblLastVisit = new System.Windows.Forms.Label();
            this.txtLastVisit = new System.Windows.Forms.TextBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.bdsPromotion = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ColumnThumbnail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnButton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel1.BackgroundImage")));
            this.splitContainer1.Panel1.Controls.Add(this.btnHover);
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnThis);
            this.splitContainer1.Panel1.Controls.Add(this.lblTitle);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1018, 718);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnHover
            // 
            this.btnHover.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnHover.ForeColor = System.Drawing.Color.White;
            this.btnHover.Location = new System.Drawing.Point(193, 11);
            this.btnHover.Name = "btnHover";
            this.btnHover.Size = new System.Drawing.Size(90, 25);
            this.btnHover.TabIndex = 5;
            this.btnHover.Text = "Close";
            this.btnHover.UseVisualStyleBackColor = false;
            this.btnHover.Click += new System.EventHandler(this.btnHover_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(906, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnThis
            // 
            this.btnThis.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnThis.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnThis.ForeColor = System.Drawing.Color.White;
            this.btnThis.Location = new System.Drawing.Point(15, 11);
            this.btnThis.Name = "btnThis";
            this.btnThis.Size = new System.Drawing.Size(170, 25);
            this.btnThis.TabIndex = 1;
            this.btnThis.Text = "This Consumption";
            this.btnThis.UseVisualStyleBackColor = false;
            this.btnThis.Click += new System.EventHandler(this.btnThis_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(382, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Last Consumption";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer2.Panel1.BackgroundImage")));
            this.splitContainer2.Panel1.Controls.Add(this.txtInvoice);
            this.splitContainer2.Panel1.Controls.Add(this.lblInvoice);
            this.splitContainer2.Panel1.Controls.Add(this.btnSubmit);
            this.splitContainer2.Panel1.Controls.Add(this.lblPerk);
            this.splitContainer2.Panel1.Controls.Add(this.txtCount);
            this.splitContainer2.Panel1.Controls.Add(this.txtConsumption);
            this.splitContainer2.Panel1.Controls.Add(this.lblNum);
            this.splitContainer2.Panel1.Controls.Add(this.lblComsumption);
            this.splitContainer2.Panel1.Controls.Add(this.ckbExtra);
            this.splitContainer2.Panel1.Controls.Add(this.lblStatus);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1018, 667);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInvoice.Location = new System.Drawing.Point(509, 34);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(100, 44);
            this.txtInvoice.TabIndex = 19;
            this.txtInvoice.Click += new System.EventHandler(this.txtInvoice_Click);
            this.txtInvoice.Leave += new System.EventHandler(this.txtInvoice_Leave);
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoice.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInvoice.ForeColor = System.Drawing.Color.White;
            this.lblInvoice.Location = new System.Drawing.Point(525, 7);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(63, 15);
            this.lblInvoice.TabIndex = 18;
            this.lblInvoice.Text = "Invoice";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Green;
            this.btnSubmit.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(906, 34);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 44);
            this.btnSubmit.TabIndex = 17;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblPerk
            // 
            this.lblPerk.AutoSize = true;
            this.lblPerk.BackColor = System.Drawing.Color.Transparent;
            this.lblPerk.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPerk.ForeColor = System.Drawing.Color.White;
            this.lblPerk.Location = new System.Drawing.Point(913, 7);
            this.lblPerk.Name = "lblPerk";
            this.lblPerk.Size = new System.Drawing.Size(47, 15);
            this.lblPerk.TabIndex = 16;
            this.lblPerk.Text = "Point";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(776, 34);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 44);
            this.txtCount.TabIndex = 15;
            this.txtCount.Click += new System.EventHandler(this.txtCount_Click);
            this.txtCount.Leave += new System.EventHandler(this.txtCount_Leave);
            // 
            // txtConsumption
            // 
            this.txtConsumption.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConsumption.Location = new System.Drawing.Point(642, 34);
            this.txtConsumption.Name = "txtConsumption";
            this.txtConsumption.Size = new System.Drawing.Size(100, 44);
            this.txtConsumption.TabIndex = 14;
            this.txtConsumption.Click += new System.EventHandler(this.txtConsumption_Click);
            this.txtConsumption.Leave += new System.EventHandler(this.txtConsumption_Leave);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.BackColor = System.Drawing.Color.Transparent;
            this.lblNum.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.ForeColor = System.Drawing.Color.White;
            this.lblNum.Location = new System.Drawing.Point(772, 7);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(79, 15);
            this.lblNum.TabIndex = 13;
            this.lblNum.Text = "No. of PP";
            // 
            // lblComsumption
            // 
            this.lblComsumption.AutoSize = true;
            this.lblComsumption.BackColor = System.Drawing.Color.Transparent;
            this.lblComsumption.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblComsumption.ForeColor = System.Drawing.Color.White;
            this.lblComsumption.Location = new System.Drawing.Point(643, 7);
            this.lblComsumption.Name = "lblComsumption";
            this.lblComsumption.Size = new System.Drawing.Size(71, 15);
            this.lblComsumption.TabIndex = 12;
            this.lblComsumption.Text = "Spending";
            // 
            // ckbExtra
            // 
            this.ckbExtra.AutoSize = true;
            this.ckbExtra.BackColor = System.Drawing.Color.Transparent;
            this.ckbExtra.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbExtra.ForeColor = System.Drawing.Color.White;
            this.ckbExtra.Location = new System.Drawing.Point(409, 35);
            this.ckbExtra.Name = "ckbExtra";
            this.ckbExtra.Size = new System.Drawing.Size(66, 19);
            this.ckbExtra.TabIndex = 11;
            this.ckbExtra.Text = "Extra";
            this.ckbExtra.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(12, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 16);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "label2";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer3.Panel2.BackgroundImage")));
            this.splitContainer3.Size = new System.Drawing.Size(1018, 580);
            this.splitContainer3.SplitterDistance = 530;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvHistory);
            this.splitContainer4.Size = new System.Drawing.Size(1018, 530);
            this.splitContainer4.SplitterDistance = 313;
            this.splitContainer4.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblProfile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblGender, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGender, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblUsername, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMobile, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtMobile, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDob, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDob, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblNote, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtNote, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblVisit, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblLastVisit, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtLastVisit, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblPoints, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtPoints, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(313, 530);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.lblProfile, 2);
            this.lblProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProfile.Location = new System.Drawing.Point(4, 1);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(305, 25);
            this.lblProfile.TabIndex = 3;
            this.lblProfile.Text = "Profile";
            this.lblProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblName.Location = new System.Drawing.Point(108, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtName.Location = new System.Drawing.Point(160, 39);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(149, 16);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "1";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblGender.Location = new System.Drawing.Point(97, 81);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(56, 17);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender";
            // 
            // txtGender
            // 
            this.txtGender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGender.BackColor = System.Drawing.Color.White;
            this.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGender.Location = new System.Drawing.Point(160, 81);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(149, 16);
            this.txtGender.TabIndex = 9;
            this.txtGender.Text = "2";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblUsername.Location = new System.Drawing.Point(80, 123);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUsername.Location = new System.Drawing.Point(160, 123);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(149, 16);
            this.txtUsername.TabIndex = 11;
            this.txtUsername.Text = "3";
            // 
            // lblMobile
            // 
            this.lblMobile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMobile.Location = new System.Drawing.Point(104, 165);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(49, 17);
            this.lblMobile.TabIndex = 14;
            this.lblMobile.Text = "Mobile";
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMobile.BackColor = System.Drawing.Color.White;
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMobile.Location = new System.Drawing.Point(160, 165);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.ReadOnly = true;
            this.txtMobile.Size = new System.Drawing.Size(149, 16);
            this.txtMobile.TabIndex = 15;
            this.txtMobile.Text = "5";
            // 
            // lblDob
            // 
            this.lblDob.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDob.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDob.Location = new System.Drawing.Point(119, 207);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(34, 17);
            this.lblDob.TabIndex = 16;
            this.lblDob.Text = "Dob";
            // 
            // txtDob
            // 
            this.txtDob.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDob.BackColor = System.Drawing.Color.White;
            this.txtDob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDob.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDob.Location = new System.Drawing.Point(160, 207);
            this.txtDob.Name = "txtDob";
            this.txtDob.ReadOnly = true;
            this.txtDob.Size = new System.Drawing.Size(149, 16);
            this.txtDob.TabIndex = 17;
            this.txtDob.Text = "6";
            // 
            // lblNote
            // 
            this.lblNote.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNote.Location = new System.Drawing.Point(115, 269);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(38, 17);
            this.lblNote.TabIndex = 18;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNote.Location = new System.Drawing.Point(160, 270);
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(149, 16);
            this.txtNote.TabIndex = 19;
            this.txtNote.Text = "7";
            // 
            // lblVisit
            // 
            this.lblVisit.AutoSize = true;
            this.lblVisit.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.lblVisit, 2);
            this.lblVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVisit.Location = new System.Drawing.Point(4, 320);
            this.lblVisit.Name = "lblVisit";
            this.lblVisit.Size = new System.Drawing.Size(305, 25);
            this.lblVisit.TabIndex = 20;
            this.lblVisit.Text = "Last Visit";
            this.lblVisit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastVisit
            // 
            this.lblLastVisit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLastVisit.AutoSize = true;
            this.lblLastVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastVisit.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLastVisit.Location = new System.Drawing.Point(88, 358);
            this.lblLastVisit.Name = "lblLastVisit";
            this.lblLastVisit.Size = new System.Drawing.Size(65, 17);
            this.lblLastVisit.TabIndex = 21;
            this.lblLastVisit.Text = "Last Visit";
            // 
            // txtLastVisit
            // 
            this.txtLastVisit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLastVisit.BackColor = System.Drawing.Color.White;
            this.txtLastVisit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastVisit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLastVisit.Location = new System.Drawing.Point(160, 358);
            this.txtLastVisit.Name = "txtLastVisit";
            this.txtLastVisit.ReadOnly = true;
            this.txtLastVisit.Size = new System.Drawing.Size(149, 16);
            this.txtLastVisit.TabIndex = 22;
            this.txtLastVisit.Text = "7";
            // 
            // lblPoints
            // 
            this.lblPoints.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPoints.Location = new System.Drawing.Point(106, 400);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(47, 17);
            this.lblPoints.TabIndex = 23;
            this.lblPoints.Text = "Points";
            // 
            // txtPoints
            // 
            this.txtPoints.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPoints.BackColor = System.Drawing.Color.White;
            this.txtPoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoints.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPoints.Location = new System.Drawing.Point(160, 400);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.ReadOnly = true;
            this.txtPoints.Size = new System.Drawing.Size(149, 16);
            this.txtPoints.TabIndex = 24;
            this.txtPoints.Text = "Points";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeColumns = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoGenerateColumns = false;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.ColumnHeadersVisible = false;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnThumbnail,
            this.ColumnName,
            this.ColumnButton});
            this.dgvHistory.DataSource = this.bdsPromotion;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 90;
            this.dgvHistory.Size = new System.Drawing.Size(701, 530);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHistory_CellMouseUp);
            this.dgvHistory.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHistory_CellMouseClick);
            this.dgvHistory.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHistory_CellMouseDown);
            this.dgvHistory.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewHistory_CellPainting);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ColumnThumbnail
            // 
            this.ColumnThumbnail.FillWeight = 70F;
            this.ColumnThumbnail.HeaderText = "thumbnail";
            this.ColumnThumbnail.Name = "ColumnThumbnail";
            this.ColumnThumbnail.ReadOnly = true;
            this.ColumnThumbnail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnThumbnail.Width = 70;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.FillWeight = 845F;
            this.ColumnName.HeaderText = "name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnButton
            // 
            this.ColumnButton.HeaderText = "Button";
            this.ColumnButton.Name = "ColumnButton";
            this.ColumnButton.ReadOnly = true;
            this.ColumnButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnButton.Width = 200;
            // 
            // HistoryPerkFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 718);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryPerkFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Koipy";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.HistoryPerkFrm_Load);
            this.SizeChanged += new System.EventHandler(this.HistoryPerkFrm_SizeChanged);
            this.Move += new System.EventHandler(this.HistoryPerkFrm_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistoryPerkFrm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPromotion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblPerk;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtConsumption;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblComsumption;
        private System.Windows.Forms.CheckBox ckbExtra;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnThis;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource bdsPromotion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnHover;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.TextBox txtDob;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblVisit;
        private System.Windows.Forms.Label lblLastVisit;
        private System.Windows.Forms.TextBox txtLastVisit;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.TextBox txtPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThumbnail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnButton;

    }
}