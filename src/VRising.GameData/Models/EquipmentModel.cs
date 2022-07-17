using ProjectM;
using Unity.Entities;

namespace VRising.GameData.Models;

public partial class EquipmentModel
{
    private readonly World _world;
    public Equipment Internal { get; }

    public ItemModel Chest => Internal.ArmorChestSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.ArmorChestSlotEntity._Entity) : null;
    public ItemModel Leg => Internal.ArmorLegsSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.ArmorLegsSlotEntity._Entity) : null;
    public ItemModel Headgear => Internal.ArmorHeadgearSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.ArmorHeadgearSlotEntity._Entity) : null;
    public ItemModel Footgear => Internal.ArmorFootgearSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.ArmorFootgearSlotEntity._Entity) : null;
    public ItemModel Gloves => Internal.ArmorGlovesSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.ArmorGlovesSlotEntity._Entity) : null;
    public ItemModel Cloak => Internal.CloakSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.CloakSlotEntity._Entity) : null;
    public ItemModel Weapon => Internal.WeaponSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.WeaponSlotEntity._Entity) : null;
    public ItemModel Jewelry => Internal.GrimoireSlotEntity._Entity != Entity.Null ? new ItemModel(_world, Internal.GrimoireSlotEntity._Entity) : null;

    public float ArmorLevel => Internal.ArmorLevel.Value;
    public float WeaponLevel => Internal.WeaponLevel.Value;
    public float SpellLevel => Internal.SpellLevel.Value;

    public EquipmentModel(World world, Equipment equipment)
    {
        _world = world;
        Internal = equipment;
    }
}