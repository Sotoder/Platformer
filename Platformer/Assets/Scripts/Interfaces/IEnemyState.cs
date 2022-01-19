namespace Platformer
{
    public interface IEnemyState
    {
        public bool IsOnPatrol { get; }
        public bool IsOnAttack { get; }
    }
}