using System;
using System.Linq;

namespace Mononoke.ECS
{
    public static class EcsUtil
    {

        /// <summary>
        /// Determines whether a type is the same as another type.
        /// It will also check inheritance and interface implementation.
        /// </summary>
        public static bool CheckComponent(IComponent comp, Type target)
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