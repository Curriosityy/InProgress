using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MetaControler : MonoBehaviour
{
    public string playerTag;
    public int nextLevel;

    public class UnityIntEvent : UnityEvent<int> { };

    [Header("Events")]
    [Space]
    public UnityIntEvent onPlayerEntered;

    private void Start()
    {
        if (onPlayerEntered == null)
        {
            onPlayerEntered = new UnityIntEvent();
        }
        onPlayerEntered.AddListener(GameMaster.gameMaster.GetComponent<ScreenChanger>().FadeToLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            onPlayerEntered.Invoke(nextLevel);
        }
    }
}