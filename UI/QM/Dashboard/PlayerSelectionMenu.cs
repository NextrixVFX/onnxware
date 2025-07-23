using onnxware.ButtonAPI;
using onnxware.ButtonAPI.QM;
using onnxware.Components.Tools;
using onnxware.ConsoleAPI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace onnxware.UI.QM.Dashboard;

public static class PlayerSelectionMenu
{
    private static List<GameObject> buttons = new List<GameObject>();
    public static void Initialize(Sprite btnBG)
    {
        
        
        QMSingleButton forceClone = new("", 1f, 0f, "Force Clone", () => Components.Exploits.ForceClone.DoForceClone(), "Force Clone", false, btnBG, btnBG);
        QMSingleButton teleportTo = new("", 2f, 0f, "Teleport", () => Components.Movement.Teleport.doTeleport(), "Teleport to this user", false, btnBG, btnBG);

        QMFoldout onnxwareFoldout = new(MenuPaths.QuickMenu_SelectedUser_Menu, ApiUtils.Identifier,
            [forceClone.GetGameObject(), teleportTo.GetGameObject()]);
        
    }
}