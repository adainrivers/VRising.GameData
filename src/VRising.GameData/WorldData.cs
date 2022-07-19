using Unity.Entities;
using UnityEngine;

namespace VRising.GameData
{
    // Credit: https://github.com/molenzwiebel/Wetstone/blob/master/API/VWorld.cs
    internal class WorldData
    {
        private World _clientWorld;
        private World _serverWorld;

        internal World Current => IsServer ? Server : Client;

        internal World Server
        {
            get
            {
                if (_serverWorld != null) return _serverWorld;

                _serverWorld = GetWorld("Server");
                return _serverWorld;
            }
        }

        internal World Client
        {
            get
            {
                if (_clientWorld != null) return _clientWorld;

                _clientWorld = GetWorld("Client_0");
                return _clientWorld;
            }
        }

        internal World Default => World.DefaultGameObjectInjectionWorld;

        internal bool IsServer => Application.productName == "VRisingServer";

        internal bool IsClient => Application.productName == "VRising";

        private World GetWorld(string name)
        {
            foreach (var world in World.s_AllWorlds)
            {
                if (world.Name == name)
                {
                    _serverWorld = world;
                    return world;
                }
            }

            return null;
        }
    }
}