
using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using onnxware.Components;
using onnxware.Components.Visual;
using UnityEngine;

namespace onnxware.UI.QM.Pages
{
    internal class Visual
    {
        public static void Utilize(QMNestedMenu btn, Sprite btnImg)
        {
            QMToggleButton BoxESPButton = new QMToggleButton(btn, 1f, 0f, "BoxESP",
            () => { BoxESP.Toggle(true); },
            () => { BoxESP.Toggle(false); }, "Toggle BoxESP", false, btnImg);

            QMToggleButton PrefabESPButton = new QMToggleButton(btn, 2f, 0f, "PrefabESP",
            () => { PrefabESP.Toggle(true); },
            () => { PrefabESP.Toggle(false); }, "Toggle PrefabESP", false, btnImg);

            QMToggleButton ThirdPersonButton = new QMToggleButton(btn, 3f, 0f, "ThirdPerson",
            () => { ThirdPerson.Toggle(true); },
            () => { ThirdPerson.Toggle(false); }, "Toggle ThirdPerson", false, btnImg);

        }
    }
}
