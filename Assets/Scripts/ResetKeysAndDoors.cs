using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetKeysAndDoors : MonoBehaviour
{
    public List<KeyControler> keyControlers;
    public List<DoorControler> doorControlers;

    public void ReenableKeysAndDoors()
    {
        foreach (KeyControler item in keyControlers)
        {
            item.gameObject.SetActive(true);
        }
        foreach (DoorControler item in doorControlers)
        {
            item.gameObject.SetActive(true);
        }
    }
}