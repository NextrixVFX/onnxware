using MelonLoader;
using onnxware.Components.Tools;
using UnityEngine;
using VRC.UI.Elements;

namespace onnxware.ButtonAPI.QM
{
    public static class ApiUtils
    {
        public static string Identifier = Globals.Variables.dataPath;
        public static readonly System.Random random = new System.Random();

        #region Component Instances
        private static QuickMenu _quickMenu;
        private static MainMenu _socialMenu;
        private static GameObject _selectedUserPageGrid;

        public static QuickMenu QuickMenu
        {
            get
            { 
                return (_quickMenu) ? _quickMenu : Resources.FindObjectsOfTypeAll<QuickMenu>()[0];
            }
        }

        // Get all players uwu
        public static List<VRC.Player> Players => PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().ToList();

        public static VRC.Player GetPlayerByDisplayName(string name) => Players.Find(plr => (plr.field_Private_APIUser_0.displayName == name));

        private static VRC.Player get_selected_player_name()
        {
            var textObject = GameObject.Find(LabelPaths.QuickMenu_NonFriendList_Label);
            var textComponent = textObject.GetComponent<TextMeshProUGUIEx>();

            return (textObject && textComponent) ? GetPlayerByDisplayName(textComponent.text) : null;
        }

        public static GameObject GetSelectedUserPageGrid()
        {
            return (_selectedUserPageGrid) ? _selectedUserPageGrid : GameObject.Find(ButtonPaths.QuickMenu_UserActions_Button);
        }

        public static MainMenu MainMenu
        {
            get
            {
                return (_socialMenu) ? _socialMenu : Resources.FindObjectsOfTypeAll<MainMenu>()[0];
            }
        }
        #endregion

        #region Templates
        private static GameObject _qmMenuTemplate;
        private static GameObject _qmTabTemplate;
        private static GameObject _qmButtonTemplate;

        public static GameObject GetQMMenuTemplate() => (_qmMenuTemplate) ? _qmMenuTemplate : _qmMenuTemplate = QuickMenu.transform.Find(MenuPaths.QuickMenu_Dashboard_Menu).gameObject;
        public static GameObject GetQMTabButtonTemplate() => (_qmTabTemplate) ? _qmTabTemplate : _qmTabTemplate = QuickMenu.transform.Find(ButtonPaths.QuickMenu_Settings_Tab).gameObject;
        public static GameObject GetQMButtonTemplate() => (_qmButtonTemplate) ? _qmButtonTemplate : _qmButtonTemplate = QuickMenu.transform.Find(ButtonPaths.QuickMenu_RejoinWorld_Button).gameObject;
        public static GameObject GetQMSmalltTemplate() => (_qmButtonTemplate) ? _qmButtonTemplate : _qmButtonTemplate = QuickMenu.transform.Find(ButtonPaths.QuickMenu_ReportUser_Button).gameObject;
        #endregion

        private static Sprite _onSprite;
        private static Sprite _offSprite;

        public static Sprite OnIconSprite()
        {
            return SpriteUtil.LoadSpriteViaVRCPath("Icons\\ToggleSwitchOn.png", 100f);
        }

        public static Sprite OffIconSprite()
        {
            return SpriteUtil.LoadSpriteViaVRCPath("Icons\\ToggleSwitchOff.png", 100f);
        }

        public static int RandomNumbers()
        {
            return random.Next(100000, 999999);
        }

        public static string GetSelectedPageName()
        {
            return QuickMenu.prop_MenuStateController_0.field_Private_UIPage_0.field_Public_String_0;
        }
    }
}
