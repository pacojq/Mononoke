using System;
using System.Collections.Generic;

namespace MononokeEngine.ECS
{
    public class EcsWorld
    {

        private Entity[] _entities;
        private int _entityCount;
        
        private IDictionary<Type, ISystem> _systems;
        
        


        public EcsWorld()
        {
            _systems = new Dictionary<Type, ISystem>();
            _entities = new Entity[1024];
            _entityCount = 0;
        }


        public void AddSystem(ISystem system)
        {
            Mononoke.Logger.Print(system.GetType().Name);
            Type t = system.GetType().BaseType.GetGenericArguments()[0];
            
            if (_systems.ContainsKey(t))
                throw new Exception("There can only exist one system of a single type.");

            _systems.Add(t, system);
            foreach (Entity e in _entities)
                system.Accept(e);
        }
        
        public void AddEntity(Entity entity)
        {
            
            foreach (ISystem s in _systems.Values)
                s.Accept(entity);
            
            // TODO check resizing
            _entities[_entityCount] = entity;
            _entityCount++;
        }
        
        public void UpdateEntity(Entity entity)
        {
            // TODO
            // when we add / remove a component
        }
        
        
    }
}