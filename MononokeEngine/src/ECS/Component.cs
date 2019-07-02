using Microsoft.Xna.Framework;
using MononokeEngine.Components.Exceptions;

namespace MononokeEngine.ECS
{
	public abstract class Component : IComponent
	{

		private Entity _entity;
		
		
		public bool Active { get; set; }
		public bool Visible { get; set; }
		

		public Entity Entity
		{
			get => _entity;
			set
			{
				if (_entity != null)
					throw new InvalidComponentStateException("Cannot set a new entity to a bound component.");
				_entity = value;
			}
		}

		

		public Vector2 LocalPosition = Vector2.Zero;
		
		public Vector2 Position
		{
			get
			{
				if (Entity != null)
					return Entity.Position + LocalPosition;
				return LocalPosition;
			}
		}
		
		
		
		public virtual void Update()
		{
			
		}

		public virtual void Render()
		{
			
		}

	}
}