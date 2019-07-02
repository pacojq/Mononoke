using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MononokeEngine.Components;
using MononokeEngine.Components.Exceptions;
using MononokeEngine.ECS.Components;
using MononokeEngine.Scenes;

namespace MononokeEngine.ECS
{
	public class Entity : IEnumerable<IComponent>
    {
        
        #region // - - - - - Properties - - - - - //
        

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


        public IEnumerable<IComponent> Components => _components.Values;
        

        


        // Left as a property just in case we want to
        // do something with the scene on depth set
        public int Depth
        {
            get => _depth;
            set => _depth = value;
        }

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
        
        #endregion



        

        #region // - - - - - Fields - - - - - //

        
        
        public bool Active = true;
        public bool Visible = true;
        public bool Collidable = true;
        
        internal int _depth = 0;


        private Dictionary<Type, IComponent> _components;
        
        #endregion
        
        
        

        public Entity(Vector2 position)
        {
            Position = position;
            _components = new Dictionary<Type, IComponent>();
            
            Transform = new Transform();
            Bind(Transform);
        }

        // Util constructor
        public Entity() : this(Vector2.Zero) { }
        
        
        

        /// <summary>
        /// Update game logic.
        /// Don't perform any rendering calls here.
        /// This method will be skipped if the entity is not <see cref="Active"/>
        /// </summary>
        public void Update()
        {
            foreach (IComponent c in Components)
            {
                if (c.Active)
                    c.Update();
            }
        }
        
        
        public void Render()
        {
            foreach (IComponent c in Components)
            {
                if (c.Visible)
                    c.Render();
            }
        }
        
        
        
        
        
        
        
        #region // - - - - - IComponent Management - - - - - //

        public void Bind(IComponent component)
        {
            if (component.Entity != null)
                throw new InvalidComponentStateException("Cannot add a component that is already bound to an entity.");

            Type t = component.GetType();
            
            // Check it's no repeated
            if (_components.ContainsKey(t))
                throw new InvalidComponentStateException("An entity can only have one component of a type.");
            
            _components.Add(t, component);
            component.Entity = this;
        }
        

        public void Unbind(IComponent component)
        {
            component.Entity = null;
            
            Type t = component.GetType();
            _components.Remove(t);
        }

        public void Bind(params IComponent[] components)
        {
            foreach (var c in components)
                Bind(c);
            
        }

        public void Unbind(params IComponent[] components)
        {
            foreach (var c in components)
                Unbind(c);
        }

        public IEnumerator<IComponent> GetEnumerator()
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