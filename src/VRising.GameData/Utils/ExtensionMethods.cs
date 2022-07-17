using System;
using ProjectM;
using Unity.Entities;

namespace VRising.GameData.Utils
{
    internal static class ExtensionMethods
    {
        internal static string GetPrefabName(this PrefabGUID prefabGuid, World world)
        {
            try
            {
                return world.GetExistingSystem<PrefabCollectionSystem>().PrefabNameLookupMap[prefabGuid].ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
