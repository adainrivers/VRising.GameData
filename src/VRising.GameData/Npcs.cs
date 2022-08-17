using Unity.Entities;
using VRising.GameData.Models;

namespace VRising.GameData
{
    public class Npcs
    {
        private readonly GameData _gameData;
        private Npcs(GameData gameData)
        {
            _gameData = gameData;
        }

        private static Npcs _instance;
        internal static Npcs GetOrCreate(GameData gameData)
        {
            return _instance ??= new Npcs(gameData);
        }

        public NpcModel FromEntity(Entity npcEntity)
        {
            return new NpcModel(_gameData, npcEntity);
        }
    }
}