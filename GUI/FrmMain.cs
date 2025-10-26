using GUI.Helpers;
namespace GUI
{
    public partial class FrmMain : Form
    {
        private SidebarMenuItem[] menuItems;
        public FrmMain()
        {
            InitializeComponent();
            menuItems = new SidebarMenuItem[]
            {
                new SidebarMenuItem(btnDashboard),
                new SidebarMenuItem(btnBook, new UCManageBook())
                //new SidebarMenuItem
            };
        }

        #region Expand/Collapse Menus
        bool menuCatalogExpanded = true;
        bool menuCirculationExpanded = true;
        bool menuUserExpanded = true;
        bool sidebarExpanded = true;

        private void menuCatalogTransition_Tick(object sender, EventArgs e)
        {
            if (menuCatalogExpanded)
            {
                pnlMenuCatalog.Height -= 10;
                if (pnlMenuCatalog.Height <= 50)
                {
                    pnlMenuCatalog.Height = 50;
                    menuCatalogTransition.Stop();
                    menuCatalogExpanded = false;
                }
            }
            else
            {
                pnlMenuCatalog.Height += 10;
                if (pnlMenuCatalog.Height >= 250)
                {
                    pnlMenuCatalog.Height = 250;
                    menuCatalogTransition.Stop();
                    menuCatalogExpanded = true;
                }
            }
        }

        private void menuCirculationTransition_Tick(object sender, EventArgs e)
        {
            if (menuCirculationExpanded)
            {
                pnlMenuCirculation.Height -= 10;
                if (pnlMenuCirculation.Height <= 50)
                {
                    pnlMenuCirculation.Height = 50;
                    menuCirculationTransition.Stop();
                    menuCirculationExpanded = false;
                }
            }
            else
            {
                pnlMenuCirculation.Height += 10;
                if (pnlMenuCirculation.Height >= 200)
                {
                    pnlMenuCirculation.Height = 200;
                    menuCirculationTransition.Stop();
                    menuCirculationExpanded = true;
                }
            }
        }
        private void menuUserTransition_Tick(object sender, EventArgs e)
        {
            if (menuUserExpanded)
            {
                pnlMenuUser.Height -= 10;
                if (pnlMenuUser.Height <= 50)
                {
                    pnlMenuUser.Height = 50;
                    menuUserTransition.Stop();
                    menuUserExpanded = false;
                }
            } else
            {
                pnlMenuUser.Height += 10;
                if (pnlMenuUser.Height >= 200)
                {
                    pnlMenuUser.Height = 200;
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
                if (pnlSidebar.Width <= 62)
                {
                    pnlSidebar.Width = 62;
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

        private void btnCirculation_Click(object sender, EventArgs e)
        {
            menuCirculationTransition.Start();
        }

        private void btnUser_Click(object sender, EventArgs e)
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
                btn.BackColor = btn.Font.SizeInPoints == 12 ? Color.FromArgb(50, 0, 0, 0) : Color.Transparent;
            }
            clickedButton.BackColor = Color.FromArgb(70, 255, 255, 255);

            foreach (SidebarMenuItem item in menuItems)
            {
                if (item.Button == clickedButton)
                {
                    SwitchUserControl(pnlMainContent, item.TargetControl ?? new UCPlaceHolder());
                    return;
                }
            }
            SwitchUserControl(pnlMainContent, new UCPlaceHolder());
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            List<Button> allButtons = FindAllButtonsRecursive(this);
            allButtons.Remove(btnMenuCatalog);
            allButtons.Remove(btnCirculation);
            allButtons.Remove(btnUser);

            foreach (Button btn in allButtons)
            {
                btn.Click += (sender, e) =>
                {

                    SetActiveButton((Button)sender, allButtons);
                };
            }

            btnDashboard.PerformClick();
        }

        private void SwitchUserControl(Panel containerPanel, UserControl userControlToLoad)
        {
            foreach (Control control in containerPanel.Controls)
            {
                control.Visible = false;
            }

            if (containerPanel.Controls.Contains(userControlToLoad))
            {
                userControlToLoad.Visible = true;
                userControlToLoad.BringToFront();
                return;
            }

            userControlToLoad.Dock = DockStyle.Fill;
            containerPanel.Controls.Add(userControlToLoad);
        }


    }
}