using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MononokeEngine.Components.Graphics;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
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
            Bind(new BoxCollider(32, 32));
            Bind(new PlayerComponent());
        }

        
    }
}