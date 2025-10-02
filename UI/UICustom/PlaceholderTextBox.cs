using System.ComponentModel;

namespace UI.UICustom
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBox))]
    [Description("TextBox có placeholder (văn bản gợi ý).")]
    public class PlaceholderTextBox : TextBox
    {
        private string _placeholderText = "Enter text...";
        private bool _isPlaceholderActive = true;
        private Color _placeholderColor = Color.Gray;
        private Color _textColor = Color.Black;

        public PlaceholderTextBox()
        {
            SetPlaceholder();
            this.GotFocus += RemovePlaceholder;
            this.LostFocus += SetPlaceholderOnFocusLost;
        }

        public bool IsPlaceholderActive
        {
            get => _isPlaceholderActive;
        }

        [Category("Appearance")]
        [Description("Văn bản gợi ý (placeholder) hiển thị khi TextBox trống.")]
        public string PlaceholderText
        {
            get => _placeholderText;
            set
            {
                _placeholderText = value;
                if (_isPlaceholderActive)
                {
                    SetPlaceholder();
                }
            }
        }

        [Category("Appearance")]
        [Description("Màu của văn bản gợi ý (placeholder).")]
        public Color PlaceholderColor
        {
            get => _placeholderColor;
            set
            {
                _placeholderColor = value;
                if (_isPlaceholderActive)
                {
                    this.ForeColor = _placeholderColor;
                }
            }
        }

        [Category("Appearance")]
        [Description("Màu của văn bản khi người dùng nhập.")]
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                if (!_isPlaceholderActive)
                {
                    this.ForeColor = _textColor;
                }
            }
        }

        public void ResetPlaceholder()
        {
            SetPlaceholder();
        }

        private void SetPlaceholder()
        {
            _isPlaceholderActive = true;
            this.Text = _placeholderText;
            this.ForeColor = _placeholderColor;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (_isPlaceholderActive)
            {
                _isPlaceholderActive = false;
                this.Text = "";
                this.ForeColor = _textColor;
            }
        }

        private void SetPlaceholderOnFocusLost(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                SetPlaceholder();
            }
        }
    }
}
