using System;
using System.Collections.Generic;
using MononokeEngine.Systems;

namespace MononokeEngine.ECS
{
    public class EcsManager
    {

        public EcsWorld Current { get; private set; }
        public IEnumerable<EcsWorld> Worlds { get; }
        
        private IDictionary<Type, ISystem> _systems;
        private ISystem _renderingSystem;



        internal EcsManager()
        {
            
        }

        internal void Initialize()
        {
            // TODO
            _systems = new Dictionary<Type, ISystem>();
            
            // Rendering system is initialized and cannot be added to worlds
            AddSystem<RenderingSystem>();
            _renderingSystem = GetSystem<RenderingSystem>();
            
            
            Current = DefaultWorld();
            
            Console.WriteLine("MnkEcs initialized!");
        }
        
        


        private EcsWorld DefaultWorld()
        {
            EcsWorld world = new EcsWorld();
            // TODO default stuff
            
            world.AddSystem(_renderingSystem);
            return world;
        }
        
        
        
        public void AddWorld(EcsWorld world)
        {
            // TODO
        }
        
        public bool AddSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            if (_systems.ContainsKey(t))
                return false;
            
            ISystem s = (ISystem) Activator.CreateInstance(t);
            _systems.Add(t, s);
            return true;
        }

        
        
        public T GetSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            return (T) _systems[t];
        }
        
    }
}