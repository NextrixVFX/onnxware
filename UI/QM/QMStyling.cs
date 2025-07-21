using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using VRC.UserCamera;

namespace onnxware.UI.QM
{
    // Stying for the quick menu
    public static class QMStyling
    {
        private static GameObject Dashboard;

        private static GameObject HeaderH1;
        private static TextMeshProUGUIEx HeaderOptions;
        private static RectTransform HeaderRect;

        private static GameObject Carousel;
        private static GameObject VRCP_Banners;

        private static GameObject QuickLinks_Header;
        private static GameObject Quicklinks_Buttons;

        private static GameObject QuickActions_Header;
        private static GameObject QuickActions_Buttons;

        public static void Initialize()
        {
            Dashboard = GameObject.Find(ButtonAPI.MenuPaths.QuickMenu_DashboardViewport_Menu);

            if (!Dashboard)
                return;

            Carousel = Dashboard.transform.Find("Carousel_Banners").gameObject;
            VRCP_Banners = Dashboard.transform.Find("VRC+_Banners").gameObject;

            GameObject.Destroy(Carousel);
            GameObject.Destroy(VRCP_Banners);

            QuickLinks_Header = Dashboard.transform.Find("Header_QuickLinks").gameObject;
            QuickActions_Header = Dashboard.transform.Find("Header_QuickActions").gameObject;

            GameObject.Destroy(QuickActions_Header);
            GameObject.Destroy(QuickLinks_Header);

            Quicklinks_Buttons = Dashboard.transform.Find("Buttons_QuickLinks").gameObject;
            QuickActions_Buttons = Dashboard.transform.Find("Buttons_QuickActions").gameObject;

            FixHeader();
            ModifyButtons([QuickActions_Buttons, Quicklinks_Buttons]);
            
        }

        public static void FixHeader()
        {
            GameObject oldHeader = GameObject.Find(ButtonAPI.LabelPaths.QuickMenu_MainHeader_Label);

            HeaderH1 = GameObject.Instantiate(oldHeader, GameObject.Find($"{MenuPaths.QuickMenu_Dashboard_Menu}Header_H1/").transform, true);

            oldHeader.SetActive(false);

            HeaderOptions = HeaderH1.GetComponent<TextMeshProUGUIEx>();
            HeaderOptions.text = $"{ApiUtils.Identifier.ToUpper()}";
            HeaderOptions.verticalAlignment = VerticalAlignmentOptions.Middle;
            HeaderOptions.horizontalAlignment = HorizontalAlignmentOptions.Center;

            HeaderRect = HeaderH1.GetComponent<RectTransform>();
            HeaderRect.anchoredPosition = Vector2.zero;
            HeaderRect.anchorMax = new(0.5f, 0.5f);
            HeaderRect.anchorMin = new(0.5f, 0.5f);
            HeaderRect.offsetMax = new(200, 25);
            HeaderRect.offsetMin = new(-200, -25);
        }

        public static void ModifyButtons(GameObject[] ButtonRows)
        {
            int rows = 0;
            foreach (GameObject buttonRow in ButtonRows)
            {
                rows++;

                RectTransform rowTransform = buttonRow.GetComponent<RectTransform>();

                int buttonCount = buttonRow.transform.childCount;

                for (int i = 0; i < buttonCount; i++)
                {
                    GameObject button = buttonRow.transform.GetChild(i).gameObject;

                    if (!button || !button.activeInHierarchy)
                        continue;

                    // Remove Icons
                    GameObject.Destroy(button.transform.Find("Icons").gameObject);
                    GameObject.Destroy(button.transform.Find("Badge_MMJump").gameObject);

                    // Set size
                    GameObject buttonBg = button.transform.Find("Background").gameObject;
                    buttonBg.transform.localScale = new Vector3(1f, 0.6f, 1f);

                }


                if (rows % 2 == 0)
                    rowTransform.anchoredPosition -= new Vector2(0f, 700f);
            }
        }
    }
}
