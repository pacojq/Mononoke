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

        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;
        
        public SpriteFont Font { get; internal set; }


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

        
        
        public void Line(Vector2 p0, Vector2 p1)
        {
            Line(p0.X, p0.Y, p1.X, p1.Y);
        }

        public void Line(float x0, float y0, float x1, float y1)
        {
            
        }


        
        
        
        
        
        
        public void Sprite(Sprite sprite, Vector2 position)
        {
            SpriteExt(sprite, position, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }
        
        public void SpriteExt(Sprite sprite, Vector2 position, Color color, float rotation, Vector2 origin,
            Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            _commands.Enqueue(
                    new DrawSprite(sprite, position, color, rotation, origin, scale, effects, layerDepth)
                );
        }
    }
}