using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravityControler : MonoBehaviour
{
    public UnityEvent onPickUp;

    // Use this for initialization
    private void Start()
    {
        if (onPickUp == null)
        {
            onPickUp = new UnityEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            onPickUp.Invoke();
            collision.GetComponent<PlayerControler>().UpSideDown();
        }
    }
}