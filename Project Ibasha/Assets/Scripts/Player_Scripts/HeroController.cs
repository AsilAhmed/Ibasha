using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed = 1f;
    public float jump_speed = 5f;
    public float timedelay = 0.5f;
    public float Radius;
    public float movement;
    Rigidbody2D rb;
    public Transform groundcheckpoint;
    public LayerMask groundlayer;
    bool isTouchingground;
    public Animator anim;
    public Vector3 respawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawn = transform.position;
    }

    void Update()
    {
        // This variable contains the state of Player whether he is touching ground or not
        isTouchingground = Physics2D.OverlapCircle(groundcheckpoint.position, Radius, groundlayer);
        
        // Movement Contains The Value of IBASHA in X-Axis
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // Changing the velocity of Player acording to time and speed To create the effectv of movement
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        
        // Jumping Condition
        if (Input.GetButtonDown("Jump") && isTouchingground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
        //Playing animations of Running and Jumping

        anim.SetFloat("Movement", Mathf.Abs(rb.velocity.x));
        anim.SetBool("OnGround", isTouchingground);

    }
}
