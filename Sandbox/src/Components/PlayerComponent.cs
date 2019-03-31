using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Mononoke.Core;
using Mononoke.Input;

namespace Sandbox.Components
{
    public class PlayerComponent : Component
    {
        
        public override void Update()
        {
            base.Update();

            Vector2 pos = this.Entity.Position;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Right))
                pos.X++;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Left))
                pos.X--;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Down))
                pos.Y++;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Up))
                pos.Y--;

            this.Entity.Position = pos;
        }
        
    }
}