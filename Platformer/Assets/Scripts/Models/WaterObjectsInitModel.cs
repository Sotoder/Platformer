using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class WaterObjectsInitModel
    {
        [SerializeField] private SpriteAnimatorConfig _waterSpriteAnimatorConfig;
        [SerializeField] private List<WaterPoolObject> _waterPoolObjects;

        public SpriteAnimatorConfig WaterSpriteAnimatorConfig { get => _waterSpriteAnimatorConfig; }
        public List<WaterPoolObject> WaterPoolObjectViews { get => _waterPoolObjects; }
    }
}