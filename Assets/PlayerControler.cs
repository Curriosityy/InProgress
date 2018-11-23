using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum Direction
{
    left,
    right
}

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    private Direction direction;
    private int jumpCounter;
    public int maxJumpCount;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    // Use this for initialization
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Wall")
        {
            jumpCounter = 0;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (direction == Direction.left)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                direction = Direction.right;
            }
            else
            {
                rb.AddForce(Vector2.right * speed);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (direction == Direction.right)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                direction = Direction.left;
            }
            else
            {
                rb.AddForce(Vector2.left * speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && jumpCounter < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCounter++;
        }
    }
}