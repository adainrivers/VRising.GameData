using System;
using System.Diagnostics;
using HarmonyLib;
using ProjectM;
using ProjectM.Auth;

namespace VRising.GameData.Patch;

internal class ClientEvents
{
    internal static event OnGameDataInitializedEventHandler OnGameDataInitialized;
    internal static event OnGameDataDestroyedEventHandler OnGameDataDestroyed;

    private static bool _onGameDataInitializedTriggered;
    [HarmonyPatch(typeof(GameDataManager), "OnUpdate")]
    [HarmonyPostfix]
    private static void GameDataManagerOnUpdatePostfix(GameDataManager __instance)
    {
        if (_onGameDataInitializedTriggered)
        {
            return;
        }

        try
        {
            if (!__instance.GameDataInitialized)
            {
                return;
            }

            _onGameDataInitializedTriggered = true;
            Debug.WriteLine("GameDataManagerOnUpdatePostfix Trigger");
            OnGameDataInitialized?.Invoke(__instance.World);
        }
        catch (Exception ex)
        {
            GameData.Logger.LogError(ex);
        }
    }

    [HarmonyPatch(typeof(ClientBootstrapSystem), "OnDestroy")]
    [HarmonyPostfix]
    private static void ClientBootstrapSystemOnDestroyPostfix(ClientBootstrapSystem __instance)
    {
        _onGameDataInitializedTriggered = false;
        try
        {
            OnGameDataDestroyed?.Invoke();
        }
        catch (Exception ex)
        {
            GameData.Logger.LogError(ex);
        }
    }

    [HarmonyPatch(typeof(SteamPlatformSystem), "TryInitClient")]
    [HarmonyPostfix]
    private static void SteamPlatformSystemOnTryInitClientPostfix(SteamPlatformSystem __instance)
    {
        try
        {
            Users.CurrentUserSteamId = __instance.UserID;
        }
        catch (Exception ex)
        {
            GameData.Logger.LogError(ex);
        }
    }
}