using System;
using System.Collections.Generic;
using System.Linq;
using GT.VRising.GameData.Models;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

namespace GT.VRising.GameData;

public class Users
{
    private Users() { }

    private static Users _instance;
    internal static Users Instance => _instance ??= new Users();

    public UserModel GetUserByPlatformId(ulong platformId)
    {
        return All.FirstOrDefault(u => u.PlatformId == platformId);
    }

    public UserModel GetUserByCharacterName(string characterName)
    {
        return All.FirstOrDefault(u => u.CharacterName == characterName);
    }

    public UserModel FromEntity(Entity userEntity)
    {
        if (!GameData.World.EntityManager.HasComponent<User>(userEntity))
        {
            throw new Exception("Given entity does not have User component.");
        }

        return new UserModel(userEntity);
    }

    public IEnumerable<UserModel> Online
    {
        get { return All.Where(u => u.IsConnected); }
    }

    public IEnumerable<UserModel> All
    {
        get
        {
            {
                var userEntities = GameData.World.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>())
                    .ToEntityArray(Allocator.Temp);
                foreach (var userEntity in userEntities)
                {
                    yield return FromEntity(userEntity);
                }
            }
        }
    }
}