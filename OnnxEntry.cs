using MelonLoader;
using UnityEngine;
using onnxware;

[assembly: MelonInfo(typeof(onnxware.OnnxEntry), "onnxware", "0.0.1", "nextrixvfx", null)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace onnxware
{
    public class OnnxEntry : MelonMod
    {
        public override void OnInitializeMelon()
        {
            GUI.Console.Log("Initialized");
        }

        public override void OnUpdate()
        {
            GUI.Console.RefreshMenu();
            Components.Jetpack.Utilize();
        }

        public override void OnApplicationQuit()
        {
            GUI.Console.IsToggledMenu = false;
        }
    }
}