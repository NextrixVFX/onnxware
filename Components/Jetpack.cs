using UnityEngine;
using MelonLoader;
using VRC.SDKBase;
using onnxware.GUI;

namespace onnxware.Components
{
    public static class Jetpack
    {

        public static bool jetpackEnabled = false;

        public static void Utilize()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                jetpackEnabled = (jetpackEnabled) ? false : true;
                string jetpackState = (jetpackEnabled) ? "[ENABLED]" : "[DISABLED]";
                GUI.Console.Log($"Jetpack is {jetpackState}");
            }

            ApplyJetpack();
        }


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
