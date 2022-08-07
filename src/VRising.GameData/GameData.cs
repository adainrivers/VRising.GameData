global using ProjectM;
using HarmonyLib;
using Unity.Entities;
using VRising.GameData.Patch;

namespace VRising.GameData;

public delegate void OnGameDataInitializedEventHandler();

public class GameData
{
    public static event OnGameDataInitializedEventHandler OnInitialize;

    public static GameDataSystems Systems { get; private set; }
    public static World World { get; private set; }
    public static Users Users { get; private set; }
    public static Items Items { get; private set; }
    public static Npcs Npcs { get; private set; }

    private static Harmony _harmonyInstance;
    private static WorldData _worldData;

    public static void Initialize()
    {
        _harmonyInstance = new Harmony("VRising.GameData");
        _worldData = new WorldData();

        if (_worldData.IsClient)
        {
            _harmonyInstance.PatchAll(typeof(ClientEvents));
            ClientEvents.OnGameDataInitialized += OnGameDataInitialized;
        }

        if (_worldData.IsServer)
        {
            _harmonyInstance.PatchAll(typeof(ServerEvents));
            ServerEvents.OnGameDataInitialized += OnGameDataInitialized;
        }
    }

    public static void Destroy()
    {
        World = null;
        Users = null;
        Items = null;
        Npcs = null;
        Systems = null;
        
        OnInitialize = null;
        if (_worldData.IsClient)
        {
            ClientEvents.OnGameDataInitialized -= OnGameDataInitialized;
        }

        if (_worldData.IsServer)
        {
            ServerEvents.OnGameDataInitialized -= OnGameDataInitialized;
        }

        _worldData = null;
        
        _harmonyInstance.UnpatchSelf();
        _harmonyInstance = null;
    }

    private static void OnGameDataInitialized()
    {
        World = _worldData.Current;
        Users = new Users();
        Items = new Items();
        Npcs = new Npcs();
        Systems = new GameDataSystems();
        OnInitialize?.Invoke();
    }


}