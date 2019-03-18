using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform player;

    public float distance = 18.0f;

    public float distanceFix = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = player.transform.position;
        position.y += distance;
        position.z -= distanceFix;
        transform.position = position;
    }
}
