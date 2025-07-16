using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onnxware.ButtonAPI
{
    public class MenuPaths
    {
        public const string QuickMenu_Dashboard_Menu = "CanvasGroup/Container/Window/QMParent/Menu_Dashboard";
    }
    
    public class ButtonPaths
    {
        public const string QuickMenu_Settings_Tab = "CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings"; // default tab template
        public const string QuickMenu_RejoinWorld_Button = "CanvasGroup/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_RejoinWorld"; // default button template
        public const string QuickMenu_ReportUser_Button = "UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Report/"; // default tiny button template
        public const string QuickMenu_UserActions_Button = "UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions";
    }

    public class LabelPaths
    {
        public const string QuickMenu_NonFriendList_Label = "UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Info/Text_Username_NonFriend"; // Name
    }
}
