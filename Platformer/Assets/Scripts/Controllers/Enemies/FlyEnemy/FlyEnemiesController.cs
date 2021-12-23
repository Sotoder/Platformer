using System.Collections.Generic;

namespace Platformer
{
    public class FlyEnemiesController
    {
        private List<FlyEnemyController> _flyEnemyControllers = new List<FlyEnemyController>();

        public FlyEnemiesController(FlyEnemiesProtoModel flyEnemiesInitModel)
        {
            var enemyControllersFactory = new FlyEnemiesControllerFactory();

            for (int i = 0; i < flyEnemiesInitModel.FlyEnemyInitModels.Count; i++)
            {
                var flyEnemyController = enemyControllersFactory.Create(flyEnemiesInitModel.FlyEnemyInitModels[i]);
                _flyEnemyControllers.Add(flyEnemyController);
            }
        }

        public void Update(float deltaTime)
        {
            for(int i = 0; i < _flyEnemyControllers.Count; i++)
            {
                _flyEnemyControllers[i].Update(deltaTime);
            }
        }
    }
}