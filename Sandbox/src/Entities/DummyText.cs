using Microsoft.Xna.Framework;
using MononokeEngine.ECS;
using MononokeEngine.Graphics.Components;

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