namespace GUI.TacGia
{
    partial class FrmDanhSachSachTheoTacGia
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvSach = new DataGridView();
            MaTuaSach = new DataGridViewTextBoxColumn();
            TenTuaSach = new DataGridViewTextBoxColumn();
            TheLoai = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
            SuspendLayout();
            // 
            // dgvSach
            // 
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.AllowUserToResizeColumns = false;
            dgvSach.AllowUserToResizeRows = false;
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.BackgroundColor = Color.White;
            dgvSach.BorderStyle = BorderStyle.None;
            dgvSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSach.ColumnHeadersHeight = 45;
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSach.Columns.AddRange(new DataGridViewColumn[] { MaTuaSach, TenTuaSach, TheLoai });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSach.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSach.Dock = DockStyle.Fill;
            dgvSach.EnableHeadersVisualStyles = false;
            dgvSach.GridColor = SystemColors.ControlLight;
            dgvSach.Location = new Point(0, 0);
            dgvSach.Name = "dgvSach";
            dgvSach.RowHeadersVisible = false;
            dgvSach.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvSach.RowTemplate.Height = 40;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.ShowCellErrors = false;
            dgvSach.ShowCellToolTips = false;
            dgvSach.ShowEditingIcon = false;
            dgvSach.ShowRowErrors = false;
            dgvSach.Size = new Size(833, 475);
            dgvSach.TabIndex = 15;
            // 
            // MaTuaSach
            // 
            MaTuaSach.DataPropertyName = "MaTuaSach";
            MaTuaSach.HeaderText = "Mã Tựa Sách";
            MaTuaSach.MinimumWidth = 6;
            MaTuaSach.Name = "MaTuaSach";
            // 
            // TenTuaSach
            // 
            TenTuaSach.DataPropertyName = "TenTuaSach";
            TenTuaSach.HeaderText = "Tên Tựa Sách";
            TenTuaSach.MinimumWidth = 6;
            TenTuaSach.Name = "TenTuaSach";
            // 
            // TheLoai
            // 
            TheLoai.DataPropertyName = "TheLoai";
            TheLoai.HeaderText = "Thể Loại";
            TheLoai.MinimumWidth = 6;
            TheLoai.Name = "TheLoai";
            // 
            // FrmDanhSachSachTheoTacGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 475);
            Controls.Add(dgvSach);
            Name = "FrmDanhSachSachTheoTacGia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sách";
            Load += FrmDanhSachSachTheoTacGia_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSach;
        private DataGridViewTextBoxColumn MaTuaSach;
        private DataGridViewTextBoxColumn TenTuaSach;
        private DataGridViewTextBoxColumn TheLoai;
    }
}