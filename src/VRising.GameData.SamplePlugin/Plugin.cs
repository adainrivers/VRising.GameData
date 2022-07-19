using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ProjectM;
using VRising.GameData.Methods;
using VRising.GameData.SamplePlugin.Patch;
using Wetstone.API;
using Wetstone.Hooks;

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

        private void Chat_OnChatMessage(VChatEvent e)
        {
            if (e.Message == "hello")
            {
                var sender = GameData.UserData.GetUserFromEntity(e.SenderUserEntity);
                sender.SendSystemMessage($"Hello {sender.CharacterName}. Your current chest armor is {sender.Equipment.Chest.PrefabName}");
            }
        }

        private void ServerEvents_OnServerStartupStateChanged(LoadPersistenceSystemV2 sender, ServerStartupState.State serverStartupState)
        {
            if (serverStartupState == ServerStartupState.State.SuccessfulStartup)
            {
                var users = GameData.UserData.GetAllUsers();
                foreach (var userModel in users)
                {
                    Logger.LogMessage($"{userModel.CharacterName} Connected: {userModel.IsConnected}");
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
