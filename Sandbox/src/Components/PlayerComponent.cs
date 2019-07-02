using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MononokeEngine.Components;
using MononokeEngine.ECS;
using MononokeEngine.Input;

namespace Sandbox.Components
{
    public class PlayerComponent : Component, IUpdatableComponent
    {

        private KeyboardInput _input;

        public PlayerComponent()
        {
            _input = MononokeEngine.Mononoke.Input.Keyboard;
        }
        
        
        public void Update()
        {
            Vector2 pos = this.Entity.Position;
            
            if (_input.IsKeyHeld(Keys.Right))
                pos.X++;
            
            if (_input.IsKeyHeld(Keys.Left))
                pos.X--;
            
            if (_input.IsKeyHeld(Keys.Down))
                pos.Y++;
            
            if (_input.IsKeyHeld(Keys.Up))
                pos.Y--;

            this.Entity.Position = pos;
        }
        
    }
}