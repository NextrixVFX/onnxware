using UnityEngine;
using MelonLoader;
using VRC.SDKBase;

namespace onnxware.Components.Movement
{
    public static class Jetpack
    {
        public static void Utilize() => ApplyJetpack();

        public static void Toggle(bool x) => jetpackEnabled = x;

        private static bool jetpackEnabled = false;

        private static void ApplyJetpack()
        {
            if (!jetpackEnabled)
                return;

            if (!Input.GetKey(KeyCode.Space))
                return;

            VRCPlayerApi localPlayer = Networking.LocalPlayer;

            if (localPlayer == null)
                return;

            Vector3 velocity = localPlayer.GetVelocity();
            velocity.y = localPlayer.GetJumpImpulse();
            localPlayer.SetVelocity(velocity);
        }
    }
}
