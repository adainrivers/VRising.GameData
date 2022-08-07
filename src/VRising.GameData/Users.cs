using System;
using System.Collections.Generic;
using System.Linq;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData
{
    public class Users
    {
        internal Users()
        {
        }

        public UserModel GetUserByPlatformId(ulong platformId)
        {
            return GetAllUsers().FirstOrDefault(u => u.PlatformId == platformId);
        }

        public UserModel GetUserByCharacterName(string characterName)
        {
            return GetAllUsers().FirstOrDefault(u => u.CharacterName == characterName);
        }

        public UserModel GetUserFromEntity(Entity userEntity)
        {
            if (!GameData.World.EntityManager.HasComponent<User>(userEntity))
            {
                throw new Exception("Given entity does not have User component.");
            }

            return new UserModel(userEntity);
        }

        public IEnumerable<UserModel> GetOnlineUsers()
        {
            return GetAllUsers().Where(u => u.IsConnected);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var userEntities = GameData.World.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>())
                .ToEntityArray(Allocator.Temp);
            foreach (var userEntity in userEntities)
            {
                yield return GetUserFromEntity(userEntity);
            }
        }
    }
}