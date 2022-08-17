using System;
using System.Collections.Generic;
using System.Linq;
using ProjectM;
using Unity.Entities;
using VRising.GameData.Models;
using VRising.GameData.Utils;

namespace VRising.GameData
{
    public class Items
    {
        private readonly GameData _gameData;
        private Items(GameData gameData)
        {
            _gameData = gameData;
        }

        private static Items _instance;
        internal static Items GetOrCreate(GameData gameData)
        {
            return _instance ??= new Items(gameData);
        }

        public ItemModel GetPrefabById(PrefabGUID prefabGuid)
        {
            try
            {
                var entity = _gameData.Systems.PrefabCollectionSystem.PrefabLookupMap[prefabGuid];
                return FromEntity(entity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            return null;
        }

        public ItemModel FromEntity(Entity entity)
        {
            try
            {
                if (_gameData.World.EntityManager.HasComponent<ItemData>(entity))
                {
                    return new ItemModel(_gameData, entity);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            return null;
        }

        private List<ItemModel> _itemPrefabs;
        public List<ItemModel> Prefabs => _itemPrefabs ??= GetItemPrefabs();

        private List<ItemModel> GetItemPrefabs()
        {
            var result = new List<ItemModel>();
            foreach (var prefabEntity in _gameData.Systems.PrefabCollectionSystem.PrefabLookupMap)
            {
                var itemModel = FromEntity(prefabEntity.Value);
                if (itemModel != null)
                {
                    result.Add(itemModel);
                }
            }
            return result;
        }

        private List<ItemModel> _weapons;
        public List<ItemModel> Weapons => _weapons ??= Prefabs.Where(itemModel => itemModel.EquipmentType == EquipmentType.Weapon).ToList();

    }
}