using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class TeleportsProtoModel
    {
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
        [SerializeField] private List<TeleportsPairView>  _teleportsPairs;
        [SerializeField] private int _teleportOffset;

        public List<TeleportsPairView> TeleportsPairs { get => _teleportsPairs; }
        public int TeleportOffset { get => _teleportOffset; }
        public SpriteAnimatorConfig SpriteAnimatorConfig { get => _spriteAnimatorConfig; }
    }
}