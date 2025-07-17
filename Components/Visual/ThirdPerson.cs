using VRC;
using VRC.SDKBase;
using onnxware.Components.Tools;
using UnityEngine;
using MelonLoader;

namespace onnxware.Components.Visual
{
    public class ThirdPerson
    {
        public static bool isToggled = false;

        public static void Toggle(bool x) => isToggled = x;

        private static VRCPlayerApi localPlayer;

        private static Camera thirdPersonCam;

        private static GameObject cameraObject;

        private static GameObject cameraHolder;

        private static float cameraDist = 300.0f;

        public static void Utilize()
        {
            localPlayer = PlayerUtil.GetLocalPlayer();
            
            if (localPlayer == null)
                return;

            Animator anim = localPlayer.gameObject.GetComponentInChildren<Animator>();

            if (!anim)
                return;

            Transform head = anim.GetBoneTransform(HumanBodyBones.Head);
            Transform playerTransform = localPlayer.gameObject.transform;

            // create third-person camera if it doesn't exist
            if (!thirdPersonCam)
            {
                // Camera Holder Empty
                /*cameraHolder = new GameObject("CameraHolder");
                cameraHolder.gameObject.transform.SetParent(head, false); // set the empty on head
                cameraHolder.transform.localRotation = Quaternion.identity;*/

                // Camera Object
                cameraObject = new GameObject("ThirdPersonCamera");
                Vector3 lossyScale = playerTransform.lossyScale;
                cameraObject.transform.SetParent(head, false);
                cameraObject.transform.localPosition = new Vector3(0f, 0f, -cameraDist); // behind the head
                cameraObject.transform.localRotation = Quaternion.identity;

                // Camera Settings
                thirdPersonCam = cameraObject.AddComponent<Camera>();
                
                thirdPersonCam.depth = 10; // priority (render on top of others)
                thirdPersonCam.fieldOfView = 60;
                thirdPersonCam.enabled = false;
                //thirdPersonCam.clearFlags = CameraClearFlags.Depth;
            }

            thirdPersonCam.enabled = isToggled;
        }
    }
}
