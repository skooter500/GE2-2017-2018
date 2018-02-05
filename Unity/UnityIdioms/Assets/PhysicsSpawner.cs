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

	void Start () {        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CreateWall(10, 10);
        }
    }
}
