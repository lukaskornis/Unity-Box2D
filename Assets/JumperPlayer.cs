using UnityEngine;

public class JumperPlayer : MonoBehaviour
{
    public float jumpForce = 10;
    public int jumpFrames = 10;
    int jumpFramesLeft;
    Rigidbody2D rb;
    SliderJoint2D slider;
    Rigidbody2D footRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = GetComponent<SliderJoint2D>();
        footRb = slider.connectedBody;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            slider.useMotor = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            slider.useMotor = false;
        }
    }
}