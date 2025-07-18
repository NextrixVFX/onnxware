using onnxware.Components.Tools;
using UnityEngine;
using VRC.SDKBase;

namespace onnxware.Components.Movement
{
    public static class Fly
    {
        private static bool isToggled = false;

        public static float multiplier = 3f;

        public static void Toggle(bool x) => isToggled = x;

        private static float gravityStrength = -1f;

        private static Collider localPlayerCollider;

        public static void Utilize()
        {
            VRCPlayerApi localPlayer = PlayerUtil.GetLocalPlayer();

            if (localPlayer == null)
                return; 

            Transform localPlayerTransform = localPlayer.gameObject.transform;

            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
                direction += localPlayerTransform.forward;

            if (Input.GetKey(KeyCode.S))
                direction -= localPlayerTransform.forward;

            if (Input.GetKey(KeyCode.A))
                direction -= localPlayerTransform.right;

            if (Input.GetKey(KeyCode.D))
                direction += localPlayerTransform.right;

            if (Input.GetKey(KeyCode.Space))
                direction += localPlayerTransform.up;

            if (Input.GetKey(KeyCode.LeftControl))
                direction -= localPlayerTransform.up;

            if (gravityStrength == -1f)
                gravityStrength = localPlayer.GetGravityStrength();

            if (!localPlayerCollider)
                localPlayerCollider = localPlayer.gameObject.GetComponent<Collider>();

            if (isToggled)
            {
                localPlayerCollider.enabled = false;
                localPlayer.SetGravityStrength(0f);
                localPlayerTransform.position += direction.normalized * (multiplier * 0.01f);
                return;
            }

            localPlayerCollider.enabled = true;
            localPlayer.SetGravityStrength(gravityStrength);
        }
    }
}
