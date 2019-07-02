using System;
using System.Collections.Generic;
using MonoGarden.Core;

namespace MonoGarden.ECS
{
    public class EcsWorld
    {

        private IEntity[] _entities;
        private int _entityCount;
        
        private List<ISystem> _systems;


        public EcsWorld()
        {
            _systems = new List<ISystem>();
            _entities = new IEntity[1024];
            _entityCount = 0;
        }


        public void AddSystem(ISystem system)
        {
            _systems.Add(system);
            foreach (IEntity e in _entities)
                system.Accept(e);
        }
        
        public void AddEntity(IEntity entity)
        {
            foreach (ISystem s in _systems)
                s.Accept(entity);
            
            // TODO check resizing
            _entities[_entityCount] = entity;
            _entityCount++;
        }
        
        
    }
}