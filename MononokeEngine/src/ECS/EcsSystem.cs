namespace MononokeEngine.ECS
{
    public abstract class EcsSystem<T> : ISystem where T : Component
    {

        private T[] _entities;
        private int _entityCount;


        public EcsSystem()
        {
            _entities = new T[256];
            _entityCount = 0;
        }



        public bool Accept(Entity entity)
        {
            if (entity == null)
                return false;

            T comp = entity.GetComponent<T>();
            if (comp == null)
                return false;
                
            // TODO check resizing
            _entities[_entityCount] = comp;
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