using System;
using System.Runtime.InteropServices;
using ProjectM;
using ProjectM.CastleBuilding;
using ProjectM.Network;
using ProjectM.Shared;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VRising.GameData.Models.Base;
using VRising.GameData.Utils;

namespace VRising.GameData.Models
{
    public partial class UserModel : EntityModel
    {
        private readonly GameData _gameData;

        internal UserModel(GameData gameData, Entity entity) : base(gameData, entity)
        {
            _gameData = gameData;
            Character = new CharacterModel(gameData, Internals.User.LocalCharacter._Entity);
            Inventory = new InventoryModel(gameData, Character);
        }

        public InventoryModel Inventory { get; }
        public CharacterModel Character { get; }

        public string CharacterName => Internals.User?.CharacterName.ToString();
        public EquipmentModel Equipment => Character.Equipment;
        public FromCharacter FromCharacter => new() { User = Entity, Character = Character.Entity };
        public bool IsAdmin => Internals.User?.IsAdmin ?? false;
        public bool IsConnected => Internals.User?.IsConnected ?? false;
        // 637960784686678697 not sure what is this
        //public DateTime LastConnectedUtc => Internals.User.TimeLastConnected.ToDateTime();
        public ulong PlatformId => Internals.User?.PlatformId ?? 0;
        public float3 Position => Internals.LocalToWorld?.Position ?? new float3();
        public UserContentFlags UserContent => Internals.User?.UserContent ?? UserContentFlags.None;

        public void SendSystemMessage(string message)
        {
            if (GameData.IsClient)
            {
                return;
            }
            ServerChatUtils.SendSystemMessageToClient(_gameData.World.EntityManager, Internals.User, message);
        }

        public bool TryGiveItem(PrefabGUID itemGuid, int amount, out Entity itemEntity)
        {
            itemEntity = Entity.Null;
            if (GameData.IsClient)
            {
                return false;
            }

            unsafe
            {
                var bytes = stackalloc byte[Marshal.SizeOf<FakeNull>()];
                var bytePtr = new IntPtr(bytes);
                Marshal.StructureToPtr(new FakeNull { value = 0, has_value = true }, bytePtr, false);
                var boxedBytePtr = IntPtr.Subtract(bytePtr, 0x10);
                var hack = new Il2CppSystem.Nullable<int>(boxedBytePtr);
                if (InventoryUtilitiesServer.TryAddItem(
                        _gameData.World.EntityManager,
                        _gameData.Systems.GameDataSystem.ItemHashLookupMap,
                        Internals.User.LocalCharacter._Entity,
                        itemGuid,
                        amount,
                        out _,
                        out var e,
                        default,
                        hack))
                {
                    itemEntity = e;
                    return true;
                }

                return false;
            }
        }

         public void DropItemNearby( PrefabGUID itemGuid, int amount)
        {
            if (GameData.IsClient)
            {
                return;
            }
            InventoryUtilitiesServer.CreateDropItem(_gameData.World.EntityManager, Entity, itemGuid, amount, new Entity());
        }

        public void TeleportTo(float2 position)
        {
            if (_gameData.World.IsClientWorld())
            {
                return;
            }
            var entity = _gameData.World.EntityManager.CreateEntity(
                ComponentType.ReadWrite<FromCharacter>(),
                ComponentType.ReadWrite<PlayerTeleportDebugEvent>()
            );

            _gameData.World.EntityManager.SetComponentData(entity, FromCharacter);

            _gameData.World.EntityManager.SetComponentData<PlayerTeleportDebugEvent>(
                entity,
                new() { Position = position, Target = PlayerTeleportDebugEvent.TeleportTarget.Self });
        }

        public bool IsInCastle()
        {
            var query = _gameData.World.EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<PrefabGUID>(),
                ComponentType.ReadOnly<LocalToWorld>(),
                ComponentType.ReadOnly<UserOwner>(),
                ComponentType.ReadOnly<CastleFloor>());

            foreach (var entityModel in query.ToEnumerable(_gameData))
            {
                if (entityModel.LocalToWorld == null)
                {
                    continue;
                }
                var localToWorld = entityModel.LocalToWorld.Value;
                var position = localToWorld.Position;
                var userPosition = Position;
                if (Math.Abs(userPosition.x - position.x) < 3 && Math.Abs(userPosition.z - position.z) < 3)
                {
                    return true;
                }
            }
            return false;
        }

        private static readonly PrefabGUID InCombatBuff = new PrefabGUID(581443919);
        private static readonly PrefabGUID InCombatPvPBuff = new PrefabGUID(697095869);
        public bool IsInCombat()
        {
            return BuffUtility.HasBuff(_gameData.World.EntityManager, Character.Entity, InCombatBuff) ||
                   BuffUtility.HasBuff(_gameData.World.EntityManager, Character.Entity, InCombatPvPBuff);

        }
    }
}