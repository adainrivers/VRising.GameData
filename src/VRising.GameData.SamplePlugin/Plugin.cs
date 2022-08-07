global using ProjectM;
using System.Linq;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;

namespace VRising.GameData.SamplePlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        internal static string Name = PluginInfo.PLUGIN_NAME;
        internal static string Guid = PluginInfo.PLUGIN_GUID;
        internal static string Version = PluginInfo.PLUGIN_VERSION;
        internal static ManualLogSource Logger { get; private set; }

        public override void Load()
        {
            Logger = Log;
            Logger.LogInfo($"Plugin {Name} {Version} is loaded!");
            GameData.Initialize();
            GameData.OnInitialize += GameDataOnInitialize;
        }

        private static void GameDataOnInitialize()
        {
            GameData.OnInitialize -= GameDataOnInitialize;

            var users = GameData.Users.GetAllUsers();
            Logger.LogMessage("All Users");
            foreach (var userModel in users)
            {
                Logger.LogMessage($"{userModel.CharacterName} Connected: {userModel.IsConnected}");
            }

            var weapons = GameData.Items.Weapons.Take(10);
            Logger.LogMessage("Some Weapons");
            foreach (var itemModel in weapons)
            {
                Logger.LogMessage($"{itemModel.Name}");
            }
        }

        public override bool Unload()
        {
            GameData.Destroy();
            Logger.LogInfo($"Plugin {Name} {Version} is unloaded!");
            return true;
        }
    }
}
