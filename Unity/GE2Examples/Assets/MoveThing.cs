using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log(transform.GetChild(0).GetComponent<Rigidbody>().velocity);
	}
}
