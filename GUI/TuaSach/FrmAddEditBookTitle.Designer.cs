namespace GUI.TuaSach
{
    partial class FrmAddEditBookTitle
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
            roundedPanel2 = new GUI.Controls.RoundPanel();
            btnCancel = new Button();
            btnSave = new Button();
            btnThemTacGia = new Button();
            btnThemTheLoai = new Button();
            txtBookName = new TextBox();
            btnXoaAnh = new Button();
            btnChonAnh = new Button();
            pnlAuthors = new FlowLayoutPanel();
            pnlGenres = new FlowLayoutPanel();
            label3 = new Label();
            label1 = new Label();
            txtBookTitleId = new TextBox();
            ptbBookCover = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            dialogChonAnh = new OpenFileDialog();
            roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBookCover).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // roundedPanel2
            // 
            roundedPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel2.BackColor = Color.Transparent;
            roundedPanel2.BackgroundColor = Color.White;
            roundedPanel2.BorderColor = Color.White;
            roundedPanel2.BorderRadius = 10;
            roundedPanel2.BorderWidth = 0F;
            roundedPanel2.Controls.Add(btnCancel);
            roundedPanel2.Controls.Add(btnSave);
            roundedPanel2.Controls.Add(btnThemTacGia);
            roundedPanel2.Controls.Add(btnThemTheLoai);
            roundedPanel2.Controls.Add(txtBookName);
            roundedPanel2.Controls.Add(btnXoaAnh);
            roundedPanel2.Controls.Add(btnChonAnh);
            roundedPanel2.Controls.Add(pnlAuthors);
            roundedPanel2.Controls.Add(pnlGenres);
            roundedPanel2.Controls.Add(label3);
            roundedPanel2.Controls.Add(label1);
            roundedPanel2.Controls.Add(txtBookTitleId);
            roundedPanel2.Controls.Add(ptbBookCover);
            roundedPanel2.Controls.Add(label2);
            roundedPanel2.Controls.Add(label5);
            roundedPanel2.Location = new Point(20, 18);
            roundedPanel2.Margin = new Padding(20);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(827, 526);
            roundedPanel2.TabIndex = 8;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Tomato;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(437, 465);
            btnCancel.Margin = new Padding(20);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(5);
            btnCancel.Size = new Size(94, 41);
            btnCancel.TabIndex = 8;
            btnCancel.Text = " Thoát";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkTurquoise;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(314, 465);
            btnSave.Margin = new Padding(20);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(83, 41);
            btnSave.TabIndex = 8;
            btnSave.Text = "  Lưu";
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnThemTacGia
            // 
            btnThemTacGia.BackColor = Color.DeepSkyBlue;
            btnThemTacGia.FlatAppearance.BorderSize = 0;
            btnThemTacGia.FlatStyle = FlatStyle.Flat;
            btnThemTacGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemTacGia.ForeColor = Color.White;
            btnThemTacGia.Image = Properties.Resources.plus;
            btnThemTacGia.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemTacGia.Location = new Point(297, 330);
            btnThemTacGia.Name = "btnThemTacGia";
            btnThemTacGia.Padding = new Padding(3);
            btnThemTacGia.Size = new Size(111, 30);
            btnThemTacGia.TabIndex = 8;
            btnThemTacGia.Text = "  Thêm TG";
            btnThemTacGia.TextAlign = ContentAlignment.MiddleLeft;
            btnThemTacGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemTacGia.UseVisualStyleBackColor = false;
            btnThemTacGia.Click += btnThemTacGia_Click;
            // 
            // btnThemTheLoai
            // 
            btnThemTheLoai.BackColor = Color.DeepSkyBlue;
            btnThemTheLoai.FlatAppearance.BorderSize = 0;
            btnThemTheLoai.FlatStyle = FlatStyle.Flat;
            btnThemTheLoai.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemTheLoai.ForeColor = Color.White;
            btnThemTheLoai.Image = Properties.Resources.plus;
            btnThemTheLoai.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemTheLoai.Location = new Point(297, 154);
            btnThemTheLoai.Name = "btnThemTheLoai";
            btnThemTheLoai.Padding = new Padding(3);
            btnThemTheLoai.Size = new Size(111, 30);
            btnThemTheLoai.TabIndex = 8;
            btnThemTheLoai.Text = "  Thêm TL";
            btnThemTheLoai.TextAlign = ContentAlignment.MiddleLeft;
            btnThemTheLoai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThemTheLoai.UseVisualStyleBackColor = false;
            btnThemTheLoai.Click += btnThemTheLoai_Click;
            // 
            // txtBookName
            // 
            txtBookName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBookName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookName.Location = new Point(422, 69);
            txtBookName.Margin = new Padding(20, 20, 20, 0);
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(385, 29);
            txtBookName.TabIndex = 7;
            // 
            // btnXoaAnh
            // 
            btnXoaAnh.AutoSize = true;
            btnXoaAnh.BackColor = Color.DeepSkyBlue;
            btnXoaAnh.FlatAppearance.BorderSize = 0;
            btnXoaAnh.FlatStyle = FlatStyle.Flat;
            btnXoaAnh.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaAnh.ForeColor = Color.White;
            btnXoaAnh.Location = new Point(165, 288);
            btnXoaAnh.Name = "btnXoaAnh";
            btnXoaAnh.Padding = new Padding(5);
            btnXoaAnh.Size = new Size(79, 37);
            btnXoaAnh.TabIndex = 6;
            btnXoaAnh.Text = "Xóa ảnh";
            btnXoaAnh.UseVisualStyleBackColor = false;
            btnXoaAnh.Click += btnXoaAnh_Click;
            // 
            // btnChonAnh
            // 
            btnChonAnh.AutoSize = true;
            btnChonAnh.BackColor = Color.DeepSkyBlue;
            btnChonAnh.FlatAppearance.BorderSize = 0;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(41, 288);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Padding = new Padding(5);
            btnChonAnh.Size = new Size(87, 37);
            btnChonAnh.TabIndex = 6;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // pnlAuthors
            // 
            pnlAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAuthors.BackColor = Color.White;
            pnlAuthors.BorderStyle = BorderStyle.FixedSingle;
            pnlAuthors.Location = new Point(422, 290);
            pnlAuthors.Margin = new Padding(20, 20, 20, 0);
            pnlAuthors.Name = "pnlAuthors";
            pnlAuthors.Size = new Size(385, 150);
            pnlAuthors.TabIndex = 5;
            // 
            // pnlGenres
            // 
            pnlGenres.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlGenres.BackColor = Color.White;
            pnlGenres.BorderStyle = BorderStyle.FixedSingle;
            pnlGenres.Location = new Point(422, 118);
            pnlGenres.Margin = new Padding(20, 20, 20, 0);
            pnlGenres.Name = "pnlGenres";
            pnlGenres.Size = new Size(385, 150);
            pnlGenres.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(297, 72);
            label3.Margin = new Padding(20, 20, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 21);
            label3.TabIndex = 0;
            label3.Text = "Tên tựa sách";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(297, 23);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 0;
            label1.Text = "Mã tựa sách";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBookTitleId
            // 
            txtBookTitleId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBookTitleId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookTitleId.Location = new Point(422, 20);
            txtBookTitleId.Margin = new Padding(20, 20, 20, 0);
            txtBookTitleId.Name = "txtBookTitleId";
            txtBookTitleId.ReadOnly = true;
            txtBookTitleId.Size = new Size(385, 29);
            txtBookTitleId.TabIndex = 1;
            // 
            // ptbBookCover
            // 
            ptbBookCover.BackColor = Color.White;
            ptbBookCover.BorderStyle = BorderStyle.FixedSingle;
            ptbBookCover.Image = Properties.Resources.image_placeholder;
            ptbBookCover.Location = new Point(20, 20);
            ptbBookCover.Margin = new Padding(20);
            ptbBookCover.Name = "ptbBookCover";
            ptbBookCover.Size = new Size(250, 250);
            ptbBookCover.SizeMode = PictureBoxSizeMode.Zoom;
            ptbBookCover.TabIndex = 0;
            ptbBookCover.TabStop = false;
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(297, 290);
            label2.Name = "label2";
            label2.Size = new Size(71, 23);
            label2.TabIndex = 0;
            label2.Text = "Tác giả";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(297, 118);
            label5.Name = "label5";
            label5.Size = new Size(71, 23);
            label5.TabIndex = 0;
            label5.Text = "Thể loại";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 564);
            panel1.TabIndex = 9;
            // 
            // dialogChonAnh
            // 
            dialogChonAnh.FileName = "openFileDialog1";
            // 
            // FrmAddEditBookTitle
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCancel;
            ClientSize = new Size(867, 564);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "FrmAddEditBookTitle";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm/Sửa Tựa sách";
            FormClosing += FrmAddEditBookTitle_FormClosing;
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBookCover).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.RoundPanel roundedPanel2;
        private Button btnCancel;
        private Button btnSave;
        private Button btnThemTacGia;
        private Button btnThemTheLoai;
        private TextBox txtBookName;
        private Button btnXoaAnh;
        private Button btnChonAnh;
        private FlowLayoutPanel pnlAuthors;
        private FlowLayoutPanel pnlGenres;
        private Label label3;
        private Label label1;
        private TextBox txtBookTitleId;
        private PictureBox ptbBookCover;
        private Label label2;
        private Label label5;
        private Panel panel1;
        private OpenFileDialog dialogChonAnh;
    }
}