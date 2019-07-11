using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MononokeEngine.Utils.Pathfinding.AStar;

namespace MononokeEngine.Utils.Pathfinding
{
    public interface IPathfindingGrid
    {
        int Width { get; }
        int Height { get; }


        void SetWalkable(int x, int y, bool walkable);
        bool  IsWalkable(int x, int y);
        
        
        List<Vector2> FindPath(float xStart, float yStart, float xTarget, float yTarget);
        List<Vector2> FindPath(Vector2 start, Vector2 target);
    }
}