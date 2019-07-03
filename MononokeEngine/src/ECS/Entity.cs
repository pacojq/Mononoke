using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MononokeEngine.Graphics;
using MononokeEngine.Physics;
using MononokeEngine.Scenes;

namespace MononokeEngine.ECS
{
	public class Entity : IEnumerable<Component>
    {
        

        public Scene Scene { get; internal set; }

        
        public Transform Transform { get; }
        
        
        /// <summary>
        /// Shortcut to get <see cref="Transform"/>.Position
        /// </summary>
        public Vector2 Position
        {
            get => Transform.Position;
            set => Transform.Position = value;
        }


        public IEnumerable<Component> Components => _components;
        private readonly List<Component> _components;
        
        private readonly List<Graphic> _graphics;

        


        // Left as a property just in case we want to
        // do something with the scene on depth set
        public int Depth
        {
            get => _depth;
            set => _depth = value;
        }
        
        internal int _depth = 0;

        /// <summary>
        /// Shortcut to get and set <see cref="Position"/>.X
        /// </summary>
        public float X
        {
            get => Position.X;
            set => Position += new Vector2(value, 0);
        }

        /// <summary>
        /// Shortcut to get and set <see cref="Position"/>.Y
        /// </summary>
        public float Y
        {
            get => Position.Y;
            set => Position += new Vector2(0, value);
        }
        


        
        public bool Active = true;
        public bool Visible = true;
        public bool Collidable = true;
        


        
        
        
        

        public Entity(Vector2 position)
        {
            _components = new List<Component>();
            _graphics = new List<Graphic>();
            
            
            Transform = new Transform();
            Bind(Transform);
            
            Position = position;
        }

        // Util constructor
        public Entity() : this(Vector2.Zero) { }
        
        
        
        
        
        public void BeforeUpdate()
        {
            foreach (Component c in Components)
            {
                if (c.Active)
                    c.BeforeUpdate();
            }
        }
        

        /// <summary>
        /// Update game logic.
        /// Don't perform any rendering calls here.
        /// This method will be skipped if the entity is not <see cref="Active"/>
        /// </summary>
        public void Update()
        {
            foreach (Component c in Components)
            {
                if (c.Active)
                    c.Update();
            }
        }
        
        
        
        public void AfterUpdate()
        {
            foreach (Component c in Components)
            {
                if (c.Active)
                    c.AfterUpdate();
            }
        }
        
        
        public void Render()
        {
            foreach (Graphic g in _graphics)
            {
                if (g.Visible)
                    g.Render();
            }
        }
        
        
        
        
        
        
        
        #region // - - - - - IComponent Management - - - - - //

        public void Bind(Component component)
        {
            if (component.Entity != null)
                throw new InvalidComponentStateException("Cannot add a component that is already bound to an entity.");

            Type t = component.GetType();
            
            _components.Add(component);
            if (component is Graphic)
                _graphics.Add((Graphic) component);
            
            component.Entity = this;
        }
        

        public void Unbind(Component component)
        {
            component.Entity = null;
            
            Type t = component.GetType();
            _components.Remove(component);
            if (component is Graphic)
                _graphics.Remove((Graphic) component);
        }

        public void Bind(params Component[] components)
        {
            foreach (var c in components)
                Bind(c);
            
        }

        public void Unbind(params Component[] components)
        {
            foreach (var c in components)
                Unbind(c);
        }

        public IEnumerator<Component> GetEnumerator()
        {
            return Components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion



        
        
        public virtual void OnSceneBegin(Scene scene)
        {
            // TODO
        }
        
        
        public virtual void OnSceneEnd(Scene scene)
        {
            // TODO
        }
    }
}