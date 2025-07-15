using MelonLoader;
using UnityEngine;

namespace onnxware.GUI
{
    public static class Console
    {
        public static bool IsToggledMenu = true;

        private static string TextBox = "";

        public static void RefreshMenu()
        {

            if (Input.GetKeyDown(KeyCode.T))
            {
                IsToggledMenu = (IsToggledMenu) ? false : true;
            }

            if (IsToggledMenu)
            {
                MelonEvents.OnGUI.Subscribe(InitMenu, 100);
            }
            else
            {
                MelonEvents.OnGUI.Unsubscribe(InitMenu);
            }
        }

        public static void InitMenu()
        {
            UnityEngine.GUI.Box(new Rect(0, 0, 300, 500), "ONNXWARE [Alpha]");
            UnityEngine.GUI.TextField(new Rect(10, 20, 280, 480), TextBox);
        }

        public static void Log(string text)
        {
            MelonLogger.Msg(text);
            TextBox += $"{text}\n";
        }
    }
}
