using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float moveDir;
    private bool isJumping;
    public int jumpCounter;
    public int maxJump;
    public float fallSpeed = 2.0f;
    private PlayerControler pc;
    private Rigidbody2D rb;
    public ParticleSystem particleOnDead;
    public ParticleSystem particleOnRun;
    public ParticleSystem particleOnJump;
    private Animator animator;

    private void FixedUpdate()
    {
        pc.Move(moveDir * Time.fixedDeltaTime, isJumping);
        isJumping = false;
        if ((Mathf.Sign(rb.velocity.y) == Mathf.Sign(Physics2D.gravity.y)))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallSpeed - 1f) * Time.fixedDeltaTime;
        }
    }

    // Use this for initialization
    private void Start()
    {
        pc = GetComponent<PlayerControler>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnLand()
    {
        animator.SetTrigger("land");
        jumpCounter = 0;
    }

    public void OnWall()
    {
        animator.SetTrigger("wall");
        jumpCounter = 0;
    }

    public void OnDead()
    {
        particleOnDead.Emit(80);
        if (!PlayerPrefs.HasKey("DeadCounter"))
        {
            PlayerPrefs.SetInt("DeadCounter", 0);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("DeadCounter", PlayerPrefs.GetInt("DeadCounter") + 1);
    }

    public void onGroundRun()
    {
        particleOnRun.Emit(1);
    }

    public void onJump()
    {
        animator.SetTrigger("jump");
    }

    // Update is called once per frame
    private void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal") * pc.speed;
        if (Input.GetButtonDown("Jump") && maxJump > jumpCounter)
        {
            Debug.Log("JUMP");
            isJumping = true;
            jumpCounter++;
        }
    }
}