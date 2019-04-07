using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Mononoke.ECS;
using Mononoke.Systems;

namespace Mononoke.Core
{
	public abstract class Scene : IEnumerable<Entity>, IEnumerable
    {

        private RenderingSystem _renderingSystem;
        
        
        public float TimeActive{ get; private set; }
        public float RawTimeActive { get; private set; }
        public List<Entity> Entities { get; private set; }
        
        
        
        public bool Paused;
        


        public Scene()
        {
            Entities = new List<Entity>();
            _renderingSystem = MnkEcs.GetSystem<RenderingSystem>();
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
                TimeActive += MnkGame.DeltaTime;
            RawTimeActive += MnkGame.RawDeltaTime;
        }
        
        
        

        public virtual void Update()
        {
            if (Paused)
                return;
        
            foreach (Entity e in Entities)
            {
                e.Update();
            }
        }

        public virtual void AfterUpdate()
        {
            
        }

        public virtual void BeforeRender()
        {
            
        }

        public virtual void Render()
        {
            _renderingSystem.Update();
        }

        public virtual void AfterRender()
        {
            
        }

        
        
        

        #region // - - - - - Entity Management - - - - - //


        public void Add(Entity entity)
        {
            Entities.Add(entity);
            MnkEcs.Current.AddEntity(entity);
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