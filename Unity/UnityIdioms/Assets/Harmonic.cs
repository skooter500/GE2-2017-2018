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
    

    public void OnDrawGizmos()
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public override Vector3 Calculate () {
        return Vector3.zero;
    }    
}
