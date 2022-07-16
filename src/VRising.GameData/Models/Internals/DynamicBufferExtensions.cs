using System.Collections.Generic;
using Unity.Entities;

namespace VRising.GameData.Models.Internals
{
    internal static class DynamicBufferExtensions
    {
        public static List<T> ToList<T>(this DynamicBuffer<T> bufferList) where T : new()
        {
            if (bufferList == null)
            {
                return null;
            }

            var result = new List<T>();
            foreach (var item in bufferList)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
