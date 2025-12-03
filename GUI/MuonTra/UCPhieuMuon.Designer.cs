using GUI.Controls;
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
        private Button btnThem;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnImport;
        private Button btnExport;
        private ComboBox cbStatusFilter;
        private DataGridViewTextBoxColumn colPhieu;
        private DataGridViewTextBoxColumn colDocGia;
        private DataGridViewTextBoxColumn colNgayMuon;
        private DataGridViewTextBoxColumn colHanTra;
        private DataGridViewTextBoxColumn colTinhTrang;

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
            panelTitle = new Panel();
            lblTitle = new Label();
            panelHeader = new Panel();
            btnThem = new Button();
            cbStatusFilter = new ComboBox();
            panelSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnExport = new Button();
            btnImport = new Button();
            colPhieu = new DataGridViewTextBoxColumn();
            colDocGia = new DataGridViewTextBoxColumn();
            colNgayMuon = new DataGridViewTextBoxColumn();
            colHanTra = new DataGridViewTextBoxColumn();
            colTinhTrang = new DataGridViewTextBoxColumn();
            dgvPhieuMuon = new ActionDataGridView();
            roundPanelContainer = new RoundPanel();
            panelTitle.SuspendLayout();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuMuon).BeginInit();
            roundPanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.Transparent;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(30, 30);
            panelTitle.Margin = new Padding(4);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(2242, 88);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(42, 22);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(367, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Phiếu Mượn";
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnThem);
            panelHeader.Controls.Add(cbStatusFilter);
            panelHeader.Controls.Add(panelSearch);
            panelHeader.Controls.Add(btnExport);
            panelHeader.Controls.Add(btnImport);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(30, 118);
            panelHeader.Margin = new Padding(4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 22, 30, 15);
            panelHeader.Size = new Size(2242, 115);
            panelHeader.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Image = Properties.Resources.plus;
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(2001, 19);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(118, 58);
            btnThem.TabIndex = 14;
            btnThem.Text = "   Thêm";
            btnThem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.Font = new Font("Segoe UI", 10.2F);
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Items.AddRange(new object[] { "Tất cả", "Đang mượn", "Quá hạn", "Đã trả" });
            cbStatusFilter.Location = new Point(550, 31);
            cbStatusFilter.Margin = new Padding(4);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(188, 36);
            cbStatusFilter.TabIndex = 2;
            cbStatusFilter.SelectedIndexChanged += cbStatusFilter_SelectedIndexChanged;
            // 
            // panelSearch
            // 
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Location = new Point(30, 25);
            panelSearch.Margin = new Padding(4);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(480, 54);
            panelSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10.2F);
            txtSearch.Location = new Point(15, 12);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm mã phiếu, tên độc giả";
            txtSearch.Size = new Size(370, 28);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.DarkTurquoise;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(392, -1);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 55);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "  Tìm";
            btnSearch.TextAlign = ContentAlignment.MiddleLeft;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BackColor = Color.MediumSeaGreen;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1875, 19);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(118, 58);
            btnExport.TabIndex = 16;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImport.BackColor = Color.DarkOrange;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(1749, 19);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(118, 58);
            btnImport.TabIndex = 15;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // colPhieu
            // 
            colPhieu.HeaderText = "Phiếu";
            colPhieu.MinimumWidth = 6;
            colPhieu.Name = "colPhieu";
            colPhieu.ReadOnly = true;
            // 
            // colDocGia
            // 
            colDocGia.HeaderText = "Độc giả";
            colDocGia.MinimumWidth = 6;
            colDocGia.Name = "colDocGia";
            colDocGia.ReadOnly = true;
            // 
            // colNgayMuon
            // 
            colNgayMuon.HeaderText = "Ngày mượn";
            colNgayMuon.MinimumWidth = 6;
            colNgayMuon.Name = "colNgayMuon";
            colNgayMuon.ReadOnly = true;
            // 
            // colHanTra
            // 
            colHanTra.HeaderText = "Hạn trả";
            colHanTra.MinimumWidth = 6;
            colHanTra.Name = "colHanTra";
            colHanTra.ReadOnly = true;
            // 
            // colTinhTrang
            // 
            colTinhTrang.HeaderText = "Tình trạng";
            colTinhTrang.MinimumWidth = 6;
            colTinhTrang.Name = "colTinhTrang";
            colTinhTrang.ReadOnly = true;
            // 
            // dgvPhieuMuon
            // 
            dgvPhieuMuon.AllowUserToAddRows = false;
            dgvPhieuMuon.AllowUserToDeleteRows = false;
            dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuMuon.BackgroundColor = Color.White;
            dgvPhieuMuon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPhieuMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPhieuMuon.ColumnHeadersHeight = 46;
            dgvPhieuMuon.Columns.AddRange(new DataGridViewColumn[] { colPhieu, colDocGia, colNgayMuon, colHanTra, colTinhTrang });
            dgvPhieuMuon.Dock = DockStyle.Fill;
            dgvPhieuMuon.EnableHeadersVisualStyles = false;
            dgvPhieuMuon.GridColor = Color.Gainsboro;
            dgvPhieuMuon.Location = new Point(30, 233);
            dgvPhieuMuon.Margin = new Padding(4);
            dgvPhieuMuon.MultiSelect = false;
            dgvPhieuMuon.Name = "dgvPhieuMuon";
            dgvPhieuMuon.ReadOnly = true;
            dgvPhieuMuon.RowHeadersVisible = false;
            dgvPhieuMuon.RowHeadersWidth = 62;
            dgvPhieuMuon.RowTemplate.Height = 48;
            dgvPhieuMuon.ShowDeleteButton = true;
            dgvPhieuMuon.ShowEditButton = true;
            dgvPhieuMuon.ShowExtendButton = false;
            dgvPhieuMuon.ShowReturnButton = false;
            dgvPhieuMuon.ShowViewButton = true;
            dgvPhieuMuon.Size = new Size(2242, 926);
            dgvPhieuMuon.TabIndex = 3;
            // 
            // roundPanelContainer
            // 
            roundPanelContainer.BackColor = Color.Transparent;
            roundPanelContainer.BackgroundColor = Color.White;
            roundPanelContainer.BorderColor = Color.Gainsboro;
            roundPanelContainer.BorderRadius = 10;
            roundPanelContainer.BorderWidth = 1F;
            roundPanelContainer.Controls.Add(dgvPhieuMuon);
            roundPanelContainer.Controls.Add(panelHeader);
            roundPanelContainer.Controls.Add(panelTitle);
            roundPanelContainer.Dock = DockStyle.Fill;
            roundPanelContainer.Location = new Point(15, 15);
            roundPanelContainer.Margin = new Padding(0);
            roundPanelContainer.Name = "roundPanelContainer";
            roundPanelContainer.Padding = new Padding(30);
            roundPanelContainer.Size = new Size(2302, 1189);
            roundPanelContainer.TabIndex = 1;
            // 
            // UCPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundPanelContainer);
            Margin = new Padding(4);
            Name = "UCPhieuMuon";
            Padding = new Padding(15);
            Size = new Size(2332, 1219);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuMuon).EndInit();
            roundPanelContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
