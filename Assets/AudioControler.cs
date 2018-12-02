using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        cam = Camera.main;
    }

    private void OnLevelWasLoaded(int level)
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = cam.transform.position;
    }
}