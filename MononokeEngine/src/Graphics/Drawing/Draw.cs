using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Graphics.Drawing.Commands;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing
{
    
    /// <summary>
    /// Through the Draw class we can request draw commands to be executed during the
    /// rendering phase.
    /// </summary>
    public class Draw
    {
        
        public SpriteFont Font { get; internal set; }
        public Color Color { get; internal set; }


        public GraphicsDevice GraphicsDevice => _graphicsDevice;

        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;

        /// <summary>
        /// The component that is performing the current Draw call.
        /// </summary>
        private GraphicComponent _currentGraphicComponent;

        private bool _open = false;


        
        
        internal Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
        }

        internal virtual void Enqueue(IDrawCommand cmd)
        {
            if (!_open)
                throw new MononokeGraphicsException("All Draw calls must be executed in the Render events.");

            cmd.Graphic = _currentGraphicComponent;
            _currentGraphicComponent.Entity.Layer.AddDrawCommand(cmd);
        }


        internal void Open()
        {
            _open = true;
        }
        
        internal void Close()
        {
            _open = false;
        }
        
        
        
        
        /// <summary>
        /// Used to specify to which <see cref="GraphicComponent"/> is requesting the draw commands.
        /// </summary>
        /// <param name="graphic"></param>
        internal void SetCurrentGraphicComponent(GraphicComponent graphic)
        {
            _currentGraphicComponent = graphic;
        }
        
        
        
        
        
        // ================================ UTIL ================================ //

        
        public void SetColor(Color color)
        {
            Color = color;
        }
        

        public void SetFont(SpriteFont font)
        {
            Font = font;
        }

        
        
        
        
        // ================================ LINES ================================ //
        
        
        public void Line(Vector2 p0, Vector2 p1)
        {
            Enqueue(new DrawLine(p0, p1, Color));
        }

        public void Line(float x0, float y0, float x1, float y1)
        {
            Line(new Vector2(x0, y0), new Vector2(x1, y1));
        }


        
        
        
        
        // ================================ RECTS ================================ //
        
        public void Rect(float x, float y, float width, float height, bool outline)
        {
            Rectangle rect = new Rectangle((int)x, (int)y, (int)width, (int)height);
            RectExt(rect, Color, outline);
        }
        
        public void Rect(Rectangle rect, bool outline)
        {
            RectExt(rect, Color, outline);
        }
        
        public void RectExt(float x, float y, float width, float height, Color color, bool outline)
        {
            Rectangle rect = new Rectangle((int)x, (int)y, (int)width, (int)height);
            RectExt(rect, color, outline);
        }
        
        public void RectExt(Rectangle rect, Color color, bool outline)
        {
            if (outline) Enqueue(new DrawRectOutline(rect, color));
            else Enqueue(new DrawRect(rect, color));
        }
        
        
        
        
        
        
        // ================================ SPRITES ================================ //
        
        
        public void Sprite(Sprite sprite, float x, float y)
        {
            Sprite(sprite, new Vector2(x, y));
        }
        
        public void Sprite(Sprite sprite, Vector2 position)
        {
            SpriteExt(sprite, position, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }
        
        public void SpriteExt(Sprite sprite, Vector2 position, Color color, float rotation, Vector2 origin,
            Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Enqueue(
                    new DrawSprite(sprite, position, color, rotation, origin, scale, effects, layerDepth)
                );
        }
        
        
        
        // ================================ TEXT ================================ //

        public void Text(string text, Vector2 position)
        {
            TextExt(text, position, Color);
        }
        public void TextExt(string text, Vector2 position, Color color)
        {
            Enqueue(
                new DrawText(Font, text, position, color)
            );
        }
    }
}