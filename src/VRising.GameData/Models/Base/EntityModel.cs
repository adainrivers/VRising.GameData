﻿using ProjectM;
using Unity.Entities;
using VRising.GameData.Models.Internals;

namespace VRising.GameData.Models.Base
{
    public abstract class EntityModel
    {
        protected EntityModel(Entity entity)
        {
            Entity = entity;
            Internals = new BaseEntityModel(GameData.World, entity);
        }

        public Entity Entity { get; }
        
        public PrefabGUID PrefabGUID => Internals.PrefabGUID ?? new PrefabGUID();

        public BaseEntityModel Internals { get; }
    }
}