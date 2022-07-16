using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ProjectM;
using VRising.GameData.SamplePlugin.Patch;

namespace VRising.GameData.SamplePlugin
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BasePlugin
    {
        public const string PluginGuid = "VRising.GameData.SamplePlugin";
        public const string PluginName = "VRising.GameData.SamplePlugin";
        public const string PluginVersion = "0.1.0";
        internal static ManualLogSource Logger { get; private set; }
        private static Harmony _harmonyInstance;

        public override void Load()
        {
            Logger = Log;
            Logger.LogInfo($"Plugin {PluginName} is loaded!");
            _harmonyInstance = new Harmony(PluginGuid);
            _harmonyInstance.PatchAll(typeof(ServerEvents));

            ServerEvents.OnServerStartupStateChanged += ServerEvents_OnServerStartupStateChanged;
        }

        private void ServerEvents_OnServerStartupStateChanged(LoadPersistenceSystemV2 sender, ServerStartupState.State serverStartupState)
        {
            if (serverStartupState == ServerStartupState.State.SuccessfulStartup)
            {
                var gameData = new GameData();
                var users = gameData.UsersData.GetAllUsers();
                foreach (var user in users)
                {
                    Logger.LogMessage($"{user.Internal.User.CharacterName} Connected: {user.Internal.User.IsConnected}");
                }
            }
        }

        public override bool Unload()
        {
            _harmonyInstance?.UnpatchSelf();
            Logger.LogInfo($"Plugin {PluginGuid} is unloaded!");
            return true;
        }
    }
}
