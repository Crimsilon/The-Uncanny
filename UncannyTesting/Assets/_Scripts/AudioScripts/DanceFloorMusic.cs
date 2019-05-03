using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloorMusic : MonoBehaviour {

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
            Debug.Log("Not muffled music");
            music.NotMuffled();
            music.AmbienceRoom();
            music.DefaultAmbience();
        }
    }
}
