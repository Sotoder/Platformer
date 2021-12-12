namespace Platformer
{
    public class MainInitializator
    {

        public MainInitializator(MainUpdateController updateController, PlayerInitModel playerInitModel)
        {
            var inputController = new InputController();
            var playerController = new PlayerController(playerInitModel, inputController);

            updateController.Add(inputController);
            updateController.Add(playerController);
        }
    }
}