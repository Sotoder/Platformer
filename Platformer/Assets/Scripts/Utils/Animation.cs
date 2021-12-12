using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public sealed class Animation
    {
        public AnimState Track;
        public List<Sprite> Sprites;
        public bool Loop;
        public float Speed = 10;
        public float Counter = 0;
        public bool Sleep;

        public void Update(float deltaTime)
        {
            if (Sleep) return;

            Counter += deltaTime * Speed;

            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count;
                Sleep = true;
            }
        }
    }
}