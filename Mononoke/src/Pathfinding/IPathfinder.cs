using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Mononoke.Pathfinding
{
    public interface IPathfinder
    {
        List<Vector2> FindPath(float xStart, float yStart, float xTarget, float yTarget);
        List<Vector2> FindPath(Vector2 start, Vector2 target);
    }
}