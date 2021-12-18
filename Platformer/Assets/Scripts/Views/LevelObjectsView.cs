using System;
using UnityEngine;

namespace Platformer
{
    public abstract class LevelObjectsView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Transform Transform { get => _transform; set => _transform = value; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        public Collider2D Collider2D { get => _collider2D; }
        public Rigidbody2D Rigidbody2D { get => _rigidbody2D; }
    }
}