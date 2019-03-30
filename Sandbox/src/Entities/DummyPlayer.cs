using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Mononoke.Components.Colliders;
using Mononoke.Components.Graphics;
using Mononoke.Core;
using Mononoke.Input;

namespace Sandbox.Entities
{
    public class DummyPlayer : Entity
    {
        
        private TextRenderer _renderer;
        
        public DummyPlayer()
        {
            _renderer = new TextRenderer("@", Vector2.Zero);
            Add(_renderer);
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