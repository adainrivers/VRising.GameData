using ProjectM;
using Unity.Entities;

namespace VRising.GameData.Models
{
    public partial class EquipmentModel
    {
        private readonly GameData _gameData;
        public Equipment Internals { get; }

        public ItemModel Chest => Internals.ArmorChestSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.ArmorChestSlotEntity._Entity)
            : null;

        public ItemModel Leg => Internals.ArmorLegsSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.ArmorLegsSlotEntity._Entity)
            : null;

        public ItemModel Headgear => Internals.ArmorHeadgearSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.ArmorHeadgearSlotEntity._Entity)
            : null;

        public ItemModel Footgear => Internals.ArmorFootgearSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.ArmorFootgearSlotEntity._Entity)
            : null;

        public ItemModel Gloves => Internals.ArmorGlovesSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.ArmorGlovesSlotEntity._Entity)
            : null;

        public ItemModel Cloak => Internals.CloakSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.CloakSlotEntity._Entity)
            : null;

        public ItemModel Weapon => Internals.WeaponSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.WeaponSlotEntity._Entity)
            : null;

        public ItemModel Jewelry => Internals.GrimoireSlotEntity._Entity != Entity.Null
            ? new ItemModel(_gameData, Internals.GrimoireSlotEntity._Entity)
            : null;

        public float ArmorLevel => Internals.ArmorLevel.Value;
        public float WeaponLevel => Internals.WeaponLevel.Value;
        public float SpellLevel => Internals.SpellLevel.Value;

        public float Level => ArmorLevel + WeaponLevel + SpellLevel;

        public EquipmentModel(GameData gameData, Equipment equipment)
        {
            _gameData = gameData;
            Internals = equipment;
        }
    }
}