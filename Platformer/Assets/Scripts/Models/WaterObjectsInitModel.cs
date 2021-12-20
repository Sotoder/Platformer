using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class WaterObjectsInitModel
    {
        [SerializeField] private SpriteAnimatorConfig _waterSpriteAnimatorConfig;
        [SerializeField] private List<WaterPoolObjectView> _waterPoolObjectViews;

        public SpriteAnimatorConfig WaterSpriteAnimatorConfig { get => _waterSpriteAnimatorConfig; }
        public List<WaterPoolObjectView> WaterPoolObjectViews { get => _waterPoolObjectViews; }
    }
}