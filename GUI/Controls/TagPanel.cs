using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Controls
{
    public partial class TagPanel : UserControl
    {
        public Color TagBackColor {
            get => BackColor;
            set => BackColor = value;
        }
        public Color TagForeColor
        {
            get => lblTagText.ForeColor;
            set
            {
                if (lblTagText.ForeColor != value)
                {
                    lblTagText.ForeColor = value;

                    // Cập nhật lại icon với màu mới
                    btnXmark.Image = Helpers.SvgHelper.LoadSvgAndChangeColor(
                        Properties.Resources.xmark,
                        value,
                        width: 10,
                        height: 12
                    );
                }
            }
        }

        public string TagText
        {
            get => lblTagText.Text;
            set => lblTagText.Text = value;
        }

        public TagPanel()
        {
            InitializeComponent();
            TagForeColor = Color.DarkBlue;
            TagBackColor = Color.LightBlue;
        }

        public TagPanel(string tagText) : this()
        {
            TagText = tagText;
        }



        private void btnX_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }
    }
}
