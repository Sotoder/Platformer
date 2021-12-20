namespace Platformer
{
    public class StayState : IState
    {
        private bool _isStay;
        private bool _isRun;
        private bool _isJump;
        private bool _isFall;

        public StayState()
        {
            _isStay = true;
            _isRun = false;
            _isJump = false;
            _isFall = false;
        }

        public bool IsStay { get => _isStay; }
        public bool IsRun { get => _isRun; }
        public bool IsJump { get => _isJump; }
        public bool IsFall { get => _isFall; }

        public void OnStateEnter(PlayerAnimationController playerViewController)
        {
            playerViewController.ChangeAnimation(AnimState.Idle);
        }
    }
}