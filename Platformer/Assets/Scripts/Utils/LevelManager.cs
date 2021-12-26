using System;

namespace Platformer
{
    public class LevelManager
    {
        private WaterPoolsAnimationController _waterPoolsAnimationController;
        private CoinsSubsystemController _coinsSubsystemController;
        private TeleportsController _teleportController;
        private TriggerController _triggerController;
        private EnemiesSubsystemController _enemiesSubsystemController;
        private CameraController _cameraController;

        public LevelManager(WaterPoolsAnimationController waterPoolsAnimationController, 
                            CoinsSubsystemController coinsSubsystemController, TeleportsController teleportController, 
                            TriggerController triggerController, EnemiesSubsystemController enemiesSubsystemController, CameraController cameraController)
        {
            _waterPoolsAnimationController = waterPoolsAnimationController;
            _coinsSubsystemController = coinsSubsystemController;
            _teleportController = teleportController;
            _triggerController = triggerController;
            _enemiesSubsystemController = enemiesSubsystemController;
            _cameraController = cameraController;

            _triggerController.LoadNextLevel += LoadNextLevel;
        }

        private void LoadNextLevel(Levels levelType)
        {
            _cameraController.ChangeLevelSettings(levelType);
        }
    }
}