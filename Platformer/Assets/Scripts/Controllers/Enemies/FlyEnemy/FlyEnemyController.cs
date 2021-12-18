using UnityEngine;

namespace Platformer
{
    public class FlyEnemyController
    {
        private FlyEnemyModel _enemyModel;
        private IEnemyView _enemyView;

        public FlyEnemyController(IEnemyInitModel flyEnemyInitModel, IEnemyView enemyView)
        {
            _enemyView = enemyView;
            _enemyModel = new FlyEnemyModel(flyEnemyInitModel.FlyEnemyConfig, _enemyView.Transform.position);
        }

        public void Update(float deltaTime)
        {
            EnemyMove(deltaTime);
        }

        private void EnemyMove(float deltaTime)
        {
            ChangeTransform(deltaTime);
            UpdateView();
        }

        private void UpdateView()
        {
            _enemyView.Transform.position = _enemyModel.CurentPosition;
        }

        private void ChangeTransform(float deltaTime)
        {
            var moveDistance = Vector2.Distance(_enemyModel.StartPosition, _enemyView.Transform.position);
            if(Mathf.Abs(moveDistance) >= _enemyModel.MaxOffset)
            {
                _enemyModel.Speed *= -1;
            }
            var xPosition = _enemyModel.CurentPosition.x + _enemyModel.Speed * deltaTime;
            var yPosition = _enemyModel.StartPosition.y + Mathf.Sin(Time.fixedTime * _enemyModel.TwichSpeed) * _enemyModel.TwichAmpletude;
            _enemyModel.CurentPosition = new Vector2 (xPosition, yPosition);
        }
    }
}