using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    float countDown;
    bool hasExploded = false;

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            //impulse
/*            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }*/
            //damage
            float dist = (Vector3.Distance(nearbyObject.bounds.center, transform.position) + 1f);
            Health health = nearbyObject.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("dist: " + dist);
                health.TakeDammage(100 / (int)dist);
                Debug.Log("damage: " + 100 / (int)dist);
            }
        }

        Destroy(gameObject);
    }
}
