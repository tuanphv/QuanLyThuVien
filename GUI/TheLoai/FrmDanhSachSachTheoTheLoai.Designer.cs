namespace GUI.TheLoai
{
    partial class FrmDanhSachSachTheoTheLoai
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
            TacGia = new DataGridViewTextBoxColumn();
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
            dgvSach.Columns.AddRange(new DataGridViewColumn[] { MaTuaSach, TenTuaSach, TacGia });
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
            dgvSach.Size = new Size(890, 507);
            dgvSach.TabIndex = 14;
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
            // TacGia
            // 
            TacGia.DataPropertyName = "TacGia";
            TacGia.HeaderText = "Tác Giả";
            TacGia.MinimumWidth = 6;
            TacGia.Name = "TacGia";
            // 
            // FrmDanhSachSachTheoTheLoai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 507);
            Controls.Add(dgvSach);
            Name = "FrmDanhSachSachTheoTheLoai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDanhSachSachTheoTheLoai";
            Load += FrmDanhSachSachTheoTheLoai_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSach;
        private DataGridViewTextBoxColumn MaTuaSach;
        private DataGridViewTextBoxColumn TenTuaSach;
        private DataGridViewTextBoxColumn TacGia;
    }
}