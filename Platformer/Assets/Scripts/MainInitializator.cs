namespace Platformer
{
    public class MainInitializator
    {

        public MainInitializator(MainUpdateController updateController, GameInitModel gameInitModel)
        {
            var inputController = new InputController();
            var playerController = new PlayerController(gameInitModel.PlayerInitModel, inputController);
            var enemiesController = new EnemiesController(gameInitModel.FlyEnemiesInitModel);
            var waterPoolsController = new WaterPoolsController(gameInitModel.WaterInitModel);
            var cameraController = new CameraController(gameInitModel.PlayerInitModel.PlayerView, gameInitModel.CameraInitModel);


            updateController.Add(inputController);
            updateController.Add(playerController);
            updateController.Add(waterPoolsController);
            updateController.Add(enemiesController);
            updateController.Add(cameraController);
        }
    }
}