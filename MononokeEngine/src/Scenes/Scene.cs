using System.Collections;
using System.Collections.Generic;
using MononokeEngine.ECS;
using MononokeEngine.Physics;

namespace MononokeEngine.Scenes
{
	public abstract class Scene : IEnumerable<Entity>, IEnumerable
    {


        private List<Layer> _layers;
        public Layer DefaultLayer { get; }
        
        
        public float TimeActive{ get; private set; }
        public float RawTimeActive { get; private set; }
        public List<Entity> Entities { get; }
        
        public Space Space { get; }
        
        public bool Paused;
        


        public Scene()
        {
            Entities = new List<Entity>();
            Space = new Space();
            
            _layers = new List<Layer>();
            DefaultLayer = new Layer();
            _layers.Add(DefaultLayer);
        }
        
        
        

        public virtual void Begin()
        {
            foreach (var entity in Entities)
                entity.OnSceneBegin(this);
        }

        public virtual void End()
        {
            foreach (var entity in Entities)
                entity.OnSceneEnd(this);
        }

        public virtual void BeforeUpdate()
        {
            if (!Paused)
                TimeActive += MononokeGame.DeltaTime;
            RawTimeActive += MononokeGame.RawDeltaTime;
            
            foreach (Entity e in Entities)
            {
                e.BeforeUpdate();
            }
        }
        
        
        

        public virtual void Update()
        {
            if (Paused)
                return;
            
            Space.Update();
        
            foreach (Entity e in Entities)
            {
                e.Update();
            }
        }

        public virtual void AfterUpdate()
        {
            foreach (Entity e in Entities)
            {
                e.AfterUpdate();
            }
        }

        
        
        public virtual void BeforeRender()
        {
            
        }

        public virtual void Render()
        {
            foreach (Entity e in Entities)
            {
                e.Render();
            }
        }

        public virtual void AfterRender()
        {
            
        }

        
        
        

        #region // - - - - - Entity Management - - - - - //


        public void Add(Entity entity)
        {
            Add(entity, DefaultLayer);
        }
        
        public void Add(Entity entity, Layer layer)
        {
            Entities.Add(entity);
            layer.Add(entity);
            Mononoke.Ecs.Current.AddEntity(entity);
        }

        public void Remove(Entity entity)
        {
            Entities.Remove(entity);
        }

        public void Add(params Entity[] entities)
        {
            foreach (var e in entities)
            {
                Entities.Add(e);   
            }
        }

        public void Remove(params Entity[] entities)
        {
            foreach (var e in entities)
            {
                Entities.Remove(e);   
            }
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        

    }
}