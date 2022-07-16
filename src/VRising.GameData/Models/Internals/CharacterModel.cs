using System.Collections.Generic;
using Unity.Entities;

namespace VRising.GameData.Models.Internals
{
    public partial class CharacterModel
    {
        private readonly World _world;
        private readonly Entity _entity;

        internal CharacterModel(World world, Entity entity)
        {
            _world = world;
            _entity = entity;
        }
        public ProjectM.AbilityBar_Server AbilityBar_Server => _world.EntityManager.GetComponentData<ProjectM.AbilityBar_Server>(_entity);
        public ProjectM.AbilityBar_Shared AbilityBar_Shared => _world.EntityManager.GetComponentData<ProjectM.AbilityBar_Shared>(_entity);
        public ProjectM.Blood Blood => _world.EntityManager.GetComponentData<ProjectM.Blood>(_entity);
        public ProjectM.Equipment Equipment => _world.EntityManager.GetComponentData<ProjectM.Equipment>(_entity);
        public ProjectM.BuffResistances BuffResistances => _world.EntityManager.GetComponentData<ProjectM.BuffResistances>(_entity);
        public ProjectM.InventoryOwner InventoryOwner => _world.EntityManager.GetComponentData<ProjectM.InventoryOwner>(_entity);
        public ProjectM.PlayerCharacter PlayerCharacter => _world.EntityManager.GetComponentData<ProjectM.PlayerCharacter>(_entity);
        public ProjectM.Team Team => _world.EntityManager.GetComponentData<ProjectM.Team>(_entity);
        public ProjectM.ReturnToNetherWaypoint ReturnToNetherWaypoint => _world.EntityManager.GetComponentData<ProjectM.ReturnToNetherWaypoint>(_entity);
        public ProjectM.BloodMoonBuffState BloodMoonBuffState => _world.EntityManager.GetComponentData<ProjectM.BloodMoonBuffState>(_entity);
        public ProjectM.Mounter Mounter => _world.EntityManager.GetComponentData<ProjectM.Mounter>(_entity);
        public ProjectM.Resident Resident => _world.EntityManager.GetComponentData<ProjectM.Resident>(_entity);
        public ProjectM.TakeDamageInSun TakeDamageInSun => _world.EntityManager.GetComponentData<ProjectM.TakeDamageInSun>(_entity);
        public ProjectM.TakeDamageInSunDebuffState TakeDamageInSunDebuffState => _world.EntityManager.GetComponentData<ProjectM.TakeDamageInSunDebuffState>(_entity);
        public ProjectM.EntityInput EntityInput => _world.EntityManager.GetComponentData<ProjectM.EntityInput>(_entity);
        public ProjectM.ControlledBy ControlledBy => _world.EntityManager.GetComponentData<ProjectM.ControlledBy>(_entity);
        public ProjectM.Interactor Interactor => _world.EntityManager.GetComponentData<ProjectM.Interactor>(_entity);
        public ProjectM.Residency Residency => _world.EntityManager.GetComponentData<ProjectM.Residency>(_entity);
        public ProjectM.RespawnCharacter RespawnCharacter => _world.EntityManager.GetComponentData<ProjectM.RespawnCharacter>(_entity);
        public ProjectM.CastleBuilding.CurrentTileModelEditing CurrentTileModelEditing => _world.EntityManager.GetComponentData<ProjectM.CastleBuilding.CurrentTileModelEditing>(_entity);
        public ProjectM.Gameplay.Scripting.Script_CreateGameplayEventOnDamageDealtToEntityCategory_DataServer Script_CreateGameplayEventOnDamageDealtToEntityCategory_DataServer => _world.EntityManager.GetComponentData<ProjectM.Gameplay.Scripting.Script_CreateGameplayEventOnDamageDealtToEntityCategory_DataServer>(_entity);
        public ProjectM.Gameplay.Scripting.Script_ApplyBuffUnderHealthThreshhold_DataServer Script_ApplyBuffUnderHealthThreshhold_DataServer => _world.EntityManager.GetComponentData<ProjectM.Gameplay.Scripting.Script_ApplyBuffUnderHealthThreshhold_DataServer>(_entity);
        public Unity.Transforms.LocalToWorld LocalToWorld => _world.EntityManager.GetComponentData<Unity.Transforms.LocalToWorld>(_entity);
        public Unity.Transforms.Rotation Rotation => _world.EntityManager.GetComponentData<Unity.Transforms.Rotation>(_entity);
        public Unity.Transforms.Translation Translation => _world.EntityManager.GetComponentData<Unity.Transforms.Translation>(_entity);
        public Unity.Physics.PhysicsCollider PhysicsCollider => _world.EntityManager.GetComponentData<Unity.Physics.PhysicsCollider>(_entity);
        public Unity.Physics.Systems.StaticPhysicsWorldBodyIndex StaticPhysicsWorldBodyIndex => _world.EntityManager.GetComponentData<Unity.Physics.Systems.StaticPhysicsWorldBodyIndex>(_entity);
        public ProjectM.PrefabGUID PrefabGUID => _world.EntityManager.GetComponentData<ProjectM.PrefabGUID>(_entity);
        public ProjectM.AbilityBarInitializationState AbilityBarInitializationState => _world.EntityManager.GetComponentData<ProjectM.AbilityBarInitializationState>(_entity);
        public ProjectM.Aggroable Aggroable => _world.EntityManager.GetComponentData<ProjectM.Aggroable>(_entity);
        public ProjectM.FactionReference FactionReference => _world.EntityManager.GetComponentData<ProjectM.FactionReference>(_entity);
        public ProjectM.VBloodConsumeSource VBloodConsumeSource => _world.EntityManager.GetComponentData<ProjectM.VBloodConsumeSource>(_entity);
        public ProjectM.CustomizationFeatures CustomizationFeatures => _world.EntityManager.GetComponentData<ProjectM.CustomizationFeatures>(_entity);
        public ProjectM.DestroyData DestroyData => _world.EntityManager.GetComponentData<ProjectM.DestroyData>(_entity);
        public ProjectM.DestroyState DestroyState => _world.EntityManager.GetComponentData<ProjectM.DestroyState>(_entity);
        public ProjectM.Energy Energy => _world.EntityManager.GetComponentData<ProjectM.Energy>(_entity);
        public ProjectM.Buffable Buffable => _world.EntityManager.GetComponentData<ProjectM.Buffable>(_entity);
        public ProjectM.GlobalCooldown GlobalCooldown => _world.EntityManager.GetComponentData<ProjectM.GlobalCooldown>(_entity);
        public ProjectM.Hideable Hideable => _world.EntityManager.GetComponentData<ProjectM.Hideable>(_entity);
        public ProjectM.Stealthable Stealthable => _world.EntityManager.GetComponentData<ProjectM.Stealthable>(_entity);
        public ProjectM.Health Health => _world.EntityManager.GetComponentData<ProjectM.Health>(_entity);
        public ProjectM.HealthConstants HealthConstants => _world.EntityManager.GetComponentData<ProjectM.HealthConstants>(_entity);
        public ProjectM.Immortal Immortal => _world.EntityManager.GetComponentData<ProjectM.Immortal>(_entity);
        public ProjectM.LastTranslation LastTranslation => _world.EntityManager.GetComponentData<ProjectM.LastTranslation>(_entity);
        public ProjectM.Movement Movement => _world.EntityManager.GetComponentData<ProjectM.Movement>(_entity);
        public ProjectM.PavementBonus PavementBonus => _world.EntityManager.GetComponentData<ProjectM.PavementBonus>(_entity);
        public ProjectM.CollisionRadius CollisionRadius => _world.EntityManager.GetComponentData<ProjectM.CollisionRadius>(_entity);
        public ProjectM.MapCollision MapCollision => _world.EntityManager.GetComponentData<ProjectM.MapCollision>(_entity);
        public ProjectM.Velocity Velocity => _world.EntityManager.GetComponentData<ProjectM.Velocity>(_entity);
        public ProjectM.TargetDirection TargetDirection => _world.EntityManager.GetComponentData<ProjectM.TargetDirection>(_entity);
        public ProjectM.TileBounds TileBounds => _world.EntityManager.GetComponentData<ProjectM.TileBounds>(_entity);
        public ProjectM.TilePosition TilePosition => _world.EntityManager.GetComponentData<ProjectM.TilePosition>(_entity);
        public ProjectM.TileModelSpatialData TileModelSpatialData => _world.EntityManager.GetComponentData<ProjectM.TileModelSpatialData>(_entity);
        public ProjectM.TileData TileData => _world.EntityManager.GetComponentData<ProjectM.TileData>(_entity);
        public ProjectM.VBloodAbilityOwnerData VBloodAbilityOwnerData => _world.EntityManager.GetComponentData<ProjectM.VBloodAbilityOwnerData>(_entity);
        public ProjectM.BloodMoonBuff BloodMoonBuff => _world.EntityManager.GetComponentData<ProjectM.BloodMoonBuff>(_entity);
        public ProjectM.CanFly CanFly => _world.EntityManager.GetComponentData<ProjectM.CanFly>(_entity);
        public ProjectM.EntityCategory EntityCategory => _world.EntityManager.GetComponentData<ProjectM.EntityCategory>(_entity);
        public ProjectM.Immaterial Immaterial => _world.EntityManager.GetComponentData<ProjectM.Immaterial>(_entity);
        public ProjectM.Invulnerable Invulnerable => _world.EntityManager.GetComponentData<ProjectM.Invulnerable>(_entity);
        public ProjectM.KeepMountBuffOnAbilityImpair KeepMountBuffOnAbilityImpair => _world.EntityManager.GetComponentData<ProjectM.KeepMountBuffOnAbilityImpair>(_entity);
        public ProjectM.LifeLeech LifeLeech => _world.EntityManager.GetComponentData<ProjectM.LifeLeech>(_entity);
        public ProjectM.Vision Vision => _world.EntityManager.GetComponentData<ProjectM.Vision>(_entity);
        public ProjectM.EntityAimData EntityAimData => _world.EntityManager.GetComponentData<ProjectM.EntityAimData>(_entity);
        public ProjectM.MoveVelocity MoveVelocity => _world.EntityManager.GetComponentData<ProjectM.MoveVelocity>(_entity);
        public ProjectM.ResistanceData ResistanceData => _world.EntityManager.GetComponentData<ProjectM.ResistanceData>(_entity);
        public ProjectM.UnitStats UnitStats => _world.EntityManager.GetComponentData<ProjectM.UnitStats>(_entity);
        public ProjectM.Sequencer.ImpactMaterial ImpactMaterial => _world.EntityManager.GetComponentData<ProjectM.Sequencer.ImpactMaterial>(_entity);
        public ProjectM.Network.NetworkedTimeout NetworkedTimeout => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkedTimeout>(_entity);
        public ProjectM.Network.NetworkedSettings NetworkedSettings => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkedSettings>(_entity);
        public ProjectM.Network.Latency Latency => _world.EntityManager.GetComponentData<ProjectM.Network.Latency>(_entity);
        public ProjectM.Network.FrameChanged FrameChanged => _world.EntityManager.GetComponentData<ProjectM.Network.FrameChanged>(_entity);
        public ProjectM.Network.NetworkId NetworkId => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkId>(_entity);
        public ProjectM.Network.NetworkSnapshot NetworkSnapshot => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkSnapshot>(_entity);
        public ProjectM.Hybrid.HybridModelSeed HybridModelSeed => _world.EntityManager.GetComponentData<ProjectM.Hybrid.HybridModelSeed>(_entity);
        public ProjectM.Hybrid.DeathRagdollForce DeathRagdollForce => _world.EntityManager.GetComponentData<ProjectM.Hybrid.DeathRagdollForce>(_entity);
        public ProjectM.Tiles.TileModel TileModel => _world.EntityManager.GetComponentData<ProjectM.Tiles.TileModel>(_entity);
        public ProjectM.CombatMusicListener_Shared CombatMusicListener_Shared => _world.EntityManager.GetComponentData<ProjectM.CombatMusicListener_Shared>(_entity);
        public ProjectM.PlacementDestroyData PlacementDestroyData => _world.EntityManager.GetComponentData<ProjectM.PlacementDestroyData>(_entity);
        public ProjectM.Interactable Interactable => _world.EntityManager.GetComponentData<ProjectM.Interactable>(_entity);
        public ProjectM.InteractedUpon InteractedUpon => _world.EntityManager.GetComponentData<ProjectM.InteractedUpon>(_entity);
        public ProjectM.TravelToTargetRadius TravelToTargetRadius => _world.EntityManager.GetComponentData<ProjectM.TravelToTargetRadius>(_entity);
        public ProjectM.DynamicCollision DynamicCollision => _world.EntityManager.GetComponentData<ProjectM.DynamicCollision>(_entity);
        public ProjectM.FallToHeight FallToHeight => _world.EntityManager.GetComponentData<ProjectM.FallToHeight>(_entity);
        public ProjectM.Height Height => _world.EntityManager.GetComponentData<ProjectM.Height>(_entity);
        public ProjectM.JumpFromCliffs JumpFromCliffs => _world.EntityManager.GetComponentData<ProjectM.JumpFromCliffs>(_entity);
        public ProjectM.CharacterVoiceActivity CharacterVoiceActivity => _world.EntityManager.GetComponentData<ProjectM.CharacterVoiceActivity>(_entity);
        public ProjectM.IsSpellControlled IsSpellControlled => _world.EntityManager.GetComponentData<ProjectM.IsSpellControlled>(_entity);
        public ProjectM.Tiles.RestrictPlacementArea RestrictPlacementArea => _world.EntityManager.GetComponentData<ProjectM.Tiles.RestrictPlacementArea>(_entity);
        public ProjectM.Network.NetworkInterpolated_Shared NetworkInterpolated_Shared => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkInterpolated_Shared>(_entity);
        public List<Unity.Entities.LinkedEntityGroup> LinkedEntityGroups => _world.EntityManager.GetBuffer<Unity.Entities.LinkedEntityGroup>(_entity).ToList();
        public List<ProjectM.FollowerBuffer> FollowerBuffers => _world.EntityManager.GetBuffer<ProjectM.FollowerBuffer>(_entity).ToList();
        public List<ProjectM.AbilityGroupSlotBuffer> AbilityGroupSlotBuffers => _world.EntityManager.GetBuffer<ProjectM.AbilityGroupSlotBuffer>(_entity).ToList();
        public List<ProjectM.VBloodAbilityBuffEntry> VBloodAbilityBuffEntries => _world.EntityManager.GetBuffer<ProjectM.VBloodAbilityBuffEntry>(_entity).ToList();
        public List<ProjectM.EntitiesInView_Server> EntitiesInView_Server => _world.EntityManager.GetBuffer<ProjectM.EntitiesInView_Server>(_entity).ToList();
        public List<ProjectM.BoolModificationBuffer> BoolModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.BoolModificationBuffer>(_entity).ToList();
        public List<ProjectM.EntityModificationBuffer> EntityModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.EntityModificationBuffer>(_entity).ToList();
        public List<ProjectM.FloatModificationBuffer> FloatModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.FloatModificationBuffer>(_entity).ToList();
        public List<ProjectM.Float3ModificationBuffer> Float3ModificationBuffer => _world.EntityManager.GetBuffer<ProjectM.Float3ModificationBuffer>(_entity).ToList();
        public List<ProjectM.IntModificationBuffer> IntModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.IntModificationBuffer>(_entity).ToList();
        public List<ProjectM.NetworkedEntityModificationBuffer> NetworkedEntityModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.NetworkedEntityModificationBuffer>(_entity).ToList();
        public List<ProjectM.PrefabGUIDModificationBuffer> PrefabGUIDModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.PrefabGUIDModificationBuffer>(_entity).ToList();
        public List<ProjectM.CombatMusicListener_SourceElement> CombatMusicListener_SourceElement => _world.EntityManager.GetBuffer<ProjectM.CombatMusicListener_SourceElement>(_entity).ToList();
        public List<ProjectM.EquipmentSetBuff> EquipmentSetBuffs => _world.EntityManager.GetBuffer<ProjectM.EquipmentSetBuff>(_entity).ToList();
        public List<ProjectM.BloodQualityBuff> BloodQualityBuffs => _world.EntityManager.GetBuffer<ProjectM.BloodQualityBuff>(_entity).ToList();
        public List<ProjectM.AttachMapIconsToEntity> AttachMapIconsToEntities => _world.EntityManager.GetBuffer<ProjectM.AttachMapIconsToEntity>(_entity).ToList();
        public List<ProjectM.MapIconPerUserData> MapIconPerUserDatas => _world.EntityManager.GetBuffer<ProjectM.MapIconPerUserData>(_entity).ToList();
        public List<ProjectM.SharedGameplayConditionReference> SharedGameplayConditionReferences => _world.EntityManager.GetBuffer<ProjectM.SharedGameplayConditionReference>(_entity).ToList();
        public List<ProjectM.GameplayConditionGroup> GameplayConditionGroups => _world.EntityManager.GetBuffer<ProjectM.GameplayConditionGroup>(_entity).ToList();
        public List<ProjectM.GameplayCondition> GameplayConditions => _world.EntityManager.GetBuffer<ProjectM.GameplayCondition>(_entity).ToList();
        public List<ProjectM.Network.NetSnapshot> NetSnapshots => _world.EntityManager.GetBuffer<ProjectM.Network.NetSnapshot>(_entity).ToList();
        public List<ProjectM.Network.SnapshotFrameChangedBuffer> SnapshotFrameChangedBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.SnapshotFrameChangedBuffer>(_entity).ToList();
        public List<ProjectM.BuffByItemCategoryCount> BuffByItemCategoryCounts => _world.EntityManager.GetBuffer<ProjectM.BuffByItemCategoryCount>(_entity).ToList();
        public List<ProjectM.BuffOnConnectionStatusElement> BuffOnConnectionStatusElements => _world.EntityManager.GetBuffer<ProjectM.BuffOnConnectionStatusElement>(_entity).ToList();
        public List<ProjectM.InteractAbilityBuffer> InteractAbilityBuffers => _world.EntityManager.GetBuffer<ProjectM.InteractAbilityBuffer>(_entity).ToList();
        public List<ProjectM.CreateGameplayEventsOnAbilityTrigger> CreateGameplayEventsOnAbilityTriggers => _world.EntityManager.GetBuffer<ProjectM.CreateGameplayEventsOnAbilityTrigger>(_entity).ToList();
        public List<ProjectM.CreateGameplayEventsOnAbilityTriggerAbilityPrefabTargets> CreateGameplayEventsOnAbilityTriggerAbilityPrefabTargets => _world.EntityManager.GetBuffer<ProjectM.CreateGameplayEventsOnAbilityTriggerAbilityPrefabTargets>(_entity).ToList();
        public List<ProjectM.CreateGameplayEventOnDamageTaken> CreateGameplayEventOnDamageTakens => _world.EntityManager.GetBuffer<ProjectM.CreateGameplayEventOnDamageTaken>(_entity).ToList();
        public List<ProjectM.CreateGameplayEventsOnSpawn> CreateGameplayEventsOnSpawns => _world.EntityManager.GetBuffer<ProjectM.CreateGameplayEventsOnSpawn>(_entity).ToList();
        public List<ProjectM.ApplyBuffOnGameplayEvent> ApplyBuffOnGameplayEvents => _world.EntityManager.GetBuffer<ProjectM.ApplyBuffOnGameplayEvent>(_entity).ToList();
        public List<ProjectM.ApplyBuffOnGameplayEventEntry> ApplyBuffOnGameplayEventEntries => _world.EntityManager.GetBuffer<ProjectM.ApplyBuffOnGameplayEventEntry>(_entity).ToList();
        public List<ProjectM.GameplayEventIdMapping> GameplayEventIdMappings => _world.EntityManager.GetBuffer<ProjectM.GameplayEventIdMapping>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_AbilityGroupSlotBuffer> Snapshot_AbilityGroupSlotBuffer => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_AbilityGroupSlotBuffer>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_FollowerBuffer> Snapshot_FollowerBuffer => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_FollowerBuffer>(_entity).ToList();
        public bool PrefabCollectionPrefabTag => _world.EntityManager.HasComponent<ProjectM.PrefabCollectionPrefabTag>(_entity);
        public bool UsesSpawnTag => _world.EntityManager.HasComponent<ProjectM.UsesSpawnTag>(_entity);
        public bool MapIcon_Server => _world.EntityManager.HasComponent<ProjectM.MapIcon_Server>(_entity);
        public bool TilePlacementTag => _world.EntityManager.HasComponent<ProjectM.TilePlacementTag>(_entity);
        public bool TileRestrictionAreaTag => _world.EntityManager.HasComponent<ProjectM.TileRestrictionAreaTag>(_entity);
        public bool RadialDamageTarget => _world.EntityManager.HasComponent<ProjectM.RadialDamageTarget>(_entity);
        public bool ScriptSpawn => _world.EntityManager.HasComponent<ProjectM.Scripting.ScriptSpawn>(_entity);
        public bool Networked => _world.EntityManager.HasComponent<ProjectM.Network.Networked>(_entity);
        public bool MoveStopTrigger => _world.EntityManager.HasComponent<ProjectM.MoveStopTrigger>(_entity);
        public bool HideOutsideVision => _world.EntityManager.HasComponent<ProjectM.HideOutsideVision>(_entity);
        public bool VampireTag => _world.EntityManager.HasComponent<ProjectM.VampireTag>(_entity);
        public bool CanBuildTileModels => _world.EntityManager.HasComponent<ProjectM.CastleBuilding.CanBuildTileModels>(_entity);
        public bool EntitySpawnedMetadata => _world.EntityManager.HasComponent<ProjectM.Gameplay.EntitySpawnedMetadata>(_entity);
        public bool BlobAssetOwner => _world.EntityManager.HasComponent<Unity.Entities.BlobAssetOwner>(_entity);
        public bool TileModelRegistrationState => _world.EntityManager.HasComponent<ProjectM.TileModelRegistrationState>(_entity);
        public bool NetworkSnapshotType => _world.EntityManager.HasComponent<ProjectM.Network.NetworkSnapshotType>(_entity);
        public bool TileModelLayer => _world.EntityManager.HasComponent<ProjectM.Tiles.TileModelLayer>(_entity);
    }
}