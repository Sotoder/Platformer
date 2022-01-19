using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerView : LevelObjectsView
    {
        public event Action<Collider2D> FoundTriggerObject = delegate (Collider2D collider2D) { }; 

        [SerializeField] GameObject _groundDetector;
        [SerializeField] LayerMask _groundMask;
        [SerializeField] float _groundDetectorRadius;

        public GameObject GroundDetector { get => _groundDetector; }
        public LayerMask GroundMask { get => _groundMask; }
        public float GroundDetectorRadius { get => _groundDetectorRadius; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            FoundTriggerObject.Invoke(collision); 
        }
    }
}
