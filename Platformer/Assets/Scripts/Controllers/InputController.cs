using System;
using UnityEngine;

namespace Platformer
{
    public class InputController : IUpdateble
    {
        public event Action ButtonJumpPressed = delegate () { };
        public event Action MoveButtonUp = delegate () { };
        public float horizontal;

        private const string HORIZONTAL = "Horizontal";

        public void Update(float deltaTime)
        {
            horizontal = Input.GetAxis(HORIZONTAL);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ButtonJumpPressed.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                MoveButtonUp.Invoke();
            }
        }
    }
}