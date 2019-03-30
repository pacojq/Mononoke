using Mononoke.Components.Graphics;
using Mononoke.Core;
using Microsoft.Xna.Framework;

namespace Sandbox.Entities
{
    public class DummyText : Entity
    {
        public DummyText()
        {
            Add(new TextRenderer("Hi there!", new Vector2()));
        }
        
    }
}