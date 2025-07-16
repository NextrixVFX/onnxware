using MelonLoader;
using onnxware.UI.QM;
using onnxware;

[assembly: MelonInfo(typeof(OnnxEntry), "onnxware", "0.0.1", "nextrixvfx", null)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace onnxware
{
    public class OnnxEntry : MelonMod
    {
        public override void OnInitializeMelon()
        {
            TopMenu.InitializeMenu();
        }

        public override void OnUpdate()
        {
            Components.Movement.Jetpack.Utilize();
        }
    }
}