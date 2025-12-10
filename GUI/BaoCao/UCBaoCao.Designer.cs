namespace GUI.BaoCao
{
    partial class UCBaoCao
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnExportExcel = new Button();
            btnLoadNoDocGia = new Button();
            btnLoadQuaHan = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            dgvQuaHan = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1633, 70);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(267, 37);
            label1.TabIndex = 0;
            label1.Text = "Báo cáo nợ quá hạn";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnExportExcel);
            panel2.Controls.Add(btnLoadNoDocGia);
            panel2.Controls.Add(btnLoadQuaHan);
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(20, 90);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1593, 45);
            panel2.TabIndex = 1;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.BackColor = Color.FromArgb(40, 167, 69);
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(1450, 9);
            btnExportExcel.Margin = new Padding(3, 2, 3, 2);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(131, 26);
            btnExportExcel.TabIndex = 4;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnLoadNoDocGia
            // 
            btnLoadNoDocGia.BackColor = Color.DeepSkyBlue;
            btnLoadNoDocGia.FlatAppearance.BorderSize = 0;
            btnLoadNoDocGia.FlatStyle = FlatStyle.Flat;
            btnLoadNoDocGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadNoDocGia.ForeColor = Color.White;
            btnLoadNoDocGia.Location = new Point(9, 9);
            btnLoadNoDocGia.Margin = new Padding(3, 2, 3, 2);
            btnLoadNoDocGia.Name = "btnLoadNoDocGia";
            btnLoadNoDocGia.Size = new Size(170, 26);
            btnLoadNoDocGia.TabIndex = 0;
            btnLoadNoDocGia.Text = "Báo cáo nợ độc giả";
            btnLoadNoDocGia.UseVisualStyleBackColor = false;
            btnLoadNoDocGia.Click += btnLoadNoDocGia_Click;
            // 
            // btnLoadQuaHan
            // 
            btnLoadQuaHan.BackColor = Color.SlateGray;
            btnLoadQuaHan.FlatAppearance.BorderSize = 0;
            btnLoadQuaHan.FlatStyle = FlatStyle.Flat;
            btnLoadQuaHan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadQuaHan.ForeColor = Color.White;
            btnLoadQuaHan.Location = new Point(185, 9);
            btnLoadQuaHan.Margin = new Padding(3, 2, 3, 2);
            btnLoadQuaHan.Name = "btnLoadQuaHan";
            btnLoadQuaHan.Size = new Size(170, 26);
            btnLoadQuaHan.TabIndex = 1;
            btnLoadQuaHan.Text = "Báo cáo theo phiếu";
            btnLoadQuaHan.UseVisualStyleBackColor = false;
            btnLoadQuaHan.Visible = false;
            btnLoadQuaHan.Click += btnLoadQuaHan_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(1130, 9);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên độc giả...";
            txtTimKiem.Size = new Size(300, 25);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(1050, 12);
            label2.Name = "label2";
            label2.Size = new Size(67, 19);
            label2.TabIndex = 2;
            label2.Text = "Tìm kiếm:";
            // 
            // dgvQuaHan
            // 
            dgvQuaHan.AllowUserToAddRows = false;
            dgvQuaHan.AllowUserToDeleteRows = false;
            dgvQuaHan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuaHan.BackgroundColor = Color.White;
            dgvQuaHan.BorderStyle = BorderStyle.None;
            dgvQuaHan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuaHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuaHan.ColumnHeadersHeight = 40;
            dgvQuaHan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvQuaHan.DefaultCellStyle = dataGridViewCellStyle2;
            dgvQuaHan.EnableHeadersVisualStyles = false;
            dgvQuaHan.GridColor = SystemColors.ControlLight;
            dgvQuaHan.Location = new Point(20, 146);
            dgvQuaHan.Margin = new Padding(3, 2, 3, 2);
            dgvQuaHan.Name = "dgvQuaHan";
            dgvQuaHan.ReadOnly = true;
            dgvQuaHan.RowHeadersVisible = false;
            dgvQuaHan.RowHeadersWidth = 51;
            dgvQuaHan.RowTemplate.Height = 40;
            dgvQuaHan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuaHan.Size = new Size(1593, 588);
            dgvQuaHan.TabIndex = 2;
            dgvQuaHan.CellDoubleClick += dgvQuaHan_CellDoubleClick;
            // 
            // UCBaoCao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(dgvQuaHan);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCBaoCao";
            Size = new Size(1633, 754);
            Load += UCBaoCao_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnLoadNoDocGia;
        private Button btnLoadQuaHan;
        private DataGridView dgvQuaHan;
        private TextBox txtTimKiem;
        private Label label2;
        private Button btnExportExcel;
    }
}
