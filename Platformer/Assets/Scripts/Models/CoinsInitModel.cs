using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class CoinsInitModel
    {
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
        [SerializeField] private List<SpriteRenderer> _coinsRenderers;

        public SpriteAnimatorConfig SpriteAnimatorConfig { get => _spriteAnimatorConfig; }
        public List<SpriteRenderer> CoinsRenderers { get => _coinsRenderers; }
    }
}