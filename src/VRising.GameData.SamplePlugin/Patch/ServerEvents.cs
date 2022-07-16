using System;
using HarmonyLib;
using ProjectM;

namespace VRising.GameData.SamplePlugin.Patch
{
    public delegate void ServerStartupStateChangeEventHandler(LoadPersistenceSystemV2 sender, ServerStartupState.State serverStartupState);

    public static class ServerEvents
    {
        public static event ServerStartupStateChangeEventHandler OnServerStartupStateChanged;
        
        [HarmonyPatch(typeof(LoadPersistenceSystemV2), nameof(LoadPersistenceSystemV2.SetLoadState))]
        [HarmonyPrefix]
        private static void ServerStartupStateChange_Prefix(ServerStartupState.State loadState, LoadPersistenceSystemV2 __instance)
        {
            try
            {
                OnServerStartupStateChanged?.Invoke(__instance, loadState);
            }
            catch (Exception e)
            {
                Plugin.Logger.LogError(e);
            }
        }
    }
}


