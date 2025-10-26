namespace GUI
{
    partial class UCManageBook
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvBooks = new DataGridView();
            maSachCol = new DataGridViewTextBoxColumn();
            pictureCol = new DataGridViewImageColumn();
            tieuDeCol = new DataGridViewTextBoxColumn();
            isbnCol = new DataGridViewTextBoxColumn();
            publicationYearCol = new DataGridViewTextBoxColumn();
            priceCol = new DataGridViewTextBoxColumn();
            totalCol = new DataGridViewTextBoxColumn();
            stockAvailableCol = new DataGridViewTextBoxColumn();
            publisherIdCol = new DataGridViewTextBoxColumn();
            genreIdCol = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            pnlGenres = new FlowLayoutPanel();
            roundedPanel1 = new GUI.Controls.RoundedPanel();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            roundedPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeColumns = false;
            dgvBooks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 25, 50);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 25, 50);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { maSachCol, pictureCol, tieuDeCol, isbnCol, publicationYearCol, priceCol, totalCol, stockAvailableCol, publisherIdCol, genreIdCol });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBooks.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.GridColor = Color.White;
            dgvBooks.Location = new Point(12, 88);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(987, 773);
            dgvBooks.TabIndex = 0;
            // 
            // maSachCol
            // 
            maSachCol.DataPropertyName = "MaSach";
            maSachCol.HeaderText = "Mã sách";
            maSachCol.Name = "maSachCol";
            maSachCol.ReadOnly = true;
            // 
            // pictureCol
            // 
            pictureCol.HeaderText = "Ảnh bìa";
            pictureCol.Name = "pictureCol";
            pictureCol.ReadOnly = true;
            // 
            // tieuDeCol
            // 
            tieuDeCol.DataPropertyName = "TieuDe";
            tieuDeCol.HeaderText = "Tiêu đề";
            tieuDeCol.Name = "tieuDeCol";
            tieuDeCol.ReadOnly = true;
            // 
            // isbnCol
            // 
            isbnCol.DataPropertyName = "ISBN";
            isbnCol.HeaderText = "ISBN";
            isbnCol.Name = "isbnCol";
            isbnCol.ReadOnly = true;
            // 
            // publicationYearCol
            // 
            publicationYearCol.DataPropertyName = "NamXuatBan";
            publicationYearCol.HeaderText = "Năm XB";
            publicationYearCol.Name = "publicationYearCol";
            publicationYearCol.ReadOnly = true;
            // 
            // priceCol
            // 
            priceCol.DataPropertyName = "GiaSach";
            priceCol.HeaderText = "Giá sách";
            priceCol.Name = "priceCol";
            priceCol.ReadOnly = true;
            // 
            // totalCol
            // 
            totalCol.DataPropertyName = "SoLuongTong";
            totalCol.HeaderText = "SL Tổng";
            totalCol.Name = "totalCol";
            totalCol.ReadOnly = true;
            // 
            // stockAvailableCol
            // 
            stockAvailableCol.DataPropertyName = "SoLuongCon";
            stockAvailableCol.HeaderText = "SL còn";
            stockAvailableCol.Name = "stockAvailableCol";
            stockAvailableCol.ReadOnly = true;
            // 
            // publisherIdCol
            // 
            publisherIdCol.DataPropertyName = "MaNXB";
            publisherIdCol.HeaderText = "Mã NXB";
            publisherIdCol.Name = "publisherIdCol";
            publisherIdCol.ReadOnly = true;
            // 
            // genreIdCol
            // 
            genreIdCol.DataPropertyName = "MaTheLoai";
            genreIdCol.HeaderText = "Mã thể loại";
            genreIdCol.Name = "genreIdCol";
            genreIdCol.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1411, 72);
            panel1.TabIndex = 1;
            // 
            // pnlGenres
            // 
            pnlGenres.BackColor = Color.WhiteSmoke;
            pnlGenres.BorderStyle = BorderStyle.FixedSingle;
            pnlGenres.Location = new Point(17, 253);
            pnlGenres.Name = "pnlGenres";
            pnlGenres.Size = new Size(357, 126);
            pnlGenres.TabIndex = 2;
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.White;
            roundedPanel1.BorderRadius = 10;
            roundedPanel1.Controls.Add(pnlGenres);
            roundedPanel1.Location = new Point(1010, 88);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(391, 773);
            roundedPanel1.TabIndex = 3;
            // 
            // UCManageBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundedPanel1);
            Controls.Add(panel1);
            Controls.Add(dgvBooks);
            Name = "UCManageBook";
            Size = new Size(1411, 876);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            roundedPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.CustomDataGridView customDataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridView dgvBooks;
        private DataGridViewCheckBoxColumn selectCol;
        private DataGridViewTextBoxColumn maSachCol;
        private DataGridViewImageColumn pictureCol;
        private DataGridViewTextBoxColumn tieuDeCol;
        private DataGridViewTextBoxColumn isbnCol;
        private DataGridViewTextBoxColumn publicationYearCol;
        private DataGridViewTextBoxColumn priceCol;
        private DataGridViewTextBoxColumn totalCol;
        private DataGridViewTextBoxColumn stockAvailableCol;
        private DataGridViewTextBoxColumn publisherIdCol;
        private DataGridViewTextBoxColumn genreIdCol;
        private Panel panel1;
        private FlowLayoutPanel pnlGenres;
        private Controls.RoundedPanel roundedPanel1;
    }
}
