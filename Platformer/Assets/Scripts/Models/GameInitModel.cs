using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class GameInitModel
    {
        [SerializeField] private EndLevelPortalsProtoModel _endLevelPortalsProtoModel;
        [SerializeField] private PlayerProtoModel _playerProtoModel;
        [SerializeField] private FlyEnemiesProtoModel _flyEnemiesProtoModel;
        [SerializeField] private WaterObjectsProtoModel _waterProtoModel;
        [SerializeField] private CameraProtoModel _cameraProtoModel;
        [SerializeField] private CoinsProtoModel _coinsProtoModel;
        [SerializeField] private TeleportsProtoModel _teleportsProtoModel;

        public EndLevelPortalsProtoModel EndLevelPortalsProtoModel { get => _endLevelPortalsProtoModel; }
        public PlayerProtoModel PlayerProtoModel { get => _playerProtoModel; }
        public FlyEnemiesProtoModel FlyEnemiesProtoModel { get => _flyEnemiesProtoModel; }
        public CameraProtoModel CameraProtoModel { get => _cameraProtoModel; }
        public WaterObjectsProtoModel WaterProtoModel { get => _waterProtoModel; }
        public CoinsProtoModel CoinsProtoModel { get => _coinsProtoModel; }
        public TeleportsProtoModel TeleportsProtoModel { get => _teleportsProtoModel; }
    }
}