using Unity.Entities;

namespace VRising.GameData.Models;

public partial class CharacterModel
{
    public Internals.CharacterModel Internal { get; }

    internal CharacterModel(World world, Entity entity)
    {
        Internal = new Internals.CharacterModel(world, entity);
    }
}