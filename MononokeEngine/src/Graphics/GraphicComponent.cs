using MononokeEngine.ECS;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics
{
    public abstract class GraphicComponent : Component
    {
        public bool Visible { get; set; }

        
        public GraphicComponent()
        {
            Visible = true;
        }

        internal bool CanDraw()
        {
            return Active;
        }

        public virtual void Draw()
        {
            // Let children implement it
        }

        public virtual void DrawGui()
        {
            // Let children implement it
        }
    }
}