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
    }

    public void OnLand()
    {
        Debug.Log("landed");
        jumpCounter = 0;
    }

    public void OnWall()
    {
        jumpCounter = 0;
    }

    public void OnDead()
    {
        GetComponentInChildren<ParticleSystem>().Emit(80);
        if (!PlayerPrefs.HasKey("DeadCounter"))
        {
            PlayerPrefs.SetInt("DeadCounter", 0);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("DeadCounter", PlayerPrefs.GetInt("DeadCounter") + 1);
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