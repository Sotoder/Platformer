namespace Platformer
{
    public class MainInitializator
    {

        public MainInitializator(MainUpdateController updateController, GameInitModel gameInitModel)
        {
            var inputController = new InputController();
            var playerController = new PlayerController(gameInitModel.PlayerInitModel, inputController);

            var enemiesController = new EnemiesController(gameInitModel.FlyEnemiesInitModel);

            updateController.Add(inputController);
            updateController.Add(playerController);
            updateController.Add(enemiesController);
        }
    }
}