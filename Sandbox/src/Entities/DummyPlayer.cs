using System;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Graphics.Components;
using MononokeEngine.Physics.Colliders;
using Sandbox.Components;

namespace Sandbox.Entities
{
    public class DummyPlayer : Entity
    {
        
        private SpriteRenderer _renderer;
        private AnimationComponent _animationComponent;
        
        public DummyPlayer()
        {
            Sprite[] sprites = new Sprite[4];
            for (int i = 1; i <= 4; i++)
                sprites[i - 1] = GraphicsManager.LoadSprite("char0" + i);
            
            Animation anim = new Animation(sprites, "walk");
            AnimationController contr = new AnimationController(anim);
            
            _renderer = new SpriteRenderer( sprites[0] );
            _animationComponent = new AnimationComponent(_renderer, contr);
            
            Bind(_renderer);
            Bind(_animationComponent);

            var col = new BoxCollider(32, 32);
            col.OnCollisionEnter += other =>
            {
                Console.WriteLine("Collision enter!");
            }; 
            
            Bind(new BoxCollider(32, 32));
            Bind(new PlayerComponent());
            Bind(new RectDrawer(32, 32));
        }

        
    }
}