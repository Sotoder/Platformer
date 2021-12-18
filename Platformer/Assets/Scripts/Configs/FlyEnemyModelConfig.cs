using UnityEngine;
using System;

namespace Platformer
{
    [CreateAssetMenu(fileName = "FlyEnemyConfig", menuName = "Configs/FlyEnemy", order = 3)]
    [Serializable]
    public class FlyEnemyModelConfig: ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxOffset;
        [SerializeField] private float _twichAmplitude;
        [SerializeField] private float _twichSpeed;

        public float Speed { get => _speed; }
        public float MaxOffset { get => _maxOffset; }
        public float TwichAmplitude { get => _twichAmplitude; }
        public float TwichSpeed { get => _twichSpeed; }
    }
}