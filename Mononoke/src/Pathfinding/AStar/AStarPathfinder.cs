
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Mononoke.DataStructures.Heaps;

namespace Mononoke.Pathfinding.AStar
{
	public class AStarPathfinder : IPathfinder
	{

		private readonly AStarGrid _grid;


		public AStarPathfinder(AStarGrid grid)
		{
			_grid = grid;
		}
		

		public List<Vector2> FindPath(float xStart, float yStart, float xTarget, float yTarget)
		{
			return FindPath(new Vector2(xStart, yStart), new Vector2(xTarget, yTarget));
		}
		
		public List<Vector2> FindPath(Vector2 startPosition, Vector2 targetPosition)
		{
			var path = new List<AStarNode>();

			int sx = (int) Math.Floor(startPosition.X);
			int sy = (int) Math.Floor(startPosition.Y);
			AStarNode startNode = _grid[sx, sy];
			
			int tx = (int) Math.Floor(targetPosition.X);
			int ty = (int) Math.Floor(targetPosition.Y);
			AStarNode targetNode = _grid[tx, ty];
			

			if (startNode != null || targetNode == null)
			{
				var openSet = new BinaryHeap<AStarNode>();
				var closedSet = new HashSet<AStarNode>();

				openSet.Add(startNode);

				while (openSet.Count > 0)
				{
					AStarNode currentNode = openSet.Poll();
					closedSet.Add(currentNode);
					
					if (currentNode == null)
						continue;

					// Reached Target
					if (currentNode == targetNode)
						return RetracePath(startNode, targetNode);

					// Add new nodes
					foreach (var neighbour in _grid.GetNeighbours(currentNode))
					{
						
						if (neighbour == null)
							continue;

						// Target forund but not walkable
						if (neighbour == targetNode && !neighbour.Walkable)
						{
							return RetracePath(startNode, currentNode);
						}

						if (!neighbour.Walkable || closedSet.Contains(neighbour))
							continue;

						int newCostToNeighbour = currentNode.GCost + GetDistance(currentNode, neighbour);
						if (newCostToNeighbour < neighbour.GCost || !openSet.Contains(neighbour))
						{
							neighbour.GCost = newCostToNeighbour;
							neighbour.HCost = GetDistance(neighbour, targetNode);
							neighbour.Parent = currentNode;

							if (!openSet.Contains(neighbour))
								openSet.Add(neighbour);
								//openSet.Remove(neighbour);
								
							//openSet.Add(neighbour);
						}
					}
				}

			}
			return null;
		}

		
		
		private List<Vector2> RetracePath(AStarNode startNode, AStarNode endNode)
		{
			var path = new List<Vector2>();

			AStarNode currentNode = endNode;
			while (currentNode != startNode)
			{
				path.Add(new Vector2(currentNode.X, currentNode.Y));
				currentNode = currentNode.Parent;
			}
			
			path.Reverse();

			return path;
		}


		
		
		int GetDistance(AStarNode a, AStarNode b)
		{
			if (a == null)
				throw new Exception("A is null");
			
			if (b == null)
				throw new Exception("B is null");
			
			int deltaX = Math.Abs(b.X - a.X);
			int deltaY = Math.Abs(b.Y - a.Y);

			// Diagonal steps cost 14. Horizontal/Vertical cost 10.
			if (deltaX > deltaY)
				return 14 * deltaY + 10 * (deltaX - deltaY);
			
			return 14 * deltaX + 10 * (deltaY - deltaX);
		}
		
		
	}
}
