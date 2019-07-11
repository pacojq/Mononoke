using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawSprite : AbstractDrawCommand
    {

        private readonly Sprite _sprite;
        private readonly Vector2 _position;
        private readonly Color _color;
        private readonly float _rotation;
        private readonly Vector2 _origin;
        private readonly Vector2 _scale;
        private readonly SpriteEffects _effects;
        private readonly float _layerDepth;
        

        public DrawSprite(Sprite sprite, Vector2 position, Color color, float rotation, Vector2 origin,
                Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            _sprite = sprite;
            _position = position;
            _color = color;
            _rotation = rotation;
            _origin = origin;
            _scale = scale;
            _effects = effects;
            _layerDepth = layerDepth;
        }
        
        
        
        public override void Execute()
        {
            Mononoke.Graphics.SpriteBatch.Draw(
                    _sprite.Texture, 
                    _position, 
                    _sprite.ClipRect, 
                    _color, 
                    _rotation,
                    _origin,
                    _scale, 
                    _effects, 
                    _layerDepth
                );
        }

        public override bool Accept(Camera cam, IRenderer renderer)
        {
            return renderer.WillDraw(cam, this);
        }
    }
}