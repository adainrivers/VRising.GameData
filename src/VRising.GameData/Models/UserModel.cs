using Unity.Entities;
using VRising.GameData.Models.Internals;

namespace VRising.GameData.Models
{
    public partial class UserModel
    {
        public readonly World World;
        public readonly Entity Entity;

        public readonly BaseEntityModel Internals;
        public readonly CharacterModel Character;

        internal UserModel(World world, Entity entity)
        {
            World = world;
            Entity = entity;
            Internals = new BaseEntityModel(world, entity);
            Character = new CharacterModel(world, Internals.User.LocalCharacter._Entity);
        }
    }
}
