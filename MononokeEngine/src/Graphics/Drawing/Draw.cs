using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Graphics.Drawing.Commands;

namespace MononokeEngine.Graphics.Drawing
{
    
    /// <summary>
    /// ALl rendering stuff will go through this class.
    /// 
    /// </summary>
    public class Draw
    {
        
        public SpriteFont Font { get; internal set; }
        public Color Color { get; internal set; }
        
        

        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;

        private bool _open = false;


        /// <summary>
        /// The command queue is cleaned up before every Render call.
        /// When the active <see cref="MononokeEngine.Scenes.Scene"/> executes
        /// its Render method, the queue will be filled with drawing commands.
        /// </summary>
        private Queue<IDrawCommand> _commands;
        
        
        internal Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
            
            _commands = new Queue<IDrawCommand>();
        }

        private void Enqueue(IDrawCommand cmd)
        {
            if (!_open)
                throw new MononokeGraphicsException("All Draw calls must be executed in the Render events.");

            _commands.Enqueue(cmd);
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
        /// Executes all <see cref="IDrawCommand"/> commands in the queue.
        /// </summary>
        internal void Render()
        {
            _spriteBatch.Begin();

            while (_commands.Count > 0)
            {
                IDrawCommand cmd = _commands.Dequeue();
                cmd.Execute();
            }
            
            _spriteBatch.End();
        }
        
        
        
        
        
        
        
        
        
        

        public void SetFont(SpriteFont font)
        {
            _commands.Enqueue(new SetFont(font, this));
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
    }
}