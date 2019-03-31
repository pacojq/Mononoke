using System;
using System.Linq;
using System.Reflection;
using Mononoke.Core;

namespace Mononoke.ECS
{
    public class EcsFilter<T> where T : struct
    {
        private Type[] _types;
        
        public EcsFilter()
        {
            FieldInfo[] fields = typeof(T).GetFields();
            _types = fields.Select(f => f.FieldType).ToArray();
        }


        
        
        internal bool Accept(IEntity entity)
        {
            Type[] types = entity.Components.Select(c => c.GetType()).ToArray();
            return Accept(types);
        }


        /// <summary>
        /// From a given entity, returns a struct with the components belonging
        /// to out filter struct.
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T Filter(IEntity entity)
        {
            Type structType = typeof(T);

            // Create the struct
            object result = Activator.CreateInstance(structType);
            FieldInfo[] fields = structType.GetFields();

            // Get the Entity matching components
            IComponent[] filtered = FilterComponents(entity);
            
            // Give values to the struct fields
            foreach (FieldInfo field in fields)
            {
                Type fType = field.FieldType;
                var comp = filtered.First(c => EcsUtil.Filter(c.GetType(), fType));
                field.SetValue(result, comp);
            }

            return (T) result;
        }
        
        
        
        private IComponent[] FilterComponents(IEntity entity)
        {
            IComponent[] result = new IComponent[_types.Length];
            int count = 0;

            IComponent[] components = entity.Components.ToArray();
            Type[] cTypes = entity.Components.Select(c => c.GetType()).ToArray();
            foreach (Type t in _types)
            {
                IComponent temp = null;
                for(int i = 0; i < cTypes.Length && temp == null; i++)
                {
                    if (EcsUtil.Filter(cTypes[i], t))
                        temp = components[i];
                }
                if (temp != null)
                {
                    result[count] = temp;
                    count++;
                }
            }
            return result;
        }
        
        
        
        
        
        
        
        public bool Accept(params Type[] otherTypes)
        {
            foreach (Type t in _types)
            {
                bool contains = false;
                for(int i = 0; i < otherTypes.Length && !contains; i++)
                    contains = EcsUtil.Filter(otherTypes[i], t);
                
                if (!contains)
                    return false;
            }
            return true;
        }
    }
}