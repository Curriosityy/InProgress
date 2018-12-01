using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingNeedleControler : MonoBehaviour
{
    private float speed = 1;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;
    public float movementSmoothing = 0.05f;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = transform.up * speed * 10f;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && collision.GetComponent<PlayerControler>().isAlive)
        {
            collision.GetComponent<PlayerControler>().Die();
        }
        DestroyNeedle();
    }

    private void DestroyNeedle()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}