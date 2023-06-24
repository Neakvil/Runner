using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float hspeed;
    float speedX;
    public float verticalimp;
    Rigidbody2D rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    
    public void LeftButtonDown()
    {
        speedX = -hspeed;
    }

    public void RightButtonDown()
    {
        speedX = hspeed;
    }

    public void Stop()
    {
        speedX = 0;
    }

    public void OneClicJump()
    {
        rb.AddForce(new Vector2(0, verticalimp), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        transform.Translate(speedX, 0, 0);
    }

    private void OnColisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
