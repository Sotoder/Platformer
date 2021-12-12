using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class PlayerInitModel
    {
        [SerializeField] private SpriteAnimatorConfig _playerAnimatorConfig;
        [SerializeField] private LevelObjectsView _playerView;
        [SerializeField] private PlayerModelConfig _playerModelConfig;

        public SpriteAnimatorConfig PlayerAnimatorConfig { get => _playerAnimatorConfig; }
        public LevelObjectsView PlayerView { get => _playerView; }
        public PlayerModelConfig PlayerModelConfig { get => _playerModelConfig; }
    }
}