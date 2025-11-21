namespace GUI.PhanQuyen
{
    partial class FrmPermissions
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
            dgvPermissions = new DataGridView();
            chucnang = new DataGridViewTextBoxColumn();
            truycap = new DataGridViewCheckBoxColumn();
            add = new DataGridViewCheckBoxColumn();
            edit = new DataGridViewCheckBoxColumn();
            delete = new DataGridViewCheckBoxColumn();
            roundPanel1 = new GUI.Controls.RoundPanel();
            panel2 = new Panel();
            txtUserGroupName = new TextBox();
            lbTotalUser = new Label();
            lbUserGroupName = new Label();
            label1 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPermissions).BeginInit();
            roundPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPermissions
            // 
            dgvPermissions.AllowUserToAddRows = false;
            dgvPermissions.AllowUserToDeleteRows = false;
            dgvPermissions.AllowUserToResizeColumns = false;
            dgvPermissions.AllowUserToResizeRows = false;
            dgvPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPermissions.BackgroundColor = Color.White;
            dgvPermissions.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPermissions.ColumnHeadersHeight = 30;
            dgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPermissions.Columns.AddRange(new DataGridViewColumn[] { chucnang, truycap, add, edit, delete });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPermissions.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPermissions.EnableHeadersVisualStyles = false;
            dgvPermissions.GridColor = SystemColors.InactiveCaption;
            dgvPermissions.Location = new Point(10, 146);
            dgvPermissions.Margin = new Padding(10);
            dgvPermissions.Name = "dgvPermissions";
            dgvPermissions.RowHeadersVisible = false;
            dgvPermissions.RowTemplate.Height = 30;
            dgvPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermissions.Size = new Size(760, 496);
            dgvPermissions.TabIndex = 0;
            // 
            // chucnang
            // 
            chucnang.DataPropertyName = "TenChucNang";
            chucnang.HeaderText = "Chức năng";
            chucnang.Name = "chucnang";
            // 
            // truycap
            // 
            truycap.DataPropertyName = "CoQuyenTruyCap";
            truycap.HeaderText = "Truy cập";
            truycap.Name = "truycap";
            truycap.Resizable = DataGridViewTriState.True;
            truycap.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // add
            // 
            add.DataPropertyName = "CoQuyenThem";
            add.HeaderText = "Thêm mới";
            add.Name = "add";
            // 
            // edit
            // 
            edit.DataPropertyName = "CoQuyenSua";
            edit.HeaderText = "Cập nhật";
            edit.Name = "edit";
            // 
            // delete
            // 
            delete.DataPropertyName = "CoQuyenXoa";
            delete.HeaderText = "Xóa";
            delete.Name = "delete";
            // 
            // roundPanel1
            // 
            roundPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundPanel1.BackColor = Color.Transparent;
            roundPanel1.BackgroundColor = Color.White;
            roundPanel1.BorderColor = Color.White;
            roundPanel1.BorderRadius = 10;
            roundPanel1.BorderWidth = 0F;
            roundPanel1.Controls.Add(panel2);
            roundPanel1.Controls.Add(label1);
            roundPanel1.Controls.Add(label2);
            roundPanel1.Controls.Add(btnCancel);
            roundPanel1.Controls.Add(btnSave);
            roundPanel1.Controls.Add(dgvPermissions);
            roundPanel1.Location = new Point(10, 10);
            roundPanel1.Margin = new Padding(10);
            roundPanel1.Name = "roundPanel1";
            roundPanel1.Size = new Size(780, 737);
            roundPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUserGroupName);
            panel2.Controls.Add(lbTotalUser);
            panel2.Controls.Add(lbUserGroupName);
            panel2.Location = new Point(10, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(365, 63);
            panel2.TabIndex = 13;
            // 
            // txtUserGroupName
            // 
            txtUserGroupName.Location = new Point(5, 34);
            txtUserGroupName.Name = "txtUserGroupName";
            txtUserGroupName.Size = new Size(357, 23);
            txtUserGroupName.TabIndex = 1;
            // 
            // lbTotalUser
            // 
            lbTotalUser.AutoSize = true;
            lbTotalUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTotalUser.Location = new Point(5, 34);
            lbTotalUser.Name = "lbTotalUser";
            lbTotalUser.Size = new Size(68, 17);
            lbTotalUser.TabIndex = 0;
            lbTotalUser.Text = "Số lượng: ";
            // 
            // lbUserGroupName
            // 
            lbUserGroupName.AutoSize = true;
            lbUserGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserGroupName.Location = new Point(3, 6);
            lbUserGroupName.Name = "lbUserGroupName";
            lbUserGroupName.Size = new Size(204, 21);
            lbUserGroupName.TabIndex = 0;
            lbUserGroupName.Text = "Nhập tên nhóm người dùng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 17);
            label1.Name = "label1";
            label1.Size = new Size(179, 25);
            label1.TabIndex = 11;
            label1.Text = "Nhóm người dùng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 111);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 11;
            label2.Text = "Thiết lập quyền";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Tomato;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(415, 677);
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
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.BackColor = Color.DarkTurquoise;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(292, 677);
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
            panel1.Controls.Add(roundPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 757);
            panel1.TabIndex = 2;
            // 
            // FrmPermissions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 757);
            Controls.Add(panel1);
            Name = "FrmPermissions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmPermissions";
            FormClosing += FrmPermissions_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPermissions).EndInit();
            roundPanel1.ResumeLayout(false);
            roundPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPermissions;
        private Controls.RoundPanel roundPanel1;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
        private DataGridViewTextBoxColumn chucnang;
        private DataGridViewCheckBoxColumn truycap;
        private DataGridViewCheckBoxColumn add;
        private DataGridViewCheckBoxColumn edit;
        private DataGridViewCheckBoxColumn delete;
        private Label label2;
        private Panel panel2;
        private Label lbUserGroupName;
        private Label label1;
        private TextBox txtUserGroupName;
        private Label lbTotalUser;
    }
}