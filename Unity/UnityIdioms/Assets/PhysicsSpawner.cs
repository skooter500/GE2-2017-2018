using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSpawner : MonoBehaviour {
    public GameObject cubePrefab;
    public GameObject tank;
    // Use this for initialization

    void CreateWall(int width, int height)
    {
        int halfw = width / 2;
        float gap = 1.5f;
        for (int row = 0; row < height; row++)
        {
            for (int col = -halfw; col < halfw; col++)
            {
                GameObject cube = GameObject.Instantiate<GameObject>(cubePrefab);
                float x = col * gap;
                float y = 0.5f + (row * gap);
                cube.transform.rotation = tank.transform.rotation;
                cube.transform.position = tank.transform.TransformPoint(new Vector3(x, y, 5));
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 0.8f);
            }
        }
    }

    void CreateTentacle(int segments)
    {
        float gap = 0.2f;
        GameObject lastCube = null;
        for (int i = 0; i < segments; i++)
        {
            GameObject cube = GameObject.Instantiate<GameObject>(cubePrefab);

            float z = 20 + (i * (1 + gap));
            cube.transform.localScale = new Vector3(1, 0.1f, 1);
            cube.transform.rotation = tank.transform.rotation;
            cube.transform.position = tank.transform.TransformPoint(new Vector3(0, 1, z));
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 0.8f);
            cube.GetComponent<Rigidbody>().useGravity = false;
            cube.GetComponent<Rigidbody>().mass = 0.1f;
            // Dont make a hinge for the 0th cube
            if (i > 0)
            {
                /*SpringJoint sj = cube.AddComponent<SpringJoint>();
                sj.connectedBody = lastCube.GetComponent<Rigidbody>();
                sj.autoConfigureConnectedAnchor = true;
                sj.spring = 10;
                sj.damper = 10.0f;
                */


                HingeJoint hj = cube.AddComponent<HingeJoint>();
                hj.connectedBody = lastCube.GetComponent<Rigidbody>();
                hj.axis = Vector3.right;
                hj.autoConfigureConnectedAnchor = true;

                JointSpring hingeSpring = hj.spring;
                hingeSpring.spring = float.PositiveInfinity;
                hingeSpring.damper = 1000000;
                hingeSpring.targetPosition = 0;
                hj.spring = hingeSpring;
                hj.useSpring = true;


                /*FixedJoint fj = cube.AddComponent<FixedJoint>();
                fj.connectedBody = lastCube.GetComponent<Rigidbody>();
                fj.autoConfigureConnectedAnchor = true;                
                */
            }
            else
            {
                cube.GetComponent<Rigidbody>().isKinematic = true;
            }
            lastCube = cube;
        }
    }

    void CreateTower(float radius, int height, int segments)
    {
        float thetaInc = (Mathf.PI * 2.0f) / (float)segments;

        for (int h = 0; h < height; h++)
        {
            for (int i = 0; i < segments; i++)
            {
                float theta = thetaInc * i + (h * thetaInc * 0.5f);
                float x = radius * Mathf.Sin(theta);
                float z = radius * Mathf.Cos(theta) + 20;
                GameObject cube = GameObject.Instantiate<GameObject>(cubePrefab);
                cube.transform.rotation = tank.transform.rotation * Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);
                cube.transform.position = tank.transform.TransformPoint(new Vector3(x, h, z));
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 0.8f);
            }
        }
    }

	void Start () {        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CreateWall(10, 10);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            CreateTower(3, 200, 12);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CreateTentacle(10);
        }
    }
}
