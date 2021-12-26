namespace Platformer
{
    public class EnemiesSubsystemController: IUpdateble
    {
        private FlyEnemiesController _flyEnemiesController;

        public EnemiesSubsystemController(FlyEnemiesProtoModel flyEnemiesInitModel)
        {
            _flyEnemiesController = new FlyEnemiesController(flyEnemiesInitModel);
        }

        public void Update(float deltaTime)
        {
            _flyEnemiesController.Update(deltaTime);
        }
    }
}