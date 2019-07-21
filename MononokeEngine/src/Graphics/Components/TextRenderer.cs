using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics.Components
{
    public class TextRenderer : GraphicComponent
    {
        public enum HorizontalAlign { Left, Center, Right };
        public enum VerticalAlign { Top, Center, Bottom };


        public string Text { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; }

        public HorizontalAlign HorizontalOrigin { get; set; }
        public VerticalAlign VerticalOrigin { get; set; }
        
        
        public TextRenderer(string text, Vector2 position)
        {
            this.Text = text;
            LocalPosition = position;
            Font = Mononoke.Graphics.DefaultFont;
            Color = Color.Black;
            HorizontalOrigin = HorizontalAlign.Left;
            VerticalOrigin = VerticalAlign.Top;
        }


        public override void Draw()
        {
            Mononoke.Graphics.SpriteBatch.DrawString(Font, Text, Position, Color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }
    }
}