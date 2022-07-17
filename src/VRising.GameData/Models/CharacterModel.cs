using Unity.Entities;

namespace VRising.GameData.Models;

public partial class CharacterModel
{
    private readonly World _world;
    public Internals.CharacterModel Internal { get; }
    
    public EquipmentModel Equipment => new(_world, Internal.Equipment);

    internal CharacterModel(World world, Entity entity)
    {
        _world = world;
        Internal = new Internals.CharacterModel(world, entity);

    }
}