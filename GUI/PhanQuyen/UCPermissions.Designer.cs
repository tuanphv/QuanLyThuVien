namespace GUI.PhanQuyen
{
    partial class UCPermissions
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvUsersGroup = new GUI.Controls.ActionDataGridView();
            IDCol = new DataGridViewTextBoxColumn();
            GroupIdCol = new DataGridViewTextBoxColumn();
            GroupNameCol = new DataGridViewTextBoxColumn();
            TotalCol = new DataGridViewTextBoxColumn();
            Actions = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            label6 = new Label();
            roundPanel2 = new GUI.Controls.RoundPanel();
            btnAddBookTitle = new Button();
            panel3 = new Panel();
            btnSearch = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsersGroup).BeginInit();
            panel1.SuspendLayout();
            roundPanel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsersGroup
            // 
            dgvUsersGroup.AllowUserToAddRows = false;
            dgvUsersGroup.AllowUserToDeleteRows = false;
            dgvUsersGroup.AllowUserToResizeColumns = false;
            dgvUsersGroup.AllowUserToResizeRows = false;
            dgvUsersGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsersGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsersGroup.BackgroundColor = Color.White;
            dgvUsersGroup.BorderStyle = BorderStyle.None;
            dgvUsersGroup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvUsersGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvUsersGroup.ColumnHeadersHeight = 40;
            dgvUsersGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsersGroup.Columns.AddRange(new DataGridViewColumn[] { IDCol, GroupIdCol, GroupNameCol, TotalCol, Actions });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvUsersGroup.DefaultCellStyle = dataGridViewCellStyle5;
            dgvUsersGroup.EnableHeadersVisualStyles = false;
            dgvUsersGroup.GridColor = Color.LightGray;
            dgvUsersGroup.Location = new Point(20, 69);
            dgvUsersGroup.Margin = new Padding(20);
            dgvUsersGroup.MultiSelect = false;
            dgvUsersGroup.Name = "dgvUsersGroup";
            dgvUsersGroup.ReadOnly = true;
            dgvUsersGroup.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dgvUsersGroup.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvUsersGroup.RowTemplate.Height = 40;
            dgvUsersGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsersGroup.ShowDeleteButton = true;
            dgvUsersGroup.ShowEditButton = true;
            dgvUsersGroup.ShowViewButton = true;
            dgvUsersGroup.Size = new Size(1081, 675);
            dgvUsersGroup.TabIndex = 0;
            // 
            // IDCol
            // 
            IDCol.DataPropertyName = "ID";
            IDCol.HeaderText = "ID";
            IDCol.Name = "IDCol";
            IDCol.ReadOnly = true;
            IDCol.Visible = false;
            // 
            // GroupIdCol
            // 
            GroupIdCol.DataPropertyName = "MaNhom";
            GroupIdCol.HeaderText = "Mã nhóm";
            GroupIdCol.Name = "GroupIdCol";
            GroupIdCol.ReadOnly = true;
            // 
            // GroupNameCol
            // 
            GroupNameCol.DataPropertyName = "TenNhom";
            GroupNameCol.HeaderText = "Tên nhóm";
            GroupNameCol.Name = "GroupNameCol";
            GroupNameCol.ReadOnly = true;
            // 
            // TotalCol
            // 
            TotalCol.DataPropertyName = "TongSoNguoi";
            TotalCol.HeaderText = "Số người dùng";
            TotalCol.Name = "TotalCol";
            TotalCol.ReadOnly = true;
            // 
            // Actions
            // 
            Actions.HeaderText = "Thao tác";
            Actions.Name = "Actions";
            Actions.ReadOnly = true;
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
            panel1.Size = new Size(1161, 70);
            panel1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(271, 37);
            label6.TabIndex = 0;
            label6.Text = "Quản lý Phân quyền";
            // 
            // roundPanel2
            // 
            roundPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel2.BackColor = Color.Transparent;
            roundPanel2.BackgroundColor = Color.White;
            roundPanel2.BorderColor = Color.White;
            roundPanel2.BorderRadius = 10;
            roundPanel2.BorderWidth = 0F;
            roundPanel2.Controls.Add(btnAddBookTitle);
            roundPanel2.Controls.Add(panel3);
            roundPanel2.Controls.Add(dgvUsersGroup);
            roundPanel2.Location = new Point(20, 90);
            roundPanel2.Margin = new Padding(20);
            roundPanel2.Name = "roundPanel2";
            roundPanel2.Size = new Size(1121, 764);
            roundPanel2.TabIndex = 1;
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
            btnAddBookTitle.Location = new Point(984, 20);
            btnAddBookTitle.Margin = new Padding(20);
            btnAddBookTitle.Name = "btnAddBookTitle";
            btnAddBookTitle.Padding = new Padding(3);
            btnAddBookTitle.Size = new Size(117, 30);
            btnAddBookTitle.TabIndex = 15;
            btnAddBookTitle.Text = "  Thêm NND";
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
            panel3.Location = new Point(399, 20);
            panel3.Margin = new Padding(20);
            panel3.Name = "panel3";
            panel3.Size = new Size(545, 30);
            panel3.TabIndex = 14;
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
            // UCPermissions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(roundPanel2);
            Controls.Add(panel1);
            Name = "UCPermissions";
            Size = new Size(1161, 874);
            Load += UCPermissions_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsersGroup).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Controls.RoundPanel roundPanel2;
        private Controls.ActionDataGridView dgvUsersGroup;
        private DataGridViewTextBoxColumn IDCol;
        private DataGridViewTextBoxColumn GroupIdCol;
        private DataGridViewTextBoxColumn GroupNameCol;
        private DataGridViewTextBoxColumn TotalCol;
        private DataGridViewTextBoxColumn Actions;
        private Button btnAddBookTitle;
        private Panel panel3;
        private Button btnSearch;
        private TextBox textBox1;
    }
}
