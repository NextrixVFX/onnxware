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

        public static Camera thirdPersonCam; // accessed by boxesp

        private static GameObject cameraObject;

        public static float cameraDist = 3.0f;

        public static void SliderCameraDist(float value) => cameraDist = value;

        public static void Utilize()
        {
            Camera mainCameraTransform = Camera.main;

            if (!mainCameraTransform)
                return;

            if (!thirdPersonCam)
            {
                // Camera Object
                cameraObject = new GameObject("ThirdPersonCamera");
                cameraObject.transform.SetParent(mainCameraTransform.transform, false);
                cameraObject.transform.localRotation = Quaternion.identity;

                // Camera Settings
                thirdPersonCam = cameraObject.AddComponent<Camera>();
                thirdPersonCam.depth = 10;
                thirdPersonCam.fieldOfView = 60;
                thirdPersonCam.enabled = false;
            }

            cameraObject.transform.localPosition = new Vector3(0f, 0f, -cameraDist); // behind the head

            thirdPersonCam.enabled = isToggled;
        }
    }
}
