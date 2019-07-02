using System;

namespace MonoGarden.Input
{
	public static class MnkInput
	{

		public static KeyboardInput Keyboard;
		
		internal static void Initialize()
		{
			Keyboard = new KeyboardInput();
			
			Console.WriteLine("MnkInput initialized!");
		}
		
		
		
		public static void Update()
		{
			Keyboard.Update();
		}
		
		
	}
}