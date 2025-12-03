using GUI.Helpers;
using GUI.TheLoai;
using GUI.TacGia;
using GUI.NhaXuatBan;
using GUI.NhaCungCap;
using GUI.NguoiDung;
using GUI.DocGia;
using GUI.MuonTra;
using System.Data;
namespace GUI
{
    public partial class FrmMain : Form
    {
        private SidebarMenuItem[] menuItems;
        private UCPlaceHolder placeholderControl = new UCPlaceHolder();
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Expand/Collapse Menus
        bool sidebarExpanded = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                pnlSidebar.Width -= 15;
                if (pnlSidebar.Width <= 54)
                {
                    pnlSidebar.Width = 54;
                    sidebarTransition.Stop();
                    sidebarExpanded = false;
                }
            }
            else
            {
                pnlSidebar.Width += 15;
                if (pnlSidebar.Width >= 250)
                {
                    pnlSidebar.Width = 250;
                    sidebarTransition.Stop();
                    sidebarExpanded = true;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        #endregion

        #region Action clicks for menu items
        public List<Button> FindAllButtonsRecursive(Control parentControl)
        {
            List<Button> buttons = new List<Button>();
            foreach (Control control in parentControl.Controls)
            {
                if (control is Button button)
                {
                    buttons.Add(button);
                }
                if (control.HasChildren)
                {
                    buttons.AddRange(FindAllButtonsRecursive(control));
                }
            }

            return buttons;
        }

        private void SetActiveButton(Button clickedButton, List<Button> btns)
        {
            foreach (Button btn in btns)
            {
                btn.BackColor = Color.Transparent;
            }

            clickedButton.BackColor = Color.FromArgb(70, 255, 255, 255);

            foreach (SidebarMenuItem item in menuItems)
            {
                if (item.Button == clickedButton)
                {
                    SwitchUserControl(pnlMainContent, item.TargetControl ?? placeholderControl);
                    return;
                }
            }
            SwitchUserControl(pnlMainContent, placeholderControl);
        }

        private void SwitchUserControl(Panel containerPanel, UserControl userControlToLoad)
        {
            // Find the control that is currently visible in the container (if any)
            Control? currentVisible = containerPanel.Controls
                .Cast<Control>()
                .FirstOrDefault(c => c.Visible);

            // If the requested control is already visible, nothing to do
            if (currentVisible != null && ReferenceEquals(currentVisible, userControlToLoad))
                return;

            // Hide the currently visible control (if any)
            if (currentVisible != null)
                currentVisible.Visible = false;

            // If the control is already added to the container, just show it and bring to front
            if (containerPanel.Controls.Contains(userControlToLoad))
            {
                userControlToLoad.Visible = true;
                userControlToLoad.BringToFront();
            }
            else
            {
                // Add, dock, show and bring to front
                userControlToLoad.Dock = DockStyle.Fill;
                userControlToLoad.Visible = true;
                containerPanel.Controls.Add(userControlToLoad);
                userControlToLoad.BringToFront();
            }
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnLogout.Text = $"  {SessionManager.CurrentUser?.TenNguoiDung}";

            menuItems = new SidebarMenuItem[]
            {
                new SidebarMenuItem(btnDashboard, new ThongKe.UCDashboard(), 1),
                new SidebarMenuItem(btnGenre, new UCTheLoai(), 2),
                new SidebarMenuItem(btnAuthor, new UCTacGia(), 3),
                new SidebarMenuItem(btnPublisher, new UCNhaXuatBan(), 4),
                new SidebarMenuItem(btnSupplier, new UCNhaCungCap(), 5),
                new SidebarMenuItem(btnBookTitle, new TuaSach.UCBookTitle(), 6),
                new SidebarMenuItem(btnBookStock, new UCPlaceHolder(), 7),
                new SidebarMenuItem(btnImportBooks, new UCPlaceHolder(), 8),
                new SidebarMenuItem(btnBorrow, new UCPhieuMuon(), 9),
                new SidebarMenuItem(btnReturn, new UCPhieuTra(), 10),
                new SidebarMenuItem(btnPayment, new UCPlaceHolder(), 11),
                new SidebarMenuItem(btnReportDebt, new BaoCao.UCBaoCao(), 12),
                new SidebarMenuItem(btnUsers, new UCNguoiDung(), 13),
                new SidebarMenuItem(btnReaders, new UCDocGia(), 14),
                new SidebarMenuItem(btnPermissions, new PhanQuyen.UCPermissions(), 15),
            };

            List<Button> allButtons = FindAllButtonsRecursive(this);
            allButtons.RemoveAll(b => b == btnLogout); // Exclude logout button

            foreach (SidebarMenuItem item in menuItems)
            {
                if (allButtons.IndexOf(item.Button) >= 0 && !SessionManager.HasPermission(item.PermissionCode, Helpers.Action.View))
                {
                    allButtons.Remove(item.Button);
                    item.Button.Visible = false;
                }
            }

            foreach (Button btn in allButtons)
            {
                btn.Click += (sender, e) =>
                {
                    SetActiveButton((Button)sender, allButtons);
                };
            }

            //btnDashboard.PerformClick();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Clear session and close main so Program.Main will show login again
            SessionManager.Logout();
            this.Close();
        }
    }
}