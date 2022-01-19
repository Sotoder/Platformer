using UnityEngine;

namespace Platformer
{
    public interface IEnemyModel
    {
        public float Speed { get; set; }
        public Vector2 CurentPosition { get; set; }
        public Vector2 StartPosition { get; }
        public IEnemyState CurentState { get; set; }
        public Transform TargetTransform { get; set; }
    }
}