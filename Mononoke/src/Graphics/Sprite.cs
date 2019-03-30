using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mononoke.Graphics
{
    public class Sprite
    {
        
        public Texture2D Texture { get; private set; }
        public Rectangle ClipRect { get; private set; }
            
        public Vector2 DrawOffset { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        
        
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            ClipRect = new Rectangle(0, 0, texture.Width, texture.Height);
            DrawOffset = Vector2.Zero;
            Width = ClipRect.Width;
            Height = ClipRect.Height;
        }
    }
}