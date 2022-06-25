using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
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
        isTouchingground = Physics2D.OverlapCircle(groundcheckpoint.position, Radius, groundlayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isTouchingground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
    }
}
