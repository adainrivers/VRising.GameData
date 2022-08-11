using System.Diagnostics;
using HarmonyLib;

namespace VRising.GameData.Patch;

internal static class ClientEvents
{
    internal static event OnGameDataInitializedEventHandler OnGameDataInitialized;

    private static bool _onGameDataInitializedTriggered;
    [HarmonyPatch(typeof(GameDataManager), "OnUpdate")]
    [HarmonyPostfix]
    private static void GameDataManagerOnUpdatePostfix(GameDataManager __instance)
    {
        Debug.WriteLine("GameDataManagerOnUpdatePostfix Start");
        if (_onGameDataInitializedTriggered)
        {
            Debug.WriteLine("GameDataManagerOnUpdatePostfix _onGameDataInitializedTriggered");
            if (!__instance.GameDataInitialized)
            {
                Debug.WriteLine("GameDataManagerOnUpdatePostfix !__instance.GameDataInitialized");
                // Reset state if game date is no longer initialized
                _onGameDataInitializedTriggered = false;
            }
            return;
        }

        try
        {
            if (!__instance.GameDataInitialized)
            {
                Debug.WriteLine("GameDataManagerOnUpdatePostfix !__instance.GameDataInitialized (2)");
                return;
            }

            _onGameDataInitializedTriggered = true;
            Debug.WriteLine("GameDataManagerOnUpdatePostfix Trigger");
            OnGameDataInitialized?.Invoke(__instance.World);
        }
        catch
        {
            //Suppress
        }
    }
}