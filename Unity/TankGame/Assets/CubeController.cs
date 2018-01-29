using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;


    // Use this for initialization
    void Start () {
		
	}

    public float speed = 5;
    public float rotSpeed = 90;

	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical");
        transform.Translate(0, 0, speed * Time.deltaTime * move);
        
        float rot = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rot * Time.deltaTime * rotSpeed);
        if (Input.GetAxis("Fire1") == 1.0f)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab);
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = this.transform.rotation;
        }
	}
}
