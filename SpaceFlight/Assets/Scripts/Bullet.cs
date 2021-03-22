
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rig;
    SphereCollider collision;
    float bulletSpeed = 500.0f;
    float delay;
    float activateCollision;

    public int bulletDamage = 1;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        collision = GetComponent<SphereCollider>();
    }

    void Update()
    {
        rig.velocity = transform.forward * bulletSpeed;

        if (Time.time >= activateCollision)
        {
            collision.enabled = true;
        }

        if (Time.time >= delay)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void OnEnable()
    {
       delay = Time.time + 1.5f;
       activateCollision = Time.time + .1f;
    }
}
