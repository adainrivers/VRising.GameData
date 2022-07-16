using System.Collections.Generic;
using System.Linq;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData;

public class UsersData
{
    private readonly World _world;

    internal UsersData(World world)
    {
        _world = world;
    }

    public UserModel GetUserByPlatformId(ulong platformId)
    {
        return GetAllUsers().FirstOrDefault(u => u.Internal.User.PlatformId == platformId);
    }

    public UserModel GetUserByCharacterName(string characterName)
    {
        return GetAllUsers().FirstOrDefault(u => u.Internal.User.CharacterName.ToString() == characterName);
    }

    public UserModel GetUserFromEntity(Entity userEntity)
    {
        return new UserModel(_world, userEntity);
    }

    public IEnumerable<UserModel> GetAllUsers()
    {
        var userEntities = _world.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>()).ToEntityArray(Allocator.Temp);
        foreach (var userEntity in userEntities)
        {
            yield return new UserModel(_world, userEntity);
        }
    }
}