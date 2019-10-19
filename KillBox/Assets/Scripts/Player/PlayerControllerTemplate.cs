using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTemplate : MonoBehaviour
{

    public float moveSpeed;

    bool grounded;
    bool facing_right;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //For movement
        float threshold = 0.5f;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal") )> threshold ||  Mathf.Abs(Input.GetAxisRaw("Vertical")) > threshold)
                anim.SetBool("Moving", true);
            else
                anim.SetBool("Moving", false);

        if (Input.GetAxisRaw("Horizontal") > threshold)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (!facing_right)
                Flip();
        }
        else if (Input.GetAxisRaw("Horizontal") < -threshold)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (facing_right)
                Flip();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > threshold)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") < -threshold)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        //For setting rotation
        if (facing_right)
        {
            sprite.flipX = false;
        }
        else if (!facing_right)
        {
            sprite.flipX = true;
        }
    }

    void Flip()
    {
        facing_right = !facing_right;
    }
}
