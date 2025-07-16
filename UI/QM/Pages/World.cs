
using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using onnxware.Components;
using onnxware.Components.Movement;
using UnityEngine;

namespace onnxware.UI.QM.Pages
{
    internal class World
    {
        public static void Utilize(QMNestedMenu btn, Sprite btnImg)
        {
            QMToggleButton JetpackButton = new QMToggleButton(btn, 1f, 0f, "Jetpack",
            () => { Jetpack.Toggle(true); },
            () => { Jetpack.Toggle(false); }, "Toggle Jetpack", false, btnImg);
        }
    }
}
