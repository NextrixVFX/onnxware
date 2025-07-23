using onnxware.Components.Tools;
using UnityEngine;
using VRC.SDKBase;

namespace onnxware.Components.Movement;

public static class Teleport
{
    private static VRCPlayerApi localPlayer;
    private static VRC.Player player;
    
    public static void doTeleport()
    {
        player = PlayerUtil.GetSelectedPlayer();
        
        if (!player)
            return;
        
        localPlayer = PlayerUtil.GetLocalPlayer();
        localPlayer.gameObject.transform.position = player.transform.position;
        ConsoleAPI.Logger.Msg($"Teleporting to {player.field_Private_VRCPlayerApi_0.displayName}");
    }
}