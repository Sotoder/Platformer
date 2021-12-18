using System.Collections.Generic;

namespace Platformer
{
    public class FlyEnemiesController
    {
        private List<FlyEnemyController> _flyEnemyControllers = new List<FlyEnemyController>();
        private FlyEnemiesControllerFactory _enemiesFactory;

        public FlyEnemiesController(FlyEnemiesInitModel flyEnemiesInitModel)
        {
            _enemiesFactory = new FlyEnemiesControllerFactory();

            for (int i = 0; i < flyEnemiesInitModel.FlyEnemyInitModels.Count; i++)
            {
                var flyEnemyController = _enemiesFactory.Create(flyEnemiesInitModel.FlyEnemyInitModels[i]);
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