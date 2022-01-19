using System;

namespace Platformer
{
    public class PlayerStateController
    {
        private PlayerModel _playerModel;
        private PlayerViewController _playerViewController;
        private InputController _inputController;
        private PlayerView _playerView;

        private StayState _stayState;
        private RunState _runState;
        private JumpState _jumpState;
        private FallState _fallState;

        public PlayerStateController(PlayerModel playerModel, InputController inputController, PlayerViewController playerViewController, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerViewController = playerViewController;
            _inputController = inputController;
            _playerView = playerView;

            _stayState = new StayState();
            _runState = new RunState();
            _jumpState = new JumpState();
            _fallState = new FallState();

            _playerModel.CurentState = _stayState;
        }

        public void Update()
        {
            if (_playerModel.IsOnGround)
            {
                if (_inputController.horizontal != 0)
                {
                    if (_playerModel.CurentState == _runState) return;
                    _runState.OnStateEnter(_playerViewController);
                    _playerModel.CurentState = _runState;

                }
                else if (_inputController.horizontal == 0)
                {
                    if (_playerModel.CurentState == _stayState) return;
                    _stayState.OnStateEnter(_playerViewController);
                    _playerModel.CurentState = _stayState;
                }
            } else
            {
                if(_playerView.Rigidbody2D.velocity.y > 0)
                {
                    if (_playerModel.CurentState == _jumpState) return;
                    _jumpState.OnStateEnter(_playerViewController);
                    _playerModel.CurentState = _jumpState;
                } 
                else
                {
                    if (_playerModel.CurentState == _fallState) return;
                    _fallState.OnStateEnter(_playerViewController);
                    _playerModel.CurentState = _fallState;
                }
            }
        }
    }
}