using Microsoft.Xna.Framework;
using MononokeEngine.Components.Graphics;
using MononokeEngine.ECS;

namespace Sandbox.Entities
{
    public class DummyText : Entity
    {
        public DummyText()
        {
            Bind(new TextRenderer("Hi there!", new Vector2()));
        }
        
    }
}