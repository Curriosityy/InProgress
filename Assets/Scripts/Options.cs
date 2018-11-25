using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keyBinding;
    public static float volume;

    // Use this for initialization
    private void Start()
    {
        keyBinding = new Dictionary<string, KeyCode>();
        keyBinding.Add("left", KeyCode.LeftArrow);
        keyBinding.Add("jump", KeyCode.UpArrow);
        keyBinding.Add("right", KeyCode.RightArrow);
        DontDestroyOnLoad(this);
    }

    public void updateKey(string keyName, KeyCode keyCode)
    {
        keyBinding[keyName] = keyCode;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}