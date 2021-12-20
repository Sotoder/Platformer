using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class CameraLevelSettings
    {
        [SerializeField] int _levelID;
        [SerializeField] float _maxLeftOffset;
        [SerializeField] float _maxRightOffset;

        public float MaxLeftOffset { get => _maxLeftOffset; }
        public float MaxRightOffset { get => _maxRightOffset; }
        public int LevelID { get => _levelID; }
    }
}