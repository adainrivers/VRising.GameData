using GT.VRising.GameData.Models.Internals;
using Unity.Entities;

namespace GT.VRising.GameData.Models
{
    public partial class CharacterModel
    {
        public Entity Entity { get; }
        public BaseEntityModel Internals { get; }

        public EquipmentModel Equipment => Internals.Equipment != null ? new(Internals.Equipment.Value) : null;

        internal CharacterModel(Entity entity)
        {
            Entity = entity;
            Internals = new BaseEntityModel(GameData.World, entity);
        }
    }
}