using Il2CppInterop.Runtime.InteropTypes.Arrays;
using onnxware.Components.Tools;
using UnityEngine;
using VRC;
using VRC.SDK3.Components;
using VRC.SDKBase;

namespace onnxware.Components.World
{
    internal class ItemOrbit
    {
        public static bool isEnabled = false;

        private static Player target;

        private static VRCPlayerApi localPlayer;

        private static VRCPickup[] pickups;

        public static int enumIndex = 0;

        public static void Toggle(string name, bool x)
        {
            if (x)
                target = PlayerUtil.GetPlayerByDisplayName(PlayerUtil.GetLocalPlayer().displayName);

            isEnabled = x;
        }

        public static void Utilize()
        {
            if (!isEnabled)
                return;

            if (!target)
                return;

            pickups = SceneUtil.GetPickups();
            localPlayer = PlayerUtil.GetLocalPlayer();

            int[,] pSort1 = // cubic
            {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1 },
                { 1, 1, 0, 0, 0, 1, 1 },
                { 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }
            };

            int[,] pSort2 = // cross
            {
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 }
            };

            int[,] pSort3 = // swastika
            {
                { 1, 1, 1, 1, 0, 0, 1 },
                { 0, 0, 0, 1, 0, 0, 1 },
                { 0, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 0, 0 },
                { 1, 0, 0, 1, 0, 0, 0 },
                { 1, 0, 0, 1, 1, 1, 1 }
            };


            List<int[,]> SortingMethods = [pSort1, pSort2, pSort3];

            int[,] selectedSort = SortingMethods[enumIndex];

            int index = 0;

            Vector2 resolution = new Vector2(selectedSort.GetLength(1), selectedSort.GetLength(0));

            for (int row = 0; row < resolution.y; row++)
            {
                for (int col = 0; col < resolution.x; col++)
                {
                    if (selectedSort[row, col] == 1 && index < pickups.Length)
                    {
                        // Set owner
                        Networking.SetOwner(localPlayer, pickups[index].gameObject);

                        // Calculate position relative to player
                        Vector3 localPlayerPos = localPlayer.GetPosition();

                        Vector2 uv = new Vector2(col / resolution.x, row / resolution.y);

                        // center
                        uv.x -= .5f;
                        uv.y -= .5f;

                        // move up
                        uv.y += 1.5f;

                        // resize
                        uv.x *= resolution.x / 3;
                        uv.y *= resolution.y / 3;

                        localPlayerPos.x += uv.x;
                        localPlayerPos.y += uv.y;

                        // Set pickup position
                        pickups[index].gameObject.transform.position = localPlayerPos;

                        index++;
                    }
                }
            }
        }

        
    }
}
