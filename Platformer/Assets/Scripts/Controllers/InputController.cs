using System;
using UnityEngine;

namespace Platformer
{
    public class InputController : IUpdateble
    {
        public event Action ButtonJumpPressed = delegate () { };
        public event Action ButtonDownPressed = delegate () { };
        public event Action MoveButtonUp = delegate () { };
        public event Action SprintButtonDown = delegate () { };
        public event Action SprintButtonUp = delegate () { };
        public float horizontal;

        private const string HORIZONTAL = "Horizontal";

        public void Update(float deltaTime)
        {
            horizontal = Input.GetAxis(HORIZONTAL);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ButtonJumpPressed.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                ButtonDownPressed.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                MoveButtonUp.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SprintButtonDown.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                SprintButtonUp.Invoke();
            }
        }
    }
}