namespace GUI
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            pnlMainContent = new Panel();
            ucDashboard1 = new UCDashboard();
            pnlMenuCirculation = new FlowLayoutPanel();
            btnCirculation = new Button();
            btnBorrow = new Button();
            btnReturn = new Button();
            btnPayment = new Button();
            btnReportDebt = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDashboard = new Button();
            pnlSidebar = new GUI.Controls.GradientPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button2 = new Button();
            pnlMenuUser = new FlowLayoutPanel();
            btnUserManagement = new Button();
            btnUsers = new Button();
            btnReaders = new Button();
            btnPermissions = new Button();
            pnlMenuInventory = new FlowLayoutPanel();
            btnInventory = new Button();
            btnBookTitle = new Button();
            btnBookStock = new Button();
            btnImport = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnLogout = new Button();
            pnlMenuCatalog = new FlowLayoutPanel();
            btnCatalog = new Button();
            btnGenre = new Button();
            btnAuthor = new Button();
            btnPublisher = new Button();
            btnSupplier = new Button();
            panel1 = new Panel();
            menuCatalogTransition = new System.Windows.Forms.Timer(components);
            sidebarTransition = new System.Windows.Forms.Timer(components);
            menuInventoryTransition = new System.Windows.Forms.Timer(components);
            menuCirculationTransition = new System.Windows.Forms.Timer(components);
            menuUserTransition = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlMainContent.SuspendLayout();
            pnlMenuCirculation.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlSidebar.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            pnlMenuUser.SuspendLayout();
            pnlMenuInventory.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlMenuCatalog.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.menus;
            pictureBox1.Location = new Point(12, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = SystemColors.ControlDark;
            pnlMainContent.Controls.Add(ucDashboard1);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(250, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1654, 1020);
            pnlMainContent.TabIndex = 2;
            // 
            // ucDashboard1
            // 
            ucDashboard1.BackColor = SystemColors.ControlLight;
            ucDashboard1.Dock = DockStyle.Fill;
            ucDashboard1.Location = new Point(0, 0);
            ucDashboard1.Name = "ucDashboard1";
            ucDashboard1.Size = new Size(1654, 1020);
            ucDashboard1.TabIndex = 0;
            // 
            // pnlMenuCirculation
            // 
            pnlMenuCirculation.BackColor = Color.Transparent;
            pnlMenuCirculation.Controls.Add(btnCirculation);
            pnlMenuCirculation.Controls.Add(btnBorrow);
            pnlMenuCirculation.Controls.Add(btnReturn);
            pnlMenuCirculation.Controls.Add(btnPayment);
            pnlMenuCirculation.Controls.Add(btnReportDebt);
            pnlMenuCirculation.Dock = DockStyle.Top;
            pnlMenuCirculation.Location = new Point(0, 480);
            pnlMenuCirculation.Margin = new Padding(0);
            pnlMenuCirculation.Name = "pnlMenuCirculation";
            pnlMenuCirculation.Size = new Size(250, 200);
            pnlMenuCirculation.TabIndex = 0;
            pnlMenuCirculation.Tag = "180";
            // 
            // btnCirculation
            // 
            btnCirculation.FlatAppearance.BorderSize = 0;
            btnCirculation.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnCirculation.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnCirculation.FlatStyle = FlatStyle.Flat;
            btnCirculation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCirculation.ForeColor = SystemColors.HighlightText;
            btnCirculation.Image = Properties.Resources.circulation;
            btnCirculation.ImageAlign = ContentAlignment.MiddleLeft;
            btnCirculation.Location = new Point(0, 0);
            btnCirculation.Margin = new Padding(0);
            btnCirculation.Name = "btnCirculation";
            btnCirculation.Padding = new Padding(10, 0, 0, 0);
            btnCirculation.Size = new Size(250, 40);
            btnCirculation.TabIndex = 3;
            btnCirculation.Tag = "menu";
            btnCirculation.Text = "    Quản lý mượn trả";
            btnCirculation.TextAlign = ContentAlignment.MiddleLeft;
            btnCirculation.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCirculation.UseVisualStyleBackColor = true;
            btnCirculation.Click += btnMenuCirculation_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBorrow.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 12F);
            btnBorrow.ForeColor = SystemColors.HighlightText;
            btnBorrow.Image = Properties.Resources.borrow;
            btnBorrow.ImageAlign = ContentAlignment.MiddleLeft;
            btnBorrow.Location = new Point(0, 40);
            btnBorrow.Margin = new Padding(0);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Padding = new Padding(10, 0, 0, 0);
            btnBorrow.Size = new Size(250, 40);
            btnBorrow.TabIndex = 3;
            btnBorrow.Tag = "subItem";
            btnBorrow.Text = "    Quản lý Phiếu Mượn";
            btnBorrow.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrow.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBorrow.UseVisualStyleBackColor = false;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 12F);
            btnReturn.ForeColor = SystemColors.HighlightText;
            btnReturn.Image = Properties.Resources._return;
            btnReturn.ImageAlign = ContentAlignment.MiddleLeft;
            btnReturn.Location = new Point(0, 80);
            btnReturn.Margin = new Padding(0);
            btnReturn.Name = "btnReturn";
            btnReturn.Padding = new Padding(10, 0, 0, 0);
            btnReturn.Size = new Size(250, 40);
            btnReturn.TabIndex = 3;
            btnReturn.Tag = "subItem";
            btnReturn.Text = "    Xử lý Trả sách";
            btnReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnReturn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturn.UseVisualStyleBackColor = false;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnPayment.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Segoe UI", 12F);
            btnPayment.ForeColor = SystemColors.HighlightText;
            btnPayment.Image = Properties.Resources.overdue;
            btnPayment.ImageAlign = ContentAlignment.MiddleLeft;
            btnPayment.Location = new Point(0, 120);
            btnPayment.Margin = new Padding(0);
            btnPayment.Name = "btnPayment";
            btnPayment.Padding = new Padding(10, 0, 0, 0);
            btnPayment.Size = new Size(250, 40);
            btnPayment.TabIndex = 3;
            btnPayment.Tag = "subItem";
            btnPayment.Text = "    Quản lý Phiếu Thu";
            btnPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnPayment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPayment.UseVisualStyleBackColor = false;
            // 
            // btnReportDebt
            // 
            btnReportDebt.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnReportDebt.FlatAppearance.BorderSize = 0;
            btnReportDebt.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReportDebt.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReportDebt.FlatStyle = FlatStyle.Flat;
            btnReportDebt.Font = new Font("Segoe UI", 12F);
            btnReportDebt.ForeColor = SystemColors.HighlightText;
            btnReportDebt.Image = Properties.Resources.overdue;
            btnReportDebt.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportDebt.Location = new Point(0, 160);
            btnReportDebt.Margin = new Padding(0);
            btnReportDebt.Name = "btnReportDebt";
            btnReportDebt.Padding = new Padding(10, 0, 0, 0);
            btnReportDebt.Size = new Size(250, 40);
            btnReportDebt.TabIndex = 3;
            btnReportDebt.Tag = "subItem";
            btnReportDebt.Text = "    Báo cáo Nợ && Quá hạn";
            btnReportDebt.TextAlign = ContentAlignment.MiddleLeft;
            btnReportDebt.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportDebt.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(btnDashboard);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel1.Location = new Point(0, 80);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 40);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDashboard.ForeColor = SystemColors.HighlightText;
            btnDashboard.Image = Properties.Resources.activity;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Margin = new Padding(0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.Size = new Size(250, 40);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "    Tổng Quan";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(flowLayoutPanel3);
            pnlSidebar.Controls.Add(pnlMenuUser);
            pnlSidebar.Controls.Add(pnlMenuCirculation);
            pnlSidebar.Controls.Add(pnlMenuInventory);
            pnlSidebar.Controls.Add(flowLayoutPanel2);
            pnlSidebar.Controls.Add(pnlMenuCatalog);
            pnlSidebar.Controls.Add(flowLayoutPanel1);
            pnlSidebar.Controls.Add(panel1);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.GradientColors = new Color[]
    {
    Color.FromArgb(42, 42, 128),
    Color.FromArgb(191, 144, 205)
    };
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 1020);
            pnlSidebar.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Transparent;
            flowLayoutPanel3.Controls.Add(button2);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel3.Location = new Point(0, 840);
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(250, 40);
            flowLayoutPanel3.TabIndex = 9;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.ForeColor = SystemColors.HighlightText;
            button2.Image = Properties.Resources.activity;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 0);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Padding = new Padding(10, 0, 0, 0);
            button2.Size = new Size(250, 40);
            button2.TabIndex = 1;
            button2.Text = "    Báo cáo - Thống kê";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            // 
            // pnlMenuUser
            // 
            pnlMenuUser.BackColor = Color.Transparent;
            pnlMenuUser.Controls.Add(btnUserManagement);
            pnlMenuUser.Controls.Add(btnUsers);
            pnlMenuUser.Controls.Add(btnReaders);
            pnlMenuUser.Controls.Add(btnPermissions);
            pnlMenuUser.Dock = DockStyle.Top;
            pnlMenuUser.Location = new Point(0, 680);
            pnlMenuUser.Margin = new Padding(0);
            pnlMenuUser.Name = "pnlMenuUser";
            pnlMenuUser.Size = new Size(250, 160);
            pnlMenuUser.TabIndex = 11;
            pnlMenuUser.Tag = "180";
            // 
            // btnUserManagement
            // 
            btnUserManagement.FlatAppearance.BorderSize = 0;
            btnUserManagement.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnUserManagement.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Image = Properties.Resources.access;
            btnUserManagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.Location = new Point(0, 0);
            btnUserManagement.Margin = new Padding(0);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Padding = new Padding(10, 0, 0, 0);
            btnUserManagement.Size = new Size(250, 40);
            btnUserManagement.TabIndex = 4;
            btnUserManagement.Tag = "menu";
            btnUserManagement.Text = "    Quản lý Người dùng ";
            btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUserManagement.UseVisualStyleBackColor = true;
            btnUserManagement.Click += btnMenuUser_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnUsers.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUsers.ForeColor = Color.White;
            btnUsers.Image = Properties.Resources.user;
            btnUsers.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsers.Location = new Point(0, 40);
            btnUsers.Margin = new Padding(0);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(10, 0, 0, 0);
            btnUsers.Size = new Size(250, 40);
            btnUsers.TabIndex = 4;
            btnUsers.Tag = "subItem";
            btnUsers.Text = "    Quản lý Tài khoản";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsers.UseVisualStyleBackColor = false;
            // 
            // btnReaders
            // 
            btnReaders.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnReaders.FlatAppearance.BorderSize = 0;
            btnReaders.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReaders.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReaders.FlatStyle = FlatStyle.Flat;
            btnReaders.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReaders.ForeColor = Color.White;
            btnReaders.Image = Properties.Resources.reader;
            btnReaders.ImageAlign = ContentAlignment.MiddleLeft;
            btnReaders.Location = new Point(0, 80);
            btnReaders.Margin = new Padding(0);
            btnReaders.Name = "btnReaders";
            btnReaders.Padding = new Padding(10, 0, 0, 0);
            btnReaders.Size = new Size(250, 40);
            btnReaders.TabIndex = 4;
            btnReaders.Tag = "subItem";
            btnReaders.Text = "    Quản lý Độc giả";
            btnReaders.TextAlign = ContentAlignment.MiddleLeft;
            btnReaders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReaders.UseVisualStyleBackColor = false;
            // 
            // btnPermissions
            // 
            btnPermissions.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnPermissions.FlatAppearance.BorderSize = 0;
            btnPermissions.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnPermissions.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnPermissions.FlatStyle = FlatStyle.Flat;
            btnPermissions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPermissions.ForeColor = Color.White;
            btnPermissions.Image = Properties.Resources.card;
            btnPermissions.ImageAlign = ContentAlignment.MiddleLeft;
            btnPermissions.Location = new Point(0, 120);
            btnPermissions.Margin = new Padding(0);
            btnPermissions.Name = "btnPermissions";
            btnPermissions.Padding = new Padding(10, 0, 0, 0);
            btnPermissions.Size = new Size(250, 40);
            btnPermissions.TabIndex = 4;
            btnPermissions.Tag = "subItem";
            btnPermissions.Text = "    Quản lý Phân quyền";
            btnPermissions.TextAlign = ContentAlignment.MiddleLeft;
            btnPermissions.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPermissions.UseVisualStyleBackColor = false;
            // 
            // pnlMenuInventory
            // 
            pnlMenuInventory.BackColor = Color.Transparent;
            pnlMenuInventory.Controls.Add(btnInventory);
            pnlMenuInventory.Controls.Add(btnBookTitle);
            pnlMenuInventory.Controls.Add(btnBookStock);
            pnlMenuInventory.Controls.Add(btnImport);
            pnlMenuInventory.Dock = DockStyle.Top;
            pnlMenuInventory.FlowDirection = FlowDirection.TopDown;
            pnlMenuInventory.Location = new Point(0, 320);
            pnlMenuInventory.Margin = new Padding(0);
            pnlMenuInventory.Name = "pnlMenuInventory";
            pnlMenuInventory.Size = new Size(250, 160);
            pnlMenuInventory.TabIndex = 2;
            pnlMenuInventory.Tag = "200";
            // 
            // btnInventory
            // 
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnInventory.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInventory.ForeColor = SystemColors.HighlightText;
            btnInventory.Image = Properties.Resources.catalog;
            btnInventory.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventory.Location = new Point(0, 0);
            btnInventory.Margin = new Padding(0);
            btnInventory.Name = "btnInventory";
            btnInventory.Padding = new Padding(10, 0, 0, 0);
            btnInventory.Size = new Size(250, 40);
            btnInventory.TabIndex = 2;
            btnInventory.Tag = "menu";
            btnInventory.Text = "    Quản lý Kho && Sách";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnMenuInventory_Click;
            // 
            // btnBookTitle
            // 
            btnBookTitle.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnBookTitle.FlatAppearance.BorderSize = 0;
            btnBookTitle.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBookTitle.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBookTitle.FlatStyle = FlatStyle.Flat;
            btnBookTitle.Font = new Font("Segoe UI", 12F);
            btnBookTitle.ForeColor = SystemColors.HighlightText;
            btnBookTitle.Image = Properties.Resources.genre;
            btnBookTitle.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookTitle.Location = new Point(0, 40);
            btnBookTitle.Margin = new Padding(0);
            btnBookTitle.Name = "btnBookTitle";
            btnBookTitle.Padding = new Padding(10, 0, 0, 0);
            btnBookTitle.Size = new Size(250, 40);
            btnBookTitle.TabIndex = 3;
            btnBookTitle.Tag = "subItem";
            btnBookTitle.Text = "    Quản lý Tựa sách";
            btnBookTitle.TextAlign = ContentAlignment.MiddleLeft;
            btnBookTitle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBookTitle.UseVisualStyleBackColor = false;
            // 
            // btnBookStock
            // 
            btnBookStock.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnBookStock.FlatAppearance.BorderSize = 0;
            btnBookStock.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBookStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBookStock.FlatStyle = FlatStyle.Flat;
            btnBookStock.Font = new Font("Segoe UI", 12F);
            btnBookStock.ForeColor = SystemColors.HighlightText;
            btnBookStock.Image = Properties.Resources.author;
            btnBookStock.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookStock.Location = new Point(0, 80);
            btnBookStock.Margin = new Padding(0);
            btnBookStock.Name = "btnBookStock";
            btnBookStock.Padding = new Padding(10, 0, 0, 0);
            btnBookStock.Size = new Size(250, 40);
            btnBookStock.TabIndex = 4;
            btnBookStock.Tag = "subItem";
            btnBookStock.Text = "    Quản lý Sách && Tồn kho";
            btnBookStock.TextAlign = ContentAlignment.MiddleLeft;
            btnBookStock.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBookStock.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnImport.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 12F);
            btnImport.ForeColor = SystemColors.HighlightText;
            btnImport.Image = Properties.Resources.publisher;
            btnImport.ImageAlign = ContentAlignment.MiddleLeft;
            btnImport.Location = new Point(0, 120);
            btnImport.Margin = new Padding(0);
            btnImport.Name = "btnImport";
            btnImport.Padding = new Padding(10, 0, 0, 0);
            btnImport.Size = new Size(250, 40);
            btnImport.TabIndex = 5;
            btnImport.Tag = "subItem";
            btnImport.Text = "    Nhập sách";
            btnImport.TextAlign = ContentAlignment.MiddleLeft;
            btnImport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImport.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(btnLogout);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 980);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(250, 40);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.HighlightText;
            btnLogout.Image = Properties.Resources.logout;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 0);
            btnLogout.Margin = new Padding(0);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 0, 0);
            btnLogout.Size = new Size(250, 40);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "    Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // pnlMenuCatalog
            // 
            pnlMenuCatalog.BackColor = Color.Transparent;
            pnlMenuCatalog.Controls.Add(btnCatalog);
            pnlMenuCatalog.Controls.Add(btnGenre);
            pnlMenuCatalog.Controls.Add(btnAuthor);
            pnlMenuCatalog.Controls.Add(btnPublisher);
            pnlMenuCatalog.Controls.Add(btnSupplier);
            pnlMenuCatalog.Dock = DockStyle.Top;
            pnlMenuCatalog.Location = new Point(0, 120);
            pnlMenuCatalog.Margin = new Padding(0);
            pnlMenuCatalog.Name = "pnlMenuCatalog";
            pnlMenuCatalog.Size = new Size(250, 200);
            pnlMenuCatalog.TabIndex = 2;
            // 
            // btnCatalog
            // 
            btnCatalog.Dock = DockStyle.Top;
            btnCatalog.FlatAppearance.BorderSize = 0;
            btnCatalog.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnCatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnCatalog.FlatStyle = FlatStyle.Flat;
            btnCatalog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCatalog.ForeColor = SystemColors.HighlightText;
            btnCatalog.Image = Properties.Resources.catalog;
            btnCatalog.ImageAlign = ContentAlignment.MiddleLeft;
            btnCatalog.Location = new Point(0, 0);
            btnCatalog.Margin = new Padding(0);
            btnCatalog.Name = "btnCatalog";
            btnCatalog.Padding = new Padding(10, 0, 0, 0);
            btnCatalog.Size = new Size(250, 40);
            btnCatalog.TabIndex = 2;
            btnCatalog.Tag = "menu";
            btnCatalog.Text = "    Quản lý Danh mục";
            btnCatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnCatalog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCatalog.UseVisualStyleBackColor = true;
            btnCatalog.Click += btnMenuCatalog_Click;
            // 
            // btnGenre
            // 
            btnGenre.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnGenre.FlatAppearance.BorderSize = 0;
            btnGenre.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnGenre.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnGenre.FlatStyle = FlatStyle.Flat;
            btnGenre.Font = new Font("Segoe UI", 12F);
            btnGenre.ForeColor = SystemColors.HighlightText;
            btnGenre.Image = Properties.Resources.genre;
            btnGenre.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenre.Location = new Point(0, 40);
            btnGenre.Margin = new Padding(0);
            btnGenre.Name = "btnGenre";
            btnGenre.Padding = new Padding(10, 0, 0, 0);
            btnGenre.Size = new Size(250, 40);
            btnGenre.TabIndex = 3;
            btnGenre.Tag = "subItem";
            btnGenre.Text = "    Quản lý Thể loại";
            btnGenre.TextAlign = ContentAlignment.MiddleLeft;
            btnGenre.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGenre.UseVisualStyleBackColor = false;
            // 
            // btnAuthor
            // 
            btnAuthor.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnAuthor.FlatAppearance.BorderSize = 0;
            btnAuthor.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnAuthor.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnAuthor.FlatStyle = FlatStyle.Flat;
            btnAuthor.Font = new Font("Segoe UI", 12F);
            btnAuthor.ForeColor = SystemColors.HighlightText;
            btnAuthor.Image = Properties.Resources.author;
            btnAuthor.ImageAlign = ContentAlignment.MiddleLeft;
            btnAuthor.Location = new Point(0, 80);
            btnAuthor.Margin = new Padding(0);
            btnAuthor.Name = "btnAuthor";
            btnAuthor.Padding = new Padding(10, 0, 0, 0);
            btnAuthor.Size = new Size(250, 40);
            btnAuthor.TabIndex = 4;
            btnAuthor.Tag = "subItem";
            btnAuthor.Text = "    Quản lý Tác giả";
            btnAuthor.TextAlign = ContentAlignment.MiddleLeft;
            btnAuthor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAuthor.UseVisualStyleBackColor = false;
            // 
            // btnPublisher
            // 
            btnPublisher.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnPublisher.FlatAppearance.BorderSize = 0;
            btnPublisher.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnPublisher.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnPublisher.FlatStyle = FlatStyle.Flat;
            btnPublisher.Font = new Font("Segoe UI", 12F);
            btnPublisher.ForeColor = SystemColors.HighlightText;
            btnPublisher.Image = Properties.Resources.publisher;
            btnPublisher.ImageAlign = ContentAlignment.MiddleLeft;
            btnPublisher.Location = new Point(0, 120);
            btnPublisher.Margin = new Padding(0);
            btnPublisher.Name = "btnPublisher";
            btnPublisher.Padding = new Padding(10, 0, 0, 0);
            btnPublisher.Size = new Size(250, 40);
            btnPublisher.TabIndex = 5;
            btnPublisher.Tag = "subItem";
            btnPublisher.Text = "    Quản lý Nhà xuất bản";
            btnPublisher.TextAlign = ContentAlignment.MiddleLeft;
            btnPublisher.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPublisher.UseVisualStyleBackColor = false;
            // 
            // btnSupplier
            // 
            btnSupplier.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnSupplier.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Segoe UI", 12F);
            btnSupplier.ForeColor = SystemColors.HighlightText;
            btnSupplier.Image = Properties.Resources.publisher;
            btnSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplier.Location = new Point(0, 160);
            btnSupplier.Margin = new Padding(0);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Padding = new Padding(10, 0, 0, 0);
            btnSupplier.Size = new Size(250, 40);
            btnSupplier.TabIndex = 6;
            btnSupplier.Tag = "subItem";
            btnSupplier.Text = "    Quản lý Nhà cung cấp";
            btnSupplier.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplier.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupplier.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 80);
            panel1.TabIndex = 0;
            // 
            // menuCatalogTransition
            // 
            menuCatalogTransition.Interval = 10;
            menuCatalogTransition.Tick += menuCatalogTransition_Tick;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // menuInventoryTransition
            // 
            menuInventoryTransition.Interval = 10;
            menuInventoryTransition.Tick += menuInventoryTransition_Tick;
            // 
            // menuCirculationTransition
            // 
            menuCirculationTransition.Interval = 10;
            menuCirculationTransition.Tick += menuCirculationTransition_Tick;
            // 
            // menuUserTransition
            // 
            menuUserTransition.Interval = 10;
            menuUserTransition.Tick += menuUserTransition_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1020);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlMainContent.ResumeLayout(false);
            pnlMenuCirculation.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            pnlMenuUser.ResumeLayout(false);
            pnlMenuInventory.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            pnlMenuCatalog.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlMainContent;
        private UCBookTitle ucManageBook1;
        private UCBookTitle ucManageBook2;
        private UCBookTitle ucManageBook3;
        private Controls.GradientPanel pnlSidebar;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button btnDashboard;
        private PictureBox pictureBox1;
        private FlowLayoutPanel pnlMenuCatalog;
        private Button btnCatalog;
        private Button btnAuthor;
        private Button btnGenre;
        private Button btnPublisher;
        private System.Windows.Forms.Timer menuCatalogTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private FlowLayoutPanel pnlMenuCirculation;
        private Button btnCirculation;
        private Button btnBorrow;
        private Button btnReturn;
        private Button btnReportDebt;
        private Button btnLogout;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel pnlMenuUser;
        private Button btnReaders;
        private Button btnPermissions;
        private Button btnUsers;
        private Button btnUserManagement;
        private Button btnSupplier;
        private FlowLayoutPanel pnlMenuInventory;
        private Button btnInventory;
        private Button btnBookTitle;
        private Button btnBookStock;
        private Button btnImport;
        private Button btnPayment;
        private System.Windows.Forms.Timer menuInventoryTransition;
        private System.Windows.Forms.Timer menuCirculationTransition;
        private System.Windows.Forms.Timer menuUserTransition;
        private UCDashboard ucDashboard1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button2;
    }
}
