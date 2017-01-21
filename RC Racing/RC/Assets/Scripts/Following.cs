using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour {

	public PathAI path;  // path the needs to be followed
	public float speed = 20.0f;
	public float mass = 5.0f;
	public bool isLooping = true;  // if true entity follows path continuously
	
	private float curSpeed; 	// actual speed of entity
	private int curPathIndex;
	private float pathLength;
	private Vector3 targetPoint;
	
	private Vector3 velocity;
	
	void Start () {
		// initialize properties
		pathLength = path.Length;
		curPathIndex = 0;
		
		// get current velocity direction (blue axis of the entity)
		velocity = transform.forward;
		
	}
	
	// Update is called once per frame
	void Update () {
		// unify the speed
		curSpeed = speed * Time.deltaTime;
		
		// find next target
		targetPoint = path.GetPoint (curPathIndex);
		
		// if within radius from the waypoint, move to next waypoint
		if (Vector3.Distance (transform.position, targetPoint) < path.Radius) {
			// don't move vehicle if path is finished
			if (curPathIndex < pathLength - 1)
				curPathIndex++;
			else if (isLooping)
				curPathIndex = 0;
			else
				return;
		}
		
		// move vehicle until end point is reached
		if (curPathIndex >= pathLength)
			return;
		
		// calculate next velocity towards the path
		if (curPathIndex >= pathLength - 1 && !isLooping)
			velocity += Steer (targetPoint, true);
		else
			velocity += Steer (targetPoint);
		//Move vehicle according to velocity
		transform.position += velocity;
		//rotate towards desired velocity
		transform.rotation = Quaternion.LookRotation (velocity);
	}
	
	// steer vector towards target
	public Vector3 Steer(Vector3 target, bool bFinalPoint = false){
		//calculate the directional vector from the current position towards the targewt point
		Vector3 desiredVelocity = (target - transform.position);
		float dist = desiredVelocity.magnitude;
		
		//normalise desired velocity
		desiredVelocity.Normalize ();
		
		//slow down if arriving at end, otherwise use speed
		if (bFinalPoint && dist < 10.0f)
			desiredVelocity *= (curSpeed * (dist / 10.0f));
		else
			desiredVelocity *= curSpeed;
		
		// calculate force vector
		Vector3 steeringForce = desiredVelocity - velocity;
		Vector3 acceleration = steeringForce / mass;
		
		return acceleration;
	}
}
