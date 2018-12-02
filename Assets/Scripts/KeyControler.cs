using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyControler : MonoBehaviour
{
    public UnityEvent onKeyPickUp;

    // Use this for initialization
    private void Start()
    {
        if (onKeyPickUp == null)
        {
            onKeyPickUp = new UnityEvent();
        }
        GameMaster.gameMaster.GetComponent<ResetKeysAndDoors>().keyControlers.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            onKeyPickUp.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void ResetKeys()
    {
    }

    public void OnDestroy()
    {
        GameMaster.gameMaster.GetComponent<ResetKeysAndDoors>().keyControlers.Remove(this);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}