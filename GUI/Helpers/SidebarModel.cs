using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Helpers
{
    public struct SidebarMenuItem
    {
        public Button Button;
        public UserControl? TargetControl;
        public int PermissionCode;

        public SidebarMenuItem(Button btn, UserControl control = null, int permissionCode = 0)
        {
            Button = btn;
            TargetControl = control;
            PermissionCode = permissionCode;
        }
    }
}
