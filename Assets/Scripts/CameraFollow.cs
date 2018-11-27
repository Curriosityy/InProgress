using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Transform player;
    private PlayerControler pc;
    public Transform cameraTransform;
    public float cameraDelay = 0.5f;
    public float cameraSpeed = 2f;
    private float counter = 0;
    private Vector2 lastPosition;
    public float shakeDeadDuration = 1f;
    public float shakeDeadMagnitude = 1f;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (pc == null)
        {
            if (player != null)
            {
                pc = player.GetComponent<PlayerControler>();
                pc.onDeadEvent.AddListener(ShakeCamera);
            }
        }
        else
        {
            if (pc.isAlive)
            {
                Vector2 lerped = Vector2.Lerp(transform.position, player.position, cameraSpeed * Time.deltaTime);
                transform.position = new Vector3(lerped.x, lerped.y, transform.position.z);
            }
            else
            {
                pc = null;
            }
        }
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCamera(shakeDeadDuration, shakeDeadMagnitude));
    }

    private IEnumerator ShakeCamera(float duration, float magintude)
    {
        Vector3 orginalPos = cameraTransform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float xPos = Random.Range(-1f, 1f) * magintude;
            float yPos = Random.Range(-1f, 1f) * magintude;
            cameraTransform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        cameraTransform.localPosition = orginalPos;
    }
}