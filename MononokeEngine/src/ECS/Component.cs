using Microsoft.Xna.Framework;

namespace MononokeEngine.ECS
{
	public abstract class Component
	{

		private Entity _entity;
		
		
		public bool Active { get; set; }
		
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



		public Component()
		{
			Active = true;
		}
		
		
		
		
		public virtual void BeforeUpdate()
		{
			
		}
		
		public virtual void Update()
		{
			
		}
		
		public virtual void AfterUpdate()
		{
			
		}


	}
}