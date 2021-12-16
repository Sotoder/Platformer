using System;

namespace Platformer
{
    public class PlayerStateController
    {
        private PlayerModel _playerModel;
        private PlayerViewController _playerViewController;
        private InputController _inputController;

        private StayState _stayState;
        private RunState _runState;
        private JumpState _jumpState;

        public PlayerStateController(PlayerModel playerModel, InputController inputController, PlayerViewController playerViewController)
        {
            _playerModel = playerModel;
            _playerViewController = playerViewController;
            _inputController = inputController;

            _stayState = new StayState();
            _runState = new RunState();
            _jumpState = new JumpState();

            _playerModel.CurentState = _stayState;
        }

        public void Update()
        {
            if (_playerModel.IsOnGround)
            {
                if (_inputController.horizontal != 0)
                {
                    if (_playerModel.CurentState == _runState) return;
                    _runState.OnStateEnter(_playerViewController, _playerModel.AnimationSpeed);
                    _playerModel.CurentState = _runState;

                }
                else if (_inputController.horizontal == 0)
                {
                    if (_playerModel.CurentState == _stayState) return;
                    _stayState.OnStateEnter(_playerViewController, _playerModel.AnimationSpeed);
                    _playerModel.CurentState = _stayState;
                }
            } else
            {
                if (_playerModel.CurentState == _jumpState) return;
                _jumpState.OnStateEnter(_playerViewController, _playerModel.AnimationSpeed);
                _playerModel.CurentState = _jumpState;
            }
        }
    }
}