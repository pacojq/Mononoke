using System;
using System.Collections.Generic;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Graphics.Drawing;

namespace MononokeEngine.Scenes
{
	public class Layer
	{
		public int Depth { get; set; }


		private List<Entity> _entities;

		public IEnumerable<Entity> Entities => _entities;


		private HashSet<Scene> _scenes;


		
		// ====================== RENDERING ====================== //
		
		internal IGraphicsCulling GraphicsCulling { get; private set; }

		internal IEnumerable<IDrawCommand> DrawCommands => _drawCommands;

		private List<IDrawCommand> _drawCommands;
		
		


		public Layer(int depth = 0)
		{
			Depth = depth;
			_entities = new List<Entity>();

			GraphicsCulling = Mononoke.Graphics.Renderer.BasicCulling;
			_drawCommands = new List<IDrawCommand>();
		}





		internal void Update()
		{
			GraphicsCulling.Update();
		}
		
		
		
		
		

		public void Attach(Scene scene)
		{
			if (_scenes.Contains(scene))
			{
				Mononoke.Logger.Print("The layer is already attached to this scene");
				return;
			}

			_scenes.Add(scene);
			// TODO binding and depth stuff
		}
		
		public void Detach(Scene scene)
		{
			
		}
		
		
		
		
		
		
		
		// ====================== ENTITIES ====================== //


		internal void Add(Entity entity)
		{
			_entities.Add(entity);
			foreach (var graphic in entity.Graphics)
				AddGraphic(graphic);
		}


		internal bool Remove(Entity entity)
		{
			foreach (var graphic in entity.Graphics)
				RemoveGraphic(graphic);
			return _entities.Remove(entity);
		}
		

		public bool Contains(Entity entity)
		{
			return _entities.Contains(entity);
		}
		
		
		
		
		
		
		// ====================== RENDERING ====================== //
		
		internal void AddGraphic(GraphicComponent graphic)
		{
			GraphicsCulling.AddGraphic(graphic);
		}
		
		
		internal void RemoveGraphic(GraphicComponent graphic)
		{
			GraphicsCulling.RemoveGraphic(graphic);
		}

		internal void AddDrawCommand(IDrawCommand cmd)
		{
			_drawCommands.Add(cmd);
		}

		internal void ClearDrawCommands()
		{
			_drawCommands.Clear();
		}
		
		
	}
}