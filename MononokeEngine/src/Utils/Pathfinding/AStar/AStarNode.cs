using System;

namespace MononokeEngine.Utils.Pathfinding.AStar
{
	
	internal class AStarNode : IComparable<AStarNode>
	{

		public bool Walkable { get; set; }
		public Vec2 Position { get; private set; }

		public int X => (int) Position.X;
		public int Y => (int) Position.Y;

		internal AStarNode Parent { get; set; }
		
		
		
		/// <summary>
		/// Distance from the starting node
		/// </summary>
		internal int GCost { get; set; }
		
		/// <summary>
		/// Distance from the end node
		/// </summary>
		internal int HCost { get; set; }
		
		
		/// <summary>
		/// Sum of GCost and HCost
		/// </summary>
		internal int FCost => GCost + HCost;
		
		
		
		

		// HEAP STUFF
		
		public int HeapIndex { get; set; }
		public bool MinusInfiniteWeight { get; set; }

		
		

		internal AStarNode(bool walkable, int x, int y)
		{
			Walkable = walkable;
			Position = new Vec2(x, y);
		}

		
		
		public int CompareTo(AStarNode other)
		{
			var dif = FCost.CompareTo(other.FCost);
			return dif == 0 ? HCost.CompareTo(other.HCost) : dif;
		}

		public override string ToString()
		{
			return "[" + X + ", " + Y + "] : " + (Walkable ? "walkable" : "occupied");
		}
	}
}
