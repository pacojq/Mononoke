using MononokeEngine.ECS;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics
{
    public abstract class GraphicComponent : Component
    {
        public bool Visible { get; set; }

        
        /// <summary>
        /// Before rendering each frame, we'll check which graphics
        /// will be rendered.
        /// The boolean value will be stored here.
        /// </summary>
        internal bool WillRenderThisFrame { get; set; }


        public GraphicComponent()
        {
            Visible = true;
        }


        public void Render()
        {
            if (!WillRenderThisFrame)
                return;

            if (!Active)
                return;

            Mononoke.Graphics.Draw.SetCurrentGraphicComponent(this);
            Draw();
        }
        
        protected abstract void Draw();


        /// <summary>
        /// Used for graphic optimization. Check if a Graphic might be rendered
        /// by a given Camera.
        ///
        /// Returns true by default.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public virtual bool IsOnCameraBounds(Camera camera)
        {
            return true;
        }
    }
}