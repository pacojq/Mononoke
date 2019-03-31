using Microsoft.Xna.Framework;

namespace Mononoke.Core
{
	public abstract class Component
	{
		public Entity Entity { get; internal set; }
		
		
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



		public virtual void OnBinding(Entity entity)
		{
			
		}
		
		public virtual void OnUnbinding(Entity entity)
		{
			
		}
		
		
		public virtual void Update()
		{
			
		}


		public virtual void Render()
		{
			
		}
	}
}