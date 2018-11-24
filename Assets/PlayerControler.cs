using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    left,
    right,
    none
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
    private Material sb;
    public float maxSpeed;
    private Direction direction;
    private bool grounded = true;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravMultipler - 1) * Time.deltaTime;
        }

        sb.SetFloat("_Rotation", skyRotation);
        skyRotation += rb.velocity.x / 10 * Time.deltaTime;
        skyRotation %= 360;
    }

    // Use this for initialization
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sb = RenderSettings.skybox;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            grounded = true;
            jumpCounter = 0;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(Options.keyBinding["right"]))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
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
        if (Input.GetKey(Options.keyBinding["left"]))
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
        if (Input.GetKeyDown(Options.keyBinding["jump"]) && jumpCounter < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCounter++;
            grounded = false;
        }
        if (!Input.GetKey(Options.keyBinding["right"]) && !Input.GetKey(Options.keyBinding["left"]) && !Input.GetKeyDown(Options.keyBinding["jump"]) && grounded)
        {
            direction = Direction.none;
            rb.velocity = Vector2.zero;
        }
    }
}