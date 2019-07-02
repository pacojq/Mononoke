using Microsoft.Xna.Framework;
using MononokeEngine.ECS;
using MononokeEngine.Physics.Colliders;

namespace MononokeEngine.Physics
{
	public abstract class Collider : Component
	{
		public virtual float Width { get; protected set; }
		public virtual float Height { get; protected set; }
		
		public bool IsTrigger { get; set; }
		
		
		
		public virtual float Top { get; protected set; }
		public virtual float Bottom { get; protected set; }
		public virtual float Left { get; protected set; }
		public virtual float Right { get; protected set; }
		
		
		public virtual float CenterX { get; protected set; }
		public virtual float CenterY { get; protected set; }
		
		
		public virtual bool Collide(Vector2 point)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool Collide(Rectangle rect)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool Collide(BoxCollider other)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool Collide(CircleCollider other)
		{
			throw new System.NotImplementedException();
		}
	}
}