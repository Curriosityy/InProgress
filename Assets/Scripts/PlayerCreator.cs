using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform cameraTransform;
    public Transform parent;
    public TimeCounter tc;
    public float timeToNextSpawn = 2.0f;

    // Use this for initialization
    private void Start()
    {
        InstantiatePlayer();
    }

    public void InstantiatePlayer()
    {
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
        GameObject playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity, parent);
        CameraFollow.player = playerInstance.transform;
        playerInstance.GetComponent<PlayerControler>().onDeadEvent.AddListener(InstantiatePlayerAgain);
        tc.timer = 0;
    }

    public void InstantiatePlayerAgain()
    {
        StartCoroutine(PlayAgain());
    }

    public IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(timeToNextSpawn);
        InstantiatePlayer();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}