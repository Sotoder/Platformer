using UnityEngine;

namespace Platformer
{
    public class FlyEnemiesControllerFactory: IEnemyControllerFactory<FlyEnemyController>
    {
        public FlyEnemyController Create(IEnemyInitModel enemyInitModel)
        {
            var enemy = Object.Instantiate(enemyInitModel.Prefab, enemyInitModel.SpawnPoint.transform.position, enemyInitModel.SpawnPoint.transform.rotation);
            var enemyView = enemy.GetComponent<IEnemyView>();
            enemyView.SpriteRenderer.sortingOrder = 5;

            return new FlyEnemyController(enemyInitModel, enemyView);
        }
    }
}