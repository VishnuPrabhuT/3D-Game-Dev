using UnityEngine;
using System.Collections;

public class RoadCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionExit(Collision other)
    {
        Debug.Log("on road" + other.gameObject.name);

        //if (other.gameObject.tag != "Road")
        //{
          
        //    Time.timeScale = 0.5f;
        //}
        //if(other.gameObject.tag == "Road")
        //    Debug.Log("Airborne" + other.gameObject.name);

    }
}
