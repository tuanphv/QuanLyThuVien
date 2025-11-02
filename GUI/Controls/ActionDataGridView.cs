using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Controls
{
    public class ActionDataGridView : DataGridView
    {
        public bool ShowEditButton { get; set; } = true;
        public bool ShowDeleteButton { get; set; } = true;
        public bool ShowViewButton { get; set; } = true;

        public event EventHandler<int> EditButtonClicked;
        public event EventHandler<int> DeleteButtonClicked;
        public event EventHandler<int> ViewButtonClicked;

        private ToolTip toolTip = new ToolTip();
        private int hoveredRow = -1;
        private string hoveredButton = "";

        private bool eventsAttached = false; // ✅ tránh gắn lại event nhiều lần

        public ActionDataGridView()
        {
            // === Sự kiện ===
            this.DataBindingComplete += (s, e) =>
            {
                AddActionColumnIfNeeded();
                AttachEventsOnce();
                this.ColumnHeadersHeight = 40;
            };
            this.RowsAdded += (s, e) => this.Invalidate();

            // === Chống nhấp nháy ===
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, this, new object[] { true });
        }

        private void AttachEventsOnce()
        {
            if (eventsAttached) return;
            eventsAttached = true;

            this.CellPainting += CustomCellPainting;
            this.CellClick += CustomCellClick;
            this.MouseMove += CustomMouseMove;
        }

        private void AddActionColumnIfNeeded()
        {
            if (!this.Columns.Contains("Actions"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Thao tác",
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                this.Columns.Add(col);
            }
        }

        private void CustomCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || this.Columns[e.ColumnIndex].Name != "Actions")
                return;

            e.PaintBackground(e.CellBounds, true);

            int buttonWidth = 40;
            int buttonHeight = 28;
            int spacing = 6;

            var buttons = new List<(string key, Image icon, bool visible)>
            {
                ("edit", Properties.Resources.edit, ShowEditButton),
                ("delete", Properties.Resources.bin, ShowDeleteButton),
                ("view", Properties.Resources.info, ShowViewButton)
            };

            var visibleButtons = buttons.Where(b => b.visible).ToList();
            if (visibleButtons.Count == 0) return;

            int totalWidth = visibleButtons.Count * buttonWidth + (visibleButtons.Count - 1) * spacing;
            int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int startY = e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2;

            for (int i = 0; i < visibleButtons.Count; i++)
            {
                var btn = visibleButtons[i];
                Rectangle rect = new Rectangle(startX + i * (buttonWidth + spacing), startY, buttonWidth, buttonHeight);
                bool isHovered = hoveredRow == e.RowIndex && hoveredButton == btn.key;
                DrawCustomButton(e.Graphics, rect, btn.icon, GetColor(btn.key), isHovered);
            }

            e.Handled = true;
        }

        private void DrawCustomButton(Graphics g, Rectangle rect, Image icon, Color backColor, bool isHovered)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 6;
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(isHovered ? ControlPaint.Light(backColor) : backColor))
                    g.FillPath(brush, path);

                using (Pen pen = new Pen(Color.Gray))
                    g.DrawPath(pen, path);

                if (icon != null)
                {
                    int iconX = rect.X + (rect.Width - icon.Width) / 2;
                    int iconY = rect.Y + (rect.Height - icon.Height) / 2;
                    g.DrawImage(icon, new Point(iconX, iconY));
                }
            }
        }

        private Color GetColor(string key)
        {
            return key switch
            {
                "edit" => Color.LightBlue,
                "delete" => Color.LightCoral,
                "view" => Color.LightGreen,
                _ => Color.LightGray
            };
        }

        private void CustomMouseMove(object sender, MouseEventArgs e)
        {
            var hit = this.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0 || hit.ColumnIndex < 0 || this.Columns[hit.ColumnIndex].Name != "Actions")
                return;

            var cellRect = this.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
            int buttonWidth = 40;
            int buttonHeight = 28;
            int spacing = 6;

            var buttons = new List<(string key, Image icon, bool visible)>
    {
        ("edit", Properties.Resources.edit, ShowEditButton),
        ("delete", Properties.Resources.bin, ShowDeleteButton),
        ("view", Properties.Resources.info, ShowViewButton)
    };

            var visibleButtons = buttons.Where(b => b.visible).ToList();
            int totalWidth = visibleButtons.Count * buttonWidth + (visibleButtons.Count - 1) * spacing;
            int startX = cellRect.X + (cellRect.Width - totalWidth) / 2;
            int startY = cellRect.Y + (cellRect.Height - buttonHeight) / 2;

            Point mousePos = this.PointToClient(Cursor.Position);

            int newHoveredRow = -1;
            string newHoveredButton = "";

            for (int i = 0; i < visibleButtons.Count; i++)
            {
                var btn = visibleButtons[i];
                Rectangle rect = new Rectangle(startX + i * (buttonWidth + spacing), startY, buttonWidth, buttonHeight);
                if (rect.Contains(mousePos))
                {
                    newHoveredRow = hit.RowIndex;
                    newHoveredButton = btn.key;
                    break;
                }
            }

            // ✅ Chỉ vẽ lại nếu thay đổi thực sự
            if (newHoveredRow != hoveredRow || newHoveredButton != hoveredButton)
            {
                // Vẽ lại cell cũ và mới để tránh sót viền hover
                if (hoveredRow >= 0 && hoveredButton != "" && hoveredRow < this.Rows.Count)
                    this.InvalidateCell(this.Columns["Actions"].Index, hoveredRow);

                hoveredRow = newHoveredRow;
                hoveredButton = newHoveredButton;

                if (hoveredRow >= 0)
                {
                    this.InvalidateCell(this.Columns["Actions"].Index, hoveredRow);
                    toolTip.SetToolTip(this, hoveredButton switch
                    {
                        "edit" => "Sửa",
                        "delete" => "Xóa",
                        "view" => "Xem",
                        _ => ""
                    });
                }
            }
        }


        private void CustomCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.Columns[e.ColumnIndex].Name != "Actions")
                return;

            if (hoveredButton == "edit")
                EditButtonClicked?.Invoke(this, e.RowIndex);
            else if (hoveredButton == "delete")
                DeleteButtonClicked?.Invoke(this, e.RowIndex);
            else if (hoveredButton == "view")
                ViewButtonClicked?.Invoke(this, e.RowIndex);
        }
    }
}
