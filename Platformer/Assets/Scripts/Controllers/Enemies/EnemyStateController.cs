using System;
using UnityEngine;

namespace Platformer
{
    public class EnemyStateController
    {
        private IEnemyModel _enemyModel;
        private AgroZone _agroZone;

        private PatrolState _patrolState;
        private AttackState _attackState;

        public EnemyStateController (IEnemyModel enemyModel)
        {
            _enemyModel = enemyModel;

            _patrolState = new PatrolState();
            _attackState = new AttackState();

            _enemyModel.CurentState = _patrolState;
        }

        public void SetPatrolState()
        {
            _enemyModel.CurentState = _patrolState;
        }

        public void SetAttackState()
        {
            _enemyModel.CurentState = _attackState;
        }
    }
}