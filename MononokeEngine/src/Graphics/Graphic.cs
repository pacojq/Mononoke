using MononokeEngine.ECS;

namespace MononokeEngine.Graphics
{
    public abstract class Graphic : Component
    {
        public bool Visible { get; set; }



        public Graphic()
        {
            Visible = true;
        }
        
        
        public abstract void Render();
    }
}