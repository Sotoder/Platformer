using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public sealed class SpriteSequence
    {
        public AnimState Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}