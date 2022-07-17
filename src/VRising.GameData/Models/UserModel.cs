using ProjectM;
using Unity.Entities;

namespace VRising.GameData.Models
{
    public partial class UserModel
    {
        private readonly World _world;

        public Internals.UserModel Internal { get; }
        public CharacterModel Character { get; }

        internal UserModel(World world, Entity entity)
        {
            _world = world;
            Internal = new Internals.UserModel(world, entity);
            Character = new CharacterModel(world, Internal.User.LocalCharacter._Entity);
        }

        public void SendSystemMessage(string message)
        {
            if (_world.IsClientWorld())
            {
                return;
            }
            ServerChatUtils.SendSystemMessageToClient(_world.EntityManager, Internal.User, message);
        }
    }
}
