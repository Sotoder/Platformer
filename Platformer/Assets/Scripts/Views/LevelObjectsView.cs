using System;
using UnityEngine;

namespace Platformer
{
    public abstract class LevelObjectsView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider2D;
        public Rigidbody2D Rigidbody2D;
    }
}