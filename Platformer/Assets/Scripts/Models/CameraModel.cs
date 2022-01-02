using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CameraModel
    {
        public CameraLevelSettings CurrentLevelSettings;

        private List<CameraLevelSettings> _levelsSettings = new List<CameraLevelSettings>();
        private Transform _cameraTransform;
        private PlayerView _playerView;

        public Transform CameraTransform { get => _cameraTransform; }
        public PlayerView PlayerView { get => _playerView; }
        public List<CameraLevelSettings> LevelsSettings { get => _levelsSettings; }

        public CameraModel(CameraProtoModel cameraInitModel, PlayerView playerView)
        {
            _levelsSettings = cameraInitModel.CameraConfig.CameraLevelSettings;
            _cameraTransform = cameraInitModel.CameraTransform;
            _playerView = playerView;

            CurrentLevelSettings = _levelsSettings[0];
        }
    }
}