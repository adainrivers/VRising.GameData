using System;
using HarmonyLib;
using ProjectM;
using VRising.GameData.Utils;

namespace VRising.GameData.Patch;

internal static class ServerEvents
{
    internal static event OnGameDataInitializedEventHandler OnGameDataInitialized;

    [HarmonyPatch(typeof(LoadPersistenceSystemV2), nameof(LoadPersistenceSystemV2.SetLoadState))]
    [HarmonyPostfix]
    private static void ServerStartupStateChange_Postfix(ServerStartupState.State loadState, LoadPersistenceSystemV2 __instance)
    {
        try
        {
            if (loadState == ServerStartupState.State.SuccessfulStartup)
            {
                OnGameDataInitialized?.Invoke(__instance.World);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
        }
    }
}