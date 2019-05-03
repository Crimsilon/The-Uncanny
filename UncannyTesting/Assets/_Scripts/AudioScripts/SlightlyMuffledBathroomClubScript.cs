using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightlyMuffledBathroomClubScript : MonoBehaviour
{

    public Osborne_AudioManager_CyberpunkNoir music;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Muffled bathroom music");
            music.BitMuffled();
            music.AmbienceRoom();
            music.BathroomAmbience();
        }
    }
}
