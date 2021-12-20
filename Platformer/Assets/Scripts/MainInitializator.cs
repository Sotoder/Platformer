namespace Platformer
{
    public class MainInitializator
    {

        public MainInitializator(MainUpdateController updateController, GameInitModel gameInitModel)
        {
            var waterPoolsAnimationController = new WaterPoolsAnimationController(gameInitModel.WaterInitModel);
            var coinsAnimationController = new CoinsAnimationController(gameInitModel.CoinsInitModel);

            var triggerController = new TriggerController(gameInitModel.PlayerInitModel.PlayerView)
                                                 .AddAnimatedObjects(coinsAnimationController, gameInitModel.CoinsInitModel.CoinsRenderers);

            var inputController = new InputController();
            var playerController = new PlayerController(gameInitModel.PlayerInitModel, inputController, triggerController);
            var enemiesSubsystemController = new EnemiesSubsystemController(gameInitModel.FlyEnemiesInitModel);
            var cameraController = new CameraController(gameInitModel.PlayerInitModel.PlayerView, gameInitModel.CameraInitModel);

            updateController.Add(inputController);
            updateController.Add(playerController);
            updateController.Add(enemiesSubsystemController);
            updateController.Add(cameraController);
            updateController.Add(waterPoolsAnimationController);
            updateController.Add(coinsAnimationController);
        }
    }
}