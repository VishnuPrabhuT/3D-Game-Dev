using UnityEngine;
using System.Collections;

public class ShootObject : MonoBehaviour {

	public GameObject TargetPos;
	public GameObject Miss;
	public int MissileLimit;
	public int MissileCount;
	public GameObject[] Missiles;
    public GameObject car;
	
	void Start (){
		//Find the target object that already exists in the sceene
		TargetPos = GameObject.FindGameObjectWithTag("Target");
	}
	
	void Update ()
    {
        if (Input.GetButton("Fire1"))
        {
           Rigidbody newProjectile = Instantiate(Miss, transform.position, transform.rotation) as Rigidbody;
            newProjectile.velocity = transform.TransformDirection(new Vector3(10, 0, 0));
        }

    }
	

}
