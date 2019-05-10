using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnManager : MonoBehaviour {

    public GameObject playerPrefab;

    public Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
