using UnityEngine;
using VRC;

namespace onnxware.Globals
{
    internal class Variables
    {
        public const string DataPath = "onnxware"; // client name
        public static GameObject userInterface;
        public static GameObject quickMenu;
        public static List<Player> playerList;
        public static bool Debug = true;
    }
}
