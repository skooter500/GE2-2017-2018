using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	public Vector3 force;
	public Vector3 velocity;
	public Vector3 acceleration;
	public float mass = 1;
	public float maxForce = 10;
	public float maxSpeed = 10;

	public GameObject target;

	public float fleeDistance = 5;
	public float slowingDistance = 10;
	// Use this for initialization
	void Start () {

	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, transform.position + (force * 10));
	}

	Vector3 FleeForce()
	{
		Vector3 toTarget = target.transform.position - transform.position;
		if (toTarget.magnitude > fleeDistance) {
			return Vector3.zero;
		} else {
			toTarget.Normalize ();
			Vector3 desired = toTarget * maxSpeed;
			return velocity - desired;
		}
	}

	Vector3 SeekForce()
	{
		Vector3 toTarget = target.transform.position - transform.position;
		toTarget.Normalize ();
		Vector3 desired = toTarget * maxSpeed;
		return desired - velocity;
	}


	Vector3 Calculate()
	{
		return ArriveForce ();
	}

	Vector3 ArriveForce()
	{
		Vector3 toTarget = target.transform.position - transform.position;
		float dist = toTarget.magnitude;
		float ramped = maxSpeed * (dist / slowingDistance);
		float clamped = Mathf.Min (ramped, maxSpeed);
		Vector3 desired = clamped * (toTarget / dist);
		return desired - velocity;
	}



	
	// Update is called once per frame
	void Update () {
		force = Calculate ();
		force = Vector3.ClampMagnitude (force, maxForce);
		acceleration = force / mass;
		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		velocity *= 0.99f;
		transform.position += velocity * Time.deltaTime;

		if (velocity.magnitude > float.Epsilon) {
			transform.forward = velocity;
		}
	}
}
