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
            var p = new DummyPlayer();
            Add(p);
            
        }
    }
}