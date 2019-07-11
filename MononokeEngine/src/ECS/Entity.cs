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
        
        public Layer Layer { get; internal set; }

        
        public Transform Transform { get; }
        
        
        /// <summary>
        /// Shortcut to get <see cref="Transform"/>.Position
        /// </summary>
        public virtual Vector2 Position
        {
            get => Transform.Position;
            set => Transform.Position = value;
        }
        
        
        /// <summary>
        /// The position of the Entity in the previous frame.
        /// </summary>
        public Vector2 PreviousPosition { get; private set; }


        
        public IEnumerable<Component> Components => _components;
        private readonly List<Component> _components;
        
        
        /// <summary>
        /// An enumeration of the Graphic components bind to the entity.
        /// </summary>
        public IEnumerable<Graphic> Graphics => _graphics;
        private readonly List<Graphic> _graphics;
        
        
        /// <summary>
        /// An enumeration of the Collider components bind to the entity.
        /// </summary>
        public IEnumerable<Collider> Colliders => _colliders;
        private readonly List<Collider> _colliders;

        


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
        public virtual float X
        {
            get => Position.X;
            set => Position = new Vector2(value, Position.Y);
        }
        
        /// <summary>
        /// Shortcut to get and set <see cref="PreviousPosition"/>.X
        /// </summary>
        public float PreviousX => PreviousPosition.X;
        
        

        /// <summary>
        /// Shortcut to get and set <see cref="Position"/>.Y
        /// </summary>
        public virtual float Y
        {
            get => Position.Y;
            set => Position = new Vector2(Position.X, value);
        }

        /// <summary>
        /// Shortcut to get and set <see cref="PreviousPosition"/>.Y
        /// </summary>
        public float PreviousY => PreviousPosition.Y;
        


        
        public bool Active { get; set; }
        public bool Visible { get; set; }
        public bool Collidable { get; set; }
    
        


        
        
        
        

        public Entity(Vector2 position)
        {
            _components = new List<Component>();
            _graphics = new List<Graphic>();
            _colliders = new List<Collider>();
            
            
            Transform = new Transform();
            Bind(Transform);
            
            Position = position;
            PreviousPosition = position;

            Active = true;
            Visible = true;
            Collidable = true;
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

            PreviousPosition = Position;
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

            if (component is GraphicComponent)
            {
                GraphicComponent graphic = (GraphicComponent) component;
                Layer.AddGraphic(graphic);
                _graphics.Add(graphic);
            }

            if (component is Collider)
            {
                _colliders.Add((Collider) component);
                if (Scene != null)
                    Scene.Space.AddCollider((Collider) component);
            }

            component.Entity = this;
        }
        

        public void Unbind(Component component)
        {
            component.Entity = null;
            
            Type t = component.GetType();
            _components.Remove(component);

            if (component is GraphicComponent)
            {
                GraphicComponent graphic = (GraphicComponent) component;
                Layer.RemoveGraphic(graphic);
                _graphics.Remove(graphic);
            }

            if (component is Collider)
            {
                _colliders.Remove((Collider) component);
                if (Scene != null)
                    Scene.Space.RemoveCollider((Collider) component);
            }
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