using UnityEngine;

namespace Platformer
{
    public class CameraController: ILateUpdateble
    {
        private CameraModel _cameraModel;

        public CameraController(PlayerView playerView, CameraProtoModel cameraInitModel)
        {
            _cameraModel = new CameraModel(cameraInitModel, playerView);
        }

        public void LateUpdate(float deltaTime)
        {
            var xPosition = Mathf.Clamp(_cameraModel.PlayerView.Transform.position.x, 
                                        _cameraModel.CurrentLevelSettings.MaxLeftOffset, 
                                        _cameraModel.CurrentLevelSettings.MaxRightOffset);

            var newPosition = new Vector3(xPosition, _cameraModel.CameraTransform.position.y, _cameraModel.CameraTransform.position.z);

            _cameraModel.CameraTransform.position = newPosition;  
        }

        public void ChangeLevelSettings(Levels level)
        {
            foreach (var levelSettings in _cameraModel.LevelsSettings)
            {
                if (level == levelSettings.Level)
                {
                    _cameraModel.CurrentLevelSettings = levelSettings;
                    break;
                }
            }
        }
    }
}