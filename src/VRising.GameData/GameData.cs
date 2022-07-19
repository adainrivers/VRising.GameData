using System;
using Unity.Entities;

namespace VRising.GameData
{
    public class GameData
    {
        public static void Initialize()
        {
            var worldData = new WorldData();
            World = worldData.Current ?? throw new Exception("World is not ready yet");
            Users = new UserData();
            Items = new ItemData();
            Systems = new GameDataSystems();
        }

        public static GameDataSystems Systems { get; private set; }
        public static World World { get; private set; }
        public static UserData Users { get; private set; }
        public static ItemData Items { get; private set; }
    }
}