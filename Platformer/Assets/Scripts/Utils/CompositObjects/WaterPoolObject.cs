using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class WaterPoolObject
    {
        [SerializeField] private List<SpriteRenderer> _waterSpriteRenderers;

        public List<SpriteRenderer> WaterSpriteRenderers { get => _waterSpriteRenderers; }
    }
}
