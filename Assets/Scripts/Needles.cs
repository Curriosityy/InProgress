﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needles : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponentInParent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && collision.GetComponent<PlayerControler>().isAlive)
        {
            GetComponent<Animator>().SetTrigger("juicy");
            collision.GetComponent<PlayerControler>().Die();
        }
    }
}