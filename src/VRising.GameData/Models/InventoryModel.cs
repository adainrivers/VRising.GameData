using System.Collections.Generic;
using System.Linq;
using GT.VRising.GameData.Models.Data;
using GT.VRising.GameData.Models.Internals;
using ProjectM;
using Unity.Entities;

namespace GT.VRising.GameData.Models;

public class InventoryModel
{
    private readonly CharacterModel _characterModel;

    internal InventoryModel(CharacterModel characterModel)
    {
        _characterModel = characterModel;
    }

    public List<InventoryItemData> Items => GetInventoryItems();

    private List<InventoryItemData> GetInventoryItems()
    {
        InventoryUtilities.TryGetInventoryEntity(GameData.World.EntityManager, _characterModel.Entity,
            out var inventoryEntity);

        var inventory = new BaseEntityModel(GameData.World, inventoryEntity);
        var items = inventory.InventoryBuffers;
        if (items == null)
        {
            return new List<InventoryItemData>();
        }

        return items.Select((i, index) =>
        {
            var itemPrefabEntity = i.ItemType.GuidHash == 0 ? Entity.Null : GameData.Systems.PrefabCollectionSystem.PrefabLookupMap[i.ItemType];
            return new InventoryItemData { Item = new ItemModel(itemPrefabEntity), Stacks = i.Stacks, Slot = index };
        }).ToList();
    }
}