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
        private TriggerController _triggerController;
        private MoveImplementation _moveImplementation;

        public IPlayerDataForQuests PlayerDataForQuests { get => _playerModel; }

        public PlayerController(PlayerProtoModel playerInitModel, InputController inputController, TriggerController triggerController)
        {
            _playerView = playerInitModel.PlayerView;
            _playerModel = new PlayerModel(playerInitModel.PlayerModelConfig);

            _playerAnimatorController = new SpriteAnimatorController(playerInitModel.PlayerAnimatorConfig);
            _playerViewController = new PlayerViewController(_playerView, _playerAnimatorController);
            _playerViewController.ChangeAnimation(AnimState.Idle);

            _playerStateController = new PlayerStateController(_playerModel, inputController, _playerViewController, _playerView);
            _playerGroundDetector = new PlayerGroundDetector(_playerModel, _playerView);
            _moveImplementation = new MoveImplementation(_playerModel.Speed, _playerView.Rigidbody2D, _playerModel.Force, _playerModel.JumpForce, _playerModel.SprintModifier);

            _inputController = inputController;
            _inputController.ButtonJumpPressed += Jump;
            _inputController.MoveButtonUp += Stop;
            _inputController.SprintButtonDown += SprintOn;
            _inputController.SprintButtonUp += SprintOff;
            _inputController.ButtonDownPressed += Down;

            _triggerController = triggerController;
            _triggerController.GetCoin += AddScore;
            _triggerController.Teleportation += TeleportPlayer;
        }

        private void Down()
        {
            _playerViewController.GoDown();
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if(_inputController.horizontal != 0)
            {
                _playerViewController.CheckAndSetScale(_inputController.horizontal);
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

        private void TeleportPlayer(int xOffset, Vector2 teleportPosition)
        {
            _playerViewController.Teleport(xOffset, teleportPosition);
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