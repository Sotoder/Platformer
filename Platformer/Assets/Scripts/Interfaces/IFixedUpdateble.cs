namespace Platformer
{
    public interface IFixedUpdateble: IController
    {
        public void FixedUpdate(float fixedDeltaTime);
    }
}