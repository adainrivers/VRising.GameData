using ProjectM;
using VRising.GameData.Models;

namespace VRising.GameData
{
    public class ItemData
    {
        internal ItemData()
        {
        }

        public ItemModel GetPrefabById(PrefabGUID prefabGuid)
        {
            try
            {
                var entity = GameData.Systems.PrefabCollectionSystem.PrefabLookupMap[prefabGuid];
                if (GameData.World.EntityManager.HasComponent<ItemModel>(entity))
                {
                    return new ItemModel(entity);
                }
            }
            catch
            {
                // Prefab not found
            }

            return null;
        }
    }
}