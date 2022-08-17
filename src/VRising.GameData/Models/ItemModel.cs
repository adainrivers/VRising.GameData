using ProjectM;
using Unity.Entities;
using VRising.GameData.Models.Base;
using VRising.GameData.Models.Internals;
using VRising.GameData.Utils;

namespace VRising.GameData.Models
{
    public partial class ItemModel : EntityModel
    {
        internal ItemModel(Entity entity) : base(entity)
        {
            PrefabName = Internals.PrefabGUID?.GetPrefabName();
            ManagedGameData = new BaseManagedDataModel(GameData.World, Internals);
        }

        public BaseManagedDataModel ManagedGameData { get; }

        public string PrefabName { get; }
        public string Name => ManagedGameData?.ManagedItemData?.Name.ToString();

        public ItemCategory ItemCategory => Internals.ItemData?.ItemCategory ?? ItemCategory.NONE;
        public ItemType ItemType => Internals.ItemData?.ItemType ?? 0;
        public EquipmentType EquipmentType => Internals.EquippableData?.EquipmentType ?? EquipmentType.None;
    }
}