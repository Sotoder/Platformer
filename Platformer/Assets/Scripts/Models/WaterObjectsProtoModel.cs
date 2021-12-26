using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class WaterObjectsProtoModel
    {
        [SerializeField] private SpriteAnimatorConfig _waterSpriteAnimatorConfig;
        [SerializeField] private List<WaterPoolObjectView> _waterPoolObjects;

        public SpriteAnimatorConfig WaterSpriteAnimatorConfig { get => _waterSpriteAnimatorConfig; }
        public List<WaterPoolObjectView> WaterPoolObjectViews { get => _waterPoolObjects; }
    }
}