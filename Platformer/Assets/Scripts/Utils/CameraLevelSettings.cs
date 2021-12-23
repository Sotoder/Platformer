using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class CameraLevelSettings
    {
        [SerializeField] Levels level;
        [SerializeField] float _maxLeftOffset;
        [SerializeField] float _maxRightOffset;

        public float MaxLeftOffset { get => _maxLeftOffset; }
        public float MaxRightOffset { get => _maxRightOffset; }
        public Levels Level { get => level; }
    }
}