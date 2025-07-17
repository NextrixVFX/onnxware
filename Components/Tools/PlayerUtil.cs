
using MelonLoader;
using onnxware.Components.Tools;
using VRC;
using VRC.SDKBase;
using UnityEngine;

namespace onnxware.Components.Tools
{
    internal class PlayerUtil
    {
        // Get all players in an instance
        public static Player[] GetAllPlayers() => UnityEngine.Object.FindObjectsOfType<Player>(); //  PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray();

        // Get Specific Player
        public static Player GetPlayerByDisplayName(string name) => GetAllPlayers().ToList().Find(plr => (plr.field_Private_APIUser_0.displayName == name));

        public static Player GetPlayerByID(string id) => GetAllPlayers().ToList().Find(plr => (plr.field_Private_APIUser_0.id == id));

        // Get Local Player
        public static VRCPlayerApi GetLocalPlayer() => Networking.LocalPlayer;

        public static void AddActionToPlayerListener(Action<IPlayer> action)
        {
            NetworkManager.field_Internal_Static_NetworkManager_0
            .field_Private_ObjectPublicHa1UnT1Unique_1_IPlayer_2
            .field_Private_HashSet_1_UnityAction_1_T_0
            .Add(new Action<IPlayer>(obj =>
            { action(obj); }));

        }
            


    }
}
