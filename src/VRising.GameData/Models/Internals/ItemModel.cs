using System.Collections.Generic;
using Unity.Entities;

namespace VRising.GameData.Models.Internals
{
    public partial class ItemModel
    {
        private readonly World _world;
        private readonly Entity _entity;

        internal ItemModel(World world, Entity entity)
        {
            _world = world;
            _entity = entity;
        }
        public ProjectM.Equippable Equippable => _world.EntityManager.GetComponentData<ProjectM.Equippable>(_entity);
        public ProjectM.ItemData ItemData => _world.EntityManager.GetComponentData<ProjectM.ItemData>(_entity);
        public Unity.Transforms.LocalToWorld LocalToWorld => _world.EntityManager.GetComponentData<Unity.Transforms.LocalToWorld>(_entity);
        public Unity.Transforms.Rotation Rotation => _world.EntityManager.GetComponentData<Unity.Transforms.Rotation>(_entity);
        public Unity.Transforms.Translation Translation => _world.EntityManager.GetComponentData<Unity.Transforms.Translation>(_entity);
        public ProjectM.PrefabGUID PrefabGUID => _world.EntityManager.GetComponentData<ProjectM.PrefabGUID>(_entity);
        public ProjectM.DestroyData DestroyData => _world.EntityManager.GetComponentData<ProjectM.DestroyData>(_entity);
        public ProjectM.DestroyState DestroyState => _world.EntityManager.GetComponentData<ProjectM.DestroyState>(_entity);
        public ProjectM.EquippableData EquippableData => _world.EntityManager.GetComponentData<ProjectM.EquippableData>(_entity);
        public ProjectM.Network.NetworkedSettings NetworkedSettings => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkedSettings>(_entity);
        public ProjectM.Network.UpToDateUserBitMask UpToDateUserBitMask => _world.EntityManager.GetComponentData<ProjectM.Network.UpToDateUserBitMask>(_entity);
        public ProjectM.Network.FrameChanged FrameChanged => _world.EntityManager.GetComponentData<ProjectM.Network.FrameChanged>(_entity);
        public ProjectM.Network.NetworkId NetworkId => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkId>(_entity);
        public ProjectM.Network.NetworkSnapshot NetworkSnapshot => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkSnapshot>(_entity);
        public ProjectM.Shared.Salvageable Salvageable => _world.EntityManager.GetComponentData<ProjectM.Shared.Salvageable>(_entity);
        public List<ProjectM.RecipeRequirementBuffer> RecipeRequirementBuffers => _world.EntityManager.GetBuffer<ProjectM.RecipeRequirementBuffer>(_entity).ToList();
        public List<ProjectM.ModifyUnitStatBuff_DOTS> ModifyUnitStatBuff_DOTS => _world.EntityManager.GetBuffer<ProjectM.ModifyUnitStatBuff_DOTS>(_entity).ToList();
        public List<ProjectM.Network.NetSnapshot> NetSnapshots => _world.EntityManager.GetBuffer<ProjectM.Network.NetSnapshot>(_entity).ToList();
        public List<ProjectM.Network.SnapshotFrameChangedBuffer> SnapshotFrameChangedBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.SnapshotFrameChangedBuffer>(_entity).ToList();
        public bool PrefabCollectionPrefabTag => _world.EntityManager.HasComponent<ProjectM.PrefabCollectionPrefabTag>(_entity);
        public bool UsesSpawnTag => _world.EntityManager.HasComponent<ProjectM.UsesSpawnTag>(_entity);
        public bool InventoryItem => _world.EntityManager.HasComponent<ProjectM.InventoryItem>(_entity);
        public bool Networked => _world.EntityManager.HasComponent<ProjectM.Network.Networked>(_entity);
        public bool EntitySpawnedMetadata => _world.EntityManager.HasComponent<ProjectM.Gameplay.EntitySpawnedMetadata>(_entity);
        public bool NetworkSnapshotType => _world.EntityManager.HasComponent<ProjectM.Network.NetworkSnapshotType>(_entity);
    }
}