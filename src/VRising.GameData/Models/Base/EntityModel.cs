using Unity.Entities;
using VRising.GameData.Models.Internals;

namespace VRising.GameData.Models.Base
{
    public abstract class EntityModel
    {
        protected EntityModel(GameData gameData, Entity entity)
        {
            Entity = entity;
            Internals = new BaseEntityModel(gameData.World, entity);
        }

        public Entity Entity { get; }
        public BaseEntityModel Internals { get; }
    }
}