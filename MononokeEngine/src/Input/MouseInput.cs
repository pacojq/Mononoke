using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MononokeEngine.Input
{
    public class MouseInput
    {
        public MouseState PreviousState { get; private set; }
        public MouseState CurrentState { get; private set; }
        
        
        internal MouseInput()
        {
            PreviousState = new MouseState();
            CurrentState = new MouseState();
        }
        
        internal void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();
             Mononoke.Logger.Print($"MousePos: {Position}");
        }
        
        
        
        
        public Vector2 Position
        {
            // var vector = Vector2.Transform(value, Engine.ScreenMatrix);
            get => new Vector2(CurrentState.X, CurrentState.Y);
            set => Mouse.SetPosition((int)Math.Round(value.X), (int)Math.Round(value.Y));
        }
        
        public float X
        {
            get => Position.X;
            set => Position = new Vector2(value, Position.Y);
        }

        public float Y
        {
            get => Position.Y;
            set => Position = new Vector2(Position.X, value);
        }
        
        
        
        
        
        public bool LeftBtnHeld => CurrentState.LeftButton == ButtonState.Pressed;
        
        public bool LeftBtnPressed => CurrentState.LeftButton == ButtonState.Pressed 
                                      && PreviousState.LeftButton == ButtonState.Released;
        
        public bool LeftBtnReleased => CurrentState.LeftButton == ButtonState.Released 
                                       && PreviousState.LeftButton == ButtonState.Pressed;
        


        public bool RightBtnHeld => CurrentState.RightButton == ButtonState.Pressed;

        public bool RightBtnPressed => CurrentState.RightButton == ButtonState.Pressed 
                                       && PreviousState.RightButton == ButtonState.Released;
        
        public bool RightBtnReleased => CurrentState.RightButton == ButtonState.Released 
                                        && PreviousState.RightButton == ButtonState.Pressed;
        


        public bool MiddleBtnHeld => CurrentState.MiddleButton == ButtonState.Pressed;

        public bool MiddleBtnPressed => CurrentState.MiddleButton == ButtonState.Pressed 
                                        && PreviousState.MiddleButton == ButtonState.Released;

        public bool MiddleBtnReleased => CurrentState.MiddleButton == ButtonState.Released 
                                         && PreviousState.MiddleButton == ButtonState.Pressed;
        
        
    }
}