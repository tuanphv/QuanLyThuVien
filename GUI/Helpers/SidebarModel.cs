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

        public SidebarMenuItem(Button btn, UserControl control = null)
        {
            Button = btn;
            TargetControl = control;
        }
    }
}
