using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleSpawner : MonoBehaviour
{
    public GameObject needlePrefab;
    public GameObject top;
    public float timeBetweenSpawn;
    public float needleSpeed;
    private float time;
    private bool startedCR = false;
    public float delayToFirstShoot = 0;
    public Collider2D smallNeedleCollider;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (!startedCR)
        {
            time += Time.deltaTime;
            if (delayToFirstShoot <= time)
            {
                startedCR = true;
                StartCoroutine(CouSpewnNeedle());
            }
        }
    }

    private IEnumerator CouSpewnNeedle()
    {
        SpawnNeedle();
        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine(CouSpewnNeedle());
        yield return null;
    }

    private void SpawnNeedle()
    {
        GameObject spawned = Instantiate(needlePrefab, top.transform.position, transform.rotation, top.transform);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), spawned.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(smallNeedleCollider, spawned.GetComponent<Collider2D>());
    }
}