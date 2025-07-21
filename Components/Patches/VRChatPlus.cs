using HarmonyLib;
using System.Reflection;

namespace onnxware.Components.Patches
{
    public static class VRChatPlus
    {
        public static void Initialize()
        {
            HarmonyLib.Harmony HarmonyInstance = new("com.onnxware.vrchatplus");

            HarmonyInstance.Patch(
                typeof(VRCPlusStatus).GetProperty(nameof(VRCPlusStatus.prop_Object1PublicTBoTUnique_1_Boolean_0)).GetGetMethod(), // vrchat boolean that represents if you have vrc+
                postfix: new HarmonyMethod(typeof(VRChatPlus).GetMethod(nameof(VRCPlusOverride), BindingFlags.Static | BindingFlags.NonPublic)) // make ur status true
            );
        }

        private static void VRCPlusOverride(ref Object1PublicTBoTUnique<bool> __result)
        {
            if (__result == null || (__result.prop_T_0 && __result.field_Protected_T_0)) return;
            
            // change the boolean to true (indicating you have vrc+)
            __result.prop_T_0 = true;
            __result.field_Protected_T_0 = true;
            ConsoleAPI.Logger.Msg("Enabled VRChat Plus", ConsoleAPI.Logger.LoggerLevel.Info, ConsoleColor.Magenta);
        }
    }
}
