using ProjectM;

namespace VRising.GameData
{
    public class Systems
    {
        private readonly GameData _gameData;
        private Systems(GameData gameData)
        {
            _gameData = gameData;
        }

        private static Systems _instance;
        internal static Systems GetOrCreate(GameData gameData)
        {
            return _instance ??= new Systems(gameData);
        }

        public PrefabCollectionSystem PrefabCollectionSystem => _gameData.World.GetExistingSystem<PrefabCollectionSystem>();
        public GameDataSystem GameDataSystem => _gameData.World.GetExistingSystem<GameDataSystem>();
        public ManagedDataRegistry ManagedDataRegistry => GameDataSystem.ManagedDataRegistry;
    }
}