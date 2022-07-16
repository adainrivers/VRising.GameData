using Unity.Entities;

namespace VRising.GameData.Models
{
    public partial class UserModel
    {
        public Internals.UserModel Internal { get; }
        public CharacterModel Character { get; }

        internal UserModel(World world, Entity entity)
        {
            Internal = new Internals.UserModel(world, entity);
            Character = new CharacterModel(world, entity);
        }
    }
}
