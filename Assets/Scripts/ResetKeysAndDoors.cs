using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetKeysAndDoors : MonoBehaviour
{
    private List<KeyControler> _keyControlers;
    private List<DoorControler> _doorControlers;

    public List<KeyControler> keyControlers
    {
        get
        {
            return _keyControlers;
        }

        set
        {
            _keyControlers = value;
        }
    }

    public List<DoorControler> doorControlers
    {
        get
        {
            return _doorControlers;
        }

        set
        {
            _doorControlers = value;
        }
    }

    private void Start()
    {
        if (_keyControlers == null)
        {
            _keyControlers = new List<KeyControler>();
        }
        if (_doorControlers == null)
        {
            _doorControlers = new List<DoorControler>();
        }
    }

    public void ReenableKeysAndDoors()
    {
        foreach (KeyControler item in _keyControlers)
        {
            item.gameObject.SetActive(true);
        }
        foreach (DoorControler item in _doorControlers)
        {
            item.gameObject.SetActive(true);
        }
    }

    /*
    private void OnLevelWasLoaded(int level)
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("door");
        for (int i = 0; i < temp.Length; i++)
        {
            doorControlers.Add(temp[i].GetComponent<DoorControler>());
        }
        temp = GameObject.FindGameObjectsWithTag("key");
        for (int i = 0; i < temp.Length; i++)
        {
            keyControlers.Add(temp[i].GetComponent<KeyControler>());
        }
    }*/
}