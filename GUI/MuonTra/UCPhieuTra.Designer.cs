using GUI.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    partial class UCPhieuTra
    {
        private System.ComponentModel.IContainer components = null!;
        private Panel panelTitle;
        private Label lblTitle;
        private RoundPanel roundPanelContainer;
        private Panel panelHeader;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnLapPhieuTra;
        private ActionDataGridView dgvPhieuTra;
        private DataGridViewTextBoxColumn colMaPhieu;
        private DataGridViewTextBoxColumn colDocGia;
        private DataGridViewTextBoxColumn colNgayTra;
        private DataGridViewTextBoxColumn colTongSach;
        private DataGridViewTextBoxColumn colTienPhat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            components = new System.ComponentModel.Container();
            panelTitle = new Panel();
            lblTitle = new Label();
            panelHeader = new Panel();
            panelSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnLapPhieuTra = new Button();
            dgvPhieuTra = new ActionDataGridView();
            colMaPhieu = new DataGridViewTextBoxColumn();
            colDocGia = new DataGridViewTextBoxColumn();
            colNgayTra = new DataGridViewTextBoxColumn();
            colTongSach = new DataGridViewTextBoxColumn();
            colTienPhat = new DataGridViewTextBoxColumn();
            roundPanelContainer = new RoundPanel();
            panelTitle.SuspendLayout();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuTra).BeginInit();
            roundPanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.Transparent;
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1866, 70);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(34, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(226, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý trả sách";
            panelTitle.Controls.Add(lblTitle);
            // 
            // panelHeader
            // 
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 70);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1866, 90);
            panelHeader.TabIndex = 1;
            panelHeader.Controls.Add(btnLapPhieuTra);
            panelHeader.Controls.Add(panelSearch);
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Location = new Point(1200, 23);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(300, 44);
            panelSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(12, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm mã phiếu/độc giả";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.DarkTurquoise;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(220, -1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 44);
            btnSearch.TabIndex = 1;
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnLapPhieuTra
            // 
            btnLapPhieuTra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLapPhieuTra.BackColor = Color.MediumSeaGreen;
            btnLapPhieuTra.FlatAppearance.BorderSize = 0;
            btnLapPhieuTra.FlatStyle = FlatStyle.Flat;
            btnLapPhieuTra.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLapPhieuTra.ForeColor = Color.White;
            btnLapPhieuTra.Location = new Point(1520, 22);
            btnLapPhieuTra.Name = "btnLapPhieuTra";
            btnLapPhieuTra.Size = new Size(160, 46);
            btnLapPhieuTra.TabIndex = 2;
            btnLapPhieuTra.Text = "Tạo phiếu trả";
            btnLapPhieuTra.UseVisualStyleBackColor = false;
            btnLapPhieuTra.Click += btnLapPhieuTra_Click;
            // 
            // dgvPhieuTra
            // 
            dgvPhieuTra.AllowUserToAddRows = false;
            dgvPhieuTra.AllowUserToDeleteRows = false;
            dgvPhieuTra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhieuTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuTra.BackgroundColor = Color.White;
            dgvPhieuTra.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPhieuTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPhieuTra.ColumnHeadersHeight = 46;
            dgvPhieuTra.Columns.AddRange(new DataGridViewColumn[] { colMaPhieu, colDocGia, colNgayTra, colTongSach, colTienPhat });
            dgvPhieuTra.EnableHeadersVisualStyles = false;
            dgvPhieuTra.GridColor = Color.Gainsboro;
            dgvPhieuTra.Location = new Point(34, 180);
            dgvPhieuTra.MultiSelect = false;
            dgvPhieuTra.Name = "dgvPhieuTra";
            dgvPhieuTra.ReadOnly = true;
            dgvPhieuTra.RowHeadersVisible = false;
            dgvPhieuTra.RowTemplate.Height = 48;
            dgvPhieuTra.ShowDeleteButton = true;
            dgvPhieuTra.ShowEditButton = false;
            dgvPhieuTra.ShowViewButton = true;
            dgvPhieuTra.Size = new Size(1753, 721);
            dgvPhieuTra.TabIndex = 2;
            // 
            // colMaPhieu
            // 
            colMaPhieu.HeaderText = "Phiếu";
            colMaPhieu.MinimumWidth = 6;
            colMaPhieu.Name = "colMaPhieu";
            colMaPhieu.ReadOnly = true;
            // 
            // colDocGia
            // 
            colDocGia.HeaderText = "Độc giả";
            colDocGia.MinimumWidth = 6;
            colDocGia.Name = "colDocGia";
            colDocGia.ReadOnly = true;
            // 
            // colNgayTra
            // 
            colNgayTra.HeaderText = "Ngày trả";
            colNgayTra.MinimumWidth = 6;
            colNgayTra.Name = "colNgayTra";
            colNgayTra.ReadOnly = true;
            // 
            // colTongSach
            // 
            colTongSach.HeaderText = "Sách đã trả";
            colTongSach.MinimumWidth = 6;
            colTongSach.Name = "colTongSach";
            colTongSach.ReadOnly = true;
            // 
            // colTienPhat
            // 
            colTienPhat.HeaderText = "Tiền phạt";
            colTienPhat.MinimumWidth = 6;
            colTienPhat.Name = "colTienPhat";
            colTienPhat.ReadOnly = true;
            // 
            // roundPanelContainer
            // 
            roundPanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanelContainer.BackgroundColor = Color.White;
            roundPanelContainer.BorderColor = Color.Gainsboro;
            roundPanelContainer.BorderRadius = 10;
            roundPanelContainer.BorderWidth = 1F;
            roundPanelContainer.Controls.Add(dgvPhieuTra);
            roundPanelContainer.Controls.Add(panelHeader);
            roundPanelContainer.Controls.Add(panelTitle);
            roundPanelContainer.Location = new Point(23, 20);
            roundPanelContainer.Name = "roundPanelContainer";
            roundPanelContainer.Size = new Size(1820, 930);
            roundPanelContainer.TabIndex = 3;
            // 
            // UCPhieuTra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundPanelContainer);
            Name = "UCPhieuTra";
            Size = new Size(1866, 975);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuTra).EndInit();
            roundPanelContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
