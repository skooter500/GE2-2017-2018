using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmonic : SteeringBehaviour {

    public float frequency = 1.0f; // How often to oscillate
    public float amplitude = 30; // The angle to oscillate
    public float radius = 10;
    public float distance = 15;

    public Axis direction = Axis.Horizontal; // Oscillation direction
    public enum Axis { Horizontal, Vertical };
    
    float theta = 0.0f; // This will cycle between 0 and 2pi

    Vector3 target;
    Vector3 worldTarget;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Vector3 c = transform.TransformPoint
                (Vector3.forward * distance);
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(transform.position, worldTarget);
            Gizmos.DrawWireSphere(c, radius);
            Gizmos.DrawWireSphere(worldTarget, 1);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public override Vector3 Calculate () {
        float n = Mathf.Sin(theta);
        float angle = n * amplitude * Mathf.Deg2Rad;

        Vector3 yawRoll = transform.rotation.eulerAngles;
        yawRoll.x = 0;

        if (direction == Axis.Horizontal)
        {
            target.x = Mathf.Sin(angle);
            target.z = Mathf.Cos(angle);
            target.y = 0;
            yawRoll.z = 0;
        }
        else
        {
            target.y = Mathf.Sin(angle);
            target.z = Mathf.Cos(angle);
            target.x = 0;
        }

        target *= radius;

        Vector3 localTarget = target + (Vector3.forward * distance);

        worldTarget = transform.position + Quaternion.Euler(yawRoll) * localTarget;
        theta += Time.deltaTime * Mathf.PI * 2.0f * frequency;
        return boid.SeekForce(worldTarget);
    }


}
