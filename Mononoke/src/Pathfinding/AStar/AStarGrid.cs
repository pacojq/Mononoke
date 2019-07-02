/*
* Copyright © Paco Juan
* https://twitter.com/_thisIsPJ
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Mononoke.Pathfinding.AStar
{
	public class AStarGrid : IGrid
	{
	
		private AStarNode[,] _grid;
		private int _width, _height;
	
		internal AStarNode this[int x, int y] => _grid[x, y];
		internal AStarNode this[Vec2 pos] => _grid[pos.X, pos.Y];
	
		
		public AStarGrid(bool[,] walkable)
		{
			_width = walkable.GetLength(0);
			_height = walkable.GetLength(1);

			_grid = new AStarNode[_width, _height];
			for (var x = 0; x < _width; x++)
				for (var y = 0; y < _height; y++)
					_grid[x, y] = new AStarNode(walkable[x, y], x, y);
            
		}

		

		internal List<AStarNode> GetNeighbours(AStarNode aStarNode)
		{
			List<AStarNode> neighbours = new List<AStarNode>();

			/*
			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (x == 0 && y == 0)
						continue;

					var nX = node.GridX + x;
					var nY = node.GridY + y;
					if (IsCoordValid(nX, nY))
						neighbours.Add(_grid[nX, nY]);
				}
			}
			*/
			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					var nX = aStarNode.X + x;
					var nY = aStarNode.Y + y;
					if ((x == 0 && y == 0) || !IsCoordValid(nX, nY))
						continue;
					
					
					if (x != 0 && y != 0) // Corners
					{
						// Diagonal neighbours are only added if there's no direct unwalkable neighbour near them
						if (_grid[nX - Math.Sign(x), nY].Walkable && _grid[nX, nY - Math.Sign(y)].Walkable)
							neighbours.Add(_grid[nX, nY]);
					}
					else neighbours.Add(_grid[nX, nY]); // Direct neighbours
				}
			}
			
			return neighbours;
		}


		internal bool IsCoordValid(int x, int y)
		{
			return (x >= 0 && x < _width && y >= 0 && y < _height);
		}
		
		
		internal int GetDistance(int x0, int y0, int x1, int y1)
		{
			if (!IsCoordValid(x0, y0) || !IsCoordValid(x1, y1))
				return -1;
			
			
			int deltaX = Math.Abs(x1 - x0);
			int deltaY = Math.Abs(y1 - y0);

			return deltaX + deltaY;
		}
	
	}
}
