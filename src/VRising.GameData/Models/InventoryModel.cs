using System.Collections.Generic;
using System.Linq;
using ProjectM;
using Unity.Entities;
using VRising.GameData.Models.Data;
using VRising.GameData.Models.Internals;

namespace VRising.GameData.Models;

public class InventoryModel
{
    private readonly GameData _gameData;
    private readonly CharacterModel _characterModel;

    internal InventoryModel(GameData gameData, CharacterModel characterModel)
    {
        _gameData = gameData;
        _characterModel = characterModel;
    }

    public List<InventoryItemData> Items => GetInventoryItems();

    private List<InventoryItemData> GetInventoryItems()
    {
        InventoryUtilities.TryGetInventoryEntity(_gameData.World.EntityManager, _characterModel.Entity,
            out var inventoryEntity);

        var inventory = new BaseEntityModel(_gameData.World, inventoryEntity);
        var items = inventory.InventoryBuffers;
        if (items == null)
        {
            return new List<InventoryItemData>();
        }

        return items.Select((i, index) =>
        {
            var itemPrefabEntity = i.ItemType.GuidHash == 0 ? Entity.Null : _gameData.Systems.PrefabCollectionSystem.PrefabLookupMap[i.ItemType];
            return new InventoryItemData { Item = new ItemModel(_gameData, itemPrefabEntity), Stacks = i.Stacks, Slot = index };
        }).ToList();
    }
}