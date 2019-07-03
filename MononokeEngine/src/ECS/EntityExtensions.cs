using System;
using System.Linq;

namespace MononokeEngine.ECS
{
    public static class EntityExtensions
    {
        
        public static T GetComponent<T>(this Entity e) where T : Component
        {
            foreach (var c in e.Components)
                if (CheckComponent(c, typeof(T)))
                    return (T) c;
            return default(T);
        }
        
        
        /// <summary>
        /// Determines whether a type is the same as another type.
        /// It will also check inheritance and interface implementation.
        /// </summary>
        private static bool CheckComponent(Component comp, Type target)
        {
            Type actual = comp.GetType();
            
            if (actual == target)
                return true;
            if (actual.IsSubclassOf(target))
                return true;
            if (actual.IsEquivalentTo(target))
                return true;
            if (actual.GetInterfaces().Contains(target))
                return true;
            
            return false;
        }
        
        
    }
}