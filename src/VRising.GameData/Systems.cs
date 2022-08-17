using ProjectM;

namespace VRising.GameData
{
    public class Systems
    {
        private Systems() { }

        private static Systems _instance;
        internal static Systems Instance => _instance ??= new Systems();

        public PrefabCollectionSystem PrefabCollectionSystem => GameData.World.GetExistingSystem<PrefabCollectionSystem>();
        public GameDataSystem GameDataSystem => GameData.World.GetExistingSystem<GameDataSystem>();
        public ManagedDataRegistry ManagedDataRegistry => GameDataSystem.ManagedDataRegistry;
    }
}