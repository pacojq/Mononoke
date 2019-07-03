using System;

namespace MononokeEngine.Utils
{
    public static class Random
    {
        private static System.Random _rand = new System.Random();
        private static int _seed;

        public static void SetSeed(int seed)
        {
            _rand = new System.Random(seed);
            _seed = seed;
        }
        
        public static int GetSeed()
        {
            return _seed;
        }

        
        public static int NextInt()
        {
            return _rand.Next();
        }
        
        public static int NextInt(int max)
        {
            return _rand.Next(max);
        }
        
        
        public static float Next()
        {
            return (float) _rand.NextDouble();
        }
        
        public static float Next(float max)
        {
            return (float) _rand.NextDouble() * max;
        }
        
        
        
        
        public static float Range(float min, float max)
        {
            return min + (float) _rand.NextDouble() * (max - min);
        }
        
        public static int Range(int min, int max)
        {
            return min + (int) System.Math.Round(_rand.NextDouble() * (max - min));
        }
        
        public static double Range(double min, double max)
        {
            return min + _rand.NextDouble() * (max - min);
        }
        
        
    }
}