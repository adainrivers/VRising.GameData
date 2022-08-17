using System;
using System.Collections.Generic;
using System.Linq;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData;

public class Users
{
    private readonly GameData _gameData;
    private Users(GameData gameData)
    {
        _gameData = gameData;
    }

    private static Users _instance;
    internal static Users GetOrCreate(GameData gameData)
    {
        return _instance ??= new Users(gameData);
    }

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
        if (!_gameData.World.EntityManager.HasComponent<User>(userEntity))
        {
            throw new Exception("Given entity does not have User component.");
        }

        return new UserModel(_gameData, userEntity);
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
                var userEntities = _gameData.World.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>())
                    .ToEntityArray(Allocator.Temp);
                foreach (var userEntity in userEntities)
                {
                    yield return FromEntity(userEntity);
                }
            }
        }
    }
}