using MelonLoader;
using onnxware.Components.Tools;
using onnxware.ButtonAPI.QM;
using onnxware.UI.QM.Pages;
using UnityEngine;
using VRC.UI.Elements;
using System.Collections;

namespace onnxware.UI.QM
{
    public class TopMenu
    {
        private static Sprite btnBackImg;

        public static void Init()
        {
            MelonCoroutines.Start(WaitForQM());
        }

        // Wait till quick menu exists.
        private static IEnumerator WaitForQM()
        {
            while (true)
            {
                if (GetQuickMenu() != null)
                { CreateMenu(); yield break; }

                yield return null;
            }
        }

        private static GameObject GetQuickMenu() => GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)");

        private static void CreateMenu()
        {
            if (!btnBackImg)
                btnBackImg = SpriteUtil.LoadSpriteViaVRCPath("Icons\\ButtonBackground.png", 100f);

            if (!CreateTopMenu())
                return; // failed to create menu

            // Create contents of menus
            World.Utilize(Menus.World, btnBackImg);
            Movement.Utilize(Menus.Movement, btnBackImg);
            Visual.Utilize(Menus.Visual, btnBackImg);
            Exploits.Utilize(Menus.Exploits, btnBackImg);

            ConsoleAPI.Logger.Msg("Created onnxware menu tab.");
        }

        // Create buttons in topmenu (tab)
        private static bool CreateTopMenu()
        {
            bool useHalfButton = false;

            Menus.TopMenu = new QMTabMenu("onnxware", "onnxware", SpriteUtil.LoadSpriteViaVRCPath("Icons\\OdiumIcon.png", 100f));
            Menus.World = new QMNestedMenu(Menus.TopMenu, 1f, 0f, "World", "World", "World Functions", useHalfButton, SpriteUtil.LoadSpriteViaVRCPath("Icons\\WorldIcon.png", 100f), btnBackImg);
            Menus.Movement = new QMNestedMenu(Menus.TopMenu, 2f, 0f, "Movement", "Movement", "Movement Functions", useHalfButton, SpriteUtil.LoadSpriteViaVRCPath("Icons\\MovementIcon.png", 100f), btnBackImg);
            Menus.Visual = new QMNestedMenu(Menus.TopMenu, 3f, 0f, "Visual", "Visual", "Visual Functions", useHalfButton, SpriteUtil.LoadSpriteViaVRCPath("Icons\\VisualIcon.png", 100f), btnBackImg);
            Menus.Exploits = new QMNestedMenu(Menus.TopMenu, 4f, 0f, "Exploits", "Exploits", "Exploit Functions", useHalfButton, SpriteUtil.LoadSpriteViaVRCPath("Icons\\ExploitIcon.png", 100f), btnBackImg);
           
            return true;
        }
    }
}
