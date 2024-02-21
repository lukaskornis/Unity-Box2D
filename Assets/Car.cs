using UnityEngine;

[ RequireComponent( typeof( Rigidbody2D ) ) ]
public class Car : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    WheelJoint2D frontWheel;
    WheelJoint2D backWheel;
    // visual center of mass
    public Transform centerOfMass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.centerOfMass = centerOfMass.localPosition;
    }
}