namespace Platformer
{
    public class RunState : IState
    {
        private bool _isStay;
        private bool _isRun;
        private bool _isJump;
        private bool _isFall;

        public RunState()
        {
            _isStay = false;
            _isRun = true;
            _isJump = false;
            _isFall = false;
        }

        public bool IsStay { get => _isStay; }
        public bool IsRun { get => _isRun; }
        public bool IsJump { get => _isJump; }
        public bool IsFall { get => _isFall; }

        public void OnStateEnter(PlayerAnimationController playerViewController)
        {
            playerViewController.ChangeAnimation(AnimState.Run);
        }
    }
}