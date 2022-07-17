using System;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using ProjectM;
using UnhollowerRuntimeLib;
using VRising.GameData.ClassGenerator.Patch;

namespace VRising.GameData.ClassGenerator
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("xyz.molenzwiebel.wetstone")]
    public class Plugin : BasePlugin
    {
        public const string PluginGuid = "VRising.GameData.ClassGenerator";
        public const string PluginName = "VRising.GameData.ClassGenerator";
        public const string PluginVersion = "0.6.0";
        internal static ManualLogSource Logger { get; private set; }
        private static Harmony _harmonyInstance;

        public override void Load()
        {
            Logger = Log;
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginName} is loaded!");
            _harmonyInstance = new Harmony(PluginGuid);
            _harmonyInstance.PatchAll(typeof(ServerEvents));
            if (!ClassInjector.IsTypeRegisteredInIl2Cpp<CreateGameDataClassesConsoleCommand>())
            {
                ClassInjector.RegisterTypeInIl2Cpp<CreateGameDataClassesConsoleCommand>();
            }


            ServerEvents.OnServerStartupStateChanged += ServerEvents_OnServerStartupStateChanged;
        }

        private void ServerEvents_OnServerStartupStateChanged(ProjectM.LoadPersistenceSystemV2 sender, ProjectM.ServerStartupState.State serverStartupState)
        {
            switch (serverStartupState)
            {
                case ServerStartupState.State.None:
                    break;
                case ServerStartupState.State.Waiting:
                    break;
                case ServerStartupState.State.Initializing:
                    break;
                case ServerStartupState.State.SuccessfulStartup:
                    ClassGenerator.GenerateClasses();
                    break;
                case ServerStartupState.State.Failed:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(serverStartupState), serverStartupState, null);
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
