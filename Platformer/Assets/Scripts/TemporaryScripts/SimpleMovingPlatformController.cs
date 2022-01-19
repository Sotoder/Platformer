using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovingPlatformController : MonoBehaviour
{
    [SerializeField] private SliderJoint2D _sliderJoint;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float force = 5f;
    private bool _isInLimit;

    private void FixedUpdate()
    {
        if ((_sliderJoint.jointTranslation >= _sliderJoint.limits.max || _sliderJoint.jointTranslation <= _sliderJoint.limits.min) && !_isInLimit)
        {
            force *= -1;
            _rigidbody.AddForce(Vector2.one * force, ForceMode2D.Force);
            _isInLimit = true;
        }
        else
        {
            _isInLimit = false;
            _rigidbody.AddForce(Vector2.one * force, ForceMode2D.Force);
        }
    }
}
