using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerView : LevelObjectsView
    {
        [SerializeField] GameObject _groundDetector;
        [SerializeField] LayerMask _groundMask;
        [SerializeField] float _groundDetectorRadius;

        public GameObject GroundDetector { get => _groundDetector; }
        public LayerMask GroundMask { get => _groundMask; }
        public float GroundDetectorRadius { get => _groundDetectorRadius; }
    }
}
