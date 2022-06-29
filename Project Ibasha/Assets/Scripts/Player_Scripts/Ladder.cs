using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    private float VerticalMovement;     // For vertical movement of player on ladder
    private float ClimbSpeed = 5f;      // Climbing speed of player on ladder
    private bool IsClimbing;            // Checking whether player is climbing or not
    private bool IsLadder;              // Checking whether there is a ladder or not 

    [SerializeField] private Rigidbody2D rgb;


    // Update is called once per frame
    void Update()
    {
        // If player press UP key or W which are default keys for vertical movement where value resides between 1 and -1
        VerticalMovement = Input.GetAxis("Vertical");

        if (IsLadder && VerticalMovement > 0)
        {
            IsClimbing = true;      // So player is trying to climb on the ladder 
        }
    }

    private void FixedUpdate()
    {
        if (IsClimbing)
        {
            Debug.Log(rgb.gravityScale);
            rgb.gravityScale = 0f;
            rgb.velocity = new Vector2(rgb.velocity.x, ClimbSpeed * VerticalMovement);
        }
        else
        {
            rgb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            IsLadder = true;
            Debug.Log("Colliding with ladder");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            IsLadder = false;
            IsClimbing = false;
        }
    }

}
