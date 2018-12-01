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

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (timeBetweenSpawn <= time)
        {
            SpawnNeedle();
            time = 0;
        }
    }

    private void SpawnNeedle()
    {
        GameObject spawned = Instantiate(needlePrefab, top.transform.position, transform.rotation, top.transform);
    }
}