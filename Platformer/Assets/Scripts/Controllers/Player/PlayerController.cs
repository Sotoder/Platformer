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
        private PlayerAnimationController _playerAnimationController;

        private InputController _inputController;
        private TriggerController _triggerController;
        private MoveImplementation _moveImplementation;


        public PlayerController(PlayerInitModel playerInitModel, InputController inputController, TriggerController triggerController)
        {
            _playerView = playerInitModel.PlayerView;
            _playerModel = new PlayerModel(playerInitModel.PlayerModelConfig);

            _playerAnimatorController = new SpriteAnimatorController(playerInitModel.PlayerAnimatorConfig);
            _playerAnimationController = new PlayerAnimationController(_playerView, _playerAnimatorController);
            _playerAnimationController.ChangeAnimation(AnimState.Idle);

            _playerStateController = new PlayerStateController(_playerModel, inputController, _playerAnimationController, _playerView);
            _playerGroundDetector = new PlayerGroundDetector(_playerModel, _playerView);
            _moveImplementation = new MoveImplementation(_playerModel.Speed, _playerView.Rigidbody2D, _playerModel.Force, _playerModel.JumpForce, _playerModel.SprintModifier);

            _inputController = inputController;
            _inputController.ButtonJumpPressed += Jump;
            _inputController.MoveButtonUp += Stop;
            _inputController.SprintButtonDown += SprintOn;
            _inputController.SprintButtonUp += SprintOff;

            _triggerController = triggerController;
            _triggerController.GetCoin += AddScore;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if(_inputController.horizontal != 0)
            {
                _playerAnimationController.CheckAndSetScale(_inputController.horizontal);
                _moveImplementation.Move(_inputController.horizontal, fixedDeltaTime, _playerModel.IsSprint);
            }
        }

        public void Update(float deltaTime)
        {
            _playerAnimatorController.Update(deltaTime);
            _playerStateController.Update();
            _playerGroundDetector.Update();
        }

        private void Jump()
        {
            if (!_playerModel.IsOnGround && _playerModel.CurrentCountAirJumps == 0) return;

            _moveImplementation.Jump();

            if (!_playerModel.IsOnGround)
            {
                _playerModel.CurrentCountAirJumps--;
            }
        }

        private void Stop()
        {
            _moveImplementation.Stop();
        }

        private void SprintOff()
        {
            _playerModel.IsSprint = false;
            _playerAnimatorController.ActiveAnimation[_playerView.SpriteRenderer].Speed /= _playerModel.SprintModifier;
        }

        private void SprintOn()
        {
            _playerModel.IsSprint = true;
            _playerAnimatorController.ActiveAnimation[_playerView.SpriteRenderer].Speed *= _playerModel.SprintModifier;
        }

        private void AddScore()
        {
            _playerModel.AddCoinsScore();
        }

        public void Dispose()
        {
            _inputController.ButtonJumpPressed -= Jump;
            _inputController.MoveButtonUp -= Stop;
            _inputController.SprintButtonDown -= SprintOn;
            _inputController.SprintButtonUp -= SprintOff;
            _triggerController.GetCoin -= AddScore;
        }
    }
}