using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControler : MonoBehaviour
{
    //public SpriteRenderer sprite2;
    private Rigidbody2D rb;

    private bool facingRight = true;

    private Vector2 velocity = Vector2.zero;
    private bool isOnWall = false;
    private bool isGrounded = true;
    private bool isFalling = false;
    public float speed;
    public float jumpForce;
    public float movementSmoothing = 0.05f;
    public bool isAlive = true;
    public Vector2 groundCheckerSize;
    public Vector2 wallCheckerSize;
    public SpriteRenderer playerSprite;

    [Header("Checkers")]
    [Space]
    public Transform grounChecker;

    public Transform leftWallChecker;
    public Transform rightWallChecker;

    [Header("Layers")]
    [Space]
    public LayerMask whatIsGround;

    public LayerMask whatIsWall;

    public LayerMask wallLayer;

    [Header("Events")]
    [Space]
    public UnityEvent onLandEvent;

    public UnityEvent onWallEvent;

    public UnityEvent onDeadEvent;

    public UnityEvent onGroundRun;

    public UnityEvent onJump;

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
        if (onGroundRun == null)
        {
            onGroundRun = new UnityEvent();
        }
        if (onJump == null)
        {
            onJump = new UnityEvent();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(grounChecker.transform.position, groundCheckerSize);
        Gizmos.DrawWireCube(leftWallChecker.transform.position, wallCheckerSize);
        Gizmos.DrawWireCube(rightWallChecker.transform.position, wallCheckerSize);
    }

    private void FixedUpdate()
    {
        bool wasFalling = isFalling;
        bool wasGrounded = isGrounded;
        bool wasOnWall = isOnWall;
        isGrounded = false;
        isOnWall = false;
        isFalling = true;
        if (Mathf.Sign(Physics2D.gravity.y) == Mathf.Sign(rb.velocity.y))
        {
            isFalling = true;
        }

        Collider2D[] colliders = Physics2D.OverlapBoxAll(grounChecker.position, groundCheckerSize, 0, wallLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            isGrounded = true;
            Debug.Log("bottom");
            if (!wasGrounded && wasFalling)
            {
                {
                    Debug.Log(".");
                    onLandEvent.Invoke();
                }
            }
        }
        colliders = Physics2D.OverlapBoxAll(rightWallChecker.position, wallCheckerSize, 0, wallLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("right");
            isOnWall = true;
            if (!wasOnWall && !wasGrounded)
            {
                Debug.Log("..");
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
            if (isGrounded && move != 0)
            {
                onGroundRun.Invoke();
            }
            if (jump)
            {
                Debug.Log("JUMP2");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce);
                onJump.Invoke();
                isGrounded = false;
                isFalling = false;
            }
            if (facingRight && move < 0)
            {
                Flip();
            }
            else if (!facingRight && move > 0)
            {
                Flip();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        GetComponent<BoxCollider2D>().enabled = false;
        playerSprite.enabled = false;
        //sprite2.enabled = false;
        onDeadEvent.Invoke();
        Destroy(gameObject, 3f);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 tran = transform.localScale;
        tran.x *= -1;
        transform.localScale = tran;
    }
}