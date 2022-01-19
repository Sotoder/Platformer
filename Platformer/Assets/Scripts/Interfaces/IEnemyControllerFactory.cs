namespace Platformer
{
    public interface IEnemyControllerFactory<T>
    {
        public T Create(IEnemyInitModel enemyInitModel);
    }
}