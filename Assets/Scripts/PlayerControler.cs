using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControler : MonoBehaviour
{
    public SpriteRenderer sprite2;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;
    private bool isOnWall = false;
    private bool isGrounded = true;

    public float speed;
    public float jumpForce;
    public float movementSmoothing = 0.05f;
    public bool isAlive = true;
    public Vector2 boxSize;
    private Vector2 rotated;

    [Header("Checkers")]
    [Space]
    public Transform grounChecker;

    public Transform leftWallChecker;
    public Transform rightWallChecker;

    [Header("Layers")]
    [Space]
    public LayerMask whatIsGround;

    public LayerMask whatIsWall;

    [Header("Events")]
    [Space]
    public UnityEvent onLandEvent;

    public UnityEvent onWallEvent;

    public UnityEvent onDeadEvent;

    // Use this for initialization
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isAlive = true;
        if (onLandEvent == null)
        {
            onLandEvent = new UnityEvent();
        }
        if (onWallEvent == null)
        {
            onWallEvent = new UnityEvent();
        }
        if (onDeadEvent == null)
        {
            onDeadEvent = new UnityEvent();
        }
        rotated = new Vector2(boxSize.y, boxSize.x);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(grounChecker.transform.position, boxSize);
        Gizmos.DrawWireCube(leftWallChecker.transform.position, rotated);
        Gizmos.DrawWireCube(rightWallChecker.transform.position, rotated);
    }

    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        bool wasOnWall = isOnWall;
        isGrounded = false;
        isOnWall = false;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(grounChecker.position, boxSize, 0, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            isGrounded = true;
            if (!wasGrounded && ((Mathf.Sign(rb.velocity.y) == Mathf.Sign(Physics2D.gravity.y)) || rb.velocity.y == 0))
            {
                Debug.Log("l");
                onLandEvent.Invoke();
            }
        }
        colliders = Physics2D.OverlapBoxAll(leftWallChecker.position, rotated, 0, whatIsWall);
        for (int i = 0; i < colliders.Length; i++)
        {
            isOnWall = true;
            if (!wasOnWall)
            {
                onWallEvent.Invoke();
            }
        }
        colliders = Physics2D.OverlapBoxAll(rightWallChecker.position, rotated, 0, whatIsWall);
        for (int i = 0; i < colliders.Length; i++)
        {
            isOnWall = true;
            if (!wasOnWall)
            {
                onWallEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if (isAlive)
        {
            Vector2 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
            if (jump)
            {
                Debug.Log("JUMP2");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }
    }

    public void Die()
    {
        isAlive = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        sprite2.enabled = false;
        onDeadEvent.Invoke();
        Destroy(gameObject, 3f);
    }
}