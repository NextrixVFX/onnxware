using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace onnxware.UI.QM
{
    // Stying for the quick menu
    public static class QMStyling
    {
        private static GameObject _dashboard;

        private static GameObject _headerH1;
        private static TextMeshProUGUIEx _headerOptions;
        private static RectTransform _headerRect;

        private static GameObject _carousel;
        private static GameObject _vrcpBanners;

        private static GameObject _quickLinksHeader;
        private static GameObject _quicklinksButtons;

        private static GameObject _quickActionsHeader;
        private static GameObject _quickActionsButtons;

        public static void Initialize()
        {
            _dashboard = GameObject.Find(ButtonAPI.MenuPaths.QuickMenu_DashboardViewport_Menu);

            if (!_dashboard)
                return;

            _carousel = _dashboard.transform.Find("Carousel_Banners").gameObject;
            _vrcpBanners = _dashboard.transform.Find("VRC+_Banners").gameObject;

            Object.Destroy(_carousel);
            Object.Destroy(_vrcpBanners);

            _quickLinksHeader = _dashboard.transform.Find("Header_QuickLinks").gameObject;
            _quickActionsHeader = _dashboard.transform.Find("Header_QuickActions").gameObject;

            Object.Destroy(_quickActionsHeader);
            Object.Destroy(_quickLinksHeader);

            _quicklinksButtons = _dashboard.transform.Find("Buttons_QuickLinks").gameObject;
            _quickActionsButtons = _dashboard.transform.Find("Buttons_QuickActions").gameObject;

            FixHeader();
            ModifyButtons([_quickActionsButtons, _quicklinksButtons]);
            
        }

        private static void FixHeader()
        {
            var oldHeader = GameObject.Find(ButtonAPI.LabelPaths.QuickMenu_MainHeader_Label);

            _headerH1 = Object.Instantiate(oldHeader, GameObject.Find($"{MenuPaths.QuickMenu_Dashboard_Menu}Header_H1/").transform, true);

            oldHeader.SetActive(false);

            _headerOptions = _headerH1.GetComponent<TextMeshProUGUIEx>();
            _headerOptions.text = $"{ApiUtils.Identifier.ToUpper()}";
            _headerOptions.verticalAlignment = VerticalAlignmentOptions.Middle;
            _headerOptions.horizontalAlignment = HorizontalAlignmentOptions.Center;

            _headerRect = _headerH1.GetComponent<RectTransform>();
            _headerRect.anchoredPosition = Vector2.zero;
            _headerRect.anchorMax = new Vector2(0.5f, 0.5f);
            _headerRect.anchorMin = new Vector2(0.5f, 0.5f);
            _headerRect.offsetMax = new Vector2(200, 25);
            _headerRect.offsetMin = new Vector2(-200, -25);
        }

        private static void ModifyButtons(GameObject[] buttonRows)
        {
            var rows = 0;
            foreach (var buttonRow in buttonRows)
            {
                rows++;

                var rowTransform = buttonRow.GetComponent<RectTransform>();

                var buttonCount = buttonRow.transform.childCount;

                for (var i = 0; i < buttonCount; i++)
                {
                    var button = buttonRow.transform.GetChild(i).gameObject;

                    if (!button || !button.activeInHierarchy)
                        continue;

                    // Remove Icons
                    Object.Destroy(button.transform.Find("Icons").gameObject);
                    Object.Destroy(button.transform.Find("Badge_MMJump").gameObject);

                    // Set size
                    var buttonBg = button.transform.Find("Background").gameObject;
                    buttonBg.transform.localScale = new Vector3(1f, 0.6f, 1f);

                }

                if (rows % 2 == 0)
                    rowTransform.anchoredPosition -= new Vector2(0f, 700f);
            }
        }
    }
}
