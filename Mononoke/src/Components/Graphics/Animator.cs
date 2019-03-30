using System;
using Mononoke.Core;
using Mononoke.Graphics;

namespace Mononoke.Components.Graphics
{
    public class Animator : Component
    {

        public SpriteRenderer Renderer;
        public AnimationController Controller;
        public Animation CurrentAnimation;
        
        
        public int ImageIndex { get; private set; }
        private float _actualImageIndex;

        public Action OnAnimationUpdate;
        
        
        
        public Animator(SpriteRenderer renderer, AnimationController controller)
        {
            Renderer = renderer;
            Controller = controller;
            CurrentAnimation = controller.CurrentAnimation;
            
            ImageIndex = 0;
            _actualImageIndex = 0;
        }


        public override void Update()
        {
            base.Update();

            _actualImageIndex += CurrentAnimation.Speed;
            _actualImageIndex %= CurrentAnimation.FrameCount;
            ImageIndex = (int) Math.Floor(_actualImageIndex);

            UpdateSprite(CurrentAnimation[ImageIndex]);
        }

        private void UpdateSprite(Sprite frame)
        {
            if (Renderer.Sprite == frame)
                return;

            Renderer.Sprite = frame;
            if (OnAnimationUpdate != null)
                OnAnimationUpdate();
        }
    }
}