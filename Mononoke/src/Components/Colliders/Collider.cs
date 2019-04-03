using Microsoft.Xna.Framework;
using Mononoke.Core;
using Mononoke.Physics;

namespace Mononoke.Components.Colliders
{
	public abstract class Collider : Component, ICollider
	{
		public float Width { get; protected set; }
		public float Height { get; protected set; }
		
		public bool IsTrigger { get; protected set; }
		
		public float Top { get; protected set; }
		public float Bottom { get; protected set; }
		public float Left { get; protected set; }
		public float Right { get; protected set; }
		
		public float CenterX { get; protected set; }
		public float CenterY { get; protected set; }
		
		
		public bool Collide(Vector2 point)
		{
			throw new System.NotImplementedException();
		}

		public bool Collide(Rectangle rect)
		{
			throw new System.NotImplementedException();
		}

		public bool Collide(BoxCollider other)
		{
			throw new System.NotImplementedException();
		}

		public bool Collide(CircleCollider other)
		{
			throw new System.NotImplementedException();
		}
	}
}