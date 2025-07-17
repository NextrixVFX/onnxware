using System;
using System.Collections;
using onnxware.Components.Tools;
using VRC.SDK3.Components;
using VRC;
using VRC.SDKBase;
using MelonLoader;

namespace onnxware.Components.Tools
{
    public static class SceneUtil
    {
        private static VRCPlayerApi localPlayer;

        private static VRCPickup[] sdk3Items;

        // Gets all data (pickups) from scene
        public static void Init()
        {
            MelonCoroutines.Start(WaitForLocalPlayer());
        }

        private static IEnumerator WaitForLocalPlayer()
        {
            while (true)
            {
                if (PlayerUtil.GetLocalPlayer() != null)
                { CreateScene(); yield break; }
                
                yield return null;
            }
        }

        private static void CreateScene()
        {
            sdk3Items = UnityEngine.Object.FindObjectsOfType<VRCPickup>();
        }

        public static VRCPickup[] GetPickups () => sdk3Items;
    }
}
