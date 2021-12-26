using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class EndLevelPortalsProtoModel
    {
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
        [SerializeField] List<EndLevelPortalView> endLevelPortalViews;

        public SpriteAnimatorConfig SpriteAnimatorConfig { get => _spriteAnimatorConfig; }
        public List<EndLevelPortalView> EndLevelPortalViews { get => endLevelPortalViews; }
    }
}