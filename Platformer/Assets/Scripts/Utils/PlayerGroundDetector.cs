using UnityEngine;

namespace Platformer
{
    internal class PlayerGroundDetector
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;

        public PlayerGroundDetector(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        private void GroundStateUpdate()
        {
            _playerModel.IsOnGround = Physics2D.OverlapCircle(_playerView.GroundDetector.transform.position, _playerView.GroundDetectorRadius, _playerView.GroundMask);
        }

        public void Update()
        {
            GroundStateUpdate();
        }
    }
}