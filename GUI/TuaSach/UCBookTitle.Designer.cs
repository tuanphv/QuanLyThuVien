namespace GUI.TuaSach
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label6 = new Label();
            roundedPanel1 = new GUI.Controls.RoundPanel();
            dgvBookTitles = new GUI.Controls.ActionDataGridView();
            btnAddBookTitle = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            BookTitleID = new DataGridViewTextBoxColumn();
            BookTitleName = new DataGridViewTextBoxColumn();
            Image = new DataGridViewImageColumn();
            Genres = new DataGridViewTextBoxColumn();
            Authors = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookTitles).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
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
            panel1.Size = new Size(1633, 70);
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
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BackgroundColor = Color.White;
            roundedPanel1.BorderColor = Color.White;
            roundedPanel1.BorderRadius = 10;
            roundedPanel1.BorderWidth = 0F;
            roundedPanel1.Controls.Add(dgvBookTitles);
            roundedPanel1.Controls.Add(btnAddBookTitle);
            roundedPanel1.Controls.Add(panel3);
            roundedPanel1.Controls.Add(label4);
            roundedPanel1.Controls.Add(comboBox2);
            roundedPanel1.Controls.Add(comboBox1);
            roundedPanel1.Controls.Add(label7);
            roundedPanel1.Location = new Point(20, 90);
            roundedPanel1.Margin = new Padding(20);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(1593, 644);
            roundedPanel1.TabIndex = 6;
            // 
            // dgvBookTitles
            // 
            dgvBookTitles.AllowUserToAddRows = false;
            dgvBookTitles.AllowUserToDeleteRows = false;
            dgvBookTitles.AllowUserToResizeColumns = false;
            dgvBookTitles.AllowUserToResizeRows = false;
            dgvBookTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBookTitles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookTitles.BackgroundColor = Color.White;
            dgvBookTitles.BorderStyle = BorderStyle.None;
            dgvBookTitles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookTitles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookTitles.ColumnHeadersHeight = 40;
            dgvBookTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBookTitles.Columns.AddRange(new DataGridViewColumn[] { BookTitleID, BookTitleName, Image, Genres, Authors });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvBookTitles.DefaultCellStyle = dataGridViewCellStyle4;
            dgvBookTitles.EnableHeadersVisualStyles = false;
            dgvBookTitles.GridColor = SystemColors.ControlLight;
            dgvBookTitles.Location = new Point(20, 69);
            dgvBookTitles.Margin = new Padding(20);
            dgvBookTitles.Name = "dgvBookTitles";
            dgvBookTitles.ReadOnly = true;
            dgvBookTitles.RowHeadersVisible = false;
            dgvBookTitles.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvBookTitles.RowTemplate.Height = 80;
            dgvBookTitles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookTitles.ShowCellErrors = false;
            dgvBookTitles.ShowCellToolTips = false;
            dgvBookTitles.ShowDeleteButton = true;
            dgvBookTitles.ShowEditButton = true;
            dgvBookTitles.ShowEditingIcon = false;
            dgvBookTitles.ShowRowErrors = false;
            dgvBookTitles.ShowViewButton = true;
            dgvBookTitles.Size = new Size(1551, 555);
            dgvBookTitles.TabIndex = 14;
            // 
            // btnAddBookTitle
            // 
            btnAddBookTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddBookTitle.BackColor = Color.DeepSkyBlue;
            btnAddBookTitle.FlatAppearance.BorderSize = 0;
            btnAddBookTitle.FlatStyle = FlatStyle.Flat;
            btnAddBookTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddBookTitle.ForeColor = Color.White;
            btnAddBookTitle.Image = Properties.Resources.plus;
            btnAddBookTitle.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddBookTitle.Location = new Point(1431, 20);
            btnAddBookTitle.Margin = new Padding(20);
            btnAddBookTitle.Name = "btnAddBookTitle";
            btnAddBookTitle.Padding = new Padding(3);
            btnAddBookTitle.Size = new Size(140, 30);
            btnAddBookTitle.TabIndex = 13;
            btnAddBookTitle.Text = "  Thêm Tựa sách";
            btnAddBookTitle.TextAlign = ContentAlignment.MiddleLeft;
            btnAddBookTitle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddBookTitle.UseVisualStyleBackColor = false;
            btnAddBookTitle.Click += btnAddBookTitle_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(textBox1);
            panel3.Location = new Point(846, 20);
            panel3.Margin = new Padding(20);
            panel3.Name = "panel3";
            panel3.Size = new Size(545, 30);
            panel3.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkTurquoise;
            btnSearch.Dock = DockStyle.Right;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(471, 0);
            btnSearch.Margin = new Padding(0, 20, 20, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(2);
            btnSearch.Size = new Size(72, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "  Tìm";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(5, 5);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(461, 18);
            textBox1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 24);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 0;
            label4.Text = "Thể loại:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Tất cả", "Tác giả 1", "Tác giả 2", "Tác giả 3" });
            comboBox2.Location = new Point(331, 20);
            comboBox2.Margin = new Padding(20);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(144, 29);
            comboBox2.TabIndex = 11;
            comboBox2.Text = "Tất cả";
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất cả", "Thể loại A", "Thể loại B", "Thể loại C" });
            comboBox1.Location = new Point(100, 20);
            comboBox1.Margin = new Padding(20);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(122, 29);
            comboBox1.Sorted = true;
            comboBox1.TabIndex = 11;
            comboBox1.Text = "Tất cả";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(256, 24);
            label7.Name = "label7";
            label7.Size = new Size(71, 21);
            label7.TabIndex = 0;
            label7.Text = "Tác giả: ";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BookTitleID
            // 
            BookTitleID.DataPropertyName = "MaTuaSach";
            BookTitleID.HeaderText = "Mã tựa sách";
            BookTitleID.Name = "BookTitleID";
            BookTitleID.ReadOnly = true;
            // 
            // BookTitleName
            // 
            BookTitleName.DataPropertyName = "TenTuaSach";
            BookTitleName.HeaderText = "Tên tựa sách";
            BookTitleName.Name = "BookTitleName";
            BookTitleName.ReadOnly = true;
            // 
            // Image
            // 
            Image.DataPropertyName = "AnhBia";
            Image.HeaderText = "Ảnh bìa";
            Image.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Image.Name = "Image";
            Image.ReadOnly = true;
            // 
            // Genres
            // 
            Genres.DataPropertyName = "TheLoai";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Genres.DefaultCellStyle = dataGridViewCellStyle2;
            Genres.HeaderText = "Thể loại";
            Genres.Name = "Genres";
            Genres.ReadOnly = true;
            // 
            // Authors
            // 
            Authors.DataPropertyName = "TacGia";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Authors.DefaultCellStyle = dataGridViewCellStyle3;
            Authors.HeaderText = "Tác giả";
            Authors.Name = "Authors";
            Authors.ReadOnly = true;
            // 
            // UCBookTitle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundedPanel1);
            Controls.Add(panel1);
            Name = "UCBookTitle";
            Size = new Size(1633, 754);
            Load += UCBookTitle_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookTitles).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Controls.RoundPanel roundedPanel1;
        private Label label6;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Panel panel3;
        private Button btnSearch;
        private TextBox textBox1;
        private Label label4;
        private Label label7;
        private Button btnAddBookTitle;
        private Controls.ActionDataGridView dgvBookTitles;
        private DataGridViewTextBoxColumn BookTitleID;
        private DataGridViewTextBoxColumn BookTitleName;
        private DataGridViewImageColumn Image;
        private DataGridViewTextBoxColumn Genres;
        private DataGridViewTextBoxColumn Authors;
    }
}
