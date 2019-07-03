using MononokeEngine;
using MononokeEngine.Scenes;
using MononokeEngine.Utils;
using Sandbox.Entities;

namespace Sandbox.Scenes
{
    public class Scene1 : Scene
    {
        public Scene1()
        {
            for (int i = 0; i < 30; i++)
            {
                var p = new DummyPlayer();
                Add(p);
                p.X = Random.Range(.2f, .8f) * MononokeGame.Width;
                p.Y = Random.Range(.2f, .8f) * MononokeGame.Height;
            }
            
            for (int i = 0; i < 10; i++)
            {
                var b = new DummyBox();
                Add(b);
                b.X = Random.Next(MononokeGame.Width);
                b.Y = Random.Next(MononokeGame.Height);
            }

        }
    }
}