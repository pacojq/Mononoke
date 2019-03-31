using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mononoke.Components.Colliders;
using Mononoke.Components.Graphics;
using Mononoke.Core;
using Mononoke.Graphics;
using Mononoke.Input;
using Sandbox.Components;

namespace Sandbox.Entities
{
    public class DummyPlayer : Entity
    {
        
        private SpriteRenderer _renderer;
        private Animator _animator;
        
        public DummyPlayer()
        {
            Sprite[] sprites = new Sprite[4];
            for (int i = 1; i <= 4; i++)
                sprites[i - 1] = MnkGraphics.LoadSprite("char0" + i);
            
            Animation anim = new Animation(sprites, "walk");
            AnimationController contr = new AnimationController(anim);
            
            _renderer = new SpriteRenderer( sprites[0] );
            _animator = new Animator(_renderer, contr);
            
            Bind(_renderer);
            Bind(_animator);
            Bind(new BoxCollider(32, 32));
            Bind(new PlayerComponent());
        }

        
    }
}