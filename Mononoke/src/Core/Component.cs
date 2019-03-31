using Microsoft.Xna.Framework;
using Mononoke.Components.Exceptions;
using Mononoke.ECS;

namespace Mononoke.Core
{
	public abstract class Component : IComponent
	{

		private IEntity _entity;
		public IEntity Entity
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



		public virtual void OnBinding(IEntity entity)
		{
			
		}
		
		public virtual void OnUnbinding(IEntity entity)
		{
			
		}
		
		
		public virtual void Update()
		{
			
		}


	}
}