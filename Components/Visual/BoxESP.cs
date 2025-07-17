using onnxware.Components.Tools;
using VRC;
using VRC.SDKBase;
using UnityEngine;
using MelonLoader;


namespace onnxware.Components.Visual
{
    public static class BoxESP
    {
        public static bool isToggled = false;

        private static bool isInitialized = true;

        private static Color boxColor = Color.white;

        private static Vector3 boxDimensions = new Vector3(0.6f, 2f, 0.4f);

        private static List<PlayerBoxData> playerBoxes = new List<PlayerBoxData>();

        private static Material lineMaterial;

        private static ESPUtil BoxESPUtil = new();

        public static void Toggle(bool x)
        {
            isToggled = x;
            BoxESPUtil._toggle = isToggled;

            if (isInitialized && isToggled)
                BoxESPUtil.RefreshPlayerList(assignPlayersBox);
            
        }
            

        // Runs in OnInitializeMelon
        public static void Init(float delay)
        {
            CreateLineMaterial();
            MelonCoroutines.Start(BoxESPUtil.WaitForPlayerListener(assignPlayersBox));
            MelonLogger.Msg((isInitialized) ? "BoxESP Initialized" : "BoxESP Initialization Failed");
        }

        private static void assignPlayersBox()
        {
            playerBoxes.Clear();

            // Create bound data for each valid entity
            foreach (Player player in BoxESPUtil.playerArray)
            {
                if (!player)
                    continue;

                // Don't add localPlayer into array
                if (player.gameObject == BoxESPUtil.localPlayer.gameObject)
                    continue;

                Animator playerAnimator = player.GetComponentInChildren<Animator>();

                if (!playerAnimator || !playerAnimator.isHuman)
                    continue;

                PlayerBoxData playerBoxData = new PlayerBoxData(player, playerAnimator);
                CalculateBoxData(ref playerBoxData, BoxESPUtil.localPlayer);
                playerBoxes.Add(playerBoxData);
            }
        }

        public static void Utilize()
        {
            if (!isToggled)
                return;

            // if you dont *reverse* the list itll only update 1 player's bounding position idk why
            for (int i = playerBoxes.Count - 1; i >= 0; i--)
            {
                // if a player left before the refresh remove them
                if (!playerBoxes[i].player || !playerBoxes[i].animator)
                {
                    playerBoxes.RemoveAt(i);
                    continue;
                }

                // Recalculate positions (cause people move duh)
                PlayerBoxData boxData = playerBoxes[i];
                CalculateBoxData(ref boxData, BoxESPUtil.localPlayer);
                playerBoxes[i] = boxData;
            }
        }
        
        // Runs in OnGUI
        public static void RenderBoxes()
        {
            if (!isToggled)
                return;

            Camera camera = Camera.current;

            // No Scene loaded
            if (!camera)
                return;

            // Get Current Viewport
            GL.PushMatrix();
            DebugHelper d = new DebugHelper();
            d.DebugLine( () => lineMaterial.SetPass(0) ); // Overlay
            GL.LoadPixelMatrix();

            // Render on new buffer (our screen is 0)
            GL.Begin(1);
            GL.Color(boxColor);

            // We can iterate a second time because this is running on our GPU (not cpu)
            foreach (PlayerBoxData pbd in playerBoxes)
            { Renderer.DrawBoundingBox(pbd.boundingBox, camera); }

            // Close buffer
            GL.End();
            GL.PopMatrix();
        }

        private static void CalculateBoxData(ref PlayerBoxData boxData, VRCPlayerApi localPlayer)
        {
            if (!boxData.rootBone || !boxData.headBone)
                return;

            Vector3 midPoint = Vector3.Lerp(boxData.rootBone.position, boxData.headBone.position, 0.5f);

            boxData.boundingBox = new Bounds(midPoint, boxDimensions);
            boxData.distFromLocalPlayer = Vector3.Distance(localPlayer.GetPosition(), midPoint);
        }

        public struct PlayerBoxData
        {
            public Player player;
            public Animator animator;
            public Transform rootBone;
            public Transform headBone;
            public Bounds boundingBox;
            public float distFromLocalPlayer;
            public string playerName;

            public PlayerBoxData(Player entity, Animator anim)
            {
                this.player = entity;
                this.animator = anim;
                this.rootBone = anim.GetBoneTransform(HumanBodyBones.Hips);
                this.headBone = anim.GetBoneTransform(HumanBodyBones.Head);
                this.playerName = entity.field_Private_APIUser_0.displayName;
                this.boundingBox = default(Bounds);
                this.distFromLocalPlayer = 0f;
            }
        }

        public static void CreateLineMaterial()
        {
            if (lineMaterial)
                return;

            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = (HideFlags)61; // ?
            lineMaterial.SetInt("_SrcBlend", 5); // SrcBlend
            lineMaterial.SetInt("_DstBlend", 10); // OneMinusSrcBlend
            lineMaterial.SetInt("_Cull", 0); // Off
            lineMaterial.SetInt("_ZTest", 8); // ?
            lineMaterial.SetInt("_ZWrite", 0); // Off
        }

        public static void Destroy()
        {
            isToggled = false;
            playerBoxes.Clear();

            if (lineMaterial)
                UnityEngine.Object.Destroy(lineMaterial);

            lineMaterial = null;
        }
    }
}
