using UnityEngine;

namespace Platformer
{
    public interface IEnemyView
    {
        public Transform Transform { get; set; }
        public SpriteRenderer SpriteRenderer { get; }
        public Collider2D Collider2D { get; }
        public Rigidbody2D Rigidbody2D { get; }
    }
}