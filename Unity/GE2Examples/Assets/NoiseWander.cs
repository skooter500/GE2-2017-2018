using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseWander : SteeringBehaviour
{
    public float frequency = 1.0f; 
    public float amplitude = 30; 
    public float radius = 10;
    public float distance = 15;

    public Axis direction = Axis.Horizontal; 
    public enum Axis { Horizontal, Vertical };

    float theta = 0.0f; 

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

    public static float Map(float value, float r1, float r2, float m1, float m2)
    {
        float dist = value - r1;
        float range1 = r2 - r1;
        float range2 = m2 - m1;
        return m1 + ((dist / range1) * range2);
    }

    // Update is called once per frame
    public override Vector3 Calculate()
    {
        float n = Map(Mathf.PerlinNoise(theta, 0), 0, 1, -1, 1);
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