using ProjectM;
using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData;

public class ItemData
{
    public readonly World World;

    internal ItemData(World world)
    {
        World = world;
    }

    public ItemModel GetPrefabById(PrefabGUID prefabGuid)
    {
        try
        {
            var entity = GameData.Systems.PrefabCollectionSystem.PrefabLookupMap[prefabGuid];
            if (World.EntityManager.HasComponent<ItemModel>(entity))
            {
                return new ItemModel(World, entity);
            }
        }
        catch 
        {
            // Prefab not found
        }
        return null;
    }
}