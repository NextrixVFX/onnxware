using MelonLoader;
using System;
using System.Collections.Generic;

namespace onnxware.ButtonAPI.QuickMenu
{
    internal class Tab
    {
        public static void SetupTab()
        {
            MelonCoroutines.Start(Tab.WaitForMenu());
        }

        private static IEnumerator WaitForMenu()
        {
            return new Tab.<WaitForMenu>d__5(0);
        }
    }
}
