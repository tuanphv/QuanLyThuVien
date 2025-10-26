using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace GUI.Controls
{
    /// <summary>
    /// Simple CustomDataGridView
    /// - No rounded corners (square cells)
    /// - No column separators (no vertical lines between cells)
    /// - Alternating row colors, hover row highlight, custom selection color
    /// - Double buffered for smoother rendering
    /// - Keeps default editing/sorting behaviors
    /// </summary>
    [ToolboxBitmap(typeof(DataGridView))]
    public class CustomDataGridView : DataGridView
    {
        private int _hoverRow = -1;

        public CustomDataGridView()
        {
            // Improve painting performance and appearance
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                     System.Windows.Forms.ControlStyles.UserPaint |
                     System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);

            // Enable protected DoubleBuffered property via reflection
            typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?
                .SetValue(this, true, null);

            // Basic visual settings
            BackgroundColor = Color.White;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.None; // no cell borders
            RowHeadersVisible = false;
            EnableHeadersVisualStyles = false; // we'll draw headers ourselves
            // GridColor cannot be Transparent in designer -> use near-background color
            GridColor = Color.FromArgb(230, 230, 230);

            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToAddRows = false;

            // Defaults for appearance
            HeaderBackColor = Color.FromArgb(60, 140, 255);
            HeaderBackColor2 = Color.FromArgb(40, 110, 230);
            HeaderForeColor = Color.White;
            HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);

            RowBackColor = Color.White;
            AlternatingRowBackColor = Color.FromArgb(250, 250, 250);
            RowHoverBackColor = Color.FromArgb(240, 250, 255);
            RowSelectedBackColor = Color.FromArgb(80, 160, 255);
            RowSelectedForeColor = Color.White;

            CellPadding = new Padding(8, 6, 8, 6);

            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ColumnHeadersHeight = 34;
            RowTemplate.Height = 30;
        }

        #region Appearance properties

        [Category("Appearance")]
        public Color HeaderBackColor { get; set; }

        [Category("Appearance")]
        public Color HeaderBackColor2 { get; set; }

        [Category("Appearance")]
        public Color HeaderForeColor { get; set; }

        [Category("Appearance")]
        public Font HeaderFont { get; set; }

        [Category("Appearance")]
        public Color RowBackColor { get; set; }

        [Category("Appearance")]
        public Color AlternatingRowBackColor { get; set; }

        [Category("Appearance")]
        public Color RowHoverBackColor { get; set; }

        [Category("Appearance")]
        public Color RowSelectedBackColor { get; set; }

        [Category("Appearance")]
        public Color RowSelectedForeColor { get; set; }

        [Category("Layout")]
        public new Padding CellPadding { get; set; }

        #endregion

        #region Mouse tracking (hover row)

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var ht = this.HitTest(e.X, e.Y);
            if (ht.RowIndex != _hoverRow)
            {
                int oldHover = _hoverRow;
                _hoverRow = ht.RowIndex;

                if (oldHover >= 0 && oldHover < Rows.Count) InvalidateRow(oldHover);
                if (_hoverRow >= 0 && _hoverRow < Rows.Count) InvalidateRow(_hoverRow);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverRow != -1)
            {
                int oldHover = _hoverRow;
                _hoverRow = -1;
                if (oldHover >= 0 && oldHover < Rows.Count) InvalidateRow(oldHover);
            }
        }

        #endregion

        #region Painting overrides

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            // Keep default painting for header or out-of-bounds
            if (e.RowIndex < 0)
            {
                base.OnCellPainting(e);
                return;
            }

            // Let the editing cell be painted by default to preserve editor visuals
            if (this.IsCurrentCellInEditMode && e.RowIndex == this.CurrentCell?.RowIndex && e.ColumnIndex == this.CurrentCell?.ColumnIndex)
            {
                e.Handled = false;
                base.OnCellPainting(e);
                return;
            }

            // High quality text rendering for cell content
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Determine background color
            bool isSelected = this.Rows[e.RowIndex].Selected;
            bool isHover = (e.RowIndex == _hoverRow);

            Color back = RowBackColor;
            if (e.RowIndex % 2 == 1) back = AlternatingRowBackColor;
            if (isSelected) back = RowSelectedBackColor;
            else if (isHover) back = RowHoverBackColor;

            // Paint simple rectangular background (no rounding)
            using (var fill = new SolidBrush(back))
            {
                e.Graphics.FillRectangle(fill, e.CellBounds);
            }

            // Draw text (respect padding)
            object value = e.FormattedValue;
            string text = value?.ToString() ?? string.Empty;

            Color fore = this.Rows[e.RowIndex].DefaultCellStyle.ForeColor.IsEmpty ? this.ForeColor : this.Rows[e.RowIndex].DefaultCellStyle.ForeColor;
            if (isSelected) fore = RowSelectedForeColor;

            var textRect = new Rectangle(e.CellBounds.X + CellPadding.Left, e.CellBounds.Y + CellPadding.Top,
                                         e.CellBounds.Width - (CellPadding.Left + CellPadding.Right),
                                         e.CellBounds.Height - (CellPadding.Top + CellPadding.Bottom));

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            var align = this.Columns[e.ColumnIndex].DefaultCellStyle.Alignment;
            if (align == DataGridViewContentAlignment.MiddleCenter || align == DataGridViewContentAlignment.TopCenter || align == DataGridViewContentAlignment.BottomCenter)
            {
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;
            }
            else if (align == DataGridViewContentAlignment.MiddleRight || align == DataGridViewContentAlignment.TopRight || align == DataGridViewContentAlignment.BottomRight)
            {
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.EndEllipsis;
            }

            TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font ?? this.Font, textRect, fore, flags);

            // Draw focus rectangle if this is the current cell and the grid has focus
            bool cellHasFocus = this.CurrentCell != null
                && e.RowIndex == this.CurrentCell.RowIndex
                && e.ColumnIndex == this.CurrentCell.ColumnIndex
                && this.Focused;

            if (cellHasFocus)
            {
                var focusRect = e.CellBounds;
                focusRect.Inflate(-3, -3);
                ControlPaint.DrawFocusRectangle(e.Graphics, focusRect);
            }

            // DO NOT draw vertical separators between columns (user requested no column separators)

            e.Handled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw header background (simple rectangle or gradient)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Fill background
            using (var bg = new SolidBrush(this.BackgroundColor))
            {
                e.Graphics.FillRectangle(bg, ClientRectangle);
            }

            // Header area
            var headerRect = this.DisplayRectangle;
            headerRect.Height = this.ColumnHeadersHeight;

            using (var grad = new System.Drawing.Drawing2D.LinearGradientBrush(headerRect, HeaderBackColor, HeaderBackColor2, System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(grad, headerRect);
            }

            // Draw header texts
            for (int i = 0; i < this.Columns.Count; i++)
            {
                var col = this.Columns[i];
                var rc = this.GetCellDisplayRectangle(i, -1, true);
                if (rc.Width <= 0 || rc.Height <= 0) continue;

                string headerText = col.HeaderText ?? string.Empty;
                Rectangle textRect = new Rectangle(rc.X + 8, rc.Y, rc.Width - 16, rc.Height);
                TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
                if (col.HeaderCell.Style.Alignment == DataGridViewContentAlignment.MiddleCenter) flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;

                TextRenderer.DrawText(e.Graphics, headerText, HeaderFont ?? this.Font, textRect, HeaderForeColor, flags);

                // Optional sort glyph
                if (col.HeaderCell.SortGlyphDirection != SortOrder.None)
                {
                    Point[] tri;
                    int cx = rc.Right - 12;
                    int cy = rc.Y + rc.Height / 2;
                    if (col.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                    {
                        tri = new[] { new Point(cx - 4, cy + 3), new Point(cx + 4, cy + 3), new Point(cx, cy - 3) };
                    }
                    else
                    {
                        tri = new[] { new Point(cx - 4, cy - 3), new Point(cx + 4, cy - 3), new Point(cx, cy + 3) };
                    }
                    using (var brush = new SolidBrush(HeaderForeColor))
                    {
                        e.Graphics.FillPolygon(brush, tri);
                    }
                }
            }

            // Let base handle painting cells (we override cell painting)
            base.OnPaint(e);
        }

        #endregion
    }
}