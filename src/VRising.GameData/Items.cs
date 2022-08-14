using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData
{
    public class Items
    {
        private Items() { }

        private static Items _instance;
        internal static Items Instance => _instance ??= new Items();

        public ItemModel GetPrefabById(PrefabGUID prefabGuid)
        {
            try
            {
                var entity = GameData.Systems.PrefabCollectionSystem.PrefabLookupMap[prefabGuid];
                return FromEntity(entity);
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }

            return null;
        }

        public ItemModel FromEntity(Entity entity)
        {
            try
            {
                if (GameData.World.EntityManager.HasComponent<ItemData>(entity))
                {
                    return new ItemModel(entity);
                }
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }

            return null;
        }

        private List<ItemModel> _itemPrefabs;
        public List<ItemModel> Prefabs => _itemPrefabs ??= GetItemPrefabs();

        private List<ItemModel> GetItemPrefabs()
        {
            var result = new List<ItemModel>();
            foreach (var prefabEntity in GameData.Systems.PrefabCollectionSystem.PrefabLookupMap)
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