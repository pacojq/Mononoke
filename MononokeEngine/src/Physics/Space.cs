using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MononokeEngine.ECS;

namespace MononokeEngine.Physics
{
	
	
	/// <summary>
	/// The Space has the responsibility of dealing with all the physics of
	/// a given <see cref="MononokeEngine.Scenes.Scene"/>.
	/// </summary>
	public class Space
	{
		public Vector2 Gravity { get; set; }



		private readonly List<Collider> _colliders;
		
		

		public Space(Vector2 gravity)
		{
			Gravity = gravity;
			_colliders = new List<Collider>();
		}
		
		public Space() : this(Vector2.Zero)
		{
			
		}
		
		
		

		internal void AddEntityToChangeQueue(Entity entity)
		{
			throw new System.NotImplementedException();
		}


		internal void Update()
		{
			// Update Pending List
			
			
			// Update Gravity
			if (Gravity != Vector2.Zero)
			{
				foreach (var col in _colliders)
				{
					
				}
			}
			
		}


		private void UpdateCollider(Collider col)
		{
			
		}
		
		
	}
}