using Unity.Entities;

namespace VRising.GameData
{
    public class GameData
    {
        public GameData()
        {
            WorldData = new WorldData();
            var world = WorldData.IsServer? WorldData.Server: WorldData.Client;
            UsersData = new UsersData(world);

        }
        public WorldData WorldData { get; }
        public UsersData UsersData { get; }
    }
}
