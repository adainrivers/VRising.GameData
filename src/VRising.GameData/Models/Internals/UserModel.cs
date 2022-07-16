using System.Collections.Generic;
using Unity.Entities;

namespace VRising.GameData.Models.Internals
{
    public partial class UserModel
    {
        private readonly World _world;
        private readonly Entity _entity;

        internal UserModel(World world, Entity entity)
        {
            _world = world;
            _entity = entity;
        }
        public ProjectM.ProgressionMapper ProgressionMapper => _world.EntityManager.GetComponentData<ProjectM.ProgressionMapper>(_entity);
        public ProjectM.Team Team => _world.EntityManager.GetComponentData<ProjectM.Team>(_entity);
        public ProjectM.EntityInput EntityInput => _world.EntityManager.GetComponentData<ProjectM.EntityInput>(_entity);
        public ProjectM.Controller Controller => _world.EntityManager.GetComponentData<ProjectM.Controller>(_entity);
        public ProjectM.Network.User User => _world.EntityManager.GetComponentData<ProjectM.Network.User>(_entity);
        public ProjectM.Network.InputCommandDataProxy InputCommandDataProxy => _world.EntityManager.GetComponentData<ProjectM.Network.InputCommandDataProxy>(_entity);
        public ProjectM.AchievementOwner AchievementOwner => _world.EntityManager.GetComponentData<ProjectM.AchievementOwner>(_entity);
        public ProjectM.CurrentMapZone CurrentMapZone => _world.EntityManager.GetComponentData<ProjectM.CurrentMapZone>(_entity);
        public Unity.Transforms.LocalToWorld LocalToWorld => _world.EntityManager.GetComponentData<Unity.Transforms.LocalToWorld>(_entity);
        public Unity.Transforms.Rotation Rotation => _world.EntityManager.GetComponentData<Unity.Transforms.Rotation>(_entity);
        public Unity.Transforms.Translation Translation => _world.EntityManager.GetComponentData<Unity.Transforms.Translation>(_entity);
        public ProjectM.PrefabGUID PrefabGUID => _world.EntityManager.GetComponentData<ProjectM.PrefabGUID>(_entity);
        public ProjectM.ClanRole ClanRole => _world.EntityManager.GetComponentData<ProjectM.ClanRole>(_entity);
        public ProjectM.CryptSelection CryptSelection => _world.EntityManager.GetComponentData<ProjectM.CryptSelection>(_entity);
        public ProjectM.DestroyData DestroyData => _world.EntityManager.GetComponentData<ProjectM.DestroyData>(_entity);
        public ProjectM.DestroyState DestroyState => _world.EntityManager.GetComponentData<ProjectM.DestroyState>(_entity);
        public ProjectM.Emoter Emoter => _world.EntityManager.GetComponentData<ProjectM.Emoter>(_entity);
        public ProjectM.UserHealth UserHealth => _world.EntityManager.GetComponentData<ProjectM.UserHealth>(_entity);
        public ProjectM.Shapeshift Shapeshift => _world.EntityManager.GetComponentData<ProjectM.Shapeshift>(_entity);
        public ProjectM.JoinDefaultTeamOnSpawn JoinDefaultTeamOnSpawn => _world.EntityManager.GetComponentData<ProjectM.JoinDefaultTeamOnSpawn>(_entity);
        public ProjectM.Terrain.CurrentWorldRegion CurrentWorldRegion => _world.EntityManager.GetComponentData<ProjectM.Terrain.CurrentWorldRegion>(_entity);
        public ProjectM.Network.NetworkedSettings NetworkedSettings => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkedSettings>(_entity);
        public ProjectM.Network.UpToDateUserBitMask UpToDateUserBitMask => _world.EntityManager.GetComponentData<ProjectM.Network.UpToDateUserBitMask>(_entity);
        public ProjectM.Network.Latency Latency => _world.EntityManager.GetComponentData<ProjectM.Network.Latency>(_entity);
        public ProjectM.Network.ServerNetworkState ServerNetworkState => _world.EntityManager.GetComponentData<ProjectM.Network.ServerNetworkState>(_entity);
        public ProjectM.Network.FrameChanged FrameChanged => _world.EntityManager.GetComponentData<ProjectM.Network.FrameChanged>(_entity);
        public ProjectM.Network.NetworkId NetworkId => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkId>(_entity);
        public ProjectM.Network.NetworkSnapshot NetworkSnapshot => _world.EntityManager.GetComponentData<ProjectM.Network.NetworkSnapshot>(_entity);
        public ProjectM.Network.DisconnectedTimer DisconnectedTimer => _world.EntityManager.GetComponentData<ProjectM.Network.DisconnectedTimer>(_entity);
        public ProjectM.Network.UserHeartCount UserHeartCount => _world.EntityManager.GetComponentData<ProjectM.Network.UserHeartCount>(_entity);
        public ProjectM.Experience Experience => _world.EntityManager.GetComponentData<ProjectM.Experience>(_entity);
        public List<ProjectM.AllyPermission> AllyPermissions => _world.EntityManager.GetBuffer<ProjectM.AllyPermission>(_entity).ToList();
        public List<ProjectM.UnlockedWaypointElement> UnlockedWaypointElements => _world.EntityManager.GetBuffer<ProjectM.UnlockedWaypointElement>(_entity).ToList();
        public List<ProjectM.BoolModificationBuffer> BoolModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.BoolModificationBuffer>(_entity).ToList();
        public List<ProjectM.NetworkedEntityModificationBuffer> NetworkedEntityModificationBuffers => _world.EntityManager.GetBuffer<ProjectM.NetworkedEntityModificationBuffer>(_entity).ToList();
        public List<ProjectM.Network.InputCommandBufferElement> InputCommandBufferElements => _world.EntityManager.GetBuffer<ProjectM.Network.InputCommandBufferElement>(_entity).ToList();
        public List<ProjectM.RespawnPointOwnerBuffer> RespawnPointOwnerBuffers => _world.EntityManager.GetBuffer<ProjectM.RespawnPointOwnerBuffer>(_entity).ToList();
        public List<ProjectM.UserMapZoneElement> UserMapZoneElements => _world.EntityManager.GetBuffer<ProjectM.UserMapZoneElement>(_entity).ToList();
        public List<ProjectM.QueuedWorkstationCraftAction> QueuedWorkstationCraftActions => _world.EntityManager.GetBuffer<ProjectM.QueuedWorkstationCraftAction>(_entity).ToList();
        public List<ProjectM.QueuedWorkstationCraftActionItems> QueuedWorkstationCraftActionItems => _world.EntityManager.GetBuffer<ProjectM.QueuedWorkstationCraftActionItems>(_entity).ToList();
        public List<ProjectM.WorkstationRecipesBuffer> WorkstationRecipesBuffers => _world.EntityManager.GetBuffer<ProjectM.WorkstationRecipesBuffer>(_entity).ToList();
        public List<ProjectM.Network.IncomingClientMessage> IncomingClientMessages => _world.EntityManager.GetBuffer<ProjectM.Network.IncomingClientMessage>(_entity).ToList();
        public List<ProjectM.Network.NetSnapshot> NetSnapshots => _world.EntityManager.GetBuffer<ProjectM.Network.NetSnapshot>(_entity).ToList();
        public List<ProjectM.Network.SnapshotFrameChangedBuffer> SnapshotFrameChangedBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.SnapshotFrameChangedBuffer>(_entity).ToList();
        public List<ProjectM.Network.IncomingNetBuffer> IncomingNetBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.IncomingNetBuffer>(_entity).ToList();
        public List<ProjectM.Network.UserNetBuffer> UserNetBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.UserNetBuffer>(_entity).ToList();
        public List<ProjectM.Network.PriorityEntitiesToSerializeBuffer> PriorityEntitiesToSerializeBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.PriorityEntitiesToSerializeBuffer>(_entity).ToList();
        public List<ProjectM.Network.PanicEntitiesToSerializeBuffer> PanicEntitiesToSerializeBuffers => _world.EntityManager.GetBuffer<ProjectM.Network.PanicEntitiesToSerializeBuffer>(_entity).ToList();
        public List<ProjectM.Network.TileCollisionHistoryElement> TileCollisionHistoryElements => _world.EntityManager.GetBuffer<ProjectM.Network.TileCollisionHistoryElement>(_entity).ToList();
        public List<ProjectM.Network.TileGameplayHeightsHistoryElement> TileGameplayHeightsHistoryElements => _world.EntityManager.GetBuffer<ProjectM.Network.TileGameplayHeightsHistoryElement>(_entity).ToList();
        public List<ProjectM.Network.TileCollisionHistoryMetadataElement> TileCollisionHistoryMetadataElements => _world.EntityManager.GetBuffer<ProjectM.Network.TileCollisionHistoryMetadataElement>(_entity).ToList();
        public List<ProjectM.Network.TileDisabledCollisionHistoryElement> TileDisabledCollisionHistoryElements => _world.EntityManager.GetBuffer<ProjectM.Network.TileDisabledCollisionHistoryElement>(_entity).ToList();
        public List<ProjectM.Network.InputCommandStateHistoryBufferElement> InputCommandStateHistoryBufferElements => _world.EntityManager.GetBuffer<ProjectM.Network.InputCommandStateHistoryBufferElement>(_entity).ToList();
        public List<ProjectM.DefaultAction> DefaultActions => _world.EntityManager.GetBuffer<ProjectM.DefaultAction>(_entity).ToList();
        public List<ProjectM.EmoteAbility> EmoteAbilities => _world.EntityManager.GetBuffer<ProjectM.EmoteAbility>(_entity).ToList();
        public List<ProjectM.ShapeshiftAbility> ShapeshiftAbilities => _world.EntityManager.GetBuffer<ProjectM.ShapeshiftAbility>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_AllyPermission> Snapshot_AllyPermission => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_AllyPermission>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_QueuedWorkstationCraftAction> Snapshot_QueuedWorkstationCraftAction => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_QueuedWorkstationCraftAction>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_RespawnPointOwnerBuffer> Snapshot_RespawnPointOwnerBuffer => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_RespawnPointOwnerBuffer>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_UnlockedWaypointElement> Snapshot_UnlockedWaypointElement => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_UnlockedWaypointElement>(_entity).ToList();
        public List<ProjectM.Network.Snapshot_UserMapZoneElement> Snapshot_UserMapZoneElement => _world.EntityManager.GetBuffer<ProjectM.Network.Snapshot_UserMapZoneElement>(_entity).ToList();
        public bool PrefabCollectionPrefabTag => _world.EntityManager.HasComponent<ProjectM.PrefabCollectionPrefabTag>(_entity);
        public bool UsesSpawnTag => _world.EntityManager.HasComponent<ProjectM.UsesSpawnTag>(_entity);
        public bool Networked => _world.EntityManager.HasComponent<ProjectM.Network.Networked>(_entity);
        public bool AlwaysNetworked => _world.EntityManager.HasComponent<ProjectM.Network.AlwaysNetworked>(_entity);
        public bool EntitySpawnedMetadata => _world.EntityManager.HasComponent<ProjectM.Gameplay.EntitySpawnedMetadata>(_entity);
        public bool NetworkSnapshotType => _world.EntityManager.HasComponent<ProjectM.Network.NetworkSnapshotType>(_entity);
    }
}