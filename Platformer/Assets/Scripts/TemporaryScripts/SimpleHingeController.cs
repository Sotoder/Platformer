using UnityEngine;

public class SimpleHingeController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _hingeJoint2;
    private bool _isInLimit;

    private void FixedUpdate()
    {
        if((_hingeJoint2.jointAngle <= _hingeJoint2.limits.max || _hingeJoint2.jointAngle >= _hingeJoint2.limits.min) && !_isInLimit)
        {
            var motor = _hingeJoint2.motor;
            motor.motorSpeed = _hingeJoint2.motor.motorSpeed * -1;
            _hingeJoint2.motor = motor;
            _isInLimit = true;
        }
        else 
        {
            _isInLimit = false;
        }
    }
}
