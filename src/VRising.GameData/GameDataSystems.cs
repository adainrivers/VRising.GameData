namespace VRising.GameData
{
    public class GameDataSystems
    {
        internal GameDataSystems()
        {
        }

        public PrefabCollectionSystem PrefabCollectionSystem => GameData.World.GetExistingSystem<PrefabCollectionSystem>();
        public GameDataSystem GameDataSystem => GameData.World.GetExistingSystem<GameDataSystem>();
        public ManagedDataRegistry ManagedDataRegistry => GameDataSystem.ManagedDataRegistry;
    }
}