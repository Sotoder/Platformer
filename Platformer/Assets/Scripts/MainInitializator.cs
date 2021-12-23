using System.Collections.Generic;

namespace Platformer
{
    public class MainInitializator
    {

        public MainInitializator(MainUpdateController updateController, GameInitModel gameInitModel)
        {
            var waterPoolsAnimationController = new WaterPoolsAnimationController(gameInitModel.WaterProtoModel);

            var coinsSubsystemController = new CoinsSubsystemController(gameInitModel.CoinsProtoModel, 
                                                                        gameInitModel.CameraProtoModel.CameraTransform, 
                                                                        gameInitModel.PlayerProtoModel.PlayerView);

            var teleportController = new TeleportsController(gameInitModel.TeleportsProtoModel);

            var triggerController = new TriggerController(gameInitModel.PlayerProtoModel.PlayerView)
                                                 .AddTriggerdObjects(TriggeredObjectTypes.Coin, coinsSubsystemController.TriggeredObjects)
                                                 .AddTriggerdObjects(TriggeredObjectTypes.Teleport, teleportController.TriggerTeleportObjects);
            
            var cameraController = new CameraController(gameInitModel.PlayerProtoModel.PlayerView, gameInitModel.CameraProtoModel);
            var inputController = new InputController();
            var playerController = new PlayerController(gameInitModel.PlayerProtoModel, inputController, triggerController);
            var enemiesSubsystemController = new EnemiesSubsystemController(gameInitModel.FlyEnemiesProtoModel);

            updateController.Add(inputController);
            updateController.Add(playerController);
            updateController.Add(enemiesSubsystemController);
            updateController.Add(cameraController);
            updateController.Add(waterPoolsAnimationController);
            updateController.Add(coinsSubsystemController);
            updateController.Add(teleportController);
        }
    }
}