using UnityEngine;

namespace Platformer
{
    public class CameraController: ILateUpdateble
    {
        private CameraModel _cameraModel;

        public CameraController(PlayerView playerView, CameraInitModel cameraInitModel)
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

        public void ChangeLevelSettings(int levelID)
        {
            foreach (var levelSettings in _cameraModel.LevelsSettings)
            {
                if (levelID == levelSettings.LevelID)
                {
                    _cameraModel.CurrentLevelSettings = levelSettings;
                    return;
                }
            }
        }
    }
}