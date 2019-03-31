using System;

namespace Mononoke.Pathfinding.AStar
{
	
	internal class AStarNode : IComparable<AStarNode>
	{

		public bool Walkable { get; private set; }
		public Vec2 Position { get; private set; }

		public int X => (int) Position.X;
		public int Y => (int) Position.Y;

		internal AStarNode Parent;
		
		
		
		internal int GCost;
		internal int HCost;
		internal int FCost
		{
			get { return GCost + HCost; }
		}
	

		
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
