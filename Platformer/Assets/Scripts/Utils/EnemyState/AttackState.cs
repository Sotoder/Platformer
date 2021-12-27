namespace Platformer
{
    public class AttackState : IEnemyState
    {
        private bool _isOnAttack;
        private bool _isOnPatrol;

        public bool IsOnAttack { get => _isOnAttack; }
        public bool IsOnPatrol { get => _isOnPatrol; }

        public AttackState()
        {
            _isOnAttack = true;
            _isOnPatrol = false;
        }
    }
}