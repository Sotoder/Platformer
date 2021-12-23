using UnityEngine;

namespace Platformer
{
    public class MoveImplementation
    {
        private Vector3 _direction;
        private float _speed;
        private float _force;
        private Rigidbody2D _rigidbody;

        public float Speed { get => _speed; }

        public MoveImplementation(float speed, Rigidbody2D rigidbody, float force)
        {
            _speed = speed;
            _force = force;
            _rigidbody = rigidbody;
        }

        public void Move(float horizontal, float fixedDeltaTime)
        {
            var speed = fixedDeltaTime * Speed;
            _direction.Set(horizontal * speed, 0.0f, 0.0f);
            _rigidbody.velocity = _direction * speed * _force;
        }
    }
}