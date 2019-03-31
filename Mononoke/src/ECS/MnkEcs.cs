using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mononoke.Systems;

namespace Mononoke.ECS
{
    public static class MnkEcs
    {

        public static EcsWorld Current;
        public static IEnumerable<EcsWorld> Worlds;
        
        private static IDictionary<Type, ISystem> _systems;

        private static ISystem _renderingSystem;


        public static void Initialize()
        {
            // TODO
            _systems = new Dictionary<Type, ISystem>();
            
            // Rendering system is initialized and cannot be added to worlds
            AddSystem<RenderingSystem>();
            _renderingSystem = GetSystem<RenderingSystem>();
            
            
            Current = DefaultWorld();
            
            Console.WriteLine("MnkEcs initialized!");
        }


        private static EcsWorld DefaultWorld()
        {
            EcsWorld world = new EcsWorld();
            // TODO default stuff
            
            world.AddSystem(_renderingSystem);
            return world;
        }
        
        
        
        public static void AddWorld(EcsWorld world)
        {
            
        }
        
        public static bool AddSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            if (_systems.ContainsKey(t))
                return false;
            
            ISystem s = (ISystem) Activator.CreateInstance(t);
            _systems.Add(t, s);
            return true;
        }

        
        
        public static T GetSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            return (T) _systems[t];
        }
        
    }
}