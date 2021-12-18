namespace Platformer
{
    internal class EnemiesController: IUpdateble
    {
        private FlyEnemiesController _flyEnemiesController;

        public EnemiesController(FlyEnemiesInitModel flyEnemiesInitModel)
        {
            _flyEnemiesController = new FlyEnemiesController(flyEnemiesInitModel);
        }

        public void Update(float deltaTime)
        {
            _flyEnemiesController.Update(deltaTime);
        }
    }
}