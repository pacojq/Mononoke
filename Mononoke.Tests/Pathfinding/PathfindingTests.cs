using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Mononoke.Pathfinding.AStar;
using NUnit.Framework;

namespace Mononoke.Tests.Pathfinding
{
    [TestFixture]
    public class PathfindingTests
    {
        
        private bool[,] CreateMap(int width, int height)
        {
            var map = new bool[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    map[x, y] = true;

            return map;
        }
        

        [Test]
        public void Test1()
        {
            var grid = new AStarGrid(CreateMap(5, 5));
            var pathfinder = new AStarPathfinder(grid);

            List<Vector2> path = null;
            
            path = pathfinder.FindPath(0, 0, 1, 1);
            Assert.AreEqual(1, path.Count);
            
            path = pathfinder.FindPath(0, 0, 2, 2);
            Assert.AreEqual(2, path.Count);
            
            path = pathfinder.FindPath(0, 0, 2, 1);
            Assert.AreEqual(2, path.Count);
            
            path = pathfinder.FindPath(0, 0, 3, 2);
            Assert.AreEqual(3, path.Count);
        }
        
        
    }
}