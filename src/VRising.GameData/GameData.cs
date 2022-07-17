using Unity.Entities;

namespace VRising.GameData
{
    public class GameData
    {
        public GameData()
        {
            WorldData = new WorldData();
            UserData = new UserData(WorldData.Current);

        }
        public WorldData WorldData { get; }
        public UserData UserData { get; }
    }
}
