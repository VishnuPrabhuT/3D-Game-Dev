using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    Vector3 respawn_Pos;
    Quaternion respawn_Rot;

    // Use this for initialization
    void Start () {
        respawn_Pos = transform.position;
        respawn_Rot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
                { transform.rotation = respawn_Rot; }
                }
}
