using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameObject _gameMaster = null;

    public static GameObject gameMaster
    {
        get
        {
            return _gameMaster;
        }
    }

    private void Awake()
    {
        if (_gameMaster == null)
        {
            _gameMaster = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}