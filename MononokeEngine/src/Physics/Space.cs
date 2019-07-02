using Microsoft.Xna.Framework;

namespace MononokeEngine.Physics
{
	public class Space
	{
		public Vector2 Gravity { get; set; }

		public Space(Vector2 gravity)
		{
			Gravity = gravity;
		}
		
		public Space() : this(Vector2.Zero)
		{
			
		}

	}
}