using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mononoke.Components.Colliders;
using Mononoke.Components.Graphics;
using Mononoke.Core;
using Mononoke.Graphics;
using Mononoke.Input;

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
            
            Add(_renderer);
            Add(_animator);
            Add(new BoxCollider(32, 32));
        }

        public override void Update()
        {
            base.Update();

            if (MnkInput.Keyboard.IsKeyHeld(Keys.Right))
                _renderer.LocalPosition.X++;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Left))
                _renderer.LocalPosition.X--;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Down))
                _renderer.LocalPosition.Y++;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Up))
                _renderer.LocalPosition.Y--;
        }
    }
}