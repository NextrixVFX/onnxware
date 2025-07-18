
using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using onnxware.Components;
using onnxware.Components.Movement;
using UnityEngine;

namespace onnxware.UI.QM.Pages
{
    internal class Movement
    {
        public static void Utilize(QMNestedMenu btn, Sprite btnImg)
        {
            QMToggleButton SpeedButton = new QMToggleButton(btn, 1f, 0f, "Speed",
            () => { Speed.Toggle(true); ConsoleAPI.Logger.Msg("Enabled Speed"); },
            () => { Speed.Toggle(false); ConsoleAPI.Logger.Msg("Disabled Speed"); }, "Toggle Speed", false, btnImg);

            QMToggleButton FlyButton = new QMToggleButton(btn, 2f, 0f, "Fly",
            () => { Fly.Toggle(true); ConsoleAPI.Logger.Msg("Enabled Fly"); },
            () => { Fly.Toggle(false); ConsoleAPI.Logger.Msg("Disabled Fly"); }, "Toggle Fly", false, btnImg);

            QMToggleButton JetpackButton = new QMToggleButton(btn, 3f, 0f, "Jetpack",
            () => { Jetpack.Toggle(true); ConsoleAPI.Logger.Msg("Enabled Jetpack"); },
            () => { Jetpack.Toggle(false); ConsoleAPI.Logger.Msg("Disabled Jetpack"); }, "Toggle Jetpack", false, btnImg);

            QMSlider MovementSpeedSlider = new QMSlider(btn, 0f, 1f,
                (value) => { Speed.multiplier = value; }, "Movement Speed", Speed.multiplier, 1f, 10f);

            QMSlider FlySpeedSlider = new QMSlider(btn, 0f, 2f,
                (value) => { Fly.multiplier = value; }, "Fly Speed", Fly.multiplier, 1f, 10f);

        }

    }
}
