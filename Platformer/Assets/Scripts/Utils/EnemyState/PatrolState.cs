namespace Platformer
{
    public class PatrolState : IEnemyState
    {
        private bool _isOnAttack;
        private bool _isOnPatrol;

        public bool IsOnAttack { get => _isOnAttack; }
        public bool IsOnPatrol { get => _isOnPatrol; }

        public PatrolState ()
        {
            _isOnAttack = false;
            _isOnPatrol = true;
        }
    }
}