using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class PlayerInitModel
    {
        [SerializeField] private SpriteAnimatorConfig _playerAnimatorConfig;
        [SerializeField] private LevelObjectsView _playerView;
        [SerializeField] private float _speed;
        [SerializeField] private float _force;
        [SerializeField] private float _animationSpeed;

        public SpriteAnimatorConfig PlayerAnimatorConfig { get => _playerAnimatorConfig; }
        public LevelObjectsView PlayerView { get => _playerView; }
        public float Speed { get => _speed; }
        public float Force { get => _force; }
        public float AnimationSpeed { get => _animationSpeed; }
    }
}