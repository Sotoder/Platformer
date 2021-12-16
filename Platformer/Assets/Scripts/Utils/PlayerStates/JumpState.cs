namespace Platformer
{
    public class JumpState : IState
    {
        private bool _isStay;
        private bool _isRun;
        private bool _isJump;

        public JumpState()
        {
            _isStay = false;
            _isRun = false;
            _isJump = true;
        }

        public bool IsStay { get => _isStay; }
        public bool IsRun { get => _isRun; }
        public bool IsJump { get => _isJump; }

        public void OnStateEnter(PlayerViewController playerViewController, float animationSpeed)
        {
            playerViewController.ChangeAnimation(animationSpeed, AnimState.Jump);
        }
    }
}