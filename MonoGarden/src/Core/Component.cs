using Microsoft.Xna.Framework;
using MonoGarden.Components.Exceptions;
using MonoGarden.ECS;

namespace MonoGarden.Core
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
			// To be implemented by each individual component
		}
		
		public virtual void OnUnbinding(IEntity entity)
		{
			// To be implemented by each individual component
		}
		


	}
}