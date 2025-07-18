
using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using onnxware.Components;
using onnxware.Components.Movement;
using onnxware.Components.Visual;
using UnityEngine;

namespace onnxware.UI.QM.Pages
{
    internal class Visual
    {
        public static void Utilize(QMNestedMenu btn, Sprite btnImg)
        {
            QMToggleButton BoxESPButton = new QMToggleButton(btn, 1f, 0f, "BoxESP",
            () => { BoxESP.Toggle(true); ConsoleAPI.Logger.Msg("Enabled BoxESP"); },
            () => { BoxESP.Toggle(false); ConsoleAPI.Logger.Msg("Disabled BoxESP"); }, "Toggle BoxESP", false, btnImg);

            QMToggleButton PrefabESPButton = new QMToggleButton(btn, 2f, 0f, "PrefabESP",
            () => { PrefabESP.Toggle(true); ConsoleAPI.Logger.Msg("Enabled PrefabESP"); },
            () => { PrefabESP.Toggle(false); ConsoleAPI.Logger.Msg("Disabled PrefabESP"); }, "Toggle PrefabESP", false, btnImg);

            QMToggleButton ThirdPersonButton = new QMToggleButton(btn, 3f, 0f, "ThirdPerson",
            () => { ThirdPerson.Toggle(true); ConsoleAPI.Logger.Msg("Enabled ThirdPerson"); },
            () => { ThirdPerson.Toggle(false); ConsoleAPI.Logger.Msg("Disabled ThirdPerson"); }, "Toggle ThirdPerson", false, btnImg);

            QMSlider ThirdPersonSlider = new QMSlider(btn, 0f, 1f,
                (value) => { ThirdPerson.cameraDist = value; }, "3rd Person Distance", ThirdPerson.cameraDist, 1f, 5f);
        }
    }
}
