using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics
{
    public class Sprite
    {
        
        public Texture2D Texture { get; }
        public Rectangle ClipRect { get; }
            
        public Vector2 DrawOffset { get; set; }
        public int Width { get; }
        public int Height { get; }
        
        
        
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