using UnityEngine;

public class TestbedPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float hor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
        Application.targetFrameRate = 60;
        Time.fixedDeltaTime = 1f / 60f;
    }

    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");

        if( hor != 0 )
        {
            rb.AddForce( Vector2.right * hor * 10);
            if(rb.velocity.x > 5) rb.velocity = new Vector2(5, rb.velocity.y);
            if(rb.velocity.x < -5) rb.velocity = new Vector2(-5, rb.velocity.y);
        }else{
            rb.AddForce( Vector2.right * -rb.velocity.x * 5);
        }
    }
}