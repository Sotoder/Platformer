﻿using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player", order = 2)]
    public class PlayerModelConfig: ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _force;
        [SerializeField] private float _jumpForce;
        [SerializeField] private int _countAirJumps;
        [SerializeField] private float _animationSpeed;

        public float Speed { get => _speed; }
        public float Force { get => _force; }
        public float AnimationSpeed { get => _animationSpeed; }
        public float JumpForce { get => _jumpForce; }
        public int CountAirJumps { get => _countAirJumps; }
    }
}