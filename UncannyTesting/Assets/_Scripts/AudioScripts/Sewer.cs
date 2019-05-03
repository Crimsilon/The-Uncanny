using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sewer : MonoBehaviour {

    public Osborne_AudioManager_CyberpunkNoir music;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            music.SewerAmbienceAndMusic();
        }
    }
}
