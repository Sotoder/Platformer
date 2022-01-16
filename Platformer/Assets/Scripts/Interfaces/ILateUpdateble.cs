namespace Platformer
{
    public interface ILateUpdateble: IController
    {
        public void LateUpdate(float deltaTime);
    }
}