using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesCollison : MonoBehaviour
{
    private ParticleSystem pc;
    private List<ParticleCollisionEvent> collisionEvents;
    public GameObject bloodPrefab;

    public void Start()
    {
        pc = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        pc.GetCollisionEvents(other, collisionEvents);
        foreach (ParticleCollisionEvent pcevent in collisionEvents)
        {
            Debug.Log(other.name);
            Debug.DrawLine(transform.position, pcevent.intersection);
            Instantiate(bloodPrefab, pcevent.intersection, Quaternion.identity, other.transform);
            // other.GetComponentInChildren<SpriteRenderer>().sprite.texture.SetPixel(pcevent.intersection.x,pcevent.intersection.y,)
        }
        //Debug.Break();
    }
}