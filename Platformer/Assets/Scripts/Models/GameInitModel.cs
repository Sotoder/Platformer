using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class GameInitModel
    {
        [SerializeField] private PlayerInitModel _playerInitModel;
        [SerializeField] private FlyEnemiesInitModel _flyEnemiesInitModel;
        [SerializeField] private WaterObjectsInitModel _waterInitModel;
        [SerializeField] private CameraInitModel _cameraInitModel;
        [SerializeField] private CoinsInitModel _coinsInitModel;

        public PlayerInitModel PlayerInitModel { get => _playerInitModel; }
        public FlyEnemiesInitModel FlyEnemiesInitModel { get => _flyEnemiesInitModel; }
        public CameraInitModel CameraInitModel { get => _cameraInitModel; }
        public WaterObjectsInitModel WaterInitModel { get => _waterInitModel; }
        public CoinsInitModel CoinsInitModel { get => _coinsInitModel; }
    }
}