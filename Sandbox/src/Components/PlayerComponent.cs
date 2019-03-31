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

            if (MnkInput.Keyboard.IsKeyHeld(Keys.Right))
                Entity.Position.X++;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Left))
                Entity.Position.X--;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Down))
                Entity.Position.Y++;
            
            if (MnkInput.Keyboard.IsKeyHeld(Keys.Up))
                Entity.Position.Y--;
        }
        
    }
}