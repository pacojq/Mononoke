using Microsoft.Xna.Framework;
using MononokeEngine;
using MononokeEngine.ECS;
using MononokeEngine.Scenes;
using MononokeEngine.Utils;
using Sandbox.Components;
using Sandbox.Entities;

namespace Sandbox.Scenes
{
    public class Scene1 : Scene
    {
        
        public Scene1()
        {
            Entity cameraControllerEntity = new Entity();
            cameraControllerEntity.Bind(new CameraController());
            cameraControllerEntity.Bind(new CameraControllerDrawer());
            
            Add(cameraControllerEntity);
            
            MainCamera.Width /= 2;
            MainCamera.Height /= 2;
            var offset = new Vector2(MainCamera.Width / 2f, MainCamera.Height / 2f);
            MainCamera.Offset = offset;
            

            for (int i = 0; i < 100; i++)
            {
                var p = new DummyPlayer();
                Add(p);
                p.X = Random.Range(.2f, .8f) * MononokeGame.Width;
                p.Y = Random.Range(.2f, .8f) * MononokeGame.Height;

                /*
                var b = new DummyBox();
                Add(b);
                b.X = Random.Next(MononokeGame.Width);
                b.Y = Random.Next(MononokeGame.Height);
                */
            }

            //Space.EnableDebugDraw = true;
        }

    }
}