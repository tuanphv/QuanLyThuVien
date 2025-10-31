namespace GUI
{
    partial class UCBookTitle
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvBooks = new DataGridView();
            idCol = new DataGridViewTextBoxColumn();
            maTuaSachCol = new DataGridViewTextBoxColumn();
            tenTuaSachCol = new DataGridViewTextBoxColumn();
            anhBiaCol = new DataGridViewImageColumn();
            genreCol = new DataGridViewTextBoxColumn();
            authorCol = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            label6 = new Label();
            pnlGenres = new FlowLayoutPanel();
            ptbBookCover = new PictureBox();
            label1 = new Label();
            txtBookTitleId = new TextBox();
            label5 = new Label();
            roundedPanel1 = new GUI.Controls.RoundPanel();
            roundedPanel2 = new GUI.Controls.RoundPanel();
            button4 = new Button();
            button3 = new Button();
            txtBookName = new TextBox();
            button2 = new Button();
            button1 = new Button();
            pnlAuthors = new FlowLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            dialogChonAnh = new OpenFileDialog();
            panel2 = new Panel();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBookCover).BeginInit();
            roundedPanel1.SuspendLayout();
            roundedPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeColumns = false;
            dgvBooks.AllowUserToResizeRows = false;
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvBooks.ColumnHeadersHeight = 30;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { idCol, maTuaSachCol, tenTuaSachCol, anhBiaCol, genreCol, authorCol });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvBooks.DefaultCellStyle = dataGridViewCellStyle6;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.GridColor = Color.LightGray;
            dgvBooks.Location = new Point(20, 20);
            dgvBooks.Margin = new Padding(20);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowTemplate.Height = 30;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(800, 640);
            dgvBooks.TabIndex = 10;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // idCol
            // 
            idCol.DataPropertyName = "Id";
            idCol.HeaderText = "ID";
            idCol.Name = "idCol";
            idCol.ReadOnly = true;
            idCol.Visible = false;
            // 
            // maTuaSachCol
            // 
            maTuaSachCol.DataPropertyName = "MaTuaSach";
            maTuaSachCol.HeaderText = "Mã tựa sách";
            maTuaSachCol.Name = "maTuaSachCol";
            maTuaSachCol.ReadOnly = true;
            // 
            // tenTuaSachCol
            // 
            tenTuaSachCol.DataPropertyName = "TenTuaSach";
            tenTuaSachCol.HeaderText = "Tên tựa sách";
            tenTuaSachCol.Name = "tenTuaSachCol";
            tenTuaSachCol.ReadOnly = true;
            // 
            // anhBiaCol
            // 
            anhBiaCol.DataPropertyName = "AnhBia";
            anhBiaCol.HeaderText = "Ảnh bìa";
            anhBiaCol.Name = "anhBiaCol";
            anhBiaCol.ReadOnly = true;
            // 
            // genreCol
            // 
            genreCol.DataPropertyName = "TheLoai";
            genreCol.HeaderText = "Thể loại";
            genreCol.Name = "genreCol";
            genreCol.ReadOnly = true;
            genreCol.Visible = false;
            // 
            // authorCol
            // 
            authorCol.DataPropertyName = "TacGia";
            authorCol.HeaderText = "Tác giả";
            authorCol.Name = "authorCol";
            authorCol.ReadOnly = true;
            authorCol.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 70);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(233, 37);
            label6.TabIndex = 0;
            label6.Text = "Quản lý Tựa sách";
            // 
            // pnlGenres
            // 
            pnlGenres.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlGenres.BackColor = Color.White;
            pnlGenres.BorderStyle = BorderStyle.FixedSingle;
            pnlGenres.Location = new Point(22, 292);
            pnlGenres.Margin = new Padding(20, 10, 20, 10);
            pnlGenres.Name = "pnlGenres";
            pnlGenres.Size = new Size(458, 75);
            pnlGenres.TabIndex = 5;
            // 
            // ptbBookCover
            // 
            ptbBookCover.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ptbBookCover.BackColor = Color.White;
            ptbBookCover.BorderStyle = BorderStyle.FixedSingle;
            ptbBookCover.Location = new Point(20, 20);
            ptbBookCover.Margin = new Padding(20);
            ptbBookCover.Name = "ptbBookCover";
            ptbBookCover.Size = new Size(200, 200);
            ptbBookCover.TabIndex = 0;
            ptbBookCover.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(240, 20);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 0;
            label1.Text = "Mã tựa sách";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBookTitleId
            // 
            txtBookTitleId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBookTitleId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookTitleId.Location = new Point(240, 49);
            txtBookTitleId.Margin = new Padding(8, 8, 20, 8);
            txtBookTitleId.Name = "txtBookTitleId";
            txtBookTitleId.Size = new Size(240, 29);
            txtBookTitleId.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 249);
            label5.Name = "label5";
            label5.Size = new Size(75, 23);
            label5.TabIndex = 0;
            label5.Text = "Thể loại";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BackgroundColor = Color.White;
            roundedPanel1.BorderColor = Color.White;
            roundedPanel1.BorderRadius = 10;
            roundedPanel1.BorderWidth = 0F;
            roundedPanel1.Controls.Add(dgvBooks);
            roundedPanel1.Location = new Point(20, 90);
            roundedPanel1.Margin = new Padding(20, 20, 10, 20);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(840, 690);
            roundedPanel1.TabIndex = 6;
            // 
            // roundedPanel2
            // 
            roundedPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedPanel2.BackColor = Color.Transparent;
            roundedPanel2.BackgroundColor = Color.White;
            roundedPanel2.BorderColor = Color.White;
            roundedPanel2.BorderRadius = 10;
            roundedPanel2.BorderWidth = 0F;
            roundedPanel2.Controls.Add(button5);
            roundedPanel2.Controls.Add(button7);
            roundedPanel2.Controls.Add(button4);
            roundedPanel2.Controls.Add(button6);
            roundedPanel2.Controls.Add(button3);
            roundedPanel2.Controls.Add(txtBookName);
            roundedPanel2.Controls.Add(button2);
            roundedPanel2.Controls.Add(button1);
            roundedPanel2.Controls.Add(pnlAuthors);
            roundedPanel2.Controls.Add(pnlGenres);
            roundedPanel2.Controls.Add(label3);
            roundedPanel2.Controls.Add(label1);
            roundedPanel2.Controls.Add(txtBookTitleId);
            roundedPanel2.Controls.Add(ptbBookCover);
            roundedPanel2.Controls.Add(label2);
            roundedPanel2.Controls.Add(label5);
            roundedPanel2.Location = new Point(880, 90);
            roundedPanel2.Margin = new Padding(10, 20, 20, 20);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(500, 690);
            roundedPanel2.TabIndex = 7;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkTurquoise;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Image = Properties.Resources.save;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(213, 526);
            button4.Name = "button4";
            button4.Padding = new Padding(5);
            button4.Size = new Size(81, 39);
            button4.TabIndex = 8;
            button4.Text = "  Lưu";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DeepSkyBlue;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.plus;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(341, 249);
            button3.Name = "button3";
            button3.Padding = new Padding(3);
            button3.Size = new Size(139, 30);
            button3.TabIndex = 8;
            button3.Text = "  Thêm thể loại";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            // 
            // txtBookName
            // 
            txtBookName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookName.Location = new Point(240, 115);
            txtBookName.Margin = new Padding(0, 20, 20, 0);
            txtBookName.Multiline = true;
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(240, 52);
            txtBookName.TabIndex = 7;
            // 
            // button2
            // 
            button2.BackColor = Color.DeepSkyBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(380, 183);
            button2.Name = "button2";
            button2.Padding = new Padding(5);
            button2.Size = new Size(100, 37);
            button2.TabIndex = 6;
            button2.Text = "Xóa ảnh";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DeepSkyBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(240, 183);
            button1.Name = "button1";
            button1.Padding = new Padding(5);
            button1.Size = new Size(101, 37);
            button1.TabIndex = 6;
            button1.Text = "Chọn ảnh";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pnlAuthors
            // 
            pnlAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAuthors.BackColor = Color.White;
            pnlAuthors.BorderStyle = BorderStyle.FixedSingle;
            pnlAuthors.Location = new Point(22, 440);
            pnlAuthors.Margin = new Padding(20, 10, 20, 10);
            pnlAuthors.Name = "pnlAuthors";
            pnlAuthors.Size = new Size(458, 73);
            pnlAuthors.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(240, 85);
            label3.Margin = new Padding(20, 20, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 21);
            label3.TabIndex = 0;
            label3.Text = "Tên tựa sách";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 397);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 0;
            label2.Text = "Tác giả";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dialogChonAnh
            // 
            dialogChonAnh.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(870, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(530, 730);
            panel2.TabIndex = 8;
            // 
            // button5
            // 
            button5.BackColor = Color.Tomato;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.bin;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(341, 526);
            button5.Name = "button5";
            button5.Padding = new Padding(5);
            button5.Size = new Size(82, 39);
            button5.TabIndex = 8;
            button5.Text = "  Xóa";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.DeepSkyBlue;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Image = Properties.Resources.plus;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(341, 397);
            button6.Name = "button6";
            button6.Padding = new Padding(3);
            button6.Size = new Size(139, 30);
            button6.TabIndex = 8;
            button6.Text = "  Thêm tác giả";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.DeepSkyBlue;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button7.ForeColor = Color.White;
            button7.Image = Properties.Resources.plus;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(74, 526);
            button7.Name = "button7";
            button7.Padding = new Padding(5);
            button7.Size = new Size(95, 39);
            button7.TabIndex = 8;
            button7.Text = "  Thêm";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = false;
            // 
            // UCBookTitle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundedPanel1);
            Controls.Add(roundedPanel2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UCBookTitle";
            Size = new Size(1400, 800);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBookCover).EndInit();
            roundedPanel1.ResumeLayout(false);
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridView dgvBooks;
        private DataGridViewCheckBoxColumn selectCol;
        private Panel panel1;
        private FlowLayoutPanel pnlGenres;
        private PictureBox ptbBookCover;
        private Label label1;
        private TextBox txtBookTitleId;
        private Label label5;
        private Controls.RoundPanel roundedPanel1;
        private Controls.RoundPanel roundedPanel2;
        private Label label6;
        private Button button1;
        private OpenFileDialog dialogChonAnh;
        private Panel panel2;
        private FlowLayoutPanel pnlAuthors;
        private Label label2;
        private TextBox txtBookName;
        private Label label3;
        private DataGridViewTextBoxColumn idCol;
        private DataGridViewTextBoxColumn maTuaSachCol;
        private DataGridViewTextBoxColumn tenTuaSachCol;
        private DataGridViewImageColumn anhBiaCol;
        private DataGridViewTextBoxColumn genreCol;
        private DataGridViewTextBoxColumn authorCol;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
        private Button button6;
    }
}
