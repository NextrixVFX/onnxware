using MelonLoader;
using onnxware.UI.QM;
using onnxware;
using onnxware.Components.Tools;
using System.Reflection;

[assembly: MelonInfo(typeof(OnnxEntry), "onnxware", "0.0.1", "nextrixvfx", null)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace onnxware
{
    public class OnnxEntry : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Initialized onnxware");

            // Menu
            TopMenu.Init();

            //Visual
            Components.Visual.BoxESP.Init(5f);

            Components.Visual.PrefabESP.Init(5f);

            

        }

        public override void OnUpdate()
        {
            // Movement
            Components.Movement.Jetpack.Utilize();

            // World
            Components.World.ItemOrbit.Utilize();

            // Visuals
            Components.Visual.BoxESP.Utilize();
            Components.Visual.ThirdPerson.Utilize();
        }

        public override void OnGUI()
        {
            Components.Visual.BoxESP.RenderBoxes();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("Loaded Scene ->\t" + sceneName);

            // Get all scene data (ex: pickups)
            SceneUtil.Init();
        }

        public override void OnApplicationQuit()
        {
            // World
            Components.World.ItemOrbit.Toggle("", false);

            // Movement
            Components.Movement.Jetpack.Toggle(false);
            Components.Movement.Speed.Toggle(false);

            // Visual
            Components.Visual.BoxESP.Toggle(false);
            Components.Visual.PrefabESP.Toggle(false);
            Components.Visual.ThirdPerson.Toggle(false);
            Components.Visual.BoxESP.Destroy();

            // Exploits
            Components.Exploits.LoudMic.Toggle(false);
        }
    }
}