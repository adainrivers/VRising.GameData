using System;
using HarmonyLib;
using Unity.Entities;
using UnityEngine;
using VRising.GameData.Patch;

namespace VRising.GameData;

public delegate void OnGameDataInitializedEventHandler(World world);
internal delegate void OnGameDataDestroyedEventHandler();

public class GameData : IDisposable
{
    private bool _initialized;

    private const string NotInitializedError = "GameData is not initialized";

    public static bool IsServer = Application.productName == "VRisingServer";
    public static bool IsClient = Application.productName == "VRising";

    public static GameVersionData GameVersion => GameVersionUtils.GetVersionData();

    public event OnGameDataInitializedEventHandler OnInitialize;

    private World _world;
    public World World => _world ?? throw new InvalidOperationException(NotInitializedError);

    public Systems Systems => _initialized ? Systems.GetOrCreate(this) : throw new InvalidOperationException(NotInitializedError);
    public Users Users => _initialized ? Users.GetOrCreate(this) : throw new InvalidOperationException(NotInitializedError);
    public Items Items => _initialized ? Items.GetOrCreate(this) : throw new InvalidOperationException(NotInitializedError);
    public Npcs Npcs => _initialized ? Npcs.GetOrCreate(this) : throw new InvalidOperationException(NotInitializedError);

    private Harmony _harmonyInstance;
    private readonly string _instanceId = Guid.NewGuid().ToString();

    public GameData()
    {
        _harmonyInstance = new Harmony(_instanceId);
        Create();
    }

    private void Create()
    {
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

    private void Destroy()
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

    private void OnGameDataDestroyed()
    {
        _world = null;
        _initialized = false;
    }

    private void OnGameDataInitialized(World world)
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
                Utils.Logger.LogError(e);
            }
        }
    }

    public void Dispose()
    {
        Destroy();
    }
}