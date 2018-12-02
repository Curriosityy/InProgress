using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    private Animator anim;
    public SpriteRenderer doorSprite;
    public Collider2D cd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cd = GetComponent<Collider2D>();
        GameMaster.gameMaster.GetComponent<ResetKeysAndDoors>().doorControlers.Add(this);
    }

    public void OpenDoor()
    {
        anim.SetTrigger("open");
    }

    public void BreakDebug()
    {
        Debug.Break();
    }

    private void OnDestroy()
    {
        GameMaster.gameMaster.GetComponent<ResetKeysAndDoors>().doorControlers.Remove(this);
    }

    public void DisableDisplay()
    {
        doorSprite.enabled = false;
        cd.enabled = false;
    }

    public void DisableDoor()
    {
        gameObject.SetActive(false);
        doorSprite.enabled = enabled;
        cd.enabled = enabled;
    }
}