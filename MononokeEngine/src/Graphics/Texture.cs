using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics
{
    
    /// <summary>
    /// Wrapper class for a <see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/>
    /// </summary>
    public class Texture
    {
        public Texture2D Texture2D => _tex;
        
        public Rectangle ClipRect { get; }
        public Vector2 Offset { get; }
        public int Width { get; }
        public int Height { get; }
        
        
        private readonly Texture2D _tex;
        
        
        

        public Texture(Texture2D texture)
        {
            _tex = texture;
            
            ClipRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Offset = Vector2.Zero;
            Width = texture.Width;
            Height = texture.Height;
        }
        
        
        public Texture(int width, int height, Color color)
        {
            _tex = new Texture2D(Mononoke.Graphics.GraphicsDevice, width, height);
            
            Color[] pixels = new Color[width * height];
            for (int i = 0; i < width * height; i++)
                pixels[i] = color;
            _tex.SetData(pixels);
            
            ClipRect = new Rectangle(0, 0, width, height);
            Offset = Vector2.Zero;
            Width = width;
            Height = height;
        }
    }
}