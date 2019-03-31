using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Mononoke.Components.Exceptions;
using Mononoke.Physics;

namespace Mononoke.Core
{
	public class Entity : IEnumerable<Component>
    {
        
        #region // - - - - - Properties - - - - - //
        

        public Scene Scene { get; private set; }
        public List<Component> Components { get; private set; }
        
        
        // Left as a property just in case we want to
        // do something with the scene on depth set
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>
        /// Shortcut to get and set <see cref="Position"/>.X
        /// </summary>
        public float X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        /// <summary>
        /// Shortcut to get and set <see cref="Position"/>.Y
        /// </summary>
        public float Y
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }
        
        #endregion



        

        #region // - - - - - Fields - - - - - //

        
        
        public bool Active = true;
        public bool Visible = true;
        public bool Collidable = true;
        
        public Vector2 Position;
        
        internal int _depth = 0;
        
        
        #endregion
        
        
        

        public Entity(Vector2 position)
        {
            Position = position;
            Components = new List<Component>();
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
            foreach (Component c in Components)
            {
                c.Update();   
            }
        }

        /// <summary>
        /// This method will be skipped if the entity is not <see cref="Visible"/>
        /// </summary>
        public virtual void Render()
        {
            foreach (Component c in Components)
            {
                c.Render();   
            }
        }

        
        
        
        
        
        
        
        #region // - - - - - Component Management - - - - - //

        public void Bind(Component component)
        {
            if (component.Entity != null)
                throw new InvalidComponentStateException("Cannot add a component that is already linked to an entity.");
            
            Components.Add(component);
            component.OnBinding(this);
            component.Entity = this;
        }
        

        public void Unbind(Component component)
        {
            Components.Remove(component);
            component.Entity = null;
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

        public T Get<T>() where T : Component
        {
            foreach (var c in Components)
                if (c is T)
                    return c as T;
            return null;
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