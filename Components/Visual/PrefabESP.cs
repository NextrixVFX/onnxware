using MelonLoader;
using UnityEngine;
using System.Collections;
using onnxware.Components.Tools;
using VRC.SDKBase;
using VRC;
using Harmony;


namespace onnxware.Components.Visual
{
    public static class PrefabESP
    {
        

        private static bool isToggled = false;

        private static bool isInitialized = true;

        private static Vector3 boxDimensions = new Vector3(0.6f, 2f, 0.4f);

        private static ESPUtil PrefabESPUtil = new();

        private static List<GameObject> cubeList = [];

        public static void Toggle(bool x)
        {
            isToggled = x;
            PrefabESPUtil._toggle = isToggled;
            if (isInitialized && isToggled)
                PrefabESPUtil.RefreshPlayerList(assignPrefabToPlayers);

            if (!x)
                onDisable();
        }

        public static void Init(float delay)
        {
            MelonCoroutines.Start(PrefabESPUtil.WaitForPlayerListener(assignPrefabToPlayers));
            MelonLogger.Msg((isInitialized) ? "PrefabESP Initialized" : "PrefabESP Initialization Failed");
        }

        private static void assignPrefabToPlayers()
        {

            foreach (Player player in PrefabESPUtil.playerArray)
            {
                if (player.gameObject == PrefabESPUtil.localPlayer.gameObject)
                    continue;

                Animator animator = player.GetComponentInChildren<Animator>();
                
                if (!animator || !animator.isHuman)
                    continue;

                Transform rootBone = animator.GetBoneTransform(HumanBodyBones.Hips);
                Transform headBone = animator.GetBoneTransform(HumanBodyBones.Head);

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                cube.name = "TorsoCube";
                cube.transform.SetParent(rootBone, false);
                cube.GetComponent<Collider>().enabled = false;

                Vector3 playerSize = Vector3.Lerp(rootBone.position, headBone.position, 0.5f);

                playerSize.x = Math.Min(playerSize.x, 2f);
                playerSize.y = Math.Min(playerSize.y, 2f);
                playerSize.z = Math.Min(playerSize.z, 2f);

                Bounds boundingBox = new Bounds(playerSize, boxDimensions);

                // Scale and position cube
                cube.transform.localPosition = Vector3.zero;
                cube.transform.localRotation = Quaternion.identity;
                cube.transform.localScale = boundingBox.size;

                // Optional: change cube appearance
                Shader overlayShader = Shader.Find("Hidden/Internal-Colored");
                Material overlayMat = new Material(overlayShader);
                overlayMat.SetInt("_ZWrite", 0);
                overlayMat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
                overlayMat.SetColor("_Color", Color.red);
                overlayMat.renderQueue = 32767;
                cube.GetComponent<UnityEngine.Renderer>().material = overlayMat;


                cubeList.Add(cube);
            }

        }

        private static void onDisable()
        {

            if (cubeList.Count == 0)
                return;

            for (int i = cubeList.Count - 1; i >= 0; i--)
            {
                if (!cubeList[i])
                {
                    cubeList.RemoveAt(i);
                    continue;
                }
                    

                //cubeList[i].transform.SetParent(null);
                cubeList[i].transform.localPosition = new Vector3(int.MaxValue, int.MaxValue, int.MaxValue);
                GameObject.Destroy(cubeList[i]);
                cubeList.RemoveAt(i);
            }
        }
    }
}
