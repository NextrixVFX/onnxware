using onnxware.Components.Tools;
using UnityEngine;
using VRC.SDKBase;

namespace onnxware.Components.Movement
{
    public static class Speed
    {
        public static bool isToggled = false;

        public static float multiplier = 3f;

        private static float walkSpeed = 0f;

        private static float runSpeed = 0f;

        public static void Toggle(bool x)
        {
            isToggled = x;

            VRCPlayerApi localPlayer = PlayerUtil.GetLocalPlayer();

            if (localPlayer == null)
                return;

            float s = (isToggled) ? multiplier : 1f;

            if (walkSpeed == 0 && runSpeed == 0)
            {
                walkSpeed = localPlayer.GetWalkSpeed();
                runSpeed = localPlayer.GetRunSpeed();
            }

            localPlayer.SetWalkSpeed(walkSpeed * s);
            localPlayer.SetRunSpeed(runSpeed * s);
        }
    }
}
