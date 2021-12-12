using UnityEngine;

namespace Platformer
{
    public class PlayerModel
    {
        public float Speed;
        public float Force;
        public float AnimationSpeed;

        public PlayerModel(float speed, float force, float animationSpeed)
        {
            Speed = speed;
            Force = force;
            AnimationSpeed = animationSpeed;
        }
    }
}