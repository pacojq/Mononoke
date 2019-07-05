using System;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Graphics.Components;
using MononokeEngine.Physics;
using MononokeEngine.Physics.Colliders;

namespace Sandbox.Entities
{
    public class DummyBox: Entity
    {
        public DummyBox()
        {
            Bind( new SpriteRenderer(GraphicsManager.LoadSprite("box")) );
            
            
            BoxCollider collider = new BoxCollider(32, 32);
            Bind(collider);

            collider.OnCollisionEnter += OnCollision;
            collider.OnCollisionStay += OnCollision;

            collider.OnCollisionEnter += other => Console.WriteLine("On collision enter");
            collider.OnCollisionExit += other => Console.WriteLine("On collision exit");
        }

        private void OnCollision(Collider other)
        {
            float deltaX = other.Entity.X - other.Entity.PreviousX;
            float deltaY = other.Entity.Y - other.Entity.PreviousY;

            if (other.Entity.X < this.X && deltaX > 0)
                X += deltaX;

            else if (other.Entity.X > this.X && deltaX < 0)
                X += deltaX;
            

            if (other.Entity.Y < this.Y && deltaY > 0)
                Y += deltaY;
                    
            else if (other.Entity.Y > this.Y && deltaY < 0)
                Y += deltaY;
        }

        
    }
}