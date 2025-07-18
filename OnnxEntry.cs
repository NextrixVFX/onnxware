using MelonLoader;
using onnxware.UI.QM;
using onnxware;
using onnxware.Components.Tools;
using System.Reflection;
using onnxware.Globals;

[assembly: MelonInfo(typeof(OnnxEntry), "onnxware", "0.0.1", "nextrixvfx", null)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace onnxware
{
    public class OnnxEntry : MelonMod
    {
        public override void OnInitializeMelon()
        {

            if (Variables.Debug)
                ConsoleAPI.Initialize.consoleCreated = ConsoleAPI.Initialize.AllocConsole();

            ConsoleAPI.Logger.Msg("Initialized onnxware!", ConsoleAPI.Logger.LoggerLevel.Info, ConsoleColor.Green);

            // Menu
            TopMenu.Init();

            //Visual
            Components.Visual.BoxESP.Init();
            Components.Visual.PrefabESP.Init();
        }

        public override void OnUpdate()
        {
            // Movement
            Components.Movement.Jetpack.Utilize();
            Components.Movement.Speed.Utilize();
            Components.Movement.Fly.Utilize();

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
            ConsoleAPI.Logger.Msg("Loaded Scene\t" + sceneName, ConsoleAPI.Logger.LoggerLevel.Info, ConsoleColor.Blue);

            // Get all scene data (ex: pickups)
            SceneUtil.Init();
        }

        public override void OnApplicationQuit()
        {
            ConsoleAPI.Logger.Msg("Exiting VRChat! Disabling Cheats...", ConsoleAPI.Logger.LoggerLevel.Info, ConsoleColor.Red);

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

            ConsoleAPI.Logger.Msg("All Cheats Disabled.");

            // ConsoleAPI

            if (Variables.Debug)
                ConsoleAPI.Initialize.FreeConsole();

            ConsoleAPI.Initialize.consoleCreated = false;
        }
    }
}