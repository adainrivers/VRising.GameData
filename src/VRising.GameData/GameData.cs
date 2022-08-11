global using ProjectM;
using HarmonyLib;
using Unity.Entities;
using UnityEngine;
using VRising.GameData.Patch;

namespace VRising.GameData;

public delegate void OnGameDataInitializedEventHandler(World world);

public class GameData
{
    public static bool IsServer = Application.productName == "VRisingServer";
    public static bool IsClient = Application.productName == "VRising";

    public static event OnGameDataInitializedEventHandler OnInitialize;

    public static GameDataSystems Systems { get; private set; }
    public static World World { get; private set; }
    public static Users Users { get; private set; }
    public static Items Items { get; private set; }
    public static Npcs Npcs { get; private set; }

    private static Harmony _harmonyInstance;


    public static void Create()
    {
        _harmonyInstance = new Harmony("VRising.GameData");


        if (IsClient)
        {
            _harmonyInstance.PatchAll(typeof(ClientEvents));
            ClientEvents.OnGameDataInitialized += OnGameDataInitialized;
        }

        if (IsServer)
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
        if (IsClient)
        {
            ClientEvents.OnGameDataInitialized -= OnGameDataInitialized;
        }

        if (IsServer)
        {
            ServerEvents.OnGameDataInitialized -= OnGameDataInitialized;
        }
        
        _harmonyInstance.UnpatchSelf();
        _harmonyInstance = null;
    }

    private static void OnGameDataInitialized(World world)
    {
        World = world;
        Users = new Users();
        Items = new Items();
        Npcs = new Npcs();
        Systems = new GameDataSystems();
        OnInitialize?.Invoke(world);
    }


}