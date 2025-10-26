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
            pnlHeader = new Panel();
            pictureBox1 = new PictureBox();
            pnlMainContent = new Panel();
            ucPlaceHolder1 = new UCPlaceHolder();
            pnlMenuCirculation = new FlowLayoutPanel();
            btnCirculation = new Button();
            btnBorrow = new Button();
            btnReturn = new Button();
            btnOverdue = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDashboard = new Button();
            pnlSidebar = new UI.UICustom.GradientPanel();
            pnlMenuUser = new FlowLayoutPanel();
            btnUser = new Button();
            btnReader = new Button();
            btnLibraryCard = new Button();
            btnAccount = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnLogout = new Button();
            pnlMenuCatalog = new FlowLayoutPanel();
            btnMenuCatalog = new Button();
            btnBook = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panel1 = new Panel();
            menuCatalogTransition = new System.Windows.Forms.Timer(components);
            sidebarTransition = new System.Windows.Forms.Timer(components);
            menuCirculationTransition = new System.Windows.Forms.Timer(components);
            menuUserTransition = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlMainContent.SuspendLayout();
            pnlMenuCirculation.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlMenuUser.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnlMenuCatalog.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(42, 42, 128);
            pnlHeader.Controls.Add(pictureBox1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1537, 50);
            pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.menus;
            pictureBox1.Location = new Point(17, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = SystemColors.ControlDark;
            pnlMainContent.Controls.Add(ucPlaceHolder1);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(250, 50);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1287, 834);
            pnlMainContent.TabIndex = 2;
            // 
            // ucPlaceHolder1
            // 
            ucPlaceHolder1.BackColor = Color.White;
            ucPlaceHolder1.Dock = DockStyle.Fill;
            ucPlaceHolder1.Location = new Point(0, 0);
            ucPlaceHolder1.Name = "ucPlaceHolder1";
            ucPlaceHolder1.Size = new Size(1287, 834);
            ucPlaceHolder1.TabIndex = 0;
            // 
            // pnlMenuCirculation
            // 
            pnlMenuCirculation.BackColor = Color.Transparent;
            pnlMenuCirculation.Controls.Add(btnCirculation);
            pnlMenuCirculation.Controls.Add(btnBorrow);
            pnlMenuCirculation.Controls.Add(btnReturn);
            pnlMenuCirculation.Controls.Add(btnOverdue);
            pnlMenuCirculation.Dock = DockStyle.Top;
            pnlMenuCirculation.Location = new Point(0, 330);
            pnlMenuCirculation.Name = "pnlMenuCirculation";
            pnlMenuCirculation.Size = new Size(250, 200);
            pnlMenuCirculation.TabIndex = 0;
            // 
            // btnCirculation
            // 
            btnCirculation.FlatAppearance.BorderSize = 0;
            btnCirculation.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnCirculation.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnCirculation.FlatStyle = FlatStyle.Flat;
            btnCirculation.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCirculation.ForeColor = SystemColors.HighlightText;
            btnCirculation.Image = Properties.Resources.circulation;
            btnCirculation.ImageAlign = ContentAlignment.MiddleLeft;
            btnCirculation.Location = new Point(0, 0);
            btnCirculation.Margin = new Padding(0);
            btnCirculation.Name = "btnCirculation";
            btnCirculation.Padding = new Padding(15, 0, 0, 0);
            btnCirculation.Size = new Size(250, 50);
            btnCirculation.TabIndex = 2;
            btnCirculation.Text = "   Quản lý mượn trả";
            btnCirculation.TextAlign = ContentAlignment.MiddleLeft;
            btnCirculation.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCirculation.UseVisualStyleBackColor = true;
            btnCirculation.Click += btnCirculation_Click;
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
            btnBorrow.Location = new Point(0, 50);
            btnBorrow.Margin = new Padding(0);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Padding = new Padding(15, 0, 0, 0);
            btnBorrow.Size = new Size(250, 50);
            btnBorrow.TabIndex = 2;
            btnBorrow.Text = "    Quản lý phiếu mượn";
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
            btnReturn.Location = new Point(0, 100);
            btnReturn.Margin = new Padding(0);
            btnReturn.Name = "btnReturn";
            btnReturn.Padding = new Padding(15, 0, 0, 0);
            btnReturn.Size = new Size(250, 50);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "    Quản lý phiếu trả";
            btnReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnReturn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturn.UseVisualStyleBackColor = false;
            // 
            // btnOverdue
            // 
            btnOverdue.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnOverdue.FlatAppearance.BorderSize = 0;
            btnOverdue.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnOverdue.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnOverdue.FlatStyle = FlatStyle.Flat;
            btnOverdue.Font = new Font("Segoe UI", 12F);
            btnOverdue.ForeColor = SystemColors.HighlightText;
            btnOverdue.Image = Properties.Resources.overdue;
            btnOverdue.ImageAlign = ContentAlignment.MiddleLeft;
            btnOverdue.Location = new Point(0, 150);
            btnOverdue.Margin = new Padding(0);
            btnOverdue.Name = "btnOverdue";
            btnOverdue.Padding = new Padding(15, 0, 0, 0);
            btnOverdue.Size = new Size(250, 50);
            btnOverdue.TabIndex = 2;
            btnOverdue.Text = "    Báo cáo quá hạn/phạt";
            btnOverdue.TextAlign = ContentAlignment.MiddleLeft;
            btnOverdue.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOverdue.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(btnDashboard);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel1.Location = new Point(0, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 50);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = SystemColors.HighlightText;
            btnDashboard.Image = Properties.Resources.activity;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Margin = new Padding(0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(250, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "   Tổng quan";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlSidebar
            // 
            pnlSidebar.Color1 = Color.FromArgb(42, 42, 128);
            pnlSidebar.Color2 = Color.FromArgb(191, 144, 205);
            pnlSidebar.Controls.Add(pnlMenuUser);
            pnlSidebar.Controls.Add(flowLayoutPanel2);
            pnlSidebar.Controls.Add(pnlMenuCirculation);
            pnlSidebar.Controls.Add(pnlMenuCatalog);
            pnlSidebar.Controls.Add(flowLayoutPanel1);
            pnlSidebar.Controls.Add(panel1);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 50);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 834);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenuUser
            // 
            pnlMenuUser.BackColor = Color.Transparent;
            pnlMenuUser.Controls.Add(btnUser);
            pnlMenuUser.Controls.Add(btnReader);
            pnlMenuUser.Controls.Add(btnLibraryCard);
            pnlMenuUser.Controls.Add(btnAccount);
            pnlMenuUser.Dock = DockStyle.Top;
            pnlMenuUser.Location = new Point(0, 530);
            pnlMenuUser.Name = "pnlMenuUser";
            pnlMenuUser.Size = new Size(250, 200);
            pnlMenuUser.TabIndex = 11;
            // 
            // btnUser
            // 
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.ForeColor = Color.White;
            btnUser.Image = Properties.Resources.access;
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Location = new Point(0, 0);
            btnUser.Margin = new Padding(0);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(15, 0, 0, 0);
            btnUser.Size = new Size(250, 50);
            btnUser.TabIndex = 0;
            btnUser.Text = "   Quản lý gười dùng ";
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnReader
            // 
            btnReader.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnReader.FlatAppearance.BorderSize = 0;
            btnReader.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnReader.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnReader.FlatStyle = FlatStyle.Flat;
            btnReader.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReader.ForeColor = Color.White;
            btnReader.Image = Properties.Resources.reader;
            btnReader.ImageAlign = ContentAlignment.MiddleLeft;
            btnReader.Location = new Point(0, 50);
            btnReader.Margin = new Padding(0);
            btnReader.Name = "btnReader";
            btnReader.Padding = new Padding(15, 0, 0, 0);
            btnReader.Size = new Size(250, 50);
            btnReader.TabIndex = 0;
            btnReader.Text = "    Quản lý độc giả";
            btnReader.TextAlign = ContentAlignment.MiddleLeft;
            btnReader.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReader.UseVisualStyleBackColor = false;
            // 
            // btnLibraryCard
            // 
            btnLibraryCard.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnLibraryCard.FlatAppearance.BorderSize = 0;
            btnLibraryCard.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnLibraryCard.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnLibraryCard.FlatStyle = FlatStyle.Flat;
            btnLibraryCard.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLibraryCard.ForeColor = Color.White;
            btnLibraryCard.Image = Properties.Resources.card;
            btnLibraryCard.ImageAlign = ContentAlignment.MiddleLeft;
            btnLibraryCard.Location = new Point(0, 100);
            btnLibraryCard.Margin = new Padding(0);
            btnLibraryCard.Name = "btnLibraryCard";
            btnLibraryCard.Padding = new Padding(15, 0, 0, 0);
            btnLibraryCard.Size = new Size(250, 50);
            btnLibraryCard.TabIndex = 0;
            btnLibraryCard.Text = "    Quản lý thẻ thư viện";
            btnLibraryCard.TextAlign = ContentAlignment.MiddleLeft;
            btnLibraryCard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLibraryCard.UseVisualStyleBackColor = false;
            // 
            // btnAccount
            // 
            btnAccount.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnAccount.FlatAppearance.BorderSize = 0;
            btnAccount.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnAccount.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAccount.ForeColor = Color.White;
            btnAccount.Image = Properties.Resources.user;
            btnAccount.ImageAlign = ContentAlignment.MiddleLeft;
            btnAccount.Location = new Point(0, 150);
            btnAccount.Margin = new Padding(0);
            btnAccount.Name = "btnAccount";
            btnAccount.Padding = new Padding(15, 0, 0, 0);
            btnAccount.Size = new Size(250, 50);
            btnAccount.TabIndex = 0;
            btnAccount.Text = "    Quản lý tài khoản";
            btnAccount.TextAlign = ContentAlignment.MiddleLeft;
            btnAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAccount.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(btnLogout);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 784);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(250, 50);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.HighlightText;
            btnLogout.Image = Properties.Resources.logout;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 0);
            btnLogout.Margin = new Padding(0);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(250, 50);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "   Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // pnlMenuCatalog
            // 
            pnlMenuCatalog.BackColor = Color.Transparent;
            pnlMenuCatalog.Controls.Add(btnMenuCatalog);
            pnlMenuCatalog.Controls.Add(btnBook);
            pnlMenuCatalog.Controls.Add(button3);
            pnlMenuCatalog.Controls.Add(button4);
            pnlMenuCatalog.Controls.Add(button5);
            pnlMenuCatalog.Dock = DockStyle.Top;
            pnlMenuCatalog.Location = new Point(0, 80);
            pnlMenuCatalog.Name = "pnlMenuCatalog";
            pnlMenuCatalog.Size = new Size(250, 250);
            pnlMenuCatalog.TabIndex = 2;
            // 
            // btnMenuCatalog
            // 
            btnMenuCatalog.FlatAppearance.BorderSize = 0;
            btnMenuCatalog.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnMenuCatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnMenuCatalog.FlatStyle = FlatStyle.Flat;
            btnMenuCatalog.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenuCatalog.ForeColor = SystemColors.HighlightText;
            btnMenuCatalog.Image = Properties.Resources.catalog;
            btnMenuCatalog.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuCatalog.Location = new Point(0, 0);
            btnMenuCatalog.Margin = new Padding(0);
            btnMenuCatalog.Name = "btnMenuCatalog";
            btnMenuCatalog.Padding = new Padding(15, 0, 0, 0);
            btnMenuCatalog.Size = new Size(250, 50);
            btnMenuCatalog.TabIndex = 1;
            btnMenuCatalog.Text = "   Danh mục sách";
            btnMenuCatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuCatalog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuCatalog.UseVisualStyleBackColor = true;
            btnMenuCatalog.Click += btnMenuCatalog_Click;
            // 
            // btnBook
            // 
            btnBook.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            btnBook.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnBook.FlatStyle = FlatStyle.Flat;
            btnBook.Font = new Font("Segoe UI", 12F);
            btnBook.ForeColor = SystemColors.HighlightText;
            btnBook.Image = Properties.Resources.books;
            btnBook.ImageAlign = ContentAlignment.MiddleLeft;
            btnBook.Location = new Point(0, 50);
            btnBook.Margin = new Padding(0);
            btnBook.Name = "btnBook";
            btnBook.Padding = new Padding(15, 0, 0, 0);
            btnBook.Size = new Size(250, 50);
            btnBook.TabIndex = 1;
            btnBook.Text = "    Quản lý sách";
            btnBook.TextAlign = ContentAlignment.MiddleLeft;
            btnBook.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBook.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(50, 0, 0, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F);
            button3.ForeColor = SystemColors.HighlightText;
            button3.Image = Properties.Resources.author;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 100);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Padding = new Padding(15, 0, 0, 0);
            button3.Size = new Size(250, 50);
            button3.TabIndex = 1;
            button3.Text = "    Quản lý tác giả";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(50, 0, 0, 0);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F);
            button4.ForeColor = SystemColors.HighlightText;
            button4.Image = Properties.Resources.genre;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, 150);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Padding = new Padding(15, 0, 0, 0);
            button4.Size = new Size(250, 50);
            button4.TabIndex = 1;
            button4.Text = "    Quản lý thể loại";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(50, 0, 0, 0);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 255, 255, 255);
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F);
            button5.ForeColor = SystemColors.HighlightText;
            button5.Image = Properties.Resources.publisher;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(0, 200);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Padding = new Padding(15, 0, 0, 0);
            button5.Size = new Size(250, 50);
            button5.TabIndex = 1;
            button5.Text = "    Quản lý NXB";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 30);
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
            ClientSize = new Size(1537, 884);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlMainContent.ResumeLayout(false);
            pnlMenuCirculation.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            pnlMenuUser.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            pnlMenuCatalog.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlMainContent;
        private UCManageBook ucManageBook1;
        private UCManageBook ucManageBook2;
        private UCManageBook ucManageBook3;
        private UI.UICustom.GradientPanel pnlSidebar;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button btnDashboard;
        private PictureBox pictureBox1;
        private FlowLayoutPanel pnlMenuCatalog;
        private Button btnMenuCatalog;
        private Button btnBook;
        private Button button3;
        private Button button4;
        private Button button5;
        private System.Windows.Forms.Timer menuCatalogTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private FlowLayoutPanel pnlMenuCirculation;
        private Button btnCirculation;
        private Button btnBorrow;
        private Button btnReturn;
        private Button btnOverdue;
        private System.Windows.Forms.Timer menuCirculationTransition;
        private Button btnLogout;
        private UCPlaceHolder ucPlaceHolder1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel pnlMenuUser;
        private Button btnReader;
        private Button btnLibraryCard;
        private Button btnAccount;
        private Button btnUser;
        private System.Windows.Forms.Timer menuUserTransition;
    }
}
