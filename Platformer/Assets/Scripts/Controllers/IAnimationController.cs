using System;
using UnityEngine;

namespace Platformer
{
    public interface IAnimationController
    {
        public Type AnimationControllerType { get; }
        public void RemoveSpriteRenderer(SpriteRenderer spriteRenderer);
    }
}