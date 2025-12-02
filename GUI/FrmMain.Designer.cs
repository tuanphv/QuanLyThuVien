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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            pictureBox1 = new PictureBox();
            btnBorrow = new Button();
            btnReturn = new Button();
            btnPayment = new Button();
            btnReportDebt = new Button();
            pnlSidebar = new GUI.Controls.GradientPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDashboard = new Button();
            btnGenre = new Button();
            btnAuthor = new Button();
            btnPublisher = new Button();
            btnSupplier = new Button();
            btnBookTitle = new Button();
            btnBookStock = new Button();
            btnImportBooks = new Button();
            btnUsers = new Button();
            btnReaders = new Button();
            btnPermissions = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnLogout = new Button();
            panel1 = new Panel();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            pnlMainContent = new Panel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSidebar.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.Transparent;
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBorrow.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBorrow.ForeColor = SystemColors.HighlightText;
            btnBorrow.Image = Properties.Resources.borrow;
            btnBorrow.ImageAlign = ContentAlignment.MiddleLeft;
            btnBorrow.Location = new Point(0, 320);
            btnBorrow.Margin = new Padding(0);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Padding = new Padding(10, 0, 0, 0);
            btnBorrow.Size = new Size(280, 40);
            btnBorrow.TabIndex = 3;
            btnBorrow.Tag = "subItem";
            btnBorrow.Text = "    Quản lý Phiếu Mượn";
            btnBorrow.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrow.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBorrow.UseVisualStyleBackColor = false;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.Transparent;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReturn.ForeColor = SystemColors.HighlightText;
            btnReturn.Image = Properties.Resources._return;
            btnReturn.ImageAlign = ContentAlignment.MiddleLeft;
            btnReturn.Location = new Point(0, 360);
            btnReturn.Margin = new Padding(0);
            btnReturn.Name = "btnReturn";
            btnReturn.Padding = new Padding(10, 0, 0, 0);
            btnReturn.Size = new Size(280, 40);
            btnReturn.TabIndex = 3;
            btnReturn.Tag = "subItem";
            btnReturn.Text = "    Xử lý Trả sách";
            btnReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnReturn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturn.UseVisualStyleBackColor = false;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.Transparent;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnPayment.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPayment.ForeColor = SystemColors.HighlightText;
            btnPayment.Image = Properties.Resources.overdue;
            btnPayment.ImageAlign = ContentAlignment.MiddleLeft;
            btnPayment.Location = new Point(0, 400);
            btnPayment.Margin = new Padding(0);
            btnPayment.Name = "btnPayment";
            btnPayment.Padding = new Padding(10, 0, 0, 0);
            btnPayment.Size = new Size(280, 40);
            btnPayment.TabIndex = 3;
            btnPayment.Tag = "subItem";
            btnPayment.Text = "    Quản lý Phiếu Thu";
            btnPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnPayment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPayment.UseVisualStyleBackColor = false;
            // 
            // btnReportDebt
            // 
            btnReportDebt.BackColor = Color.Transparent;
            btnReportDebt.FlatAppearance.BorderSize = 0;
            btnReportDebt.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReportDebt.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReportDebt.FlatStyle = FlatStyle.Flat;
            btnReportDebt.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReportDebt.ForeColor = SystemColors.HighlightText;
            btnReportDebt.Image = Properties.Resources.overdue;
            btnReportDebt.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportDebt.Location = new Point(0, 440);
            btnReportDebt.Margin = new Padding(0);
            btnReportDebt.Name = "btnReportDebt";
            btnReportDebt.Padding = new Padding(10, 0, 0, 0);
            btnReportDebt.Size = new Size(280, 40);
            btnReportDebt.TabIndex = 3;
            btnReportDebt.Tag = "subItem";
            btnReportDebt.Text = "    Báo cáo Nợ && Quá hạn";
            btnReportDebt.TextAlign = ContentAlignment.MiddleLeft;
            btnReportDebt.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportDebt.UseVisualStyleBackColor = false;
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(flowLayoutPanel1);
            pnlSidebar.Controls.Add(flowLayoutPanel2);
            pnlSidebar.Controls.Add(panel1);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.GradientColors = new Color[]
    {
    Color.FromArgb(114, 114, 230),
    Color.FromArgb(114, 114, 230)
    };
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(280, 791);
            pnlSidebar.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(btnDashboard);
            flowLayoutPanel1.Controls.Add(btnGenre);
            flowLayoutPanel1.Controls.Add(btnAuthor);
            flowLayoutPanel1.Controls.Add(btnPublisher);
            flowLayoutPanel1.Controls.Add(btnSupplier);
            flowLayoutPanel1.Controls.Add(btnBookTitle);
            flowLayoutPanel1.Controls.Add(btnBookStock);
            flowLayoutPanel1.Controls.Add(btnImportBooks);
            flowLayoutPanel1.Controls.Add(btnBorrow);
            flowLayoutPanel1.Controls.Add(btnReturn);
            flowLayoutPanel1.Controls.Add(btnPayment);
            flowLayoutPanel1.Controls.Add(btnReportDebt);
            flowLayoutPanel1.Controls.Add(btnUsers);
            flowLayoutPanel1.Controls.Add(btnReaders);
            flowLayoutPanel1.Controls.Add(btnPermissions);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 80);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(280, 661);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
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
            btnDashboard.Size = new Size(280, 40);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "    Báo cáo - Thống kê";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnGenre
            // 
            btnGenre.BackColor = Color.Transparent;
            btnGenre.FlatAppearance.BorderSize = 0;
            btnGenre.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnGenre.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnGenre.FlatStyle = FlatStyle.Flat;
            btnGenre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenre.ForeColor = SystemColors.HighlightText;
            btnGenre.Image = Properties.Resources.genre;
            btnGenre.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenre.Location = new Point(0, 40);
            btnGenre.Margin = new Padding(0);
            btnGenre.Name = "btnGenre";
            btnGenre.Padding = new Padding(10, 0, 0, 0);
            btnGenre.Size = new Size(280, 40);
            btnGenre.TabIndex = 3;
            btnGenre.Tag = "subItem";
            btnGenre.Text = "    Quản lý Thể loại";
            btnGenre.TextAlign = ContentAlignment.MiddleLeft;
            btnGenre.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGenre.UseVisualStyleBackColor = false;
            // 
            // btnAuthor
            // 
            btnAuthor.BackColor = Color.Transparent;
            btnAuthor.FlatAppearance.BorderSize = 0;
            btnAuthor.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnAuthor.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnAuthor.FlatStyle = FlatStyle.Flat;
            btnAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAuthor.ForeColor = SystemColors.HighlightText;
            btnAuthor.Image = Properties.Resources.author;
            btnAuthor.ImageAlign = ContentAlignment.MiddleLeft;
            btnAuthor.Location = new Point(0, 80);
            btnAuthor.Margin = new Padding(0);
            btnAuthor.Name = "btnAuthor";
            btnAuthor.Padding = new Padding(10, 0, 0, 0);
            btnAuthor.Size = new Size(280, 40);
            btnAuthor.TabIndex = 4;
            btnAuthor.Tag = "subItem";
            btnAuthor.Text = "    Quản lý Tác giả";
            btnAuthor.TextAlign = ContentAlignment.MiddleLeft;
            btnAuthor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAuthor.UseVisualStyleBackColor = false;
            // 
            // btnPublisher
            // 
            btnPublisher.BackColor = Color.Transparent;
            btnPublisher.FlatAppearance.BorderSize = 0;
            btnPublisher.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnPublisher.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnPublisher.FlatStyle = FlatStyle.Flat;
            btnPublisher.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPublisher.ForeColor = SystemColors.HighlightText;
            btnPublisher.Image = Properties.Resources.publisher;
            btnPublisher.ImageAlign = ContentAlignment.MiddleLeft;
            btnPublisher.Location = new Point(0, 120);
            btnPublisher.Margin = new Padding(0);
            btnPublisher.Name = "btnPublisher";
            btnPublisher.Padding = new Padding(10, 0, 0, 0);
            btnPublisher.Size = new Size(280, 40);
            btnPublisher.TabIndex = 5;
            btnPublisher.Tag = "subItem";
            btnPublisher.Text = "    Quản lý Nhà xuất bản";
            btnPublisher.TextAlign = ContentAlignment.MiddleLeft;
            btnPublisher.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPublisher.UseVisualStyleBackColor = false;
            // 
            // btnSupplier
            // 
            btnSupplier.BackColor = Color.Transparent;
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnSupplier.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSupplier.ForeColor = SystemColors.HighlightText;
            btnSupplier.Image = Properties.Resources.publisher;
            btnSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplier.Location = new Point(0, 160);
            btnSupplier.Margin = new Padding(0);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Padding = new Padding(10, 0, 0, 0);
            btnSupplier.Size = new Size(280, 40);
            btnSupplier.TabIndex = 6;
            btnSupplier.Tag = "subItem";
            btnSupplier.Text = "    Quản lý Nhà cung cấp";
            btnSupplier.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplier.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupplier.UseVisualStyleBackColor = false;
            // 
            // btnBookTitle
            // 
            btnBookTitle.BackColor = Color.Transparent;
            btnBookTitle.FlatAppearance.BorderSize = 0;
            btnBookTitle.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBookTitle.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBookTitle.FlatStyle = FlatStyle.Flat;
            btnBookTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBookTitle.ForeColor = SystemColors.HighlightText;
            btnBookTitle.Image = Properties.Resources.genre;
            btnBookTitle.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookTitle.Location = new Point(0, 200);
            btnBookTitle.Margin = new Padding(0);
            btnBookTitle.Name = "btnBookTitle";
            btnBookTitle.Padding = new Padding(10, 0, 0, 0);
            btnBookTitle.Size = new Size(280, 40);
            btnBookTitle.TabIndex = 3;
            btnBookTitle.Tag = "subItem";
            btnBookTitle.Text = "    Quản lý Tựa sách";
            btnBookTitle.TextAlign = ContentAlignment.MiddleLeft;
            btnBookTitle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBookTitle.UseVisualStyleBackColor = false;
            // 
            // btnBookStock
            // 
            btnBookStock.BackColor = Color.Transparent;
            btnBookStock.FlatAppearance.BorderSize = 0;
            btnBookStock.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBookStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBookStock.FlatStyle = FlatStyle.Flat;
            btnBookStock.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBookStock.ForeColor = SystemColors.HighlightText;
            btnBookStock.Image = Properties.Resources.author;
            btnBookStock.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookStock.Location = new Point(0, 240);
            btnBookStock.Margin = new Padding(0);
            btnBookStock.Name = "btnBookStock";
            btnBookStock.Padding = new Padding(10, 0, 0, 0);
            btnBookStock.Size = new Size(280, 40);
            btnBookStock.TabIndex = 4;
            btnBookStock.Tag = "subItem";
            btnBookStock.Text = "    Quản lý Sách && Tồn kho";
            btnBookStock.TextAlign = ContentAlignment.MiddleLeft;
            btnBookStock.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBookStock.UseVisualStyleBackColor = false;
            // 
            // btnImportBooks
            // 
            btnImportBooks.BackColor = Color.Transparent;
            btnImportBooks.FlatAppearance.BorderSize = 0;
            btnImportBooks.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnImportBooks.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnImportBooks.FlatStyle = FlatStyle.Flat;
            btnImportBooks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnImportBooks.ForeColor = SystemColors.HighlightText;
            btnImportBooks.Image = Properties.Resources.publisher;
            btnImportBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnImportBooks.Location = new Point(0, 280);
            btnImportBooks.Margin = new Padding(0);
            btnImportBooks.Name = "btnImportBooks";
            btnImportBooks.Padding = new Padding(10, 0, 0, 0);
            btnImportBooks.Size = new Size(280, 40);
            btnImportBooks.TabIndex = 5;
            btnImportBooks.Tag = "subItem";
            btnImportBooks.Text = "    Nhập sách";
            btnImportBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnImportBooks.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImportBooks.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.Transparent;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnUsers.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUsers.ForeColor = Color.White;
            btnUsers.Image = Properties.Resources.user;
            btnUsers.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsers.Location = new Point(0, 480);
            btnUsers.Margin = new Padding(0);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(10, 0, 0, 0);
            btnUsers.Size = new Size(280, 40);
            btnUsers.TabIndex = 4;
            btnUsers.Tag = "subItem";
            btnUsers.Text = "    Quản lý Tài khoản";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsers.UseVisualStyleBackColor = false;
            // 
            // btnReaders
            // 
            btnReaders.BackColor = Color.Transparent;
            btnReaders.FlatAppearance.BorderSize = 0;
            btnReaders.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReaders.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReaders.FlatStyle = FlatStyle.Flat;
            btnReaders.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReaders.ForeColor = Color.White;
            btnReaders.Image = Properties.Resources.reader;
            btnReaders.ImageAlign = ContentAlignment.MiddleLeft;
            btnReaders.Location = new Point(0, 520);
            btnReaders.Margin = new Padding(0);
            btnReaders.Name = "btnReaders";
            btnReaders.Padding = new Padding(10, 0, 0, 0);
            btnReaders.Size = new Size(280, 40);
            btnReaders.TabIndex = 4;
            btnReaders.Tag = "subItem";
            btnReaders.Text = "    Quản lý Độc giả";
            btnReaders.TextAlign = ContentAlignment.MiddleLeft;
            btnReaders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReaders.UseVisualStyleBackColor = false;
            // 
            // btnPermissions
            // 
            btnPermissions.BackColor = Color.Transparent;
            btnPermissions.FlatAppearance.BorderSize = 0;
            btnPermissions.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnPermissions.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnPermissions.FlatStyle = FlatStyle.Flat;
            btnPermissions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPermissions.ForeColor = Color.White;
            btnPermissions.Image = Properties.Resources.card;
            btnPermissions.ImageAlign = ContentAlignment.MiddleLeft;
            btnPermissions.Location = new Point(0, 560);
            btnPermissions.Margin = new Padding(0);
            btnPermissions.Name = "btnPermissions";
            btnPermissions.Padding = new Padding(10, 0, 0, 0);
            btnPermissions.Size = new Size(280, 40);
            btnPermissions.TabIndex = 4;
            btnPermissions.Tag = "subItem";
            btnPermissions.Text = "    Quản lý Phân quyền";
            btnPermissions.TextAlign = ContentAlignment.MiddleLeft;
            btnPermissions.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPermissions.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(btnLogout);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 741);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(280, 50);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.SlateBlue;
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
            btnLogout.Size = new Size(280, 50);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "    Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 80);
            panel1.TabIndex = 0;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = SystemColors.Window;
            pnlMainContent.BackgroundImage = Properties.Resources.loading;
            pnlMainContent.BackgroundImageLayout = ImageLayout.Center;
            pnlMainContent.Controls.Add(pictureBox2);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(280, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1260, 791);
            pnlMainContent.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.home_page;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1260, 791);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 791);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm Quản lý thư viện";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSidebar.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Controls.GradientPanel pnlSidebar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnAuthor;
        private Button btnGenre;
        private Button btnPublisher;
        private System.Windows.Forms.Timer sidebarTransition;
        private Button btnBorrow;
        private Button btnReturn;
        private Button btnReportDebt;
        private Button btnLogout;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnReaders;
        private Button btnPermissions;
        private Button btnUsers;
        private Button btnSupplier;
        private Button btnBookTitle;
        private Button btnBookStock;
        private Button btnImportBooks;
        private Button btnPayment;
        private Button btnDashboard;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlMainContent;
        private PictureBox pictureBox2;
    }
}
