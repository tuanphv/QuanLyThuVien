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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            actionDataGridView1 = new GUI.Controls.ActionDataGridView();
            IDCol = new DataGridViewTextBoxColumn();
            GroupIdCol = new DataGridViewTextBoxColumn();
            GroupNameCol = new DataGridViewTextBoxColumn();
            TotalCol = new DataGridViewTextBoxColumn();
            Actions = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            label6 = new Label();
            roundPanel2 = new GUI.Controls.RoundPanel();
            ((System.ComponentModel.ISupportInitialize)actionDataGridView1).BeginInit();
            panel1.SuspendLayout();
            roundPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // actionDataGridView1
            // 
            actionDataGridView1.AllowUserToAddRows = false;
            actionDataGridView1.AllowUserToDeleteRows = false;
            actionDataGridView1.AllowUserToResizeColumns = false;
            actionDataGridView1.AllowUserToResizeRows = false;
            actionDataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            actionDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            actionDataGridView1.BackgroundColor = Color.White;
            actionDataGridView1.BorderStyle = BorderStyle.None;
            actionDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            actionDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            actionDataGridView1.ColumnHeadersHeight = 40;
            actionDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            actionDataGridView1.Columns.AddRange(new DataGridViewColumn[] { IDCol, GroupIdCol, GroupNameCol, TotalCol, Actions });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            actionDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            actionDataGridView1.EnableHeadersVisualStyles = false;
            actionDataGridView1.GridColor = Color.LightGray;
            actionDataGridView1.Location = new Point(20, 20);
            actionDataGridView1.Margin = new Padding(20);
            actionDataGridView1.MultiSelect = false;
            actionDataGridView1.Name = "actionDataGridView1";
            actionDataGridView1.ReadOnly = true;
            actionDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            actionDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            actionDataGridView1.RowTemplate.Height = 40;
            actionDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            actionDataGridView1.ShowDeleteButton = true;
            actionDataGridView1.ShowEditButton = true;
            actionDataGridView1.ShowViewButton = true;
            actionDataGridView1.Size = new Size(1081, 724);
            actionDataGridView1.TabIndex = 0;
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
            roundPanel2.Controls.Add(actionDataGridView1);
            roundPanel2.Location = new Point(20, 90);
            roundPanel2.Margin = new Padding(20);
            roundPanel2.Name = "roundPanel2";
            roundPanel2.Size = new Size(1121, 764);
            roundPanel2.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)actionDataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roundPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Controls.RoundPanel roundPanel2;
        private Controls.ActionDataGridView actionDataGridView1;
        private DataGridViewTextBoxColumn IDCol;
        private DataGridViewTextBoxColumn GroupIdCol;
        private DataGridViewTextBoxColumn GroupNameCol;
        private DataGridViewTextBoxColumn TotalCol;
        private DataGridViewTextBoxColumn Actions;
    }
}
