using System;
using UnityEngine;

namespace Platformer
{
    public class InputController : IUpdateble
    {
        public float horizontal;

        private const string HORIZONTAL = "Horizontal";

        public void Update(float deltaTime)
        {
            horizontal = Input.GetAxis(HORIZONTAL);
        }
    }
}