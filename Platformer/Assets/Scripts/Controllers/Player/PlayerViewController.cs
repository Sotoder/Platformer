using System;
using UnityEngine;

namespace Platformer
{
    public class PlayerViewController
    {
        private PlayerView _playerView;
        private SpriteAnimatorController _playerAnimatorController;

        public PlayerViewController(PlayerView playerView, SpriteAnimatorController playerAnimatorController)
        {
            _playerView = playerView;
            _playerAnimatorController = playerAnimatorController;
        }


        public void CheckAndSetScale(float inputValue)
        {
            if (_playerView.Transform.localScale.x < 0 && inputValue > 0) _playerView.Transform.localScale = new Vector3(1f, 1f, 1f);
            else if (_playerView.Transform.localScale.x > 0 && inputValue < 0) _playerView.Transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        public void ChangeAnimation(AnimState animState)
        {
            _playerAnimatorController.StopAnimation(_playerView.SpriteRenderer);
            _playerAnimatorController.StartAnimation(_playerView.SpriteRenderer, animState, true);
        }

        public void Teleport(int xOffset, Vector2 teleportPosition)
        {
            _playerView.Transform.position = new Vector2(teleportPosition.x + xOffset, teleportPosition.y);
        }
    }
}