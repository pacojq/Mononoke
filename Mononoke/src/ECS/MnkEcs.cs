using System;
using System.Collections.Generic;
using Mononoke.Systems;

namespace Mononoke.ECS
{
    public class MnkEcs
    {

        public static EcsWorld Current;
        public static IEnumerable<EcsWorld> Worlds;
        
        private readonly IDictionary<Type, ISystem> _systems;
        private readonly ISystem _renderingSystem;


        private static MnkEcs _instance;

        public static void Initialize()
        {
            if (_instance == null)
                _instance = new MnkEcs();
        }

        private MnkEcs()
        {
            _instance = this;
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
        
        
        
        public static void AddWorld(EcsWorld world)
        {
            // TODO
        }
        
        public static bool AddSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            if (_instance._systems.ContainsKey(t))
                return false;
            
            ISystem s = (ISystem) Activator.CreateInstance(t);
            _instance._systems.Add(t, s);
            return true;
        }

        
        
        public static T GetSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            return (T) _instance._systems[t];
        }
        
    }
}