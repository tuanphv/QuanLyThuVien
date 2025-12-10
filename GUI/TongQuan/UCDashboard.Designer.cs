namespace GUI.ThongKe
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
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            roundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            tableLayoutPanel1.SuspendLayout();
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
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BackgroundColor = Color.CornflowerBlue;
            roundedPanel1.BorderColor = Color.White;
            roundedPanel1.BorderRadius = 10;
            roundedPanel1.BorderWidth = 0F;
            roundedPanel1.Controls.Add(lblTotalBooks);
            roundedPanel1.Controls.Add(label2);
            roundedPanel1.Controls.Add(pictureBox1);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.Location = new Point(20, 20);
            roundedPanel1.Margin = new Padding(10);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(395, 110);
            roundedPanel1.TabIndex = 1;
            // 
            // lblTotalBooks
            // 
            lblTotalBooks.AutoSize = true;
            lblTotalBooks.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBooks.ForeColor = SystemColors.HighlightText;
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
            label2.ForeColor = SystemColors.HighlightText;
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
            pictureBox1.Location = new Point(325, 25);
            pictureBox1.Margin = new Padding(0, 25, 20, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.Transparent;
            roundedPanel2.BackgroundColor = Color.CornflowerBlue;
            roundedPanel2.BorderColor = Color.White;
            roundedPanel2.BorderRadius = 10;
            roundedPanel2.BorderWidth = 0F;
            roundedPanel2.Controls.Add(lblTotalBooksBorrow);
            roundedPanel2.Controls.Add(label3);
            roundedPanel2.Controls.Add(pictureBox2);
            roundedPanel2.Dock = DockStyle.Fill;
            roundedPanel2.Location = new Point(435, 20);
            roundedPanel2.Margin = new Padding(10);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(395, 110);
            roundedPanel2.TabIndex = 1;
            // 
            // lblTotalBooksBorrow
            // 
            lblTotalBooksBorrow.AutoSize = true;
            lblTotalBooksBorrow.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBooksBorrow.ForeColor = SystemColors.HighlightText;
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
            label3.ForeColor = SystemColors.HighlightText;
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
            pictureBox2.Location = new Point(325, 25);
            pictureBox2.Margin = new Padding(0, 25, 20, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.Transparent;
            roundedPanel3.BackgroundColor = Color.CornflowerBlue;
            roundedPanel3.BorderColor = Color.White;
            roundedPanel3.BorderRadius = 10;
            roundedPanel3.BorderWidth = 0F;
            roundedPanel3.Controls.Add(lblTotalReaders);
            roundedPanel3.Controls.Add(label4);
            roundedPanel3.Controls.Add(pictureBox3);
            roundedPanel3.Dock = DockStyle.Fill;
            roundedPanel3.Location = new Point(850, 20);
            roundedPanel3.Margin = new Padding(10);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(395, 110);
            roundedPanel3.TabIndex = 1;
            // 
            // lblTotalReaders
            // 
            lblTotalReaders.AutoSize = true;
            lblTotalReaders.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalReaders.ForeColor = SystemColors.HighlightText;
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
            label4.ForeColor = SystemColors.HighlightText;
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
            pictureBox3.Location = new Point(325, 25);
            pictureBox3.Margin = new Padding(0, 25, 20, 25);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // roundedPanel4
            // 
            roundedPanel4.BackColor = Color.Transparent;
            roundedPanel4.BackgroundColor = Color.CornflowerBlue;
            roundedPanel4.BorderColor = Color.White;
            roundedPanel4.BorderRadius = 10;
            roundedPanel4.BorderWidth = 0F;
            roundedPanel4.Controls.Add(lblTotalDebt);
            roundedPanel4.Controls.Add(label5);
            roundedPanel4.Controls.Add(pictureBox4);
            roundedPanel4.Dock = DockStyle.Fill;
            roundedPanel4.Location = new Point(1265, 20);
            roundedPanel4.Margin = new Padding(10);
            roundedPanel4.Name = "roundedPanel4";
            roundedPanel4.Size = new Size(395, 110);
            roundedPanel4.TabIndex = 1;
            // 
            // lblTotalDebt
            // 
            lblTotalDebt.AutoSize = true;
            lblTotalDebt.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDebt.ForeColor = SystemColors.HighlightText;
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
            label5.ForeColor = SystemColors.HighlightText;
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
            pictureBox4.Location = new Point(325, 25);
            pictureBox4.Margin = new Padding(0, 25, 20, 25);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 70);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1670, 930);
            panel2.TabIndex = 2;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.home_page;
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Dock = DockStyle.Fill;
            pictureBox5.Location = new Point(0, 140);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(1670, 790);
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
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
            tableLayoutPanel1.Size = new Size(1670, 140);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // UCDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
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
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.RoundPanel roundedPanel1;
        private Controls.RoundPanel roundedPanel2;
        private Controls.RoundPanel roundedPanel3;
        private Controls.RoundPanel roundedPanel4;
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
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox5;
    }
}
