using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MononokeEngine;
using MononokeEngine.Graphics;
using MononokeEngine.Input;
using MononokeEngine.Scenes;

namespace Sandbox.Components
{
    public class CameraControllerDrawer : GraphicComponent
    {
        protected override void Draw()
        {
            Camera cam = Mononoke.Scenes.Current.MainCamera;
            Mononoke.Graphics.Draw.RectExt(cam.Position.X, cam.Position.Y, cam.Width, cam.Height, Color.Red, true);
            
            Mononoke.Graphics.Draw.Text(cam.Position.ToString(), -cam.Position);
        }
    }
}