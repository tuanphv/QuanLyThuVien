namespace GUI.PhieuThu
{
    partial class FrmAddPhieuThu
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
            roundPanel1 = new GUI.Controls.RoundPanel();
            dtpNgayLapPhieu = new DateTimePicker();
            txtConNo = new TextBox();
            txtTienThu = new TextBox();
            cbDocGia = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label8 = new Label();
            label5 = new Label();
            label3 = new Label();
            lblTongNo = new Label();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            panel1 = new Panel();
            roundPanel2 = new GUI.Controls.RoundPanel();
            label2 = new Label();
            roundPanel1.SuspendLayout();
            panel1.SuspendLayout();
            roundPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(dtpNgayLapPhieu);
            roundPanel1.Controls.Add(txtConNo);
            roundPanel1.Controls.Add(txtTienThu);
            roundPanel1.Controls.Add(cbDocGia);
            roundPanel1.Controls.Add(label7);
            roundPanel1.Controls.Add(label6);
            roundPanel1.Controls.Add(label4);
            roundPanel1.Controls.Add(label8);
            roundPanel1.Controls.Add(label5);
            roundPanel1.Controls.Add(label3);
            roundPanel1.Controls.Add(lblTongNo);
            roundPanel1.Controls.Add(label1);
            roundPanel1.Controls.Add(btnCancel);
            roundPanel1.Controls.Add(btnSave);
            roundPanel1.Location = new Point(10, 85);
            roundPanel1.Margin = new Padding(10);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(562, 318);
            roundPanel1.TabIndex = 0;
            // 
            // dtpNgayLapPhieu
            // 
            dtpNgayLapPhieu.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayLapPhieu.Enabled = false;
            dtpNgayLapPhieu.Format = DateTimePickerFormat.Short;
            dtpNgayLapPhieu.Location = new Point(111, 199);
            dtpNgayLapPhieu.Name = "dtpNgayLapPhieu";
            dtpNgayLapPhieu.Size = new Size(151, 23);
            dtpNgayLapPhieu.TabIndex = 14;
            // 
            // txtConNo
            // 
            txtConNo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConNo.Location = new Point(111, 145);
            txtConNo.Name = "txtConNo";
            txtConNo.PlaceholderText = "Có hả";
            txtConNo.ReadOnly = true;
            txtConNo.Size = new Size(151, 27);
            txtConNo.TabIndex = 13;
            txtConNo.Text = "0";
            txtConNo.TextAlign = HorizontalAlignment.Right;
            // 
            // txtTienThu
            // 
            txtTienThu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTienThu.Location = new Point(111, 93);
            txtTienThu.Name = "txtTienThu";
            txtTienThu.Size = new Size(151, 27);
            txtTienThu.TabIndex = 13;
            txtTienThu.Text = "0";
            txtTienThu.TextAlign = HorizontalAlignment.Right;
            txtTienThu.Click += txtTienThu_Enter;
            txtTienThu.Enter += txtTienThu_Enter;
            txtTienThu.KeyDown += txtTienThu_KeyDown;
            txtTienThu.Leave += txtTienThu_Leave;
            // 
            // cbDocGia
            // 
            cbDocGia.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDocGia.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbDocGia.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDocGia.FormattingEnabled = true;
            cbDocGia.Location = new Point(111, 36);
            cbDocGia.Name = "cbDocGia";
            cbDocGia.Size = new Size(207, 28);
            cbDocGia.TabIndex = 12;
            cbDocGia.SelectedIndexChanged += cbDocGia_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(323, 97);
            label7.Name = "label7";
            label7.Size = new Size(214, 17);
            label7.TabIndex = 11;
            label7.Text = "(Số tiền thu sẽ được trừ vào tổng nợ)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(268, 148);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 11;
            label6.Text = "VNĐ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(268, 96);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 11;
            label4.Text = "VNĐ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(19, 199);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 11;
            label8.Text = "Ngày thu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(19, 148);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 11;
            label5.Text = "Còn nợ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 96);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 11;
            label3.Text = "Số tiền thu";
            // 
            // lblTongNo
            // 
            lblTongNo.AutoSize = true;
            lblTongNo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongNo.Location = new Point(369, 39);
            lblTongNo.Name = "lblTongNo";
            lblTongNo.Size = new Size(71, 20);
            lblTongNo.TabIndex = 11;
            lblTongNo.Text = "Tổng nợ: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 39);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 11;
            label1.Text = "Độc giả";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Tomato;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(449, 258);
            btnCancel.Margin = new Padding(20);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(5);
            btnCancel.Size = new Size(94, 41);
            btnCancel.TabIndex = 9;
            btnCancel.Text = " Thoát";
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkTurquoise;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(352, 258);
            btnSave.Margin = new Padding(20);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(83, 41);
            btnSave.TabIndex = 10;
            btnSave.Text = "  Lưu";
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(roundPanel2);
            panel1.Controls.Add(roundPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(582, 413);
            panel1.TabIndex = 1;
            // 
            // roundPanel2
            // 
            roundPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel2.BackColor = Color.Transparent;
            roundPanel2.BackgroundColor = Color.White;
            roundPanel2.BorderColor = Color.White;
            roundPanel2.BorderRadius = 10;
            roundPanel2.BorderWidth = 0F;
            roundPanel2.Controls.Add(label2);
            roundPanel2.Location = new Point(10, 10);
            roundPanel2.Margin = new Padding(10);
            roundPanel2.Name = "roundPanel2";
            roundPanel2.Size = new Size(562, 66);
            roundPanel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(177, 18);
            label2.Name = "label2";
            label2.Size = new Size(202, 32);
            label2.TabIndex = 13;
            label2.Text = "PHIẾU THU TIỀN";
            // 
            // FrmAddPhieuThu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 413);
            Controls.Add(panel1);
            Name = "FrmAddPhieuThu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmAddPhieuThu";
            FormClosing += FrmAddPhieuThu_FormClosing;
            Load += FrmAddPhieuThu_Load;
            roundPanel1.ResumeLayout(false);
            roundPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            roundPanel2.ResumeLayout(false);
            roundPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.RoundPanel roundPanel1;
        private Panel panel1;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
        private ComboBox cbDocGia;
        private Label label2;
        private Label lblTongNo;
        private Controls.RoundPanel roundPanel2;
        private TextBox txtConNo;
        private TextBox txtTienThu;
        private Label label6;
        private Label label4;
        private Label label5;
        private Label label3;
        private DateTimePicker dtpNgayLapPhieu;
        private Label label7;
        private Label label8;
    }
}