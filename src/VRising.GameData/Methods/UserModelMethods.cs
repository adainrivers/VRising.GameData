using System;
using System.Runtime.InteropServices;
using ProjectM;
using ProjectM.CastleBuilding;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VRising.GameData.Models;
using VRising.GameData.Utils;

namespace VRising.GameData.Methods
{
    public static class UserModelMethods
    {
        public static bool IsUserEntity(this Entity entity)
        {
            return GameData.Instance.WorldData.Current.EntityManager.HasComponent<User>(entity);
        }

        public static void SendSystemMessage(this UserModel userModel, string message)
        {
            if (userModel.World.IsClientWorld())
            {
                return;
            }
            ServerChatUtils.SendSystemMessageToClient(userModel.World.EntityManager, userModel.Internals.User, message);
        }

        public static bool TryGiveItem(this UserModel userModel, PrefabGUID itemGuid, int amount, out Entity itemEntity)
        {
            unsafe
            {
                itemEntity = Entity.Null;
                var gameDataSystem = userModel.World.GetExistingSystem<GameDataSystem>();
                var bytes = stackalloc byte[Marshal.SizeOf<FakeNull>()];
                var bytePtr = new IntPtr(bytes);
                Marshal.StructureToPtr(new FakeNull { value = 0, has_value = true }, bytePtr, false);
                var boxedBytePtr = IntPtr.Subtract(bytePtr, 0x10);
                var hack = new Il2CppSystem.Nullable<int>(boxedBytePtr);
                if (InventoryUtilitiesServer.TryAddItem(userModel.World.EntityManager, gameDataSystem.ItemHashLookupMap,
                        userModel.Internals.User.LocalCharacter._Entity, itemGuid, amount, out _, out Entity e, default, hack))
                {
                    itemEntity = e;
                    return true;
                }

                return false;
            }
        }

        public static void DropItemNearby(this UserModel userModel, PrefabGUID itemGuid, int amount)
        {
            InventoryUtilitiesServer.CreateDropItem(userModel.World.EntityManager, userModel.Entity, itemGuid, amount, new Entity());
        }

        public static void TeleportTo(this UserModel userModel, float2 position)
        {
            if (userModel.Internals.User == null)
            {
                return;
            }
            var entity = userModel.World.EntityManager.CreateEntity(
                ComponentType.ReadWrite<FromCharacter>(),
                ComponentType.ReadWrite<PlayerTeleportDebugEvent>()
            );

            var fromCharacter = new FromCharacter
            {
                User = userModel.Entity,
                Character = userModel.Internals.User.LocalCharacter._Entity
            };

            userModel.World.EntityManager.SetComponentData(entity, fromCharacter);

            userModel.World.EntityManager.SetComponentData<PlayerTeleportDebugEvent>(entity, new()
            {
                Position = position,
                Target = PlayerTeleportDebugEvent.TeleportTarget.Self
            });
        }

        public static bool IsInCastle(this UserModel userModel)
        {
            if (userModel.Internals.LocalToWorld == null)
            {
                return false;
            }

            var query = userModel.World.EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<PrefabGUID>(),
                ComponentType.ReadOnly<LocalToWorld>(),
                ComponentType.ReadOnly<UserOwner>(),
                ComponentType.ReadOnly<CastleFloor>());
            var entities = query.ToEntityArray(Allocator.Temp);
            foreach (var entity in entities)
            {
                var localToWorld = userModel.World.EntityManager.GetComponentData<LocalToWorld>(entity);
                var position = localToWorld.Position;
                var userPosition = userModel.Internals.LocalToWorld.Value.Position;
                if (Math.Abs(userPosition.x - position.x) < 3 && Math.Abs(userPosition.z - position.z) < 3)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsInCombat(this UserModel userModel)
        {
            return userModel.Internals.InCombatBuff;
        }
    }
}
