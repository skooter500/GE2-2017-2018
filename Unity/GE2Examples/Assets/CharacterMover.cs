using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMover : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
