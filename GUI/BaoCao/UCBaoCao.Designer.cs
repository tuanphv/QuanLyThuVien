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
            btnLoadQuaHan = new Button();
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
            panel2.Controls.Add(btnLoadQuaHan);
            panel2.Location = new Point(20, 90);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1593, 45);
            panel2.TabIndex = 1;
            // 
            // btnLoadQuaHan
            // 
            btnLoadQuaHan.BackColor = Color.DeepSkyBlue;
            btnLoadQuaHan.FlatAppearance.BorderSize = 0;
            btnLoadQuaHan.FlatStyle = FlatStyle.Flat;
            btnLoadQuaHan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLoadQuaHan.ForeColor = Color.White;
            btnLoadQuaHan.Location = new Point(9, 9);
            btnLoadQuaHan.Margin = new Padding(3, 2, 3, 2);
            btnLoadQuaHan.Name = "btnLoadQuaHan";
            btnLoadQuaHan.Size = new Size(131, 26);
            btnLoadQuaHan.TabIndex = 0;
            btnLoadQuaHan.Text = "Tải dữ liệu";
            btnLoadQuaHan.UseVisualStyleBackColor = false;
            btnLoadQuaHan.Click += btnLoadQuaHan_Click;
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
            ((System.ComponentModel.ISupportInitialize)dgvQuaHan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnLoadQuaHan;
        private DataGridView dgvQuaHan;
    }
}
