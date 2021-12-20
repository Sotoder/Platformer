using UnityEngine;

namespace Platformer
{
    public class MoveImplementation
    {
        private Vector3 _direction;
        private float _speed;
        private float _force;
        private float _jumpForce;
        private Rigidbody2D _rigidbody;
        private float _sprintModifier;

        public MoveImplementation(float speed, Rigidbody2D rigidbody, float force, float jumpForce, float sprintModifier)
        {
            _speed = speed;
            _force = force;
            _jumpForce = jumpForce;
            _rigidbody = rigidbody;
            _sprintModifier = sprintModifier;
        }

        public void Move(float horizontal, float fixedDeltaTime, bool isSprint)
        {
            var normalizeInput = horizontal > 0 ? 1 : -1;
            var speed = 0f;

            if (isSprint)
            {
                speed = fixedDeltaTime * _speed * _sprintModifier;
            }
            else
            {
                speed = fixedDeltaTime * _speed;
            }

            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            _direction.Set(normalizeInput * speed, 0.0f, 0.0f);
            _rigidbody.AddForce(_direction * _force, ForceMode2D.Force);
        }

        public void Stop()
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        internal void Jump()
        {
            _rigidbody.AddForce(new Vector2(0, 1) * _jumpForce, ForceMode2D.Force);
        }
    }
}