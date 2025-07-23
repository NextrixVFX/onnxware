
using MelonLoader;
using VRC;
using VRC.SDKBase;
using UnityEngine;
using System.Collections;
using onnxware.ButtonAPI;

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
        
        public static Player GetSelectedPlayer()
        {
            GameObject nonFriedLabel = GameObject.Find(LabelPaths.QuickMenu_NonFriendList_Label);
            return GetPlayerByDisplayName(nonFriedLabel.GetComponent<TextMeshProUGUIEx>().text);
        }

        public static void OnPlayerJoin(Action<IPlayer> action)
        {
            NetworkManager.field_Internal_Static_NetworkManager_0
            .field_Private_ObjectPublicHa1UnT1Unique_1_IPlayer_1
            .field_Private_HashSet_1_UnityAction_1_T_0
            .Add(new Action<IPlayer>(obj =>
            { action(obj); }));
        }

        public static void OnPlayerLeave(Action<IPlayer> action)
        {
            NetworkManager.field_Internal_Static_NetworkManager_0
            .field_Private_ObjectPublicHa1UnT1Unique_1_IPlayer_2
            .field_Private_HashSet_1_UnityAction_1_T_0
            .Add(new Action<IPlayer>(obj =>
            { action(obj); }));
        }

        public static IEnumerator WaitForPlayerListener()
        {
            while (!NetworkManager.field_Internal_Static_NetworkManager_0)
                yield return null;

            Init();
        }

        public static void Init()
        {
            OnPlayerJoin ((player) => { ConsoleAPI.Logger.Msg($"Player {player.prop_String_0} Joined."); } );
            OnPlayerLeave((player) => { ConsoleAPI.Logger.Msg($"Player {player.prop_String_0} Left."); } );
        }


    }
}
