using System;
using BepInEx.Logging;
using HarmonyLib;
using Unity.Entities;
using UnityEngine;
using VRising.GameData.Patch;

namespace VRising.GameData;

public delegate void OnGameDataInitializedEventHandler(World world);
public delegate void OnGameDataDestroyedEventHandler();

public static class GameData
{
    static GameData()
    {
        Create();
    }

    private static bool _initialized;
    private static bool _worldDataInitialized;

    private const string NotInitializedError = "GameData is not initialized";

    public static bool IsServer = Application.productName == "VRisingServer";
    public static bool IsClient = Application.productName == "VRising";

    public static GameVersionData GameVersion => GameVersionUtils.GetVersionData();


    public static event OnGameDataInitializedEventHandler OnInitialize;
    public static event OnGameDataDestroyedEventHandler OnDestroy;

    private static World _world;
    public static World World => _world ?? throw new InvalidOperationException(NotInitializedError);

    public static Systems Systems => _worldDataInitialized ? Systems.Instance : throw new InvalidOperationException(NotInitializedError);
    public static Users Users => _worldDataInitialized ? Users.Instance : throw new InvalidOperationException(NotInitializedError);
    public static Items Items => _worldDataInitialized ? Items.Instance : throw new InvalidOperationException(NotInitializedError);
    public static Npcs Npcs => _worldDataInitialized ? Npcs.Instance : throw new InvalidOperationException(NotInitializedError);

    private static Harmony _harmonyInstance;

    internal static ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("VRising.GameData");

    public static bool Initialized => _worldDataInitialized;

    internal static void Create()
    {
        if (_initialized)
        {
            return;
        }
        _initialized = true;
        _harmonyInstance = new Harmony("VRising.GameData");

        if (IsClient)
        {
            _harmonyInstance.PatchAll(typeof(ClientEvents));
            ClientEvents.OnGameDataInitialized += OnGameDataInitialized;
            ClientEvents.OnGameDataDestroyed += OnGameDataDestroyed;
        }

        if (IsServer)
        {
            _harmonyInstance.PatchAll(typeof(ServerEvents));
            ServerEvents.OnGameDataInitialized += OnGameDataInitialized;
        }
    }

    internal static void Destroy()
    {
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

    private static void OnGameDataDestroyed()
    {
        _world = null;
        _worldDataInitialized = false;
        OnDestroy?.Invoke();
        if (OnDestroy == null)
        {
            return;
        }
        foreach (var hook in OnDestroy.GetInvocationList())
        {
            try
            {
                hook.DynamicInvoke();
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
        }
    }

    private static void OnGameDataInitialized(World world)
    {
        _world = world;
        _worldDataInitialized = true;
        if (OnInitialize == null)
        {
            return;
        }
        foreach (var hook in OnInitialize.GetInvocationList())
        {
            try
            {
                hook.DynamicInvoke(world);
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
        }
        Logger.LogInfo("GameData initialized");
    }
}