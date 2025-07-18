using onnxware.Components.Tools;
using UnityEngine;
using VRC.SDKBase;

namespace onnxware.Components.Movement
{
    public static class Speed
    {
        public static bool isToggled = false;

        public static float multiplier = 3f;

        public static void Toggle(bool x) => isToggled = x;

        public static void Utilize()
        {
            VRCPlayerApi localPlayer = PlayerUtil.GetLocalPlayer();

            if (localPlayer == null)
                return;

            float s = (isToggled) ? multiplier : 1f;

            localPlayer.SetWalkSpeed(2 * s);
            localPlayer.SetRunSpeed(4 * s);
        }
    }
}
