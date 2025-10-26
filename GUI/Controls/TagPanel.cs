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
        public Color TagBackColor { get; set; } = Color.LightBlue;
        public Color TagForeColor { get; set; } = Color.DarkBlue;

        public string TagText
        {
            get => lblTagText.Text;
            set => lblTagText.Text = value;
        }

        public TagPanel()
        {
            InitializeComponent();
            btnXmark.Image = Helpers.SvgHelper.LoadSvgAndChangeColor(Properties.Resources.xmark, TagForeColor, 10, 12);
            lblTagText.ForeColor = TagForeColor;
            this.BackColor = TagBackColor;
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
