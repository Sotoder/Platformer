namespace Platformer
{
    public interface IState
    {
        public bool IsJump { get; }
        public bool IsStay { get; }
        public bool IsRun { get; }
        public bool IsFall { get; }

        public void OnStateEnter(PlayerAnimationController playerViewController);
    }
}