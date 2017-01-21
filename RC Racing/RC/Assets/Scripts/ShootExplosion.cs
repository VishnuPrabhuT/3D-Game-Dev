using UnityEngine;
using System.Collections;

public class ShootExplosion : MonoBehaviour {
    public float radius =30.0F;
    public float power = 100000.0F;
    public GameObject explosionEffect;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                
                //rb.isKinematic = false;
                
               // rb.AddExplosionForce(power, explosionPos, radius, 1, ForceMode.Impulse);
            }
        }
        
    }
    void OnCollisionEnter(Collision other)
    { Debug.Log("HIT!");
        Instantiate(explosionEffect, other.transform.position, Quaternion.identity);
    }
}
