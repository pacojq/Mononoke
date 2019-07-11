using System.Collections.Generic;
using MononokeEngine.Graphics.Drawing.Commands;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Rendering.Chunks
{
    
    /// <summary>
    /// TODO render entities by chunks
    /// </summary>
    internal class ChunkRenderer : IRenderer
    {
        public float ChunkWidth { get; private set; }
        public float ChunkHeight { get; private set; }


        // TODO resizing stuff
        private Chunk[,] _chunks;
        
        public ChunkRenderer(float chunkWidth, float chunkHeight)
        {
            ChunkWidth = chunkWidth;
            ChunkHeight = chunkHeight;
            
            _chunks = new Chunk[5, 5];
        }


        public IEnumerable<GraphicComponent> GetVisibleGraphics(Camera camera)
        {
            throw new System.NotImplementedException();
        }

        public void AddGraphic(GraphicComponent graphic)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveGraphic(GraphicComponent graphic)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        
        
        
        
        public bool WillDraw(Camera cam, DrawLine line)
        {
            throw new System.NotImplementedException();
        }

        public bool WillDraw(Camera cam, DrawSprite sprite)
        {
            throw new System.NotImplementedException();
        }

        public bool WillDraw(Camera cam, DrawRect rect)
        {
            throw new System.NotImplementedException();
        }

        public bool WillDraw(Camera cam, SetColor rect)
        {
            throw new System.NotImplementedException();
        }
    }
}