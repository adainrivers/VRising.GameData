using Unity.Entities;
using VRising.GameData.Models.Internals;

namespace VRising.GameData.Models;

public partial class CharacterModel
{
    private readonly World _world;
    public BaseEntityModel Internals { get; }

    public EquipmentModel Equipment => Internals.Equipment != null ? new(_world, Internals.Equipment.Value) : null;

    internal CharacterModel(World world, Entity entity)
    {
        _world = world;
        Internals = new BaseEntityModel(world, entity);

    }
}