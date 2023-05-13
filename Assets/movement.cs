using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;

    private float vertical;

    private bool isFacingRight = true;

    [SerializeField] private float speed;

    [SerializeField] private float jumpingPower;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    
    [SerializeField] private LayerMask groundLayer;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        print(Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
}
