using UnityEngine;
using System.Collections;

public class MiniMapCamera : MonoBehaviour {
    public Transform Target;
    public Vector3 offset = new Vector3(0f, 10f, 0f);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    private void LateUpdate()
    { transform.position = Target.position + offset; }
}
