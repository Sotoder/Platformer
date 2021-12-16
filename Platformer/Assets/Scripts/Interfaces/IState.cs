namespace Platformer
{
    public interface IState
    {
        public bool IsJump { get; }
        public bool IsStay { get; }
        public bool IsRun { get; }

        public void OnStateEnter(PlayerViewController playerViewController, float animationSpeed);
    }
}