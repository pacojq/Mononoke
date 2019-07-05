using System;
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



		private readonly List<Entity> _entities;
		private readonly List<Collider> _colliders;
		
		

		public Space(Vector2 gravity)
		{
			Gravity = gravity;
			_entities = new List<Entity>();
			_colliders = new List<Collider>();
		}
		
		public Space() : this(Vector2.Zero) { }
		
		
		


		internal void Update()
		{
			// Update Gravity
			if (Gravity != Vector2.Zero)
			{
				foreach (var entity in _entities)
					entity.Transform.Position += Gravity;
			}
			
			
			// Check collisions
			foreach (var col in _colliders)
				UpdateCollider(col);
		}


		private void UpdateCollider(Collider col)
		{
			if (!col.Entity.Active)
				return;
			
			if (!col.Entity.Collidable)
				return;
			
			foreach (var other in _colliders)
			{
				if (other == col)
					continue;
				
				if (other.Entity == col.Entity)
					continue;

				if (!other.Entity.Active)
					continue;
				
				if (!other.Entity.Collidable)
					continue;
				
				if (col.PlaceMeeting(other))
					col.Collide(other);
			}
		}

		
		
		
		internal void AddEntity(Entity entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			_entities.Add(entity);
		}
		
		internal void RemoveEntity(Entity entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			_entities.Remove(entity);
		}
		

		internal void AddCollider(Collider collider)
		{
			if (collider == null)
				throw new ArgumentNullException(nameof(collider));
			_colliders.Add(collider);
		}
		
		internal void RemoveCollider(Collider collider)
		{
			if (collider == null)
				throw new ArgumentNullException(nameof(collider));
			_colliders.Remove(collider);
		}
	}
}