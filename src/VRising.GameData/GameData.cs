using System;
using GT.VRising.GameData.Patch;
using HarmonyLib;
using Unity.Entities;
using UnityEngine;

namespace GT.VRising.GameData;

public delegate void OnGameDataInitializedEventHandler(World world);
public delegate void OnGameDataDestroyedEventHandler();

public static class GameData
{
    private static bool _initialized;

    private const string NotInitializedError = "GameData is not initialized";

    public static bool IsServer = Application.productName == "VRisingServer";
    public static bool IsClient = Application.productName == "VRising";

    public static GameVersionData GameVersion => GameVersionUtils.GetVersionData();

    public static event OnGameDataInitializedEventHandler OnInitialize;
    public static event OnGameDataDestroyedEventHandler OnDestroy;

    private static World _world;
    public static World World => _world ?? throw new InvalidOperationException(NotInitializedError);

    public static Systems Systems => _initialized ? Systems.Instance : throw new InvalidOperationException(NotInitializedError);
    public static Users Users => _initialized ? Users.Instance : throw new InvalidOperationException(NotInitializedError);
    public static Items Items => _initialized ? Items.Instance : throw new InvalidOperationException(NotInitializedError);
    public static Npcs Npcs => _initialized ? Npcs.Instance : throw new InvalidOperationException(NotInitializedError);

    private static Harmony _harmonyInstance;


    internal static void Create()
    {
        _harmonyInstance = new Harmony(Plugin.Guid);

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
        _initialized = false;
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
                Plugin.Logger.LogError(e);
            }
        }
    }

    private static void OnGameDataInitialized(World world)
    {
        _world = world;
        _initialized = true;
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
                Plugin.Logger.LogError(e);
            }
        }
    }
}