using Mononoke.Core;
using Sandbox.Entities;

namespace Sandbox.Scenes
{
    public class Scene1 : Scene
    {
        public Scene1()
        {
            // Add(new DummyText());
            Add(new DummyPlayer());
        }
    }
}