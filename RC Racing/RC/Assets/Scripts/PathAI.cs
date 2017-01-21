using UnityEngine;
using System.Collections;

public class PathAI : MonoBehaviour {

	public bool bDebug = true;   // draw path in debug mode
	public float Radius = 2.0f;  // waypoint is reached if within radius range
	public Vector3[] pointA;	 // path itself

	public float Length {
		get {
			return pointA.Length;		// returns number of waypoints
		}
	}

	public Vector3 GetPoint(int index){		// returns position of specific waypoint
		return pointA [index];
	}

	void OnDrawGizmos(){   // if Debug mode is on, the path is drawn
		if (!bDebug)
			return;
		for (int i=0; i<pointA.Length; i++) {
			if (i + 1 < pointA.Length) {
				Debug.DrawLine (pointA [i], pointA [i + 1], Color.red);
			}
		}
	}


}
