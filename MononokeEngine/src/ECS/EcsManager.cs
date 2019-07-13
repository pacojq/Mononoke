using System;
using System.Collections.Generic;

namespace MononokeEngine.ECS
{
    public class EcsManager
    {

        public bool IsReady { get; private set; }
        
        public EcsWorld Current { get; private set; }
        public IEnumerable<EcsWorld> Worlds { get; }
        
        private IDictionary<Type, ISystem> _systems;



        internal EcsManager()
        {
            
        }

        internal void Initialize()
        {
            // TODO
            _systems = new Dictionary<Type, ISystem>();
            
            Current = DefaultWorld();

            IsReady = true;
            Mononoke.Logger.Print("MnkEcs initialized!");

        }
        
        


        private EcsWorld DefaultWorld()
        {
            EcsWorld world = new EcsWorld();
            // TODO default stuff
            
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