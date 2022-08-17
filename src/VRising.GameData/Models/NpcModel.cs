using System;
using System.Collections.Generic;
using ProjectM;
using Unity.Entities;
using Unity.Mathematics;
using VRising.GameData.Models.Base;

namespace VRising.GameData.Models
{
    public partial class NpcModel: EntityModel
    {
        private readonly GameData _gameData;

        private readonly HashSet<UnitCategory> _npcCategories = new()
        {
            UnitCategory.Beast,
            UnitCategory.Demon,
            UnitCategory.Human,
            UnitCategory.Undead,
            UnitCategory.Mechanical
        };

        internal NpcModel(GameData gameData, Entity entity) : base(gameData, entity)
        {
            _gameData = gameData;
            var entityCategory = Internals.EntityCategory;
            if (entityCategory == null || entityCategory.Value.MainCategory != MainEntityCategory.Unit || !_npcCategories.Contains(entityCategory.Value.UnitCategory))
            {
                throw new Exception("Given entity is not a NPC.");
            }
        }

        public PrefabGUID PrefabGUID => Internals.PrefabGUID ?? new PrefabGUID();
        public bool IsDead => Internals.Dead.HasValue;
        public float LifeTime => Internals.LifeTime?.Duration ?? 0;
        public float3 Position => Internals.LocalToWorld?.Position ?? new float3();
        public bool HasDropTable => Internals.DropTable;
    }
}