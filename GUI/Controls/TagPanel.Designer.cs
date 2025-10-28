namespace GUI.Controls
{
    partial class TagPanel
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
            lblTagText = new Label();
            btnXmark = new Button();
            SuspendLayout();
            // 
            // lblTagText
            // 
            lblTagText.AutoSize = true;
            lblTagText.BackColor = Color.Transparent;
            lblTagText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTagText.Location = new Point(3, 4);
            lblTagText.Margin = new Padding(3, 3, 20, 4);
            lblTagText.Name = "lblTagText";
            lblTagText.Size = new Size(52, 21);
            lblTagText.TabIndex = 0;
            lblTagText.Text = "label1";
            // 
            // btnXmark
            // 
            btnXmark.Anchor = AnchorStyles.Right;
            btnXmark.BackColor = Color.Transparent;
            btnXmark.FlatAppearance.BorderSize = 0;
            btnXmark.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 255, 255, 255);
            btnXmark.FlatStyle = FlatStyle.Flat;
            btnXmark.Location = new Point(51, 4);
            btnXmark.Margin = new Padding(0);
            btnXmark.Name = "btnXmark";
            btnXmark.Size = new Size(20, 20);
            btnXmark.TabIndex = 10;
            btnXmark.UseVisualStyleBackColor = false;
            btnXmark.Click += btnX_Click;
            // 
            // TagPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btnXmark);
            Controls.Add(lblTagText);
            ImeMode = ImeMode.NoControl;
            Margin = new Padding(5);
            Name = "TagPanel";
            Size = new Size(75, 29);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTagText;
        private Button btnXmark;
    }
}
