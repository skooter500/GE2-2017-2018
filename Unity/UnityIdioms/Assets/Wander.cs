using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour {

    public float radius = 10;
    public float distance = 15;
    public float jitter = 5.0f;

    Vector3 target;
    Vector3 worldTarget;

    private void OnDrawGizmos()
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
        target = Random.insideUnitSphere * radius;
	}
	
	// Update is called once per frame
	public override Vector3 Calculate() {
        float jitterTimeSlice = jitter * Time.deltaTime;

        Vector3 offset = Random.insideUnitSphere * jitterTimeSlice;
        target += offset;
        target.Normalize();
        target *= radius;

        Vector3 localtarget = target + Vector3.forward * distance;
        worldTarget = transform.TransformPoint(localtarget);

        return worldTarget - transform.position;

	}
}
