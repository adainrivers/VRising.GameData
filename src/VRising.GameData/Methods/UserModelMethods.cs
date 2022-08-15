using System;
using System.Runtime.InteropServices;
using GT.VRising.GameData.Models;
using GT.VRising.GameData.Utils;
using ProjectM;
using ProjectM.CastleBuilding;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace GT.VRising.GameData.Methods
{
    public static class UserModelMethods
    {
        public static void SendSystemMessage(this UserModel userModel, string message)
        {
            if (GameData.World.IsClientWorld())
            {
                return;
            }
            ServerChatUtils.SendSystemMessageToClient(GameData.World.EntityManager, userModel.Internals.User, message);
        }

        public static bool TryGiveItem(this UserModel userModel, PrefabGUID itemGuid, int amount, out Entity itemEntity)
        {
            itemEntity = Entity.Null;
            if (GameData.World.IsClientWorld())
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
                        GameData.World.EntityManager,
                        GameData.Systems.GameDataSystem.ItemHashLookupMap,
                        userModel.Internals.User.LocalCharacter._Entity,
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

        public static void DropItemNearby(this UserModel userModel, PrefabGUID itemGuid, int amount)
        {
            if (GameData.World.IsClientWorld())
            {
                return;
            }
            InventoryUtilitiesServer.CreateDropItem(GameData.World.EntityManager, userModel.Entity, itemGuid, amount, new Entity());
        }

        public static void TeleportTo(this UserModel userModel, float2 position)
        {
            if (GameData.World.IsClientWorld())
            {
                return;
            }
            var entity = GameData.World.EntityManager.CreateEntity(
                ComponentType.ReadWrite<FromCharacter>(),
                ComponentType.ReadWrite<PlayerTeleportDebugEvent>()
            );

            GameData.World.EntityManager.SetComponentData(entity, userModel.FromCharacter);

            GameData.World.EntityManager.SetComponentData<PlayerTeleportDebugEvent>(
                entity,
                new() { Position = position, Target = PlayerTeleportDebugEvent.TeleportTarget.Self });
        }

        public static bool IsInCastle(this UserModel userModel)
        {
            var query = GameData.World.EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<PrefabGUID>(),
                ComponentType.ReadOnly<LocalToWorld>(),
                ComponentType.ReadOnly<UserOwner>(),
                ComponentType.ReadOnly<CastleFloor>());

            foreach (var entityModel in query.ToEnumerable())
            {
                if (entityModel.LocalToWorld == null)
                {
                    continue;
                }
                var localToWorld = entityModel.LocalToWorld.Value;
                var position = localToWorld.Position;
                var userPosition = userModel.Position;
                if (Math.Abs(userPosition.x - position.x) < 3 && Math.Abs(userPosition.z - position.z) < 3)
                {
                    return true;
                }
            }
            return false;
        }

        private static readonly PrefabGUID InCombatBuff = new PrefabGUID(581443919);
        private static readonly PrefabGUID InCombatPvPBuff = new PrefabGUID(697095869);
        public static bool IsInCombat(this UserModel userModel)
        {
            return BuffUtility.HasBuff(GameData.World.EntityManager, userModel.Character.Entity, InCombatBuff) ||
                   BuffUtility.HasBuff(GameData.World.EntityManager, userModel.Character.Entity, InCombatPvPBuff);

        }
    }
}