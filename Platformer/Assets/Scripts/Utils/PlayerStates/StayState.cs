namespace Platformer
{
    public class StayState : IState
    {
        private bool _isStay;
        private bool _isRun;
        private bool _isJump;

        public StayState()
        {
            _isStay = true;
            _isRun = false;
            _isJump = false;
        }

        public bool IsStay { get => _isStay; }
        public bool IsRun { get => _isRun; }
        public bool IsJump { get => _isJump; }

        public void OnStateEnter(PlayerViewController playerViewController, float animationSpeed)
        {
            playerViewController.ChangeAnimation(animationSpeed, AnimState.Idle);
        }
    }
}