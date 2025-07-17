
using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using onnxware.Components;
using onnxware.Components.Tools;
using onnxware.Components.World;
using UnityEngine;

namespace onnxware.UI.QM.Pages
{
    internal class World
    {
        public static void Utilize(QMNestedMenu btn, Sprite btnImg)
        {
            QMToggleButton ItemOrbitButton = new QMToggleButton(btn, 1f, 0f, "Item Orbit",
            () => { ItemOrbit.Toggle("", true); },
            () => { ItemOrbit.Toggle("", false); }, "Toggle Item Orbit", false, btnImg);
        }
    }
}
