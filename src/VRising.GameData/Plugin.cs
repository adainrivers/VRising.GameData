using System;
using BepInEx;
using BepInEx.IL2CPP;
using Unity.Entities;
using VRising.GameData.Utils;

namespace VRising.GameData
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        private static bool _pluginLoaded = false;
        internal static string Name = PluginInfo.PLUGIN_NAME;
        internal static string Guid = PluginInfo.PLUGIN_GUID;
        internal static string Version = PluginInfo.PLUGIN_VERSION;
        internal static Logger Logger { get; private set; }
        internal static Plugin Instance { get; private set; }

        public override void Load()
        {
            if (_pluginLoaded)
            {
                return;
            }

            _pluginLoaded = true;
            Instance = this;
            Logger = new Logger(Log);

            GameData.Create();
            GameData.OnInitialize += GameData_OnInitialize;
            GameData.OnDestroy += GameData_OnDestroy;
            Logger.LogInfo($"Plugin {Name} for {GameData.GameVersion.MidVersionString} is loaded!");
        }

        private void GameData_OnDestroy()
        {
            Logger.LogInfo("GameData destroyed.");
        }

        private void GameData_OnInitialize(World world)
        {
            Logger.LogInfo($"GameData initialized for world: {world.Name}");
        }

        public override bool Unload()
        {
            if (!_pluginLoaded)
            {
                return true;
            }
            GameData.OnInitialize -= GameData_OnInitialize;
            GameData.OnDestroy -= GameData_OnDestroy;
            GameData.Destroy();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is unloaded!");
            return true;
        }
    }
}
