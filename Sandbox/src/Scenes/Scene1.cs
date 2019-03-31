using System;
using Microsoft.Xna.Framework;
using Mononoke;
using Mononoke.Core;
using Sandbox.Entities;

namespace Sandbox.Scenes
{
    public class Scene1 : Scene
    {
        public Scene1()
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                var p = new DummyPlayer();
                Add(p);
                p.X = rand.Next(MnkGame.Width);
                p.Y = rand.Next(MnkGame.Height);
            }

        }
    }
}