﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onnxware.ButtonAPI
{
    public class BasePaths
    {
        public const string QuickMenuWindow = "CanvasGroup/Container/Window/";
        public const string QuickMenuParent = $"{QuickMenuWindow}QMParent/";
    }
    
    public class MenuPaths
    {
        public const string QuickMenu_Dashboard_Menu = $"{BasePaths.QuickMenuParent}Menu_Dashboard/";
        public const string QuickMenu_DashboardViewport_Menu = $"{QuickMenu_Dashboard_Menu}ScrollRect/Viewport/VerticalLayoutGroup/";
        public const string QuickMenu_SelectedUser_Menu = $"{BasePaths.QuickMenuParent}Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/";
    }

    public class DropdownPaths
    {
        public const string QuickMenu_UserActions_Dropdown = $"{MenuPaths.QuickMenu_SelectedUser_Menu}QM_Foldout_UserActions/";
        public const string QuickMenu_UserActions_AvatarButtons = $"{MenuPaths.QuickMenu_SelectedUser_Menu}Buttons_AvatarActions/";
    }

    public class EnumPaths
    {
        public const string QuickMenu_NameplateVisibility_Enum = $"{BasePaths.QuickMenuParent}Menu_QM_GeneralSettings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/UIElements/QM_Settings_Panel/VerticalLayoutGroup/NameplateVisibility/";
    }

    public class SliderPaths
    {
        public const string QuickMenu_AvatarCullingBeyond_Slider = $"{BasePaths.QuickMenuParent}Menu_QM_GeneralSettings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/AvatarCulling/QM_Settings_Panel/VerticalLayoutGroup/HideBeyond/";
    }
    
    public class ButtonPaths
    {
        public const string QuickMenu_Settings_Tab = $"{BasePaths.QuickMenuWindow}Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings/"; // default tab template
        public const string QuickMenu_RejoinWorld_Button = $"{BasePaths.QuickMenuParent}Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_RejoinWorld/"; // default button template
        public const string QuickMenu_ReportUser_Button = $"{BasePaths.QuickMenuParent}Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Report/"; // default tiny button template
        public const string QuickMenu_UserActions_Button = $"{BasePaths.QuickMenuParent}Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/";
    }

    public class LabelPaths
    {
        public const string QuickMenu_NonFriendList_Label = $"{BasePaths.QuickMenuParent}Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Info/Text_Username_NonFriend/"; // Name
        public const string QuickMenu_SettingsHeader_Label = $"{BasePaths.QuickMenuParent}Menu_QM_GeneralSettings/QMHeader_H1/LeftItemContainer/Text_Title";
        public const string QuickMenu_MainHeader_Label = $"{MenuPaths.QuickMenu_Dashboard_Menu}Header_H1/LeftItemContainer/Text_Title/";
    }
}
