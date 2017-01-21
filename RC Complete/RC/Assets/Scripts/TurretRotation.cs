using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {
    private GameObject target;
    private Rigidbody rb;
    public GameObject bullet;
    public Transform bulletSpawn;
    public GameObject car;
    void Start () {
	
	}
    
    
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        //transform.LookAt(target.transform);
      
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * 800000000 * Time.deltaTime);
            Destroy(bulletClone, 2.0f);
             // rb.velocity = transform.TransformPoint(transform.position);
        }
    }

       
}
