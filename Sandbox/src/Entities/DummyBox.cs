using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Graphics.Components;
using MononokeEngine.Physics.Colliders;
using Sandbox.Components;

namespace Sandbox.Entities
{
    public class DummyBox: Entity
    {
        public DummyBox()
        {
            Bind( new SpriteRenderer(GraphicsManager.LoadSprite("box")) );
            Bind( new BoxCollider(32, 32) );
        }

        
    }
}