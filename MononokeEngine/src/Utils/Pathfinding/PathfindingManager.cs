using MononokeEngine.Utils.Pathfinding.AStar;

namespace MononokeEngine.Utils.Pathfinding
{
    public class PathfindingManager
    {
        internal PathfindingManager()
        {
        }

        public IPathfindingGrid NewGrid(int width, int height)
        {
            bool[,] grid = new bool[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    grid[x, y] = true;
            return NewGrid(grid);
        }
        
        public IPathfindingGrid NewGrid(bool[,] walkableArray)
        {
            return new AStarGrid(walkableArray);
        }
    }
}