using Unity.Entities;

namespace VRising.GameData.Utils
{
    internal static class Extensions
    {
        public static WorldType GetType(this World world)
        {
            return world == null ? WorldType.Unknown :
                world.Name == "Server" ? WorldType.Server :
                world.Name.StartsWith("Client") ? WorldType.Client : WorldType.Unknown;
        }
    }
}
