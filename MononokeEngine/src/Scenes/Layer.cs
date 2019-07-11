using System;
using System.Collections.Generic;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Graphics.Rendering;

namespace MononokeEngine.Scenes
{
	public class Layer
	{
		public int Depth { get; set; }


		private List<Entity> _entities;

		public IEnumerable<Entity> Entities => _entities;


		private HashSet<Scene> _scenes;


		internal IRenderer _renderer;
		
		
		public Layer(int depth = 0)
		{
			Depth = depth;
			_entities = new List<Entity>();
			_renderer = new BasicRenderer();
		}





		internal void Update()
		{
			_renderer.Update();
		}
		
		
		
		
		

		public void Attach(Scene scene)
		{
			if (_scenes.Contains(scene))
			{
				Console.WriteLine("The layer is already attached to this scene");
				return;
			}

			_scenes.Add(scene);
			// TODO binding and depth stuff
		}
		
		public void Detach(Scene scene)
		{
			
		}
		
		
		
		
		
		
		
		
		
		
		internal void Add(Entity entity)
		{
			_entities.Add(entity);
			foreach (var graphic in entity.Graphics)
				AddGraphic(graphic);
		}

		internal void AddGraphic(GraphicComponent graphic)
		{
			_renderer.AddGraphic(graphic);
		}
		
		
		internal bool Remove(Entity entity)
		{
			foreach (var graphic in entity.Graphics)
				RemoveGraphic(graphic);
			return _entities.Remove(entity);
		}
		
		internal void RemoveGraphic(GraphicComponent graphic)
		{
			_renderer.RemoveGraphic(graphic);
		}


		public bool Contains(Entity entity)
		{
			return _entities.Contains(entity);
		}
	}
}