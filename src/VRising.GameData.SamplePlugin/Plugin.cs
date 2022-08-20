using System.Linq;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using Unity.Entities;

namespace VRising.GameData.SamplePlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

    //[BepInDependency("GT.VRising.GameData")]
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
            GameData.OnInitialize += GameDataOnInitialize;
        }

        private static void GameDataOnInitialize(World world)
        {
            Logger.LogWarning("All Users:");
            foreach (var userModel in GameData.Users.All)
            {
                Logger.LogMessage($"{userModel.CharacterName} Connected: {userModel.IsConnected}");
                foreach (var inventoryItem in userModel.Inventory.Items)
                {
                    Logger.LogMessage($"\tSlot: {inventoryItem.Slot} Item: {inventoryItem.Item.Name} ({inventoryItem.Stacks})");
                }
            }

            var weapons = GameData.Items.Weapons.Take(10);
            Logger.LogWarning("Some Weapons:");
            foreach (var itemModel in weapons)
            {
                Logger.LogMessage($"{itemModel.Name}");
            }

        }

        public override bool Unload()
        {
            GameData.OnInitialize -= GameDataOnInitialize;
            Logger.LogInfo($"Plugin {Name} {Version} is unloaded!");
            return true;
        }
    }
}
