using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Necessary for physics & animations
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    // Variables to play with
    public float speed = 4.0f;
    private float horizMovement;

    private void Start()
    {
        // Define the game obj on player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Handles input for physics
    private void Update()
    {
        // Check if player has input movement 
        horizMovement = Input.GetAxisRaw("Horizontal");
    }

    // Handles running the physics
    private void FixedUpdate()
    {
        // Move player left & right
        rb2D.linearVelocity = new Vector2(horizMovement * speed, rb2D.linearVelocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    // Flipping function
    private void Flip(float horizontal)
    {
        if ((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
