using System;

namespace MononokeEngine.Input
{
	public class InputManager
	{
		public KeyboardInput Keyboard { get; private set; }
		public MouseInput Mouse { get; private set; }


		internal InputManager()
		{
		}


		internal void Initialize()
		{
			Keyboard = new KeyboardInput();
			Mouse = new MouseInput();
			
			Mononoke.Logger.Print("InputManager initialized!");
		}
		
		
		
		public void Update()
		{
			Keyboard.Update();
			Mouse.Update();
		}
		
		
	}
}