using UnityEngine;

public class BiDirectionalHinge : MonoBehaviour
{
    public float MinAngle = -180f;
    public float MaxAngle = 180f;
    public float Elasticity = 10f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float currentAngle = transform.eulerAngles.z;
        currentAngle = (currentAngle > 180f) ? currentAngle - 360f : currentAngle;

        if (currentAngle < MinAngle || currentAngle > MaxAngle)
        {
            _rigidbody.rotation = Mathf.Clamp(currentAngle, MinAngle, MaxAngle);
            _rigidbody.angularVelocity = 0;
        }
        else
        {
            float restoringForce = -Elasticity * currentAngle - _rigidbody.angularVelocity;
            _rigidbody.AddTorque(restoringForce);
        }
    }
}