using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MononokeEngine.ECS;
using MononokeEngine.Physics.Colliders;
using MononokeEngine.Scenes;

namespace MononokeEngine.Physics
{

	public delegate void CollisionEvent(Collider other);
	
	
	public abstract class Collider : Component
	{
		public virtual float Width { get; protected set; }
		public virtual float Height { get; protected set; }
		
		public bool IsTrigger { get; set; }
		
		public Vector2 Center { get; set; }


		public virtual float Top { get; }
		public virtual float Bottom { get; }
		public virtual float Left { get; }
		public virtual float Right { get; }
		
		
		public virtual float CenterX { get; protected set; }
		public virtual float CenterY { get; protected set; }


		
		
		
		// =============== Collision events =============== //

		private readonly List<Collider> _onEnter;
		private readonly List<Collider> _onStay;
		private readonly List<Collider> _onExit;
		private readonly List<Collider> _toRemove;
		
		public CollisionEvent OnCollisionEnter { get; set; }
		public CollisionEvent OnCollisionStay { get; set; }
		public CollisionEvent OnCollisionExit { get; set; }
		
		
		
		

		public Collider(Vector2 center)
		{
			Center = center;
			
			_onEnter = new List<Collider>();
			_onStay = new List<Collider>();
			_onExit = new List<Collider>();
			_toRemove = new List<Collider>();
			
			OnCollisionEnter = other => { };
			OnCollisionStay = other => { };
			OnCollisionExit = other => { };
		}

		public Collider() : this(Vector2.Zero) { }



		public virtual bool PlaceMeeting(Collider other)
		{
			return CollisionChecks.PlaceMeeting(this, other);
		}
		
		

		
		// Executed just after the physics update
		public override void BeforeUpdate()
		{
			// Remove all to "remove"
			_toRemove.Clear();
			
			// Take all "exit" collisions to "remove"
			foreach (var col in _onExit)
				_toRemove.Add(col);
			_onExit.Clear();

			// Take all "stay" collisions to "exit"
			foreach (var col in _onStay)
				_onExit.Add(col);
			_onStay.Clear();
			
			// Take all "enter" collisions to "stay"
			foreach (var col in _onEnter)
				_onStay.Add(col);
			_onEnter.Clear();
		}
		
		
		
		/// <summary>
		/// Called from <see cref="Space"/>, to communicate we're colliding
		/// with another Collider.
		/// </summary>
		/// <param name="other"></param>
		internal void Collide(Collider other)
		{
			// We already have it here
			if (_onStay.Contains(other))
			{
				// Do nothing
			}
			// It was on exit!!!! Take back to on stay
			else if (_onExit.Contains(other))
			{
				_onExit.Remove(other);
				_onStay.Add(other);
			}
			// We were going to discard it... Let's take it back
			else if (_toRemove.Contains(other))
			{
				_toRemove.Remove(other);
				_onEnter.Add(other);
			}
			else _onEnter.Add(other);
		}
		
		
		
		public override void Update()
		{
			// Execute all callbacks
			
			foreach (var col in _onEnter)
				OnCollisionEnter(col);
			
			foreach (var col in _onStay)
				OnCollisionStay(col);
			
			foreach (var col in _onExit)
				OnCollisionExit(col);
		}


		
		
		
		// ================== DEBUG UTILITIES ================== //
		
		internal abstract void DebugDraw();

		internal virtual bool IsOnCameraBounds(Camera camera)
		{
			return true;
		}


	}
}