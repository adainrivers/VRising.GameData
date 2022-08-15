using GT.VRising.GameData.Models.Base;
using GT.VRising.GameData.Models.Internals;
using GT.VRising.GameData.Utils;
using ProjectM;
using Unity.Entities;

namespace GT.VRising.GameData.Models
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