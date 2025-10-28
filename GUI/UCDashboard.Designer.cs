namespace GUI
{
    partial class UCDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            roundedPanel1 = new GUI.Controls.RoundPanel();
            lblTotalBooks = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            roundedPanel2 = new GUI.Controls.RoundPanel();
            lblTotalBooksBorrow = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            roundedPanel3 = new GUI.Controls.RoundPanel();
            lblTotalReaders = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            roundedPanel4 = new GUI.Controls.RoundPanel();
            lblTotalDebt = new Label();
            label5 = new Label();
            pictureBox4 = new PictureBox();
            roundedPanel5 = new GUI.Controls.RoundPanel();
            panel8 = new Panel();
            metricPanel4 = new GUI.Controls.MetricPanel();
            label10 = new Label();
            panel6 = new Panel();
            metricPanel2 = new GUI.Controls.MetricPanel();
            label8 = new Label();
            label6 = new Label();
            panel4 = new Panel();
            lblBorrowCount1 = new GUI.Controls.MetricPanel();
            lblBookBorrow1 = new Label();
            panel7 = new Panel();
            metricPanel3 = new GUI.Controls.MetricPanel();
            label9 = new Label();
            panel5 = new Panel();
            metricPanel1 = new GUI.Controls.MetricPanel();
            label7 = new Label();
            roundedPanel6 = new GUI.Controls.RoundPanel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            roundPanel1 = new GUI.Controls.RoundPanel();
            label13 = new Label();
            panel11 = new Panel();
            metricPanel7 = new GUI.Controls.MetricPanel();
            label14 = new Label();
            panel12 = new Panel();
            metricPanel8 = new GUI.Controls.MetricPanel();
            label15 = new Label();
            panel13 = new Panel();
            metricPanel9 = new GUI.Controls.MetricPanel();
            label16 = new Label();
            panel1.SuspendLayout();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            roundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            roundedPanel5.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            roundPanel1.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1670, 70);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(157, 37);
            label1.TabIndex = 0;
            label1.Text = "Tổng Quan";
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.White;
            roundedPanel1.BorderRadius = 10;
            roundedPanel1.Controls.Add(lblTotalBooks);
            roundedPanel1.Controls.Add(label2);
            roundedPanel1.Controls.Add(pictureBox1);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.Location = new Point(20, 20);
            roundedPanel1.Margin = new Padding(10);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(252, 110);
            roundedPanel1.TabIndex = 1;
            // 
            // lblTotalBooks
            // 
            lblTotalBooks.AutoSize = true;
            lblTotalBooks.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBooks.Location = new Point(20, 43);
            lblTotalBooks.Margin = new Padding(20, 0, 0, 20);
            lblTotalBooks.Name = "lblTotalBooks";
            lblTotalBooks.Size = new Size(65, 37);
            lblTotalBooks.TabIndex = 2;
            lblTotalBooks.Text = "100";
            lblTotalBooks.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(20, 20);
            label2.Margin = new Padding(20, 20, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 1;
            label2.Text = "Tổng Sách";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources._002_book_stack;
            pictureBox1.Location = new Point(182, 25);
            pictureBox1.Margin = new Padding(0, 25, 20, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.White;
            roundedPanel2.BorderRadius = 10;
            roundedPanel2.Controls.Add(lblTotalBooksBorrow);
            roundedPanel2.Controls.Add(label3);
            roundedPanel2.Controls.Add(pictureBox2);
            roundedPanel2.Dock = DockStyle.Fill;
            roundedPanel2.Location = new Point(292, 20);
            roundedPanel2.Margin = new Padding(10);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(252, 110);
            roundedPanel2.TabIndex = 1;
            // 
            // lblTotalBooksBorrow
            // 
            lblTotalBooksBorrow.AutoSize = true;
            lblTotalBooksBorrow.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBooksBorrow.Location = new Point(20, 43);
            lblTotalBooksBorrow.Margin = new Padding(20, 0, 0, 20);
            lblTotalBooksBorrow.Name = "lblTotalBooksBorrow";
            lblTotalBooksBorrow.Size = new Size(49, 37);
            lblTotalBooksBorrow.TabIndex = 2;
            lblTotalBooksBorrow.Text = "36";
            lblTotalBooksBorrow.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(20, 20);
            label3.Margin = new Padding(20, 20, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(130, 21);
            label3.TabIndex = 1;
            label3.Text = "Sách Đang Mượn";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources._003_inventory;
            pictureBox2.Location = new Point(182, 25);
            pictureBox2.Margin = new Padding(0, 25, 20, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.White;
            roundedPanel3.BorderRadius = 10;
            roundedPanel3.Controls.Add(lblTotalReaders);
            roundedPanel3.Controls.Add(label4);
            roundedPanel3.Controls.Add(pictureBox3);
            roundedPanel3.Dock = DockStyle.Fill;
            roundedPanel3.Location = new Point(564, 20);
            roundedPanel3.Margin = new Padding(10);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(252, 110);
            roundedPanel3.TabIndex = 1;
            // 
            // lblTotalReaders
            // 
            lblTotalReaders.AutoSize = true;
            lblTotalReaders.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalReaders.Location = new Point(20, 43);
            lblTotalReaders.Margin = new Padding(20, 0, 0, 20);
            lblTotalReaders.Name = "lblTotalReaders";
            lblTotalReaders.Size = new Size(49, 37);
            lblTotalReaders.TabIndex = 2;
            lblTotalReaders.Text = "50";
            lblTotalReaders.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(20, 20);
            label4.Margin = new Padding(20, 20, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 1;
            label4.Text = "Tổng Độc giả";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources._005_reader_1;
            pictureBox3.Location = new Point(182, 25);
            pictureBox3.Margin = new Padding(0, 25, 20, 25);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // roundedPanel4
            // 
            roundedPanel4.BackColor = Color.White;
            roundedPanel4.BorderRadius = 10;
            roundedPanel4.Controls.Add(lblTotalDebt);
            roundedPanel4.Controls.Add(label5);
            roundedPanel4.Controls.Add(pictureBox4);
            roundedPanel4.Dock = DockStyle.Fill;
            roundedPanel4.Location = new Point(836, 20);
            roundedPanel4.Margin = new Padding(10);
            roundedPanel4.Name = "roundedPanel4";
            roundedPanel4.Size = new Size(254, 110);
            roundedPanel4.TabIndex = 1;
            // 
            // lblTotalDebt
            // 
            lblTotalDebt.AutoSize = true;
            lblTotalDebt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDebt.ForeColor = Color.Black;
            lblTotalDebt.Location = new Point(20, 43);
            lblTotalDebt.Margin = new Padding(20, 0, 0, 20);
            lblTotalDebt.Name = "lblTotalDebt";
            lblTotalDebt.Size = new Size(120, 37);
            lblTotalDebt.TabIndex = 2;
            lblTotalDebt.Text = "999,999";
            lblTotalDebt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(20, 20);
            label5.Margin = new Padding(20, 20, 0, 0);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 1;
            label5.Text = "Tổng Nợ";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources._006_coin;
            pictureBox4.Location = new Point(184, 25);
            pictureBox4.Margin = new Padding(0, 25, 20, 25);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // roundedPanel5
            // 
            roundedPanel5.BackColor = Color.White;
            roundedPanel5.BorderRadius = 10;
            roundedPanel5.Controls.Add(panel8);
            roundedPanel5.Controls.Add(panel6);
            roundedPanel5.Controls.Add(label6);
            roundedPanel5.Controls.Add(panel4);
            roundedPanel5.Controls.Add(panel7);
            roundedPanel5.Controls.Add(panel5);
            roundedPanel5.Location = new Point(10, 20);
            roundedPanel5.Margin = new Padding(0);
            roundedPanel5.Name = "roundedPanel5";
            roundedPanel5.Padding = new Padding(20);
            roundedPanel5.Size = new Size(540, 380);
            roundedPanel5.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Azure;
            panel8.Controls.Add(metricPanel4);
            panel8.Controls.Add(label10);
            panel8.Location = new Point(20, 250);
            panel8.Margin = new Padding(0, 10, 0, 20);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(10, 0, 10, 0);
            panel8.Size = new Size(500, 50);
            panel8.TabIndex = 3;
            // 
            // metricPanel4
            // 
            metricPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel4.AutoSize = true;
            metricPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel4.BackColor = Color.FromArgb(184, 223, 255);
            metricPanel4.BorderRadius = 15;
            metricPanel4.Location = new Point(406, 9);
            metricPanel4.Margin = new Padding(0, 9, 0, 0);
            metricPanel4.Name = "metricPanel4";
            metricPanel4.Padding = new Padding(10, 5, 10, 5);
            metricPanel4.Size = new Size(84, 31);
            metricPanel4.TabIndex = 4;
            metricPanel4.TextValue = "15 lượt";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(10, 15);
            label10.Margin = new Padding(0, 15, 0, 0);
            label10.Name = "label10";
            label10.Size = new Size(120, 21);
            label10.TabIndex = 0;
            label10.Text = "Cơ sở lập trình";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Azure;
            panel6.Controls.Add(metricPanel2);
            panel6.Controls.Add(label8);
            panel6.Location = new Point(20, 310);
            panel6.Margin = new Padding(0, 10, 0, 0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(10, 0, 10, 0);
            panel6.Size = new Size(500, 50);
            panel6.TabIndex = 3;
            // 
            // metricPanel2
            // 
            metricPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel2.AutoSize = true;
            metricPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel2.BackColor = Color.FromArgb(184, 223, 255);
            metricPanel2.BorderRadius = 15;
            metricPanel2.Location = new Point(406, 9);
            metricPanel2.Margin = new Padding(0, 9, 0, 0);
            metricPanel2.Name = "metricPanel2";
            metricPanel2.Padding = new Padding(10, 5, 10, 5);
            metricPanel2.Size = new Size(84, 31);
            metricPanel2.TabIndex = 4;
            metricPanel2.TextValue = "15 lượt";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 15);
            label8.Margin = new Padding(0, 15, 0, 0);
            label8.Name = "label8";
            label8.Size = new Size(99, 21);
            label8.TabIndex = 0;
            label8.Text = "Toán rời rạc";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(20, 20);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(212, 32);
            label6.TabIndex = 2;
            label6.Text = "Mượn nhiều nhẩt";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Azure;
            panel4.Controls.Add(lblBorrowCount1);
            panel4.Controls.Add(lblBookBorrow1);
            panel4.Location = new Point(20, 70);
            panel4.Margin = new Padding(0, 10, 0, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10, 0, 10, 0);
            panel4.Size = new Size(500, 50);
            panel4.TabIndex = 3;
            // 
            // lblBorrowCount1
            // 
            lblBorrowCount1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBorrowCount1.AutoSize = true;
            lblBorrowCount1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            lblBorrowCount1.BackColor = Color.FromArgb(184, 223, 255);
            lblBorrowCount1.BorderRadius = 15;
            lblBorrowCount1.Location = new Point(406, 9);
            lblBorrowCount1.Margin = new Padding(0, 9, 0, 0);
            lblBorrowCount1.Name = "lblBorrowCount1";
            lblBorrowCount1.Padding = new Padding(10, 5, 10, 5);
            lblBorrowCount1.Size = new Size(84, 31);
            lblBorrowCount1.TabIndex = 4;
            lblBorrowCount1.TextValue = "15 lượt";
            // 
            // lblBookBorrow1
            // 
            lblBookBorrow1.AutoSize = true;
            lblBookBorrow1.BackColor = Color.Transparent;
            lblBookBorrow1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookBorrow1.Location = new Point(10, 15);
            lblBookBorrow1.Margin = new Padding(0, 15, 0, 0);
            lblBookBorrow1.Name = "lblBookBorrow1";
            lblBookBorrow1.Size = new Size(183, 21);
            lblBookBorrow1.TabIndex = 0;
            lblBookBorrow1.Text = "Cơ sở dữ liệu nâng cao";
            lblBookBorrow1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Azure;
            panel7.Controls.Add(metricPanel3);
            panel7.Controls.Add(label9);
            panel7.Location = new Point(20, 190);
            panel7.Margin = new Padding(0, 10, 0, 0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 0, 10, 0);
            panel7.Size = new Size(500, 50);
            panel7.TabIndex = 3;
            // 
            // metricPanel3
            // 
            metricPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel3.AutoSize = true;
            metricPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel3.BackColor = Color.FromArgb(184, 223, 255);
            metricPanel3.BorderRadius = 15;
            metricPanel3.Location = new Point(406, 9);
            metricPanel3.Margin = new Padding(0, 9, 0, 0);
            metricPanel3.Name = "metricPanel3";
            metricPanel3.Padding = new Padding(10, 5, 10, 5);
            metricPanel3.Size = new Size(84, 31);
            metricPanel3.TabIndex = 4;
            metricPanel3.TextValue = "15 lượt";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(10, 15);
            label9.Margin = new Padding(0, 15, 0, 0);
            label9.Name = "label9";
            label9.Size = new Size(140, 21);
            label9.TabIndex = 0;
            label9.Text = "Đại số tuyến tính";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Azure;
            panel5.Controls.Add(metricPanel1);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(20, 130);
            panel5.Margin = new Padding(0, 10, 0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10, 0, 10, 0);
            panel5.Size = new Size(500, 50);
            panel5.TabIndex = 3;
            // 
            // metricPanel1
            // 
            metricPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel1.AutoSize = true;
            metricPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel1.BackColor = Color.FromArgb(184, 223, 255);
            metricPanel1.BorderRadius = 15;
            metricPanel1.Location = new Point(406, 9);
            metricPanel1.Margin = new Padding(0, 9, 0, 0);
            metricPanel1.Name = "metricPanel1";
            metricPanel1.Padding = new Padding(10, 5, 10, 5);
            metricPanel1.Size = new Size(84, 31);
            metricPanel1.TabIndex = 4;
            metricPanel1.TextValue = "15 lượt";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(10, 15);
            label7.Margin = new Padding(0, 15, 0, 0);
            label7.Name = "label7";
            label7.Size = new Size(137, 21);
            label7.TabIndex = 0;
            label7.Text = "Lập trình Python";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roundedPanel6
            // 
            roundedPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel6.BackColor = Color.White;
            roundedPanel6.BorderRadius = 10;
            roundedPanel6.Location = new Point(20, 150);
            roundedPanel6.Margin = new Padding(20, 10, 10, 20);
            roundedPanel6.Name = "roundedPanel6";
            roundedPanel6.Size = new Size(1070, 760);
            roundedPanel6.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(roundedPanel6);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 70);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1100, 930);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(roundedPanel4, 3, 0);
            tableLayoutPanel1.Controls.Add(roundedPanel3, 2, 0);
            tableLayoutPanel1.Controls.Add(roundedPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(roundedPanel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 10, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1100, 140);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(roundPanel1);
            panel3.Controls.Add(roundedPanel5);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1100, 70);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 20, 20, 10);
            panel3.Size = new Size(570, 930);
            panel3.TabIndex = 3;
            // 
            // roundPanel1
            // 
            roundPanel1.BackColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.Controls.Add(label13);
            roundPanel1.Controls.Add(panel11);
            roundPanel1.Controls.Add(panel12);
            roundPanel1.Controls.Add(panel13);
            roundPanel1.Location = new Point(10, 420);
            roundPanel1.Margin = new Padding(0, 20, 0, 0);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Padding = new Padding(20);
            roundPanel1.Size = new Size(540, 260);
            roundPanel1.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(20, 20);
            label13.Margin = new Padding(0);
            label13.Name = "label13";
            label13.Size = new Size(197, 32);
            label13.TabIndex = 2;
            label13.Text = "Độc giả tích cực";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            panel11.BackColor = Color.AntiqueWhite;
            panel11.Controls.Add(metricPanel7);
            panel11.Controls.Add(label14);
            panel11.Location = new Point(20, 70);
            panel11.Margin = new Padding(0, 10, 0, 0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(10, 0, 10, 0);
            panel11.Size = new Size(500, 50);
            panel11.TabIndex = 3;
            // 
            // metricPanel7
            // 
            metricPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel7.AutoSize = true;
            metricPanel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel7.BackColor = Color.FromArgb(255, 192, 128);
            metricPanel7.BorderRadius = 15;
            metricPanel7.ForeColor = Color.FromArgb(192, 64, 0);
            metricPanel7.Location = new Point(392, 9);
            metricPanel7.Margin = new Padding(0, 9, 0, 0);
            metricPanel7.Name = "metricPanel7";
            metricPanel7.Padding = new Padding(10, 5, 10, 5);
            metricPanel7.Size = new Size(98, 31);
            metricPanel7.TabIndex = 4;
            metricPanel7.TextValue = "15 mượn";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(10, 15);
            label14.Margin = new Padding(0, 15, 0, 0);
            label14.Name = "label14";
            label14.Size = new Size(119, 21);
            label14.TabIndex = 0;
            label14.Text = "Nguyễn Văn A";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            panel12.BackColor = Color.AntiqueWhite;
            panel12.Controls.Add(metricPanel8);
            panel12.Controls.Add(label15);
            panel12.Location = new Point(20, 190);
            panel12.Margin = new Padding(0, 10, 0, 0);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(10, 0, 10, 0);
            panel12.Size = new Size(500, 50);
            panel12.TabIndex = 3;
            // 
            // metricPanel8
            // 
            metricPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel8.AutoSize = true;
            metricPanel8.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel8.BackColor = Color.FromArgb(255, 192, 128);
            metricPanel8.BorderRadius = 15;
            metricPanel8.ForeColor = Color.FromArgb(192, 64, 0);
            metricPanel8.Location = new Point(392, 9);
            metricPanel8.Margin = new Padding(0, 9, 0, 0);
            metricPanel8.Name = "metricPanel8";
            metricPanel8.Padding = new Padding(10, 5, 10, 5);
            metricPanel8.Size = new Size(98, 31);
            metricPanel8.TabIndex = 4;
            metricPanel8.TextValue = "15 mượn";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(10, 15);
            label15.Margin = new Padding(0, 15, 0, 0);
            label15.Name = "label15";
            label15.Size = new Size(126, 21);
            label15.TabIndex = 0;
            label15.Text = "Lê Thị Trúc Heo";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            panel13.BackColor = Color.AntiqueWhite;
            panel13.Controls.Add(metricPanel9);
            panel13.Controls.Add(label16);
            panel13.Location = new Point(20, 130);
            panel13.Margin = new Padding(0, 10, 0, 0);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(10, 0, 10, 0);
            panel13.Size = new Size(500, 50);
            panel13.TabIndex = 3;
            // 
            // metricPanel9
            // 
            metricPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metricPanel9.AutoSize = true;
            metricPanel9.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metricPanel9.BackColor = Color.FromArgb(255, 192, 128);
            metricPanel9.BorderRadius = 15;
            metricPanel9.ForeColor = Color.FromArgb(192, 64, 0);
            metricPanel9.Location = new Point(392, 9);
            metricPanel9.Margin = new Padding(0, 9, 0, 0);
            metricPanel9.Name = "metricPanel9";
            metricPanel9.Padding = new Padding(10, 5, 10, 5);
            metricPanel9.Size = new Size(98, 31);
            metricPanel9.TabIndex = 4;
            metricPanel9.TextValue = "15 mượn";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(10, 15);
            label16.Margin = new Padding(0, 15, 0, 0);
            label16.Name = "label16";
            label16.Size = new Size(85, 21);
            label16.TabIndex = 0;
            label16.Text = "Trần Thị B";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UCDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "UCDashboard";
            Size = new Size(1670, 1000);
            Load += UCDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedPanel3.ResumeLayout(false);
            roundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            roundedPanel4.ResumeLayout(false);
            roundedPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            roundedPanel5.ResumeLayout(false);
            roundedPanel5.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            roundPanel1.ResumeLayout(false);
            roundPanel1.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundedPanel1;
        private Controls.RoundPanel roundedPanel2;
        private Controls.RoundPanel roundedPanel3;
        private Controls.RoundPanel roundedPanel4;
        private Controls.RoundPanel roundedPanel5;
        private Controls.RoundPanel roundedPanel6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label lblTotalBooks;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblTotalBooksBorrow;
        private Label lblTotalDebt;
        private Label lblTotalReaders;
        private Panel panel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Label label6;
        private Label lblBookBorrow1;
        private Controls.MetricPanel lblBorrowCount1;
        private Panel panel8;
        private Controls.MetricPanel metricPanel4;
        private Label label10;
        private Panel panel7;
        private Controls.MetricPanel metricPanel3;
        private Label label9;
        private Panel panel6;
        private Controls.MetricPanel metricPanel2;
        private Label label8;
        private Panel panel5;
        private Controls.MetricPanel metricPanel1;
        private Label label7;
        private Controls.RoundPanel roundPanel1;
        private Label label13;
        private Panel panel11;
        private Controls.MetricPanel metricPanel7;
        private Label label14;
        private Panel panel12;
        private Controls.MetricPanel metricPanel8;
        private Label label15;
        private Panel panel13;
        private Controls.MetricPanel metricPanel9;
        private Label label16;
    }
}
