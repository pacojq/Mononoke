using System;
using Mononoke.Core;

namespace Sandbox
{
	class Program
	{
		public static int ScreenWidth = 640;
		public static int ScreenHeight = 320;
		
		static void Main(string[] args)
		{
			using (MkGame game = new MkGame(ScreenWidth, ScreenHeight, ScreenWidth, ScreenHeight, "Mononoke Sandbox", false))
			{
				
#if DEBUG
				int tickCount = 0;
				game.OnUpdate += () =>
				{
					Console.WriteLine("Tick " + tickCount);
					tickCount++;
				};
#endif
				game.OnEnd += () =>
				{
					Console.WriteLine("Game over!");
				};
				
				game.Run();
			}

		}
	}
}