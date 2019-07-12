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


        public void Render()
        {
            if (!Active)
                return;

            Mononoke.Graphics.Draw.SetCurrentGraphicComponent(this);
            Draw();
        }
        
        protected abstract void Draw();
        
    }
}