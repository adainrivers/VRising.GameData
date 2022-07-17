using Unity.Entities;
using VRising.GameData.Models.Internals;
using VRising.GameData.Utils;

namespace VRising.GameData.Models;

public partial class ItemModel
{
    public readonly World World;
    public BaseEntityModel Internals { get; }
    public BaseManagedDataModel ManagedGameData { get; }

    public string PrefabName { get; }

    internal ItemModel(World world, Entity entity)
    {
        World = world;
        Internals = new BaseEntityModel(world, entity);
        PrefabName = Internals.PrefabGUID?.GetPrefabName(world);
        ManagedGameData = new BaseManagedDataModel(world, Internals);
    }
}