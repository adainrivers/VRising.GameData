using Unity.Entities;
using VRising.GameData.Models.Internals;

namespace VRising.GameData.Models
{
    public partial class CharacterModel
    {
        private readonly GameData _gameData;
        public Entity Entity { get; }
        public BaseEntityModel Internals { get; }

        public EquipmentModel Equipment => Internals.Equipment != null ? new(_gameData, Internals.Equipment.Value) : null;

        internal CharacterModel(GameData gameData, Entity entity)
        {
            _gameData = gameData;
            Entity = entity;
            Internals = new BaseEntityModel(gameData.World, entity);
        }
    }
}