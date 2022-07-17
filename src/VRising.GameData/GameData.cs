using System;
using ProjectM;
using Unity.Entities;

namespace VRising.GameData
{
    public class GameData
    {
        private static GameData _instance;
        public static GameData Instance => _instance ??= CreateInstance();
        public static GameDataSystems Systems => new(Instance.WorldData.Current);

        private static GameData CreateInstance()
        {
            var worldData = new WorldData();
            if (worldData.Current == null)
            {
                throw new Exception("World is not ready yet");
            }
            return new GameData();
        }

        private GameData()
        {
            WorldData = new WorldData();
            UserData = new UserData(WorldData.Current);
            ItemData = new ItemData(WorldData.Current);
        }

        public WorldData WorldData { get; }
        public UserData UserData { get; }
        public ItemData ItemData { get; }
    }

    public class GameDataSystems
    {
        private readonly World _world;

        internal GameDataSystems(World world)
        {
            _world = world;
        }

        public PrefabCollectionSystem PrefabCollectionSystem => _world.GetExistingSystem<PrefabCollectionSystem>();
        public ManagedDataRegistry ManagedDataRegistry => _world.GetExistingSystem<GameDataSystem>().ManagedDataRegistry;
    }
}
