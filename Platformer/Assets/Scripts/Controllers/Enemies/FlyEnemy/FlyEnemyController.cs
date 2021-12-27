using UnityEngine;

namespace Platformer
{
    public class FlyEnemyController
    {
        private FlyEnemyModel _enemyModel;
        private IEnemyView _enemyView;
        private EnemyStateController _enemyStateController;
        private AgroZone _agroZone;

        public FlyEnemyController(IEnemyInitModel flyEnemyInitModel, IEnemyView enemyView)
        {
            _enemyView = enemyView;
            _enemyModel = new FlyEnemyModel(flyEnemyInitModel.FlyEnemyConfig, _enemyView.Transform.position);
            _agroZone = flyEnemyInitModel.AgroZone;

            _enemyStateController = new EnemyStateController(_enemyModel);

            _agroZone.PlayerInZone += AttackPlayer;
            _agroZone.PlayerLeftZone += ReturnToPatrol;
        }

        private void ReturnToPatrol()
        {
            _enemyStateController.SetPatrolState();
            _enemyModel.TargetTransform = null;
        }

        private void AttackPlayer(Transform targetTransform)
        {
            _enemyStateController.SetAttackState();
            _enemyModel.TargetTransform = targetTransform;
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
            if (_enemyModel.CurentState.IsOnPatrol)
            {
                var moveDistance = Vector2.Distance(_enemyModel.StartPosition, _enemyView.Transform.position);
                if (Mathf.Abs(moveDistance) >= _enemyModel.MaxOffset)
                {
                    _enemyModel.Speed *= -1;
                }
                var xPosition = _enemyModel.CurentPosition.x + _enemyModel.Speed * deltaTime;
                var yPosition = _enemyModel.StartPosition.y + Mathf.Sin(Time.fixedTime * _enemyModel.TwichSpeed) * _enemyModel.TwichAmpletude;
                _enemyModel.CurentPosition = new Vector2(xPosition, yPosition);
            }
            else if (_enemyModel.CurentState.IsOnAttack)
            {
                var direction = (Vector2)_enemyModel.TargetTransform.position - _enemyModel.CurentPosition;

                var xPosition = _enemyModel.CurentPosition.x + Mathf.Abs(_enemyModel.Speed) * deltaTime * direction.x;
                var yPosition = _enemyModel.CurentPosition.y + Mathf.Abs(_enemyModel.Speed) * deltaTime * direction.y;
                _enemyModel.CurentPosition = new Vector2(xPosition, yPosition);
            }
        }
    }
}