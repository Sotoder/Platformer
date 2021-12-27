using UnityEngine;

namespace Platformer
{
    public class FlyEnemyModel: IEnemyModel
    {
        public float Speed { get; set; }
        public Vector2 CurentPosition { get; set; }
        public IEnemyState CurentState { get; set; }
        public Transform TargetTransform { get; set; }

        private float _maxOffset;
        private Vector2 _startPosition;
        private float _twichSpeed;
        private float _twichAmpletude;

        public float MaxOffset { get => _maxOffset; }
        public Vector2 StartPosition { get => _startPosition; }
        public float TwichSpeed { get => _twichSpeed; }
        public float TwichAmpletude { get => _twichAmpletude; }

        public FlyEnemyModel(FlyEnemyModelConfig flyEnemyConfig, Vector2 position)
        {
            Speed = flyEnemyConfig.Speed;
            CurentPosition = position;
            _maxOffset = flyEnemyConfig.MaxOffset;
            _startPosition = position;
            _twichAmpletude = flyEnemyConfig.TwichAmplitude;
            _twichSpeed = flyEnemyConfig.TwichSpeed;
        }
    }
}