using Unity.Entities;
using Unity.Mathematics;

namespace VRising.GameData.Models
{
    public partial class NpcModel: EntityModel
    {
        internal NpcModel(Entity entity) : base(entity)
        {
        }

        public PrefabGUID PrefabGUID => Internals.PrefabGUID ?? new PrefabGUID();
        public bool IsDead => Internals.Dead.HasValue;
        public float LifeTime => Internals.LifeTime?.Duration ?? 0;
        public float3 Position => Internals.LocalToWorld?.Position ?? new float3();
        public bool HasDropTable => Internals.DropTable;
    }
}