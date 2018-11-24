using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraDelay = 0.5f;
    public float cameraSpeed = 2f;
    private float counter = 0;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 lerped = Vector2.Lerp(transform.position, player.position, cameraSpeed * Time.deltaTime);
        transform.position = new Vector3(lerped.x, lerped.y, transform.position.z);
    }
}