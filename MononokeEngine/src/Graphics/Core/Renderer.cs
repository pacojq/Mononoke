using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Graphics.Core.Rendering.Chunks;
using MononokeEngine.Graphics.Drawing;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Core
{
    
    /// <summary>
    /// The GameRenderer takes all the commands generated by the
    /// <see cref="Draw"/> class
    /// and renders them on each <see cref="Scene"/>
    /// active <see cref="Camera"/>
    /// </summary>
    internal class Renderer
    {
        
        

        private GraphicsDevice GraphicsDevice => MononokeGame.Instance.GraphicsDevice;
    



        // Culling //

        public IGraphicsCulling BasicCulling
        {
            get
            {
                if (_basicCulling == null)
                    _basicCulling = new BasicCulling();
                return _basicCulling;
            }
        }
        private BasicCulling _basicCulling;
        
        
        public IGraphicsCulling ChunkCulling
        {
            get
            {
                if (_chunkCulling == null)
                    _chunkCulling = new ChunkCulling(10, 10); // TODO
                return _chunkCulling;
            }
        }
        private ChunkCulling _chunkCulling;



        private readonly GraphicsManager _graphicsManager;
        
        
        public Renderer(GraphicsManager graphicsManager)
        {
            _graphicsManager = graphicsManager;
        }

        
        

        internal void DrawPhase()
        {
            Scene scene = Mononoke.Scenes.Current;

            if (scene == null)
            {
                GraphicsDevice.SetRenderTarget(null);
            
                Mononoke.Logger.Print($"Viewport: {_graphicsManager.Viewport}");
                GraphicsDevice.Viewport = _graphicsManager.Viewport;
                GraphicsDevice.Clear(Color.CornflowerBlue);
                
                return;
            }
            
            
            // = = = = = = = = = DRAW = = = = = = = = = //
            _graphicsManager.Draw.Open();
            
            scene.BeforeDraw();
            
            //Mononoke.Logger.Print($"Viewport: {Viewport}");
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Viewport = _graphicsManager.Viewport;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            scene.Draw();
            scene.AfterDraw();
            
            _graphicsManager.Draw.Close();
            
            
            // = = = = = = = = DRAW GUI = = = = = = = = = //
            
            _graphicsManager.DrawGUI.Open();
            
            scene.DrawGui();
            
            _graphicsManager.DrawGUI.Open();
        }
        

        
        
        
        


        public void RenderImpl()
        {
            Scene scene = Mononoke.Scenes.Current;
            if (scene == null)
                return;
            
            _graphicsManager.SpriteBatch.Begin();
            
            foreach (Camera cam in scene.Cameras)
                RenderCamera(cam);
            
            _graphicsManager.SpriteBatch.End();

            foreach (Layer layer in scene.Layers)
                layer.ClearDrawCommands();
        }
        

        private void RenderCamera(Camera cam)
        {
            Scene scene = Mononoke.Scenes.Current;
            
            foreach (Layer layer in scene.Layers)
            {
                IGraphicsCulling graphicsCulling = layer.GraphicsCulling;
                foreach (IDrawCommand cmd in layer.DrawCommands)
                {
                    if (!cmd.Accept(cam, graphicsCulling))
                        continue;
                    cmd.Execute(cam);
                }
            }
        }
        
        
        
        
        
        
        
        public void CleanUp()
        {
            Scene scene = Mononoke.Scenes.Current;
            
            foreach (Layer layer in scene.Layers)
                layer.ClearDrawCommands();
        }
        
    }
}