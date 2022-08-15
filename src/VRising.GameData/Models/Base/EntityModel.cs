using GT.VRising.GameData.Models.Internals;
using Unity.Entities;

namespace GT.VRising.GameData.Models.Base
{
    public abstract class EntityModel
    {
        protected EntityModel(Entity entity)
        {
            Entity = entity;
            Internals = new BaseEntityModel(GameData.World, entity);
        }

        public Entity Entity { get; }
        public BaseEntityModel Internals { get; }
    }
}