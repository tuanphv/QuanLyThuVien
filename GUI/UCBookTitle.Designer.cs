namespace GUI
{
    partial class UCBookTitle
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
            dgvBooks = new DataGridView();
            idCol = new DataGridViewTextBoxColumn();
            maTuaSachCol = new DataGridViewTextBoxColumn();
            tenTuaSachCol = new DataGridViewTextBoxColumn();
            anhBiaCol = new DataGridViewImageColumn();
            daAnCol = new DataGridViewCheckBoxColumn();
            panel1 = new Panel();
            pnlGenres = new FlowLayoutPanel();
            ptbBookcover = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            roundedPanel1 = new GUI.Controls.RoundPanel();
            roundedPanel2 = new GUI.Controls.RoundPanel();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBookcover).BeginInit();
            roundedPanel1.SuspendLayout();
            roundedPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeColumns = false;
            dgvBooks.AllowUserToResizeRows = false;
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBooks.ColumnHeadersHeight = 30;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { idCol, maTuaSachCol, tenTuaSachCol, anhBiaCol, daAnCol });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(188, 220, 244);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBooks.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.GridColor = Color.LightGray;
            dgvBooks.Location = new Point(20, 20);
            dgvBooks.Margin = new Padding(20);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowTemplate.Height = 30;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(832, 650);
            dgvBooks.TabIndex = 10;
            // 
            // idCol
            // 
            idCol.DataPropertyName = "Id";
            idCol.HeaderText = "ID";
            idCol.Name = "idCol";
            idCol.ReadOnly = true;
            // 
            // maTuaSachCol
            // 
            maTuaSachCol.DataPropertyName = "MaTuaSach";
            maTuaSachCol.HeaderText = "Mã tựa sách";
            maTuaSachCol.Name = "maTuaSachCol";
            maTuaSachCol.ReadOnly = true;
            maTuaSachCol.Visible = false;
            // 
            // tenTuaSachCol
            // 
            tenTuaSachCol.DataPropertyName = "TenTuaSach";
            tenTuaSachCol.HeaderText = "Tên tựa sách";
            tenTuaSachCol.Name = "tenTuaSachCol";
            tenTuaSachCol.ReadOnly = true;
            // 
            // anhBiaCol
            // 
            anhBiaCol.DataPropertyName = "AnhBia";
            anhBiaCol.HeaderText = "Ảnh bìa";
            anhBiaCol.Name = "anhBiaCol";
            anhBiaCol.ReadOnly = true;
            // 
            // daAnCol
            // 
            daAnCol.DataPropertyName = "DaAn";
            daAnCol.FalseValue = "0";
            daAnCol.FlatStyle = FlatStyle.Flat;
            daAnCol.HeaderText = "Đã ẩn";
            daAnCol.Name = "daAnCol";
            daAnCol.ReadOnly = true;
            daAnCol.Resizable = DataGridViewTriState.True;
            daAnCol.SortMode = DataGridViewColumnSortMode.Automatic;
            daAnCol.TrueValue = "1";
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
            panel1.Size = new Size(1400, 70);
            panel1.TabIndex = 1;
            // 
            // pnlGenres
            // 
            pnlGenres.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlGenres.BackColor = Color.WhiteSmoke;
            pnlGenres.BorderStyle = BorderStyle.FixedSingle;
            pnlGenres.Location = new Point(20, 281);
            pnlGenres.Margin = new Padding(20, 10, 20, 10);
            pnlGenres.Name = "pnlGenres";
            pnlGenres.Size = new Size(427, 119);
            pnlGenres.TabIndex = 5;
            // 
            // ptbBookcover
            // 
            ptbBookcover.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ptbBookcover.BackColor = Color.Gainsboro;
            ptbBookcover.Location = new Point(20, 20);
            ptbBookcover.Margin = new Padding(20);
            ptbBookcover.Name = "ptbBookcover";
            ptbBookcover.Size = new Size(209, 208);
            ptbBookcover.TabIndex = 0;
            ptbBookcover.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1145, 130);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã sách";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1231, 128);
            textBox1.Margin = new Padding(8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(139, 29);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1145, 175);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 0;
            label2.Text = "ISBN";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(1231, 173);
            textBox2.Margin = new Padding(8);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(139, 29);
            textBox2.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1145, 220);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 0;
            label3.Text = "Năm XB";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(1231, 218);
            textBox3.Margin = new Padding(8);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(139, 29);
            textBox3.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(1145, 265);
            label4.Name = "label4";
            label4.Size = new Size(75, 23);
            label4.TabIndex = 0;
            label4.Text = "Giá sách";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(1231, 263);
            textBox4.Margin = new Padding(8);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(139, 29);
            textBox4.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 248);
            label5.Name = "label5";
            label5.Size = new Size(75, 23);
            label5.TabIndex = 0;
            label5.Text = "Thể loại";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.White;
            roundedPanel1.BorderRadius = 10;
            roundedPanel1.Controls.Add(dgvBooks);
            roundedPanel1.Location = new Point(20, 90);
            roundedPanel1.Margin = new Padding(20);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(872, 690);
            roundedPanel1.TabIndex = 6;
            // 
            // roundedPanel2
            // 
            roundedPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            roundedPanel2.BackColor = Color.White;
            roundedPanel2.BorderRadius = 10;
            roundedPanel2.Controls.Add(pnlGenres);
            roundedPanel2.Controls.Add(ptbBookcover);
            roundedPanel2.Controls.Add(label5);
            roundedPanel2.Location = new Point(912, 90);
            roundedPanel2.Margin = new Padding(20);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(467, 690);
            roundedPanel2.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(233, 37);
            label6.TabIndex = 0;
            label6.Text = "Quản lý Tựa sách";
            // 
            // UCBookTitle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(roundedPanel1);
            Controls.Add(roundedPanel2);
            Name = "UCBookTitle";
            Size = new Size(1400, 800);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBookcover).EndInit();
            roundedPanel1.ResumeLayout(false);
            roundedPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.CustomDataGridView customDataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridView dgvBooks;
        private DataGridViewCheckBoxColumn selectCol;
        private Panel panel1;
        private FlowLayoutPanel pnlGenres;
        private PictureBox ptbBookcover;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private Controls.RoundPanel roundedPanel1;
        private Controls.RoundPanel roundedPanel2;
        private DataGridViewTextBoxColumn idCol;
        private DataGridViewTextBoxColumn maTuaSachCol;
        private DataGridViewTextBoxColumn tenTuaSachCol;
        private DataGridViewImageColumn anhBiaCol;
        private DataGridViewCheckBoxColumn daAnCol;
        private Label label6;
    }
}
