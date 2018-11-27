using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MetaControler : MonoBehaviour
{
    public string playerTag;

    [Header("Events")]
    [Space]
    public UnityEvent onPlayerEntered;

    private void Start()
    {
        if (onPlayerEntered == null)
        {
            onPlayerEntered = new UnityEvent();
        }
        onPlayerEntered.AddListener(ScreenChanger.gameMaster.GetComponent<ScreenChanger>().FadeToNextLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            onPlayerEntered.Invoke();
        }
    }
}