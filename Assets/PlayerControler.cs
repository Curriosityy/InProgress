using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    left,
    right
}

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;
    private int jumpCounter;
    public int maxJumpCount;
    public float gravMultipler = 4f;
    private float skyRotation = 0;
    public float maxSpeed;
    public Direction direction;
    private bool grounded = true;
    private Vector2 velocity;
    public float movementSmoothing = 0.05f;
    private float moveDir;
    private bool isJumping;

    // Use this for initialization
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move(moveDir * Time.fixedDeltaTime, isJumping);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            jumpCounter = 0;
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void Move(float move, bool jump)
    {
        Vector2 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        if (jump && jumpCounter < maxJumpCount)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);
            jumpCounter++;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }
}