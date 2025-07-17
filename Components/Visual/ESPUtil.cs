using VRC;
using System.Collections;
using UnityEngine;
using VRC.SDKBase;
using MelonLoader;
using onnxware.Components.Tools;

namespace onnxware.Components.Visual
{
    public class ESPUtil
    {
        public Player[] playerArray;
        public VRCPlayerApi localPlayer;
        public bool _toggle; // this is changed when the esp is enabled or disabled (in Toggle(x) method)

        public IEnumerator WaitForPlayerListener(Action espCode)
        {
            while (!NetworkManager.field_Internal_Static_NetworkManager_0)
                yield return null;

            Init(espCode);
        }

        public bool Init(Action espCode)
        {
            // add refreshplayerlist function to the OnPlayerJoin listener
            PlayerUtil.AddActionToPlayerListener(new Action<IPlayer>(obj => 
            {
                MelonLogger.Msg($"Player {PlayerUtil.GetPlayerByID(obj.prop_String_0).prop_VRCPlayerApi_0.displayName} Joined.");
                RefreshPlayerList(espCode);
            }));

            return true; // todo
        }

        public void RefreshPlayerList(Action espCode)
        {
            MelonLogger.Msg("Player List Refreshed");

            this.playerArray = PlayerUtil.GetAllPlayers();
            this.localPlayer = PlayerUtil.GetLocalPlayer();

            if (_toggle)
                espCode();
        }
            

    }
}
