using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData
{
    public class Npcs
    {
        internal Npcs()
        {
        }

        public NpcModel GetNpcFromEntity(Entity npcEntity)
        {
            return new NpcModel(npcEntity);
        }
    }
}