
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
            () => { ItemOrbit.Toggle("", true); ConsoleAPI.Logger.Msg("Enabled Item Orbit"); },
            () => { ItemOrbit.Toggle("", false); ConsoleAPI.Logger.Msg("Disabled Item Orbit"); }, "Toggle Item Orbit", false, btnImg);

            string[] ItemOrbitShapeOptions = ["Cubic", "Cross", "Swastika"];
            QMEnum ItemOrbitShapeEnum = new QMEnum(btn, 0f, 1f,
                (index) => { ItemOrbit.enumIndex = index; ConsoleAPI.Logger.Msg($"Changed shape to {ItemOrbitShapeOptions[index]}"); },
                (index) => { ItemOrbit.enumIndex = index; ConsoleAPI.Logger.Msg($"Changed shape to {ItemOrbitShapeOptions[index]}"); }
            , "Item Orbit Shape", 0, ItemOrbitShapeOptions);
        }
    }
}
