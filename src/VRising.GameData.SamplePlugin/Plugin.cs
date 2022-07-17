using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ProjectM;
using VRising.GameData.SamplePlugin.Patch;
using Wetstone.API;
using Wetstone.Hooks;

namespace VRising.GameData.SamplePlugin
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BasePlugin, IRunOnInitialized
    {
        public const string PluginGuid = "VRising.GameData.SamplePlugin";
        public const string PluginName = "VRising.GameData.SamplePlugin";
        public const string PluginVersion = "0.1.0";
        internal static ManualLogSource Logger { get; private set; }
        private static Harmony _harmonyInstance;
        public static GameData GameData;

        public override void Load()
        {
            Logger = Log;
            Logger.LogInfo($"Plugin {PluginName} is loaded!");
            _harmonyInstance = new Harmony(PluginGuid);
            _harmonyInstance.PatchAll(typeof(ServerEvents));

            ServerEvents.OnServerStartupStateChanged += ServerEvents_OnServerStartupStateChanged;
            Chat.OnChatMessage += Chat_OnChatMessage;
        }

        public void OnGameInitialized()
        {
            GameData = new GameData();
        }
        private void Chat_OnChatMessage(VChatEvent e)
        {
            if (e.Message == "hello")
            {
                var sender = GameData.UserData.GetUserFromEntity(e.SenderUserEntity);
                sender.SendSystemMessage($"Hello {sender.Internal.User.CharacterName}. Your current chest armor is {sender.Character.Equipment.Chest.PrefabName}");
            }
        }

        private void ServerEvents_OnServerStartupStateChanged(LoadPersistenceSystemV2 sender, ServerStartupState.State serverStartupState)
        {
            if (serverStartupState == ServerStartupState.State.SuccessfulStartup)
            {
                GameData = new GameData();
                var users = GameData.UserData.GetAllUsers();
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
