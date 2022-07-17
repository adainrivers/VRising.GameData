using System;
using System.Collections.Generic;
using System.Linq;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData;

public class UserData
{
    public readonly World World;

    internal UserData(World world)
    {
        World = world;
    }

    public UserModel GetUserByPlatformId(ulong platformId)
    {
        return GetAllUsers().FirstOrDefault(u => u.Internals.User.PlatformId == platformId);
    }

    public UserModel GetUserByCharacterName(string characterName)
    {
        return GetAllUsers().FirstOrDefault(u => u.Internals.User.CharacterName.ToString() == characterName);
    }

    public UserModel GetUserFromEntity(Entity userEntity)
    {
        if (!World.EntityManager.HasComponent<User>(userEntity))
        {
            return null;
        }
        return new UserModel(World, userEntity);
    }

    public IEnumerable<UserModel> GetOnlineUsers()
    {
        return GetAllUsers().Where(u => u.Internals.User.IsConnected);
    }

    public IEnumerable<UserModel> GetAllUsers()
    {
        var userEntities = World.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>()).ToEntityArray(Allocator.Temp);
        foreach (var userEntity in userEntities)
        {
            yield return new UserModel(World, userEntity);
        }
    }
}