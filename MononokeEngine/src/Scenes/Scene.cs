using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Physics;

namespace MononokeEngine.Scenes
{
	public abstract class Scene : IEnumerable<Entity>, IEnumerable
    {


        private List<Layer> _layers;
        public Layer DefaultLayer { get; }
        
        
        
        private List<Camera> _cameras;

        public IEnumerable<Camera> Cameras => _cameras;
        
        
        public IEnumerable<Camera> ActiveCameras => Cameras.Where(c => c.Active);
        
        public Camera MainCamera { get; set; }
        
        
        
        public float TimeActive{ get; private set; }
        public float RawTimeActive { get; private set; }
        public List<Entity> Entities { get; }
        
        public Space Space { get; }
        
        public bool Paused;
        


        public Scene()
        {
            Entities = new List<Entity>();
            Space = new Space(this);
            
            _cameras = new List<Camera>();
            MainCamera = new Camera(MononokeGame.Width, MononokeGame.Height);
            _cameras.Add(MainCamera);
            
            
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
            
            // Update the space
            Space.Update();

            // ... then the entities
            foreach (Entity e in Entities)
            {
                e.Update();
            }
            
            // ...and finally the layers
            foreach (Layer layer in _layers)
            {
                layer.Update();
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
            Camera[] cameras = ActiveCameras.ToArray();
            
            // Check which entities will render
            foreach (Entity e in Entities)
            {
                foreach (var graphic in e.Graphics)
                {
                    var cam = cameras.FirstOrDefault(c => graphic.IsOnCameraBounds(c));
                    graphic.WillRenderThisFrame = cam != null;
                }
            }
            
        }

        public virtual void Render()
        {
            foreach (Entity e in Entities)
            {
                e.Render();
            }
            
#if DEBUG            
            Space.DebugDraw();
#endif
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
            entity.Scene = this;
            
            layer.Add(entity);
            entity.Layer = layer;
            
            Space.AddEntity(entity);
            foreach (var col in entity.Colliders)
                Space.AddCollider(col);
            
            Mononoke.Ecs.Current.AddEntity(entity);
        }

        public void Remove(Entity entity)
        {
            Entities.Remove(entity);
            
            foreach (var col in entity.Colliders)
                Space.RemoveCollider(col);
            
            Space.RemoveEntity(entity);
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