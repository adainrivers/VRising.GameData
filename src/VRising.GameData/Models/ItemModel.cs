using Unity.Entities;
using VRising.GameData.Utils;

namespace VRising.GameData.Models;

public partial class ItemModel
{
    private readonly World _world;
    public Internals.ItemModel Internal { get; }

    public string PrefabName { get; }

    internal ItemModel(World world, Entity entity)
    {
        _world = world;
        Internal = new Internals.ItemModel(world, entity);
        PrefabName = Internal.PrefabGUID.GetPrefabName(world);
    }
}