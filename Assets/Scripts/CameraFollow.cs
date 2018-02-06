using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject following;
    private float offsetY, offsetZ;
	// Use this for initialization
	void Start () {
        offsetZ = transform.position.z;
        offsetY = transform.position.y;

        following = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(following.transform.position.x, offsetY, offsetZ);
	}
}
