using System;
using Mononoke.Core;

namespace Sandbox
{
	class Program
	{
		
		static void Main(string[] args)
		{
			using (SandboxGame game = new SandboxGame())
			{
				
#if DEBUG
				/*
				int tickCount = 0;
				game.OnUpdate += () =>
				{
					Console.WriteLine("Tick " + tickCount);
					tickCount++;
				};
				*/
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