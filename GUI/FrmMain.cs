using GUI.Helpers;
using GUI.TheLoai;
using GUI.TacGia;
using System.Data;
using System.Windows.Forms;
namespace GUI
{
    public partial class FrmMain : Form
    {
        private SidebarMenuItem[] menuItems;
        private UCPlaceHolder placeholderControl = new UCPlaceHolder();
        public FrmMain()
        {
            InitializeComponent();
            menuItems = new SidebarMenuItem[]
            {
                new SidebarMenuItem(btnDashboard, new ThongKe.UCDashboard()),
                new SidebarMenuItem(btnBookTitle, new TuaSach.UCBookTitle()),
                new SidebarMenuItem(btnPermissions, new PhanQuyen.UCPermissions()),
                new SidebarMenuItem(btnGenre, new UCTheLoai()),
                new SidebarMenuItem(btnAuthor, new UCTacGia())
            };
        }

        #region Expand/Collapse Menus
        bool menuCatalogExpanded = true;
        bool menuInventoryExpanded = true;
        bool menuCirculationExpanded = true;
        bool menuUserExpanded = true;
        bool sidebarExpanded = true;
        int buttonHeight = 40;

        private void menuCatalogTransition_Tick(object sender, EventArgs e)
        {
            int buttonCount = 5;
            if (menuCatalogExpanded)
            {
                pnlMenuCatalog.Height -= 10;
                if (pnlMenuCatalog.Height <= buttonHeight)
                {
                    pnlMenuCatalog.Height = buttonHeight;
                    menuCatalogTransition.Stop();
                    menuCatalogExpanded = false;
                }
            }
            else
            {
                pnlMenuCatalog.Height += 10;
                if (pnlMenuCatalog.Height >= buttonHeight * buttonCount)
                {
                    pnlMenuCatalog.Height = buttonHeight * buttonCount;
                    menuCatalogTransition.Stop();
                    menuCatalogExpanded = true;
                }
            }
        }

        private void menuInventoryTransition_Tick(object sender, EventArgs e)
        {
            int buttonCount = 4;
            if (menuInventoryExpanded)
            {
                pnlMenuInventory.Height -= 10;
                if (pnlMenuInventory.Height <= buttonHeight)
                {
                    pnlMenuInventory.Height = buttonHeight;
                    menuInventoryTransition.Stop();
                    menuInventoryExpanded = false;
                }
            }
            else
            {
                pnlMenuInventory.Height += 10;
                if (pnlMenuInventory.Height >= buttonHeight * buttonCount)
                {
                    pnlMenuInventory.Height = buttonHeight * buttonCount;
                    menuInventoryTransition.Stop();
                    menuInventoryExpanded = true;
                }
            }
        }

        private void menuCirculationTransition_Tick(object sender, EventArgs e)
        {
            int buttonCount = 5;
            if (menuCirculationExpanded)
            {
                pnlMenuCirculation.Height -= 10;
                if (pnlMenuCirculation.Height <= buttonHeight)
                {
                    pnlMenuCirculation.Height = buttonHeight;
                    menuCirculationTransition.Stop();
                    menuCirculationExpanded = false;
                }
            }
            else
            {
                pnlMenuCirculation.Height += 10;
                if (pnlMenuCirculation.Height >= buttonHeight * buttonCount)
                {
                    pnlMenuCirculation.Height = buttonHeight * buttonCount;
                    menuCirculationTransition.Stop();
                    menuCirculationExpanded = true;
                }
            }
        }
        private void menuUserTransition_Tick(object sender, EventArgs e)
        {
            int buttonCount = 4;
            if (menuUserExpanded)
            {
                pnlMenuUser.Height -= 10;
                if (pnlMenuUser.Height <= buttonHeight)
                {
                    pnlMenuUser.Height = buttonHeight;
                    menuUserTransition.Stop();
                    menuUserExpanded = false;
                }
            }
            else
            {
                pnlMenuUser.Height += 10;
                if (pnlMenuUser.Height >= buttonHeight * buttonCount)
                {
                    pnlMenuUser.Height = buttonHeight * buttonCount;
                    menuUserTransition.Stop();
                    menuUserExpanded = true;
                }
            }
        }

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

        private void btnMenuCatalog_Click(object sender, EventArgs e)
        {
            menuCatalogTransition.Start();
        }

        private void btnMenuInventory_Click(object sender, EventArgs e)
        {
            menuInventoryTransition.Start();
        }

        private void btnMenuCirculation_Click(object sender, EventArgs e)
        {
            menuCirculationTransition.Start();
        }

        private void btnMenuUser_Click(object sender, EventArgs e)
        {
            menuUserTransition.Start();
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
                btn.BackColor = (btn.Tag != null && btn.Tag.ToString() == "subItem") ? Color.FromArgb(50, 0, 0, 0) : Color.Transparent;
            }
            clickedButton.BackColor = Color.FromArgb(90, 255, 255, 255);

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
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            List<Button> allButtons = FindAllButtonsRecursive(this);

            foreach (Button btn in allButtons)
            {
                if (btn.Tag != null && btn.Tag.ToString() == "menu")
                {
                    continue; // Skip menu buttons
                }
                btn.Click += (sender, e) =>
                {
                    SetActiveButton((Button)sender, allButtons);
                };
            }

            btnDashboard.PerformClick();
        }

        private void SwitchUserControl(Panel containerPanel, UserControl userControlToLoad)
        {
            // Nếu chưa có control nào trong containerPanel, thêm control mới vào và hiển thị nó
            if (containerPanel.Controls.Count == 0)
            {
                userControlToLoad.Dock = DockStyle.Fill;
                containerPanel.Controls.Add(userControlToLoad);
                return;
            }

            var currentControl = containerPanel.Controls[containerPanel.Controls.Count - 1];

            // Nếu control hiện tại chính là control cần load → không làm gì
            if (currentControl == userControlToLoad)
                return;

            // Ẩn control hiện tại
            currentControl.Visible = false;

            // Nếu UserControl đã tồn tại trong containerPanel, chỉ cần hiển thị nó
            if (containerPanel.Controls.Contains(userControlToLoad))
            {
                userControlToLoad.Visible = true;
                userControlToLoad.BringToFront();
            }
            else // Nếu chưa tồn tại, thêm nó vào containerPanel và hiển thị
            {
                userControlToLoad.Dock = DockStyle.Fill;
                containerPanel.Controls.Add(userControlToLoad);
                userControlToLoad.BringToFront();
            }  
        }
    }
}