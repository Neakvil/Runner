using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class COntroll : MonoBehaviour
{
    public float speed = 4.0f;
    public float jump = 1.0f;
    Rigidbody2D PlayerRGB;
    Animator charAnimator;
    SpriteRenderer sprite;
    bool OnGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisground;

    private void Awake()
    {
        PlayerRGB = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    public void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        if (tempvector.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Chest")
            {
            _open = true;
            }
            Debug.Log(other.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Chest")
        {
            _open = false;
        }
        Debug.Log(other.tag);
    }

    public void Jump()
    {
        /*PlayerRGB.AddForce(transform.up*jump, ForceMode2D.Impulse);*/
    }

    /*void Ground()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        OnGround = colliders.Length > 0.3;
        Debug.Log(colliders.Length);
    }*/

    private void FixedUpdate()
    {
        /*Ground();*/
        OnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisground);
    }

    private bool _open = false;

    void Update()
{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            charAnimator.SetInteger("Stan", 3);
        }

        if (Input.GetButton("Horizontal"))
        {
            Move();
            charAnimator.SetInteger("Stan", 1);
        }

        else
        {
            charAnimator.SetInteger("Stan", 0);
        }

        /*if (Input.GetButton("Jump"))
        {*/
            /*Jump();*/
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(OnGround == true)
                {
                PlayerRGB.velocity = Vector2.up * jump;
                charAnimator.SetInteger("Stan", 2);
                }
            }
    }
}
