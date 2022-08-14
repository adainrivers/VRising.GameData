using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData
{
    public class Npcs
    {
        private Npcs() { }

        private static Npcs _instance;
        internal static Npcs Instance => _instance ??= new Npcs();

        public NpcModel FromEntity(Entity npcEntity)
        {
            return new NpcModel(npcEntity);
        }
    }
}