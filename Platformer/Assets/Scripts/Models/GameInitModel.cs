using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class GameInitModel
    {
        [SerializeField] private PlayerInitModel _playerInitModel;
        [SerializeField] private FlyEnemiesInitModel _flyEnemiesInitModel;

        public PlayerInitModel PlayerInitModel { get => _playerInitModel; }
        public FlyEnemiesInitModel FlyEnemiesInitModel { get => _flyEnemiesInitModel; }
    }
}