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
        if (_onGameDataInitializedTriggered)
        {
            return;
        }
        try
        {
            if (!__instance.GameDataInitialized) return;
            _onGameDataInitializedTriggered= true;
            OnGameDataInitialized?.Invoke();
        }
        catch
        {
            //Suppress
        }
    }
}