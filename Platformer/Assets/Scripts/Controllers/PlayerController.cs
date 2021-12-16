using System;
using UnityEngine;

namespace Platformer
{
    public class PlayerController: IUpdateble, IFixedUpdateble, IDisposable
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;

        private SpriteAnimatorController _playerAnimatorController;
        private PlayerStateController _playerStateController;
        private PlayerGroundDetector _playerGroundDetector;
        private PlayerViewController _playerViewController;

        private InputController _inputController;
        private MoveImplementation _moveImplementation;


        public PlayerController(PlayerInitModel playerInitModel, InputController inputController)
        {
            _playerView = playerInitModel.PlayerView;
            _playerModel = new PlayerModel(playerInitModel.PlayerModelConfig);

            _playerAnimatorController = new SpriteAnimatorController(playerInitModel.PlayerAnimatorConfig);
            _playerAnimatorController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true, _playerModel.AnimationSpeed);

            _playerViewController = new PlayerViewController(_playerView, _playerAnimatorController);
            _playerStateController = new PlayerStateController(_playerModel, inputController, _playerViewController);
            _playerGroundDetector = new PlayerGroundDetector(_playerModel, _playerView);
            _moveImplementation = new MoveImplementation(_playerModel.Speed, _playerView.Rigidbody2D, _playerModel.Force);

            _inputController = inputController;
            _inputController.ButtonJumpPressed += Jump;
            _inputController.MoveButtonUp += Stop;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if(_inputController.horizontal != 0)
            {
                _playerViewController.CheckAndSetScale(_inputController.horizontal);
                _moveImplementation.Move(_inputController.horizontal, fixedDeltaTime);
            }
        }

        private void Jump()
        {
            if (_playerModel.CurentState.IsJump) return;
            _moveImplementation.Jump();
        }

        private void Stop()
        {
            _moveImplementation.Stop();
        }

        public void Update(float deltaTime)
        {
            _playerAnimatorController.Update(deltaTime);
            _playerStateController.Update();
            _playerGroundDetector.Update();
        }

        public void Dispose()
        {
            _inputController.ButtonJumpPressed -= Jump;
            _inputController.MoveButtonUp -= Stop;
        }
    }
}