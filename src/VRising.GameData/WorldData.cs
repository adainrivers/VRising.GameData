using Unity.Entities;
using UnityEngine;

namespace VRising.GameData
{
    internal class WorldData
    {
        internal bool IsServer => Application.productName == "VRisingServer";
        internal bool IsClient => Application.productName == "VRising";
    }
}