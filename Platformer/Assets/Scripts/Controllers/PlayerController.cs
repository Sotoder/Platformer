using UnityEngine;

namespace Platformer
{
    public class PlayerController: IUpdateble, IFixedUpdateble
    {
        private LevelObjectsView _playerView;
        private PlayerModel _playerModel;
        private SpriteAnimatorController _playerAnimatorController;
        private InputController _inputController;
        private MoveImplementation _moveImplementation;

        public PlayerController(PlayerInitModel playerInitModel, InputController inputController)
        {
            _playerView = playerInitModel.PlayerView;
            _inputController = inputController;

            _playerModel = new PlayerModel(playerInitModel.Speed, playerInitModel.Force, playerInitModel.AnimationSpeed);

            _moveImplementation = new MoveImplementation(_playerModel.Speed, _playerView.Rigidbody2D, _playerModel.Force);

            _playerAnimatorController = new SpriteAnimatorController(playerInitModel.PlayerAnimatorConfig);

            _playerAnimatorController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true, _playerModel.AnimationSpeed);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if(_inputController.horizontal != 0)
            {
                CheckAndSetScale(_inputController.horizontal);

                if (_playerAnimatorController.ActiveAnimation[_playerView.SpriteRenderer].Track != AnimState.Run)
                {
                    StartRunAnimation();
                }

                _moveImplementation.Move(_inputController.horizontal, fixedDeltaTime);
            }
            else
            {
                _playerAnimatorController.StopAnimation(_playerView.SpriteRenderer);
                _playerAnimatorController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true, _playerModel.AnimationSpeed);
            }

        }

        private void CheckAndSetScale(float inputValue)
        {
            if (_playerView.transform.localScale.x < 0 && inputValue > 0) _playerView.transform.localScale = new Vector3(1f, 1f, 1f);
            else if (_playerView.transform.localScale.x > 0 && inputValue < 0) _playerView.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        private void StartRunAnimation()
        {
            _playerAnimatorController.StopAnimation(_playerView.SpriteRenderer);
            _playerAnimatorController.StartAnimation(_playerView.SpriteRenderer, AnimState.Run, true, _playerModel.AnimationSpeed);
        }

        public void Update(float deltaTime)
        {
            _playerAnimatorController.Update(deltaTime);      
        }
    }
}