using System;
using HarmonyLib;
using ProjectM;

namespace VRising.GameData.ClassGenerator.Patch
{
    public delegate void ServerStartupStateChangeEventHandler(LoadPersistenceSystemV2 sender, ServerStartupState.State serverStartupState);

    public static class ServerEvents
    {
        public static event ServerStartupStateChangeEventHandler OnServerStartupStateChanged;

        [HarmonyPatch(typeof(LoadPersistenceSystemV2), nameof(LoadPersistenceSystemV2.SetLoadState))]
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

        [HarmonyPatch(typeof(ClientConsoleCommandSystem), "OnCreateConsoleCommands")]
        [HarmonyPrefix]
        private static void Prefix(ClientConsoleCommandSystem __instance)
        {
            try
            {
                new CreateGameDataClassesConsoleCommand().Register(__instance);
            }
            catch (Exception e)
            {
                Plugin.Logger.LogError(e);
            }
        }
    }
}


