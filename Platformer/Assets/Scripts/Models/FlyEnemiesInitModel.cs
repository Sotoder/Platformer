using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class FlyEnemiesInitModel
    {
        [SerializeField] private List<FlyEnemyInitModel> _flyEnemyInitModels;

        public List<FlyEnemyInitModel> FlyEnemyInitModels { get => _flyEnemyInitModels; }
    }
}