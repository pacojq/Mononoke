using System;

namespace MononokeEngine.Input
{
	public class InputManager
	{
		public KeyboardInput Keyboard { get; private set; }


		internal InputManager()
		{
		}


		internal void Initialize()
		{
			Keyboard = new KeyboardInput();
			
			Mononoke.Logger.Print("InputManager initialized!");
		}
		
		
		
		public void Update()
		{
			Keyboard.Update();
		}
		
		
	}
}