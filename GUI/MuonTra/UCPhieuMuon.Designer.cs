using GUI.Controls;
using GUI.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.MuonTra
{
    partial class UCPhieuMuon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel panelTitle;
        private Label lblTitle;
        private RoundPanel roundPanelContainer;
        private ActionDataGridView dgvPhieuMuon;
        private Panel panelHeader;
        private Button btnTra;
        private Button btnGiaHan;
        private Button btnThem;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridViewTextBoxColumn colPhieu;
        private DataGridViewTextBoxColumn colDocGia;
        private DataGridViewTextBoxColumn colNgayMuon;
        private DataGridViewTextBoxColumn colHanTra;
        private DataGridViewTextBoxColumn colNgayTra;
        private DataGridViewTextBoxColumn colTinhTrang;
        private DataGridViewTextBoxColumn colGhiChu;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            SuspendLayout();
            //
            // panelTitle
            //
            panelTitle = new Panel();
            panelTitle.BackColor = Color.Transparent;
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1866, 84);
            panelTitle.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(34, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(292, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Mượn Trả";
            panelTitle.Controls.Add(lblTitle);
            //
            // panelHeader
            //
            panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 84);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1866, 112);
            panelHeader.TabIndex = 2;
            //
            // txtSearch
            //
            txtSearch = new TextBox();
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(13, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm phiếu mượn";
            txtSearch.Size = new Size(248, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            //
            // btnSearch
            //
            btnSearch = new Button();
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.DarkTurquoise;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.Location = new Point(276, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(65, 47);
            btnSearch.TabIndex = 1;
            btnSearch.UseVisualStyleBackColor = false;
            //
            // panelSearch
            //
            panelSearch = new Panel();
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Location = new Point(1027, 32);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(343, 48);
            panelSearch.TabIndex = 0;
            //
            // btnThem
            //
            btnThem = new Button();
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(1394, 32);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 48);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            //
            // btnGiaHan
            //
            btnGiaHan = new Button();
            btnGiaHan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGiaHan.BackColor = Color.DodgerBlue;
            btnGiaHan.FlatAppearance.BorderSize = 0;
            btnGiaHan.FlatStyle = FlatStyle.Flat;
            btnGiaHan.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnGiaHan.ForeColor = Color.White;
            btnGiaHan.Location = new Point(1495, 32);
            btnGiaHan.Name = "btnGiaHan";
            btnGiaHan.Size = new Size(100, 48);
            btnGiaHan.TabIndex = 2;
            btnGiaHan.Text = "Gia hạn";
            btnGiaHan.UseVisualStyleBackColor = false;
            btnGiaHan.Click += btnGiaHan_Click;
            //
            // btnTra
            //
            btnTra = new Button();
            btnTra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTra.BackColor = Color.LightSeaGreen;
            btnTra.FlatAppearance.BorderSize = 0;
            btnTra.FlatStyle = FlatStyle.Flat;
            btnTra.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTra.ForeColor = Color.White;
            btnTra.Location = new Point(1601, 32);
            btnTra.Name = "btnTra";
            btnTra.Size = new Size(92, 48);
            btnTra.TabIndex = 3;
            btnTra.Text = "Trả";
            btnTra.UseVisualStyleBackColor = false;
            btnTra.Click += btnTra_Click;
            //
            // colPhieu
            //
            colPhieu = new DataGridViewTextBoxColumn();
            colPhieu.HeaderText = "Phiếu";
            colPhieu.MinimumWidth = 6;
            colPhieu.Name = "colPhieu";
            colPhieu.ReadOnly = true;
            //
            // colDocGia
            //
            colDocGia = new DataGridViewTextBoxColumn();
            colDocGia.HeaderText = "Độc giả";
            colDocGia.MinimumWidth = 6;
            colDocGia.Name = "colDocGia";
            colDocGia.ReadOnly = true;
            //
            // colNgayMuon
            //
            colNgayMuon = new DataGridViewTextBoxColumn();
            colNgayMuon.HeaderText = "Ngày mượn";
            colNgayMuon.MinimumWidth = 6;
            colNgayMuon.Name = "colNgayMuon";
            colNgayMuon.ReadOnly = true;
            //
            // colHanTra
            //
            colHanTra = new DataGridViewTextBoxColumn();
            colHanTra.HeaderText = "Hạn trả";
            colHanTra.MinimumWidth = 6;
            colHanTra.Name = "colHanTra";
            colHanTra.ReadOnly = true;
            //
            // colNgayTra
            //
            colNgayTra = new DataGridViewTextBoxColumn();
            colNgayTra.HeaderText = "Ngày trả";
            colNgayTra.MinimumWidth = 6;
            colNgayTra.Name = "colNgayTra";
            colNgayTra.ReadOnly = true;
            //
            // colTinhTrang
            //
            colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.HeaderText = "Tình trạng";
            colTinhTrang.MinimumWidth = 6;
            colTinhTrang.Name = "colTinhTrang";
            colTinhTrang.ReadOnly = true;
            //
            // colGhiChu
            //
            colGhiChu = new DataGridViewTextBoxColumn();
            colGhiChu.HeaderText = "Ghi chú";
            colGhiChu.MinimumWidth = 6;
            colGhiChu.Name = "colGhiChu";
            colGhiChu.ReadOnly = true;
            //
            // dgvPhieuMuon
            //
            dgvPhieuMuon = new ActionDataGridView();
            dgvPhieuMuon.AllowUserToAddRows = false;
            dgvPhieuMuon.AllowUserToDeleteRows = false;
            dgvPhieuMuon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuMuon.BackgroundColor = Color.White;
            dgvPhieuMuon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPhieuMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPhieuMuon.ColumnHeadersHeight = 50;
            dgvPhieuMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPhieuMuon.Columns.AddRange(new DataGridViewColumn[] { colPhieu, colDocGia, colNgayMuon, colHanTra, colNgayTra, colTinhTrang, colGhiChu });
            dgvPhieuMuon.EnableHeadersVisualStyles = false;
            dgvPhieuMuon.GridColor = Color.Gainsboro;
            dgvPhieuMuon.Location = new Point(34, 213);
            dgvPhieuMuon.MultiSelect = false;
            dgvPhieuMuon.Name = "dgvPhieuMuon";
            dgvPhieuMuon.ReadOnly = true;
            dgvPhieuMuon.RowHeadersVisible = false;
            dgvPhieuMuon.RowTemplate.Height = 50;
            dgvPhieuMuon.ShowDeleteButton = false;
            dgvPhieuMuon.ShowEditButton = false;
            dgvPhieuMuon.ShowViewButton = true;
            dgvPhieuMuon.Size = new Size(1753, 714);
            dgvPhieuMuon.TabIndex = 3;
            //
            // roundPanelContainer
            //
            roundPanelContainer = new RoundPanel();
            roundPanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanelContainer.BackgroundColor = Color.White;
            roundPanelContainer.BorderColor = Color.Gainsboro;
            roundPanelContainer.BorderRadius = 10;
            roundPanelContainer.BorderWidth = 1F;
            roundPanelContainer.Controls.Add(dgvPhieuMuon);
            roundPanelContainer.Controls.Add(panelHeader);
            roundPanelContainer.Controls.Add(panelTitle);
            roundPanelContainer.Location = new Point(23, 27);
            roundPanelContainer.Name = "roundPanelContainer";
            roundPanelContainer.Size = new Size(1820, 951);
            roundPanelContainer.TabIndex = 1;
            //
            // panelHeader Controls
            //
            panelHeader.Controls.Add(btnTra);
            panelHeader.Controls.Add(btnGiaHan);
            panelHeader.Controls.Add(btnThem);
            panelHeader.Controls.Add(panelSearch);
            //
            // UCPhieuMuon
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundPanelContainer);
            Name = "UCPhieuMuon";
            Size = new Size(1866, 1005);
            ResumeLayout(false);
        }

        #endregion
    }
}
