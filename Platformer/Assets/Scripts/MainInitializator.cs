using System.Collections.Generic;

namespace Platformer
{
    public class MainInitializator
    {

        public MainInitializator(MainUpdateController updateController, GameInitModel gameInitModel)
        {
            var timerController = new TimerController();
            var inputController = new InputController();

            var waterPoolsAnimationController = new WaterPoolsAnimationController(gameInitModel.WaterProtoModel);

            var coinsSubsystemController = new CoinsSubsystemController(gameInitModel.CoinsProtoModel, 
                                                                        gameInitModel.CameraProtoModel.CameraTransform, 
                                                                        gameInitModel.PlayerProtoModel.PlayerView);

            var teleportController = new TeleportsController(gameInitModel.TeleportsProtoModel);
            var endLevelPortalsController = new EndLevelPortalsController(gameInitModel.EndLevelPortalsProtoModel);

            var triggerController = new TriggerController(gameInitModel.PlayerProtoModel.PlayerView)
                                                 .AddTriggerdObjects(TriggerObjectTypes.Coin, coinsSubsystemController.TriggerObjects)
                                                 .AddTriggerdObjects(TriggerObjectTypes.Teleport, teleportController.TriggerTeleportObjects)
                                                 .AddTriggerdObjects(TriggerObjectTypes.EndLevel, endLevelPortalsController.CurentEndLevelPortal);
            
            var cameraController = new CameraController(gameInitModel.PlayerProtoModel.PlayerView, gameInitModel.CameraProtoModel);
            var playerController = new PlayerController(gameInitModel.PlayerProtoModel, inputController, triggerController);
            var enemiesSubsystemController = new EnemiesSubsystemController(gameInitModel.FlyEnemiesProtoModel);

            new LevelManager(waterPoolsAnimationController, coinsSubsystemController, 
                             teleportController, triggerController, enemiesSubsystemController, cameraController);

            new GeneratorLevelController(gameInitModel.GeneratorLevelProtoModel);

            var questsController = new QuestsController(gameInitModel.QuestsConfig, playerController.PlayerDataForQuests);
            endLevelPortalsController.SubscribeOnQuests(questsController);

            updateController.Add(timerController);
            updateController.Add(inputController);
            updateController.Add(playerController);
            updateController.Add(enemiesSubsystemController);
            updateController.Add(cameraController);
            updateController.Add(waterPoolsAnimationController);
            updateController.Add(coinsSubsystemController);
            updateController.Add(teleportController);
            updateController.Add(endLevelPortalsController);
            updateController.Add(questsController);
        }
    }
}