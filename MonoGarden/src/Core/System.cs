using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonoGarden.ECS;

namespace MonoGarden.Core
{
    public abstract class System<T> : ISystem where T : struct
    {

        private T[] _entities;
        private int _entityCount;

        
        private EcsFilter<T> _ecsFilter;


        internal System()
        {
            _entities = new T[256];
            _entityCount = 0;
            _ecsFilter = new EcsFilter<T>();
        }



        

        public bool Accept(IEntity entity)
        {
            if (entity == null)
                return false;
            
            if (!_ecsFilter.Accept(entity))
                return false;
            
            // TODO check resizing
            _entities[_entityCount] = _ecsFilter.Filter(entity);
            _entityCount++;
            return true;
        }



        public virtual void BeforeUpdate() { }
        
        public void Update()
        {
            BeforeUpdate();
            for (int i = 0; i < _entityCount; i++)
                UpdateEntity(_entities[i]);
        }
        

        protected abstract void UpdateEntity(T entity);

    }
}