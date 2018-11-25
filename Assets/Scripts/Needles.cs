using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            collision.GetComponent<PlayerControler>().Die();
        }
    }
}