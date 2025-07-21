using VRC;
using System.Collections;
using VRC.SDKBase;
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

        public void Init(Action espCode)
        {
            PlayerUtil.OnPlayerJoin(obj => RefreshPlayerList(espCode));
        }

        public void RefreshPlayerList(Action espCode)
        {
            ConsoleAPI.Logger.Msg("Player List Refreshed");

            this.playerArray = PlayerUtil.GetAllPlayers();
            this.localPlayer = PlayerUtil.GetLocalPlayer();

            if (_toggle)
                espCode();
        }
            

    }
}
