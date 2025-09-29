namespace UI
{
    partial class FrmMain
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
            pnlSidebar = new Panel();
            btnLogout = new Button();
            btnReports = new Button();
            btnBorrowReturn = new Button();
            btnGenrePublisher = new Button();
            btnBooks = new Button();
            btnReaders = new Button();
            btnOverview = new Button();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            lblHeaderTitle = new Label();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.WhiteSmoke;
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnBorrowReturn);
            pnlSidebar.Controls.Add(btnGenrePublisher);
            pnlSidebar.Controls.Add(btnBooks);
            pnlSidebar.Controls.Add(btnReaders);
            pnlSidebar.Controls.Add(btnOverview);
            pnlSidebar.Controls.Add(panel2);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 757);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Crimson;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.Window;
            btnLogout.Location = new Point(0, 722);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(230, 35);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.FromArgb(52, 73, 94);
            btnReports.Location = new Point(0, 300);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(230, 40);
            btnReports.TabIndex = 6;
            btnReports.Text = "Báo cáo thống kê";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseMnemonic = false;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnBorrowReturn
            // 
            btnBorrowReturn.Dock = DockStyle.Top;
            btnBorrowReturn.FlatAppearance.BorderSize = 0;
            btnBorrowReturn.FlatStyle = FlatStyle.Flat;
            btnBorrowReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBorrowReturn.ForeColor = Color.FromArgb(52, 73, 94);
            btnBorrowReturn.Location = new Point(0, 260);
            btnBorrowReturn.Name = "btnBorrowReturn";
            btnBorrowReturn.Padding = new Padding(20, 0, 0, 0);
            btnBorrowReturn.Size = new Size(230, 40);
            btnBorrowReturn.TabIndex = 5;
            btnBorrowReturn.Text = "Mượn - Trả sách";
            btnBorrowReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrowReturn.UseMnemonic = false;
            btnBorrowReturn.UseVisualStyleBackColor = true;
            btnBorrowReturn.Click += btnBorrowReturn_Click;
            // 
            // btnGenrePublisher
            // 
            btnGenrePublisher.Dock = DockStyle.Top;
            btnGenrePublisher.FlatAppearance.BorderSize = 0;
            btnGenrePublisher.FlatStyle = FlatStyle.Flat;
            btnGenrePublisher.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenrePublisher.ForeColor = Color.FromArgb(52, 73, 94);
            btnGenrePublisher.Location = new Point(0, 220);
            btnGenrePublisher.Name = "btnGenrePublisher";
            btnGenrePublisher.Padding = new Padding(20, 0, 0, 0);
            btnGenrePublisher.Size = new Size(230, 40);
            btnGenrePublisher.TabIndex = 4;
            btnGenrePublisher.Text = "Thể loại - NXB";
            btnGenrePublisher.TextAlign = ContentAlignment.MiddleLeft;
            btnGenrePublisher.UseMnemonic = false;
            btnGenrePublisher.UseVisualStyleBackColor = true;
            btnGenrePublisher.Click += btnGenrePublisher_Click;
            // 
            // btnBooks
            // 
            btnBooks.Dock = DockStyle.Top;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBooks.ForeColor = Color.FromArgb(52, 73, 94);
            btnBooks.Location = new Point(0, 180);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(20, 0, 0, 0);
            btnBooks.Size = new Size(230, 40);
            btnBooks.TabIndex = 3;
            btnBooks.Text = "Sách";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.UseMnemonic = false;
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnReaders
            // 
            btnReaders.Dock = DockStyle.Top;
            btnReaders.FlatAppearance.BorderSize = 0;
            btnReaders.FlatStyle = FlatStyle.Flat;
            btnReaders.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReaders.ForeColor = Color.FromArgb(52, 73, 94);
            btnReaders.Location = new Point(0, 140);
            btnReaders.Name = "btnReaders";
            btnReaders.Padding = new Padding(20, 0, 0, 0);
            btnReaders.Size = new Size(230, 40);
            btnReaders.TabIndex = 2;
            btnReaders.Text = "Độc giả";
            btnReaders.TextAlign = ContentAlignment.MiddleLeft;
            btnReaders.UseMnemonic = false;
            btnReaders.UseVisualStyleBackColor = true;
            btnReaders.Click += btnReaders_Click;
            // 
            // btnOverview
            // 
            btnOverview.Dock = DockStyle.Top;
            btnOverview.FlatAppearance.BorderSize = 0;
            btnOverview.FlatStyle = FlatStyle.Flat;
            btnOverview.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOverview.ForeColor = Color.FromArgb(52, 73, 94);
            btnOverview.Location = new Point(0, 100);
            btnOverview.Name = "btnOverview";
            btnOverview.Padding = new Padding(20, 0, 0, 0);
            btnOverview.Size = new Size(230, 40);
            btnOverview.TabIndex = 1;
            btnOverview.Text = "Tổng quan";
            btnOverview.TextAlign = ContentAlignment.MiddleLeft;
            btnOverview.UseMnemonic = false;
            btnOverview.UseVisualStyleBackColor = true;
            btnOverview.Click += btnOverview_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 100);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(27, 7);
            label1.Name = "label1";
            label1.Size = new Size(171, 90);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ\r\nTHƯ VIỆN";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(lblHeaderTitle);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(230, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(921, 52);
            panel3.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.BackColor = Color.Transparent;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.DarkSlateBlue;
            lblHeaderTitle.Location = new Point(20, 9);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(138, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Tổng quan";
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.Location = new Point(230, 52);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(921, 705);
            pnlContent.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 757);
            Controls.Add(pnlContent);
            Controls.Add(panel3);
            Controls.Add(pnlSidebar);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FrmMain_Load;
            pnlSidebar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnReports;
        private Button btnBorrowReturn;
        private Button btnGenrePublisher;
        private Button btnBooks;
        private Button btnReaders;
        private Button btnOverview;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button btnLogout;
        private Label lblHeaderTitle;
        private Panel pnlContent;
    }
}